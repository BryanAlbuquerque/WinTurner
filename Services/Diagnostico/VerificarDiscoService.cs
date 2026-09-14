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

            string unidadeFormatada = unidade.Trim().TrimEnd('\\');

            if (unidadeFormatada.Length < 2 || unidadeFormatada[1] != ':')
                throw new ArgumentException("Unidade inválida.");

            string argumentos;

            // /scan é uma verificação online do NTFS.
            // Para outros sistemas de arquivos usamos CHKDSK sem parâmetros
            // de reparo, mantendo a operação somente de diagnóstico.
            string sistemaArquivos = ObterSistemaArquivos(unidadeFormatada);

            if (sistemaArquivos.Equals("NTFS", StringComparison.OrdinalIgnoreCase))
            {
                argumentos = $"{unidadeFormatada} /scan";
            }
            else
            {
                argumentos = unidadeFormatada;
            }

            var resultado = new StringBuilder();
            var stopwatch = Stopwatch.StartNew();

            using var processo = new Process();

            processo.StartInfo = new ProcessStartInfo
            {
                FileName = "chkdsk.exe",
                Arguments = argumentos,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WorkingDirectory = Environment.SystemDirectory
            };

            processo.OutputDataReceived += (_, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.Data))
                {
                    resultado.AppendLine(e.Data);
                    progresso?.Report(e.Data);
                }
            };

            processo.ErrorDataReceived += (_, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.Data))
                {
                    resultado.AppendLine(e.Data);
                    progresso?.Report(e.Data);
                }
            };

            try
            {
                if (!processo.Start())
                {
                    return new ResultadoVerificacaoDisco
                    {
                        Sucesso = false,
                        Mensagem = "Não foi possível iniciar o CHKDSK.",
                        Saida = resultado.ToString(),
                        CodigoSaida = -1
                    };
                }

                processo.BeginOutputReadLine();
                processo.BeginErrorReadLine();

                try
                {
                    await processo.WaitForExitAsync(cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    TentarEncerrarProcesso(processo);

                    throw;
                }

                // Garante que a saída assíncrona foi processada.
                processo.WaitForExit();

                stopwatch.Stop();

                int codigoSaida = processo.ExitCode;

                bool sucesso = codigoSaida == 0;

                return new ResultadoVerificacaoDisco
                {
                    Sucesso = sucesso,
                    CodigoSaida = codigoSaida,
                    Saida = resultado.ToString(),
                    Duracao = stopwatch.Elapsed,
                    Mensagem = sucesso
                        ? "A verificação foi concluída sem problemas detectados."
                        : "A verificação terminou indicando que é necessária atenção."
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
                    CodigoSaida = -1,
                    Saida = resultado + Environment.NewLine + ex.Message,
                    Duracao = stopwatch.Elapsed,
                    Mensagem = $"Erro durante a verificação: {ex.Message}"
                };
            }
        }

        private string ObterSistemaArquivos(string unidade)
        {
            try
            {
                var drive = new DriveInfo(unidade + "\\");

                if (drive.IsReady)
                    return drive.DriveFormat;
            }
            catch
            {
                // Será tratado pelo CHKDSK.
            }

            return string.Empty;
        }

        private void TentarEncerrarProcesso(Process processo)
        {
            try
            {
                if (!processo.HasExited)
                {
                    processo.Kill(entireProcessTree: true);
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

        public int CodigoSaida { get; set; }

        public string Mensagem { get; set; } = string.Empty;

        public string Saida { get; set; } = string.Empty;

        public TimeSpan Duracao { get; set; }
    }
}