using System.Diagnostics;
using System.Text;

namespace WinTuner.Services.Diagnosticos
{
    public class VerificarDiscoService
    {
        public async Task<ResultadoVerificacaoDisco> VerificarAsync(
            string unidade,
            IProgress<string>? progresso = null,
            CancellationToken cancellationToken = default)
        {
            ValidarUnidade(unidade);

            string unidadeFormatada =
                FormatarUnidade(unidade);

            string sistemaArquivos =
                ObterSistemaArquivos(unidadeFormatada);

            string argumentos;

            if (sistemaArquivos.Equals(
                    "NTFS",
                    StringComparison.OrdinalIgnoreCase))
            {
                argumentos =
                    $"{unidadeFormatada} /scan";
            }
            else
            {
                argumentos =
                    unidadeFormatada;
            }

            return await ExecutarProcessoAsync(
                "chkdsk.exe",
                argumentos,
                progresso,
                cancellationToken);
        }

        public async Task<ResultadoVerificacaoDisco> RepararAsync(
            string unidade,
            IProgress<string>? progresso = null,
            CancellationToken cancellationToken = default)
        {
            ValidarUnidade(unidade);

            string unidadeFormatada =
                FormatarUnidade(unidade);

            progresso?.Report(
                $"Iniciando reparo da unidade {unidadeFormatada}...");

            progresso?.Report(
                "Executando CHKDSK /F...");

            ResultadoVerificacaoDisco resultado =
                await ExecutarProcessoAsync(
                    "chkdsk.exe",
                    $"{unidadeFormatada} /f",
                    progresso,
                    cancellationToken);

            /*
             * Código 0:
             * nenhuma falha pendente.
             *
             * Código 1:
             * erros encontrados e corrigidos.
             *
             * Código 3:
             * pode significar que a unidade não pôde ser bloqueada
             * ou que os erros não puderam ser corrigidos.
             *
             * Quando identificamos que o volume está em uso,
             * tentamos agendar o CHKDSK para a próxima inicialização.
             */
            if (resultado.CodigoSaida == 3 &&
                SaidaIndicaVolumeEmUso(resultado.Saida))
            {
                progresso?.Report(
                    "A unidade está em uso pelo Windows.");

                progresso?.Report(
                    "Agendando CHKDSK para a próxima reinicialização...");

                ResultadoVerificacaoDisco agendamento =
                    await AgendarReparoAsync(
                        unidadeFormatada,
                        progresso,
                        cancellationToken);

                if (agendamento.Sucesso &&
                    agendamento.ReparoAgendado)
                {
                    agendamento.Saida =
                        resultado.Saida +
                        Environment.NewLine +
                        Environment.NewLine +
                        agendamento.Saida;

                    agendamento.Duracao =
                        resultado.Duracao +
                        agendamento.Duracao;

                    return agendamento;
                }
            }

            return resultado;
        }

        private async Task<ResultadoVerificacaoDisco>
            AgendarReparoAsync(
                string unidade,
                IProgress<string>? progresso,
                CancellationToken cancellationToken)
        {
            ResultadoVerificacaoDisco resultado =
                await ExecutarProcessoAsync(
                    "chkntfs.exe",
                    $"/c {unidade}",
                    progresso,
                    cancellationToken);

            if (resultado.CodigoSaida == 0)
            {
                resultado.Sucesso = true;
                resultado.RequerReparo = false;
                resultado.ReparoAgendado = true;

                resultado.Mensagem =
                    $"O reparo da unidade {unidade} foi agendado " +
                    "para a próxima reinicialização do Windows.";

                return resultado;
            }

            resultado.Sucesso = false;
            resultado.RequerReparo = true;
            resultado.ReparoAgendado = false;

            resultado.Mensagem =
                "O Windows não conseguiu agendar o reparo " +
                "para a próxima reinicialização.";

            return resultado;
        }

        private async Task<ResultadoVerificacaoDisco>
            ExecutarProcessoAsync(
                string arquivo,
                string argumentos,
                IProgress<string>? progresso,
                CancellationToken cancellationToken)
        {
            var resultado =
                new StringBuilder();

            Stopwatch stopwatch =
                Stopwatch.StartNew();

            using var processo =
                new Process();

            processo.StartInfo =
                new ProcessStartInfo
                {
                    FileName = arquivo,

                    Arguments = argumentos,

                    UseShellExecute = false,

                    RedirectStandardOutput = true,

                    RedirectStandardError = true,

                    CreateNoWindow = true,

                    WorkingDirectory =
                        Environment.SystemDirectory,

                    StandardOutputEncoding =
                        Encoding.UTF8,

                    StandardErrorEncoding =
                        Encoding.UTF8
                };

            processo.OutputDataReceived +=
                (_, e) =>
                {
                    if (string.IsNullOrWhiteSpace(e.Data))
                        return;

                    resultado.AppendLine(e.Data);

                    progresso?.Report(e.Data);
                };

            processo.ErrorDataReceived +=
                (_, e) =>
                {
                    if (string.IsNullOrWhiteSpace(e.Data))
                        return;

                    resultado.AppendLine(e.Data);

                    progresso?.Report(e.Data);
                };

            try
            {
                if (!processo.Start())
                {
                    stopwatch.Stop();

                    return CriarResultadoErro(
                        resultado,
                        stopwatch.Elapsed,
                        $"Não foi possível iniciar o processo {arquivo}.");
                }

                processo.BeginOutputReadLine();
                processo.BeginErrorReadLine();

                try
                {
                    await processo.WaitForExitAsync(
                        cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    TentarEncerrarProcesso(processo);

                    throw;
                }

                /*
                 * Aguarda o término do processamento
                 * dos eventos de saída.
                 */
                processo.WaitForExit();

                stopwatch.Stop();

                int codigoSaida =
                    processo.ExitCode;

                string saida =
                    resultado.ToString();

                return CriarResultado(
                    codigoSaida,
                    saida,
                    stopwatch.Elapsed);
            }
            catch (OperationCanceledException)
            {
                stopwatch.Stop();

                throw;
            }
            catch (Exception ex)
            {
                stopwatch.Stop();

                resultado.AppendLine();
                resultado.AppendLine(
                    $"ERRO: {ex.Message}");

                return CriarResultadoErro(
                    resultado,
                    stopwatch.Elapsed,
                    $"Erro durante a execução: {ex.Message}");
            }
        }

        private ResultadoVerificacaoDisco CriarResultado(
            int codigoSaida,
            string saida,
            TimeSpan duracao)
        {
            bool agendado =
                SaidaIndicaAgendamento(saida);

            bool encontrouProblema =
                codigoSaida != 0 ||
                SaidaIndicaProblema(saida);

            bool erroNaoCorrigido =
                SaidaIndicaErroReparo(saida);

            bool sucesso =
                codigoSaida == 0 ||
                codigoSaida == 1;

            /*
             * Se o próprio CHKDSK informou que o reparo
             * foi agendado, consideramos a operação bem-sucedida.
             */
            if (agendado)
            {
                sucesso = true;
                encontrouProblema = false;
            }

            string mensagem;

            if (agendado)
            {
                mensagem =
                    "O reparo foi agendado para a próxima " +
                    "reinicialização do Windows.";
            }
            else if (codigoSaida == 0)
            {
                mensagem =
                    "O CHKDSK concluiu a operação sem " +
                    "indicar erros pendentes.";
            }
            else if (codigoSaida == 1)
            {
                mensagem =
                    "O CHKDSK encontrou erros e realizou " +
                    "as correções necessárias.";
            }
            else if (erroNaoCorrigido)
            {
                mensagem =
                    "O CHKDSK encontrou problemas, mas " +
                    "não conseguiu corrigir todos eles.";
            }
            else if (codigoSaida == 2)
            {
                mensagem =
                    "O CHKDSK terminou com uma condição " +
                    "que requer atenção.";
            }
            else
            {
                mensagem =
                    "O CHKDSK não conseguiu concluir " +
                    "o reparo da unidade.";
            }

            return new ResultadoVerificacaoDisco
            {
                Sucesso = sucesso,

                RequerReparo =
                    !sucesso && encontrouProblema,

                ReparoAgendado =
                    agendado,

                CodigoSaida =
                    codigoSaida,

                Mensagem =
                    mensagem,

                Saida =
                    saida,

                Duracao =
                    duracao
            };
        }

        private bool SaidaIndicaProblema(
            string saida)
        {
            if (string.IsNullOrWhiteSpace(saida))
                return false;

            string texto =
                NormalizarTexto(saida);

            string[] indicadores =
            {
                "errors found",
                "error found",
                "erro encontrado",
                "erros encontrados",
                "problemas encontrados",
                "bad sectors",
                "setores defeituosos",
                "corrupt",
                "corrompido",
                "corrompidos",
                "dirty"
            };

            return indicadores.Any(
                indicador =>
                    texto.Contains(indicador));
        }

        private bool SaidaIndicaErroReparo(
            string saida)
        {
            if (string.IsNullOrWhiteSpace(saida))
                return false;

            string texto =
                NormalizarTexto(saida);

            string[] indicadores =
            {
                "could not be fixed",
                "cannot continue",
                "unable to fix",
                "errors found but not fixed",
                "nao foi possivel corrigir",
                "nao foi possivel reparar",
                "nao pode ser corrigido",
                "nao foi possivel concluir",
                "nao puderam ser corrigidos",
                "nao foram corrigidos"
            };

            return indicadores.Any(
                indicador =>
                    texto.Contains(indicador));
        }

        private bool SaidaIndicaVolumeEmUso(
            string saida)
        {
            if (string.IsNullOrWhiteSpace(saida))
                return false;

            string texto =
                NormalizarTexto(saida);

            string[] indicadores =
            {
                "cannot lock current drive",
                "volume is in use",
                "volume is in use by another process",
                "would you like to schedule",
                "nao e possivel bloquear",
                "nao foi possivel bloquear",
                "volume esta sendo usado",
                "volume esta em uso",
                "proxima reinicializacao"
            };

            return indicadores.Any(
                indicador =>
                    texto.Contains(indicador));
        }

        private bool SaidaIndicaAgendamento(
            string saida)
        {
            if (string.IsNullOrWhiteSpace(saida))
                return false;

            string texto =
                NormalizarTexto(saida);

            string[] indicadores =
            {
                "scheduled to be checked",
                "will be checked the next time",
                "this volume will be checked",
                "na proxima reinicializacao",
                "proxima reinicializacao",
                "agendada para a proxima inicializacao",
                "agendado para a proxima reinicializacao",
                "verificado na proxima vez",
                "next system restart"
            };

            return indicadores.Any(
                indicador =>
                    texto.Contains(indicador));
        }

        private string NormalizarTexto(
            string texto)
        {
            return texto
                .ToLowerInvariant()
                .Replace("á", "a")
                .Replace("à", "a")
                .Replace("ã", "a")
                .Replace("â", "a")
                .Replace("é", "e")
                .Replace("ê", "e")
                .Replace("í", "i")
                .Replace("ó", "o")
                .Replace("ô", "o")
                .Replace("õ", "o")
                .Replace("ú", "u")
                .Replace("ç", "c");
        }

        private string ObterSistemaArquivos(
            string unidade)
        {
            try
            {
                var drive =
                    new DriveInfo(
                        unidade + "\\");

                if (drive.IsReady)
                    return drive.DriveFormat;
            }
            catch
            {
                // O CHKDSK tratará a unidade.
            }

            return string.Empty;
        }

        private void ValidarUnidade(
            string unidade)
        {
            if (string.IsNullOrWhiteSpace(unidade))
            {
                throw new ArgumentException(
                    "Unidade inválida.");
            }
        }

        private string FormatarUnidade(
            string unidade)
        {
            string unidadeFormatada =
                unidade
                    .Trim()
                    .TrimEnd('\\');

            if (unidadeFormatada.Length < 2 ||
                unidadeFormatada[1] != ':')
            {
                throw new ArgumentException(
                    "Unidade inválida.");
            }

            return unidadeFormatada;
        }

        private ResultadoVerificacaoDisco
            CriarResultadoErro(
                StringBuilder resultado,
                TimeSpan duracao,
                string mensagem)
        {
            return new ResultadoVerificacaoDisco
            {
                Sucesso = false,

                RequerReparo = true,

                ReparoAgendado = false,

                CodigoSaida = -1,

                Saida =
                    resultado.ToString(),

                Duracao =
                    duracao,

                Mensagem =
                    mensagem
            };
        }

        private void TentarEncerrarProcesso(
            Process processo)
        {
            try
            {
                if (!processo.HasExited)
                {
                    processo.Kill(
                        entireProcessTree: true);

                    processo.WaitForExit(3000);
                }
            }
            catch
            {
                try
                {
                    if (!processo.HasExited)
                        processo.Kill();
                }
                catch
                {
                    // Ignora falha no encerramento.
                }
            }
        }
    }

    public class ResultadoVerificacaoDisco
    {
        public bool Sucesso { get; set; }

        public bool RequerReparo { get; set; }

        public bool ReparoAgendado { get; set; }

        public int CodigoSaida { get; set; }

        public string Mensagem { get; set; } =
            string.Empty;

        public string Saida { get; set; } =
            string.Empty;

        public TimeSpan Duracao { get; set; }
    }
}