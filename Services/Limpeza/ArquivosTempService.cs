using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WinTuner.Services.Limpeza
{
    public class ArquivosTempService
    {
        public async Task<ResultadoAnaliseTemp> AnalisarAsync(
            IProgress<string>? progresso = null,
            CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
            {
                var resultado = new ResultadoAnaliseTemp();

                List<LocalLimpeza> locais = ObterLocais();

                foreach (LocalLimpeza local in locais)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    progresso?.Report($"Analisando {local.Nome}...");

                    ResultadoLocal resultadoLocal =
                        AnalisarLocal(
                            local,
                            cancellationToken);

                    resultado.Locais.Add(resultadoLocal);

                    resultado.TotalArquivos +=
                        resultadoLocal.QuantidadeArquivos;

                    resultado.TotalBytes +=
                        resultadoLocal.TamanhoBytes;

                    resultado.TotalErros +=
                        resultadoLocal.QuantidadeErros;
                }

                progresso?.Report("Análise concluída.");

                return resultado;

            }, cancellationToken);
        }

        public async Task<ResultadoLimpezaTemp> LimparAsync(
            IEnumerable<ResultadoLocal> locaisSelecionados,
            IProgress<string>? progresso = null,
            CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
            {
                var resultado = new ResultadoLimpezaTemp();

                List<ResultadoLocal> locais =
                    locaisSelecionados.ToList();

                foreach (ResultadoLocal local in locais)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    progresso?.Report(
                        $"Limpando {local.Nome}...");

                    resultado.LocaisProcessados++;

                    if (!Directory.Exists(local.Caminho))
                    {
                        resultado.LocaisComErro++;

                        resultado.Erros.Add(
                            new ErroLimpeza
                            {
                                Local = local.Nome,
                                Caminho = local.Caminho,
                                Motivo = "A pasta não foi encontrada."
                            });

                        continue;
                    }

                    LimparDiretorio(
                        local,
                        resultado,
                        progresso,
                        cancellationToken);
                }

                progresso?.Report("Limpeza concluída.");

                return resultado;

            }, cancellationToken);
        }

        private ResultadoLocal AnalisarLocal(
            LocalLimpeza local,
            CancellationToken cancellationToken)
        {
            var resultado = new ResultadoLocal
            {
                Nome = local.Nome,
                Caminho = local.Caminho
            };

            if (!Directory.Exists(local.Caminho))
            {
                resultado.Disponivel = false;
                return resultado;
            }

            resultado.Disponivel = true;

            try
            {
                IEnumerable<string> arquivos =
                    Directory.EnumerateFiles(
                        local.Caminho,
                        "*",
                        SearchOption.AllDirectories);

                foreach (string caminho in arquivos)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    try
                    {
                        FileInfo arquivo = new FileInfo(caminho);

                        if (!arquivo.Exists)
                            continue;

                        resultado.QuantidadeArquivos++;
                        resultado.TamanhoBytes += arquivo.Length;
                    }
                    catch
                    {
                        resultado.QuantidadeErros++;
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                resultado.QuantidadeErros++;
            }
            catch (IOException)
            {
                resultado.QuantidadeErros++;
            }

            return resultado;
        }

        private void LimparDiretorio(
            ResultadoLocal local,
            ResultadoLimpezaTemp resultado,
            IProgress<string>? progresso,
            CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<string> arquivos;

                try
                {
                    arquivos = Directory.EnumerateFiles(
                        local.Caminho,
                        "*",
                        SearchOption.AllDirectories);
                }
                catch (UnauthorizedAccessException)
                {
                    resultado.LocaisComErro++;

                    resultado.Erros.Add(
                        new ErroLimpeza
                        {
                            Local = local.Nome,
                            Caminho = local.Caminho,
                            Motivo = "Acesso negado à pasta."
                        });

                    return;
                }
                catch (IOException ex)
                {
                    resultado.LocaisComErro++;

                    resultado.Erros.Add(
                        new ErroLimpeza
                        {
                            Local = local.Nome,
                            Caminho = local.Caminho,
                            Motivo = ex.Message
                        });

                    return;
                }

                foreach (string caminho in arquivos)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    try
                    {
                        FileInfo arquivo = new FileInfo(caminho);

                        if (!arquivo.Exists)
                            continue;

                        long tamanho = arquivo.Length;

                        File.Delete(caminho);

                        resultado.ArquivosExcluidos++;
                        resultado.BytesLiberados += tamanho;

                        progresso?.Report(
                            $"Excluído: {arquivo.Name}");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        resultado.ArquivosComErro++;

                        resultado.Erros.Add(
                            new ErroLimpeza
                            {
                                Local = local.Nome,
                                Caminho = caminho,
                                Motivo = "Acesso negado."
                            });
                    }
                    catch (IOException)
                    {
                        resultado.ArquivosComErro++;

                        resultado.Erros.Add(
                            new ErroLimpeza
                            {
                                Local = local.Nome,
                                Caminho = caminho,
                                Motivo =
                                    "Arquivo em uso ou indisponível."
                            });
                    }
                    catch (Exception ex)
                    {
                        resultado.ArquivosComErro++;

                        resultado.Erros.Add(
                            new ErroLimpeza
                            {
                                Local = local.Nome,
                                Caminho = caminho,
                                Motivo = ex.Message
                            });
                    }
                }

                // Remove somente diretórios vazios.
                // A pasta principal nunca é removida.
                RemoverDiretoriosVazios(
                    local.Caminho,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                resultado.LocaisComErro++;

                resultado.Erros.Add(
                    new ErroLimpeza
                    {
                        Local = local.Nome,
                        Caminho = local.Caminho,
                        Motivo = ex.Message
                    });
            }
        }

        private void RemoverDiretoriosVazios(
            string diretorio,
            CancellationToken cancellationToken)
        {
            try
            {
                string[] subdiretorios =
                    Directory.GetDirectories(
                        diretorio,
                        "*",
                        SearchOption.AllDirectories);

                // Começamos pelos mais profundos.
                foreach (string subdiretorio in subdiretorios
                             .OrderByDescending(x => x.Length))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    try
                    {
                        if (!Directory.EnumerateFileSystemEntries(
                                subdiretorio).Any())
                        {
                            Directory.Delete(subdiretorio);
                        }
                    }
                    catch
                    {
                        // Diretórios em uso/protegidos são ignorados.
                    }
                }
            }
            catch
            {
                // Não interrompe a limpeza por causa de diretórios.
            }
        }

        private List<LocalLimpeza> ObterLocais()
        {
            string tempUsuario =
                Environment.GetEnvironmentVariable("TEMP")
                ?? Path.GetTempPath();

            string windows =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.Windows);

            string tempWindows =
                Path.Combine(windows, "Temp");

            string prefetch =
                Path.Combine(windows, "Prefetch");

            return new List<LocalLimpeza>
            {
                new LocalLimpeza
                {
                    Nome = "%TEMP%",
                    Caminho = tempUsuario,
                    SelecionadoPorPadrao = true
                },

                new LocalLimpeza
                {
                    Nome = "Windows Temp",
                    Caminho = tempWindows,
                    SelecionadoPorPadrao = true
                },

                new LocalLimpeza
                {
                    Nome = "Prefetch",
                    Caminho = prefetch,
                    SelecionadoPorPadrao = false
                }
            };
        }
    }

    public class LocalLimpeza
    {
        public string Nome { get; set; } = string.Empty;

        public string Caminho { get; set; } = string.Empty;

        public bool SelecionadoPorPadrao { get; set; }
    }

    public class ResultadoAnaliseTemp
    {
        public List<ResultadoLocal> Locais { get; set; } = new();

        public int TotalArquivos { get; set; }

        public long TotalBytes { get; set; }

        public int TotalErros { get; set; }

        public string EspacoRecuperavel =>
            FormatarTamanho(TotalBytes);

        private static string FormatarTamanho(long bytes)
        {
            if (bytes < 1024)
                return $"{bytes} B";

            if (bytes < 1024 * 1024)
                return $"{bytes / 1024.0:0.00} KB";

            if (bytes < 1024 * 1024 * 1024)
                return $"{bytes / 1024.0 / 1024.0:0.00} MB";

            return $"{bytes / 1024.0 / 1024.0 / 1024.0:0.00} GB";
        }
    }

    public class ResultadoLocal
    {
        public string Nome { get; set; } = string.Empty;

        public string Caminho { get; set; } = string.Empty;

        public bool Disponivel { get; set; }

        public int QuantidadeArquivos { get; set; }

        public long TamanhoBytes { get; set; }

        public int QuantidadeErros { get; set; }

        public bool Selecionado { get; set; }

        public string TamanhoFormatado =>
            FormatarTamanho(TamanhoBytes);

        private static string FormatarTamanho(long bytes)
        {
            if (bytes < 1024)
                return $"{bytes} B";

            if (bytes < 1024 * 1024)
                return $"{bytes / 1024.0:0.00} KB";

            if (bytes < 1024 * 1024 * 1024)
                return $"{bytes / 1024.0 / 1024.0:0.00} MB";

            return $"{bytes / 1024.0 / 1024.0 / 1024.0:0.00} GB";
        }
    }

    public class ResultadoLimpezaTemp
    {
        public int LocaisProcessados { get; set; }

        public int LocaisComErro { get; set; }

        public int ArquivosExcluidos { get; set; }

        public int ArquivosComErro { get; set; }

        public long BytesLiberados { get; set; }

        public List<ErroLimpeza> Erros { get; set; } = new();

        public string EspacoLiberado =>
            FormatarTamanho(BytesLiberados);

        public bool Sucesso =>
            LocaisComErro == 0 &&
            ArquivosComErro == 0;

        private static string FormatarTamanho(long bytes)
        {
            if (bytes < 1024)
                return $"{bytes} B";

            if (bytes < 1024 * 1024)
                return $"{bytes / 1024.0:0.00} KB";

            if (bytes < 1024 * 1024 * 1024)
                return $"{bytes / 1024.0 / 1024.0:0.00} MB";

            return $"{bytes / 1024.0 / 1024.0 / 1024.0:0.00} GB";
        }
    }

    public class ErroLimpeza
    {
        public string Local { get; set; } = string.Empty;

        public string Caminho { get; set; } = string.Empty;

        public string Motivo { get; set; } = string.Empty;
    }
}