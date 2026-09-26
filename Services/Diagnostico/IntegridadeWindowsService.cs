using System.Diagnostics;
using System.Security.Principal;
using System.Text;

namespace WinTuner.Services.Diagnosticos
{
    public class IntegridadeWindowsService
    {
        public async Task<ResultadoIntegridade> VerificarDismAsync(
            CancellationToken cancellationToken = default)
        {
            return await ExecutarComandoAsync(
                "DISM.exe",
                "/Online /Cleanup-Image /CheckHealth",
                "DISM /CheckHealth",
                cancellationToken
            );
        }

        public async Task<ResultadoIntegridade> VerificarSfcAsync(
            CancellationToken cancellationToken = default)
        {
            return await ExecutarComandoAsync(
                "sfc.exe",
                "/scannow",
                "SFC /SCANNOW",
                cancellationToken
            );
        }

        public async Task<ResultadoIntegridade> RepararDismAsync(
            CancellationToken cancellationToken = default)
        {
            return await ExecutarComandoAsync(
                "DISM.exe",
                "/Online /Cleanup-Image /RestoreHealth",
                "DISM /RestoreHealth",
                cancellationToken
            );
        }

        public bool EstaExecutandoComoAdministrador()
        {
            using WindowsIdentity identidade =
                WindowsIdentity.GetCurrent();

            WindowsPrincipal principal =
                new WindowsPrincipal(identidade);

            return principal.IsInRole(
                WindowsBuiltInRole.Administrator
            );
        }

        private async Task<ResultadoIntegridade> ExecutarComandoAsync(
            string arquivo,
            string argumentos,
            string nomeOperacao,
            CancellationToken cancellationToken)
        {
            if (!EstaExecutandoComoAdministrador())
            {
                return new ResultadoIntegridade
                {
                    Sucesso = false,
                    RequerReparo = false,
                    CodigoSaida = 740,
                    Mensagem =
                        "Esta operação requer privilégios administrativos.",
                    Saida =
                        "ERRO: 740\r\n\r\n" +
                        "A operação exige privilégios elevados.\r\n" +
                        "Execute o WinTurner como administrador.",
                    Duracao = TimeSpan.Zero
                };
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            StringBuilder saida = new StringBuilder();

            using Process processo = new Process();

            processo.StartInfo = new ProcessStartInfo
            {
                FileName = arquivo,
                Arguments = argumentos,

                UseShellExecute = false,
                CreateNoWindow = true,

                RedirectStandardOutput = true,
                RedirectStandardError = true,

                StandardOutputEncoding = Encoding.Default,
                StandardErrorEncoding = Encoding.Default
            };

            processo.OutputDataReceived += (_, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    lock (saida)
                    {
                        saida.AppendLine(e.Data);
                    }
                }
            };

            processo.ErrorDataReceived += (_, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    lock (saida)
                    {
                        saida.AppendLine(e.Data);
                    }
                }
            };

            try
            {
                processo.Start();

                processo.BeginOutputReadLine();
                processo.BeginErrorReadLine();

                await processo.WaitForExitAsync(
                    cancellationToken
                );

                stopwatch.Stop();

                int codigoSaida = processo.ExitCode;

                string resultado = saida.ToString();

                bool sucesso = InterpretarSucesso(
                    nomeOperacao,
                    codigoSaida,
                    resultado
                );

                bool requerReparo = DetectarNecessidadeReparo(
                    nomeOperacao,
                    codigoSaida,
                    resultado
                );

                return new ResultadoIntegridade
                {
                    Sucesso = sucesso,
                    RequerReparo = requerReparo,
                    CodigoSaida = codigoSaida,
                    Saida = resultado,
                    Duracao = stopwatch.Elapsed,
                    Mensagem = ObterMensagem(
                        nomeOperacao,
                        codigoSaida,
                        sucesso,
                        requerReparo
                    )
                };
            }
            catch (OperationCanceledException)
            {
                TentarEncerrarProcesso(processo);

                stopwatch.Stop();

                throw;
            }
            catch (Exception ex)
            {
                TentarEncerrarProcesso(processo);

                stopwatch.Stop();

                return new ResultadoIntegridade
                {
                    Sucesso = false,
                    RequerReparo = false,
                    CodigoSaida = -1,
                    Saida = ex.Message,
                    Duracao = stopwatch.Elapsed,
                    Mensagem =
                        $"Erro ao executar {nomeOperacao}: {ex.Message}"
                };
            }
        }

        private bool InterpretarSucesso(
            string operacao,
            int codigoSaida,
            string saida)
        {
            if (codigoSaida != 0)
                return false;

            if (operacao.Contains(
                "SFC",
                StringComparison.OrdinalIgnoreCase))
            {
                if (saida.Contains(
                    "did not find any integrity violations",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (saida.Contains(
                    "found corrupt files and successfully repaired them",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (saida.Contains(
                    "não encontrou nenhuma violação de integridade",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (saida.Contains(
                    "encontrou arquivos corrompidos e os reparou com êxito",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return codigoSaida == 0;
        }

        private bool DetectarNecessidadeReparo(
            string operacao,
            int codigoSaida,
            string saida)
        {
            if (codigoSaida != 0)
                return true;

            if (operacao.Contains(
                "SFC",
                StringComparison.OrdinalIgnoreCase))
            {
                if (saida.Contains(
                    "found corrupt files",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (saida.Contains(
                    "found integrity violations",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (saida.Contains(
                    "encontrou arquivos corrompidos",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (saida.Contains(
                    "violação de integridade",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            if (operacao.Contains(
                "DISM",
                StringComparison.OrdinalIgnoreCase))
            {
                if (saida.Contains(
                    "component store is repairable",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (saida.Contains(
                    "reparável",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (saida.Contains(
                    "corruption",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (saida.Contains(
                    "corrupção",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private string ObterMensagem(
            string operacao,
            int codigoSaida,
            bool sucesso,
            bool requerReparo)
        {
            if (sucesso && !requerReparo)
            {
                return $"{operacao} concluído sem problemas.";
            }

            if (sucesso && requerReparo)
            {
                return $"{operacao} encontrou problemas que podem exigir reparo.";
            }

            return
                $"{operacao} terminou com código de saída {codigoSaida}.";
        }

        private void TentarEncerrarProcesso(Process processo)
        {
            try
            {
                if (processo.HasExited)
                    return;

                processo.Kill(true);
            }
            catch
            {
            }
        }
    }

    public class ResultadoIntegridade
    {
        public bool Sucesso { get; set; }

        public bool RequerReparo { get; set; }

        public int CodigoSaida { get; set; }

        public string Mensagem { get; set; } = string.Empty;

        public string Saida { get; set; } = string.Empty;

        public TimeSpan Duracao { get; set; }
    }
}