using System.Diagnostics;
using System.Text;

namespace WinTurner.Services.Diagnosticos
{
    public class VerificarDiscoService
    {
        public async Task<ResultadoVerificacaoDisco> VerificarAsync(
            string unidade,
            IProgress<string>? progresso = null,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(unidade))
                throw new ArgumentException("Unidade inválida.");

            string unidadeFormatada =
                unidade.Trim().TrimEnd('\\');

            if (unidadeFormatada.Length < 2 ||
                unidadeFormatada[1] != ':')
            {
                throw new ArgumentException("Unidade inválida.");
            }

            string sistemaArquivos =
                ObterSistemaArquivos(unidadeFormatada);

            string argumentos;

            // Para NTFS utilizamos /scan, que realiza
            // uma verificação online sem aplicar reparos.
            if (sistemaArquivos.Equals(
                    "NTFS",
                    StringComparison.OrdinalIgnoreCase))
            {
                argumentos =
                    $"{unidadeFormatada} /scan";
            }
            else
            {
                // Para outros sistemas de arquivos,
                // executamos CHKDSK somente para diagnóstico.
                argumentos =
                    unidadeFormatada;
            }

            return await ExecutarChkDskAsync(
                argumentos,
                progresso,
                cancellationToken);
        }

        public async Task<ResultadoVerificacaoDisco> RepararAsync(
            string unidade)
        {
            if (string.IsNullOrWhiteSpace(unidade))
                throw new ArgumentException("Unidade inválida.");

            string unidadeFormatada =
                unidade.Trim().TrimEnd('\\');

            if (unidadeFormatada.Length < 2 ||
                unidadeFormatada[1] != ':')
            {
                throw new ArgumentException("Unidade inválida.");
            }

            var stopwatch =
                Stopwatch.StartNew();

            try
            {
                using var processo =
                    new Process();

                processo.StartInfo =
                    new ProcessStartInfo
                    {
                        FileName = "chkdsk.exe",

                        // /f solicita a correção
                        // dos erros do sistema de arquivos.
                        Arguments =
                            $"{unidadeFormatada} /f",

                        // O CHKDSK de reparo precisa
                        // ser executado elevado.
                        UseShellExecute = true,

                        Verb = "runas",

                        WorkingDirectory =
                            Environment.SystemDirectory
                    };

                if (!processo.Start())
                {
                    stopwatch.Stop();

                    return new ResultadoVerificacaoDisco
                    {
                        Sucesso = false,
                        RequerReparo = true,
                        CodigoSaida = -1,
                        Duracao = stopwatch.Elapsed,
                        Mensagem =
                            "Não foi possível iniciar o CHKDSK com privilégios de administrador."
                    };
                }

                await processo.WaitForExitAsync();

                stopwatch.Stop();

                int codigoSaida =
                    processo.ExitCode;

                bool sucesso =
                    codigoSaida == 0 ||
                    codigoSaida == 1;

                return new ResultadoVerificacaoDisco
                {
                    Sucesso = sucesso,

                    RequerReparo = !sucesso,

                    CodigoSaida =
                        codigoSaida,

                    Duracao =
                        stopwatch.Elapsed,

                    Mensagem =
                        ObterMensagemReparo(
                            codigoSaida)
                };
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                stopwatch.Stop();

                // 1223 = usuário cancelou
                // a solicitação do UAC.
                if (ex.NativeErrorCode == 1223)
                {
                    return new ResultadoVerificacaoDisco
                    {
                        Sucesso = false,
                        RequerReparo = true,
                        CodigoSaida = -2,
                        Duracao = stopwatch.Elapsed,
                        Mensagem =
                            "A solicitação de administrador foi cancelada."
                    };
                }

                return new ResultadoVerificacaoDisco
                {
                    Sucesso = false,
                    RequerReparo = true,
                    CodigoSaida = -1,
                    Duracao = stopwatch.Elapsed,
                    Mensagem =
                        $"Erro ao iniciar o reparo: {ex.Message}"
                };
            }
            catch (Exception ex)
            {
                stopwatch.Stop();

                return new ResultadoVerificacaoDisco
                {
                    Sucesso = false,
                    RequerReparo = true,
                    CodigoSaida = -1,
                    Duracao = stopwatch.Elapsed,
                    Mensagem =
                        $"Erro durante o reparo: {ex.Message}"
                };
            }
        }

        private async Task<ResultadoVerificacaoDisco>
            ExecutarChkDskAsync(
                string argumentos,
                IProgress<string>? progresso,
                CancellationToken cancellationToken)
        {
            var resultado =
                new StringBuilder();

            var stopwatch =
                Stopwatch.StartNew();

            using var processo =
                new Process();

            processo.StartInfo =
                new ProcessStartInfo
                {
                    FileName = "chkdsk.exe",
                    Arguments = argumentos,

                    UseShellExecute = false,

                    RedirectStandardOutput = true,
                    RedirectStandardError = true,

                    CreateNoWindow = true,

                    WorkingDirectory =
                        Environment.SystemDirectory
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

                    return new ResultadoVerificacaoDisco
                    {
                        Sucesso = false,
                        RequerReparo = true,
                        CodigoSaida = -1,
                        Saida = resultado.ToString(),
                        Duracao = stopwatch.Elapsed,
                        Mensagem =
                            "Não foi possível iniciar o CHKDSK."
                    };
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

                // Garante que toda a saída assíncrona
                // foi processada.
                processo.WaitForExit();

                stopwatch.Stop();

                int codigoSaida =
                    processo.ExitCode;

                string saida =
                    resultado.ToString();

                bool encontrouProblema =
                    codigoSaida != 0 ||
                    SaidaIndicaProblema(saida);

                return new ResultadoVerificacaoDisco
                {
                    Sucesso =
                        codigoSaida == 0 &&
                        !encontrouProblema,

                    RequerReparo =
                        encontrouProblema,

                    CodigoSaida =
                        codigoSaida,

                    Saida =
                        saida,

                    Duracao =
                        stopwatch.Elapsed,

                    Mensagem =
                        encontrouProblema
                            ? "O CHKDSK identificou que a unidade requer atenção ou reparo."
                            : "A verificação foi concluída sem problemas detectados."
                };
            }
            catch (OperationCanceledException)
            {
                stopwatch.Stop();
                throw;
            }
            catch (Exception ex)
            {
                stopwatch.Stop();

                return new ResultadoVerificacaoDisco
                {
                    Sucesso = false,
                    RequerReparo = true,
                    CodigoSaida = -1,

                    Saida =
                        resultado +
                        Environment.NewLine +
                        ex.Message,

                    Duracao =
                        stopwatch.Elapsed,

                    Mensagem =
                        $"Erro durante a verificação: {ex.Message}"
                };
            }
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

        private bool SaidaIndicaProblema(
            string saida)
        {
            if (string.IsNullOrWhiteSpace(saida))
                return false;

            string texto =
                saida.ToLowerInvariant();

            string[] indicadores =
            {
                "errors found",
                "erro(s) encontrado(s)",
                "errors found and fixed",
                "erros encontrados",
                "problemas encontrados",
                "bad sectors",
                "setores defeituosos",
                "corrupt",
                "corrompido"
            };

            return indicadores.Any(
                indicador =>
                    texto.Contains(indicador));
        }

        private string ObterMensagemReparo(
            int codigoSaida)
        {
            return codigoSaida switch
            {
                0 =>
                    "O CHKDSK concluiu o reparo sem indicar erros pendentes.",

                1 =>
                    "O CHKDSK encontrou erros e realizou correções na unidade.",

                2 =>
                    "O CHKDSK concluiu com uma condição que requer atenção.",

                3 =>
                    "O CHKDSK não conseguiu concluir todas as correções.",

                -2 =>
                    "A solicitação de administrador foi cancelada.",

                _ =>
                    "O CHKDSK terminou com um código de saída inesperado."
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

        public int CodigoSaida { get; set; }

        public string Mensagem { get; set; } =
            string.Empty;

        public string Saida { get; set; } =
            string.Empty;

        public TimeSpan Duracao { get; set; }
    }
}