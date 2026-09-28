using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WinTuner.Services.Limpeza
{
    public class LimpezaWinService
    {
        public async Task<ResultadoAnaliseWindows> AnalisarAsync(
            IProgress<string>? progresso = null,
            CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
            {
                var resultado = new ResultadoAnaliseWindows();

                List<LocalLimpezaWindows> locais =
                    ObterLocais();

                foreach (LocalLimpezaWindows local in locais)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    progresso?.Report(
                        $"Analisando {local.Nome}...");

                    ResultadoLocalWindows resultadoLocal =
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

                progresso?.Report(
                    "Análise do Windows concluída.");

                return resultado;

            }, cancellationToken);
        }

        public async Task<ResultadoLimpezaWindows> LimparAsync(
            IEnumerable<ResultadoLocalWindows> locaisSelecionados,
            IProgress<string>? progresso = null,
            CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
            {
                var resultado =
                    new ResultadoLimpezaWindows();

                List<ResultadoLocalWindows> locais =
                    locaisSelecionados.ToList();

                foreach (ResultadoLocalWindows local in locais)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    progresso?.Report(
                        $"Limpando {local.Nome}...");

                    resultado.LocaisProcessados++;

                    if (!Directory.Exists(local.Caminho))
                    {
                        resultado.LocaisComErro++;

                        resultado.Erros.Add(
                            new ErroLimpezaWindows
                            {
                                Local = local.Nome,
                                Caminho = local.Caminho,
                                Motivo = "A pasta não foi encontrada."
                            });

                        continue;
                    }

                    LimparLocal(
                        local,
                        resultado,
                        progresso,
                        cancellationToken);
                }

                progresso?.Report(
                    "Limpeza do Windows concluída.");

                return resultado;

            }, cancellationToken);
        }

        private ResultadoLocalWindows AnalisarLocal(
            LocalLimpezaWindows local,
            CancellationToken cancellationToken)
        {
            var resultado =
                new ResultadoLocalWindows
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
                        FileInfo arquivo =
                            new FileInfo(caminho);

                        if (!arquivo.Exists)
                            continue;

                        resultado.QuantidadeArquivos++;
                        resultado.TamanhoBytes +=
                            arquivo.Length;
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

        private void LimparLocal(
            ResultadoLocalWindows local,
            ResultadoLimpezaWindows resultado,
            IProgress<string>? progresso,
            CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<string> arquivos;

                try
                {
                    arquivos =
                        Directory.EnumerateFiles(
                            local.Caminho,
                            "*",
                            SearchOption.AllDirectories);
                }
                catch (UnauthorizedAccessException)
                {
                    resultado.LocaisComErro++;

                    resultado.Erros.Add(
                        new ErroLimpezaWindows
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
                        new ErroLimpezaWindows
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
                        FileInfo arquivo =
                            new FileInfo(caminho);

                        if (!arquivo.Exists)
                            continue;

                        long tamanho =
                            arquivo.Length;

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
                            new ErroLimpezaWindows
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
                            new ErroLimpezaWindows
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
                            new ErroLimpezaWindows
                            {
                                Local = local.Nome,
                                Caminho = caminho,
                                Motivo = ex.Message
                            });
                    }
                }

                RemoverDiretoriosVazios(
                    local.Caminho,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                resultado.LocaisComErro++;

                resultado.Erros.Add(
                    new ErroLimpezaWindows
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

                foreach (string subdiretorio in
                    subdiretorios.OrderByDescending(x => x.Length))
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
                    }
                }
            }
            catch
            {
            }
        }

        private List<LocalLimpezaWindows> ObterLocais()
        {
            string windows =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.Windows);

            string programData =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.CommonApplicationData);

            string localAppData =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData);

            string update =
                Path.Combine(
                    windows,
                    "SoftwareDistribution",
                    "Download");

            string wer =
                Path.Combine(
                    programData,
                    "Microsoft",
                    "Windows",
                    "WER");

            string deliveryOptimization =
                Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.CommonApplicationData),
                    "Microsoft",
                    "Windows",
                    "DeliveryOptimization");

            string directX =
                Path.Combine(
                    localAppData,
                    "D3DSCache");

            return new List<LocalLimpezaWindows>
            {
                new LocalLimpezaWindows
                {
                    Nome = "Cache do Windows Update",
                    Caminho = update,
                    SelecionadoPorPadrao = true
                },

                new LocalLimpezaWindows
                {
                    Nome = "Relatórios de Erros do Windows",
                    Caminho = wer,
                    SelecionadoPorPadrao = true
                },

                new LocalLimpezaWindows
                {
                    Nome = "Delivery Optimization",
                    Caminho = deliveryOptimization,
                    SelecionadoPorPadrao = true
                },

                new LocalLimpezaWindows
                {
                    Nome = "Cache DirectX",
                    Caminho = directX,
                    SelecionadoPorPadrao = true
                }
            };
        }
    }

    public class LocalLimpezaWindows
    {
        public string Nome { get; set; } = string.Empty;

        public string Caminho { get; set; } = string.Empty;

        public bool SelecionadoPorPadrao { get; set; }
    }

    public class ResultadoAnaliseWindows
    {
        public List<ResultadoLocalWindows> Locais { get; set; } = new();

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

    public class ResultadoLocalWindows
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

    public class ResultadoLimpezaWindows
    {
        public int LocaisProcessados { get; set; }

        public int LocaisComErro { get; set; }

        public int ArquivosExcluidos { get; set; }

        public int ArquivosComErro { get; set; }

        public long BytesLiberados { get; set; }

        public List<ErroLimpezaWindows> Erros { get; set; } = new();

        public string EspacoLiberado =>
            FormatarTamanho(BytesLiberados);

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

    public class ErroLimpezaWindows
    {
        public string Local { get; set; } = string.Empty;

        public string Caminho { get; set; } = string.Empty;

        public string Motivo { get; set; } = string.Empty;
    }
}