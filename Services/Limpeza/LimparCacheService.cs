using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WinTuner.Services.Limpeza
{
    public class LimparCacheService
    {
        public async Task<ResultadoAnaliseCache> AnalisarAsync(
            IProgress<string>? progresso = null,
            CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
            {
                var resultado = new ResultadoAnaliseCache();

                List<LocalCache> locais = ObterLocais();

                foreach (LocalCache local in locais)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    progresso?.Report(
                        $"Analisando {local.Nome}...");

                    ResultadoCache resultadoLocal =
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
                    "Análise de cache concluída.");

                return resultado;

            }, cancellationToken);
        }

        public async Task<ResultadoLimpezaCache> LimparAsync(
            IEnumerable<ResultadoCache> locaisSelecionados,
            IProgress<string>? progresso = null,
            CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
            {
                var resultado =
                    new ResultadoLimpezaCache();

                List<ResultadoCache> locais =
                    locaisSelecionados.ToList();

                foreach (ResultadoCache local in locais)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    progresso?.Report(
                        $"Limpando {local.Nome}...");

                    resultado.LocaisProcessados++;

                    if (!local.Disponivel ||
                        !Directory.Exists(local.Caminho))
                    {
                        resultado.LocaisComErro++;

                        resultado.Erros.Add(
                            new ErroCache
                            {
                                Local = local.Nome,
                                Caminho = local.Caminho,
                                Motivo = "Cache não encontrado."
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
                    "Limpeza de cache concluída.");

                return resultado;

            }, cancellationToken);
        }

        public async Task<ResultadoDns> LimparDnsAsync(
            IProgress<string>? progresso = null,
            CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                progresso?.Report(
                    "Limpando cache DNS do Windows...");

                try
                {
                    using var processo =
                        new System.Diagnostics.Process();

                    processo.StartInfo =
                        new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = "ipconfig.exe",
                            Arguments = "/flushdns",
                            UseShellExecute = false,
                            CreateNoWindow = true,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true
                        };

                    processo.Start();

                    string saida =
                        processo.StandardOutput.ReadToEnd();

                    string erro =
                        processo.StandardError.ReadToEnd();

                    processo.WaitForExit();

                    if (processo.ExitCode == 0)
                    {
                        progresso?.Report(
                            "Cache DNS limpo com sucesso.");

                        return new ResultadoDns
                        {
                            Sucesso = true,
                            Mensagem =
                                "O cache DNS do Windows foi limpo com sucesso."
                        };
                    }

                    return new ResultadoDns
                    {
                        Sucesso = false,
                        Mensagem =
                            string.IsNullOrWhiteSpace(erro)
                                ? "Não foi possível limpar o cache DNS."
                                : erro.Trim()
                    };
                }
                catch (Exception ex)
                {
                    return new ResultadoDns
                    {
                        Sucesso = false,
                        Mensagem = ex.Message
                    };
                }

            }, cancellationToken);
        }

        private ResultadoCache AnalisarLocal(
            LocalCache local,
            CancellationToken cancellationToken)
        {
            var resultado =
                new ResultadoCache
                {
                    Nome = local.Nome,
                    Caminho = local.Caminho,
                    Tipo = local.Tipo
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
            catch
            {
                resultado.QuantidadeErros++;
            }

            return resultado;
        }

        private void LimparLocal(
            ResultadoCache local,
            ResultadoLimpezaCache resultado,
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
                        new ErroCache
                        {
                            Local = local.Nome,
                            Caminho = local.Caminho,
                            Motivo = "Acesso negado."
                        });

                    return;
                }
                catch (IOException ex)
                {
                    resultado.LocaisComErro++;

                    resultado.Erros.Add(
                        new ErroCache
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
                            new ErroCache
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
                            new ErroCache
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
                            new ErroCache
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
                    new ErroCache
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
                         subdiretorios.OrderByDescending(
                             x => x.Length))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    try
                    {
                        if (!Directory
                            .EnumerateFileSystemEntries(
                                subdiretorio)
                            .Any())
                        {
                            Directory.Delete(
                                subdiretorio);
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

        private List<LocalCache> ObterLocais()
        {
            string localAppData =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData);

            string appData =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData);

            var locais =
                new List<LocalCache>();

            string chrome =
                Path.Combine(
                    localAppData,
                    "Google",
                    "Chrome",
                    "User Data",
                    "Default",
                    "Cache");

            string chromeCodeCache =
                Path.Combine(
                    localAppData,
                    "Google",
                    "Chrome",
                    "User Data",
                    "Default",
                    "Code Cache");

            string edge =
                Path.Combine(
                    localAppData,
                    "Microsoft",
                    "Edge",
                    "User Data",
                    "Default",
                    "Cache");

            string edgeCodeCache =
                Path.Combine(
                    localAppData,
                    "Microsoft",
                    "Edge",
                    "User Data",
                    "Default",
                    "Code Cache");

            string firefox =
                Path.Combine(
                    localAppData,
                    "Mozilla",
                    "Firefox",
                    "Profiles");

            string opera =
                Path.Combine(
                    appData,
                    "Opera Software",
                    "Opera Stable",
                    "Cache");

            AdicionarSeExistente(
                locais,
                "Google Chrome",
                chrome,
                "Navegador");

            AdicionarSeExistente(
                locais,
                "Chrome Code Cache",
                chromeCodeCache,
                "Navegador");

            AdicionarSeExistente(
                locais,
                "Microsoft Edge",
                edge,
                "Navegador");

            AdicionarSeExistente(
                locais,
                "Edge Code Cache",
                edgeCodeCache,
                "Navegador");

            AdicionarPerfisFirefox(
                locais,
                firefox);

            AdicionarSeExistente(
                locais,
                "Opera",
                opera,
                "Navegador");

            return locais;
        }

        private void AdicionarPerfisFirefox(
            List<LocalCache> locais,
            string diretorioPerfis)
        {
            if (!Directory.Exists(diretorioPerfis))
                return;

            try
            {
                foreach (string perfil in
                         Directory.GetDirectories(
                             diretorioPerfis))
                {
                    string cache =
                        Path.Combine(
                            perfil,
                            "cache2");

                    AdicionarSeExistente(
                        locais,
                        $"Firefox - {Path.GetFileName(perfil)}",
                        cache,
                        "Navegador");
                }
            }
            catch
            {
            }
        }

        private void AdicionarSeExistente(
            List<LocalCache> locais,
            string nome,
            string caminho,
            string tipo)
        {
            if (!Directory.Exists(caminho))
                return;

            locais.Add(
                new LocalCache
                {
                    Nome = nome,
                    Caminho = caminho,
                    Tipo = tipo,
                    SelecionadoPorPadrao = true
                });
        }
    }

    public class LocalCache
    {
        public string Nome { get; set; } = string.Empty;
        public string Caminho { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public bool SelecionadoPorPadrao { get; set; }
    }

    public class ResultadoCache
    {
        public string Nome { get; set; } = string.Empty;
        public string Caminho { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public bool Disponivel { get; set; }
        public int QuantidadeArquivos { get; set; }
        public long TamanhoBytes { get; set; }
        public int QuantidadeErros { get; set; }
        public bool Selecionado { get; set; }

        public string TamanhoFormatado =>
            FormatarTamanho(TamanhoBytes);

        private static string FormatarTamanho(
            long bytes)
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

    public class ResultadoAnaliseCache
    {
        public List<ResultadoCache> Locais { get; set; } = new();

        public int TotalArquivos { get; set; }

        public long TotalBytes { get; set; }

        public int TotalErros { get; set; }

        public string EspacoRecuperavel =>
            FormatarTamanho(TotalBytes);

        private static string FormatarTamanho(
            long bytes)
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

    public class ResultadoLimpezaCache
    {
        public int LocaisProcessados { get; set; }

        public int LocaisComErro { get; set; }

        public int ArquivosExcluidos { get; set; }

        public int ArquivosComErro { get; set; }

        public long BytesLiberados { get; set; }

        public List<ErroCache> Erros { get; set; } = new();

        public string EspacoLiberado =>
            FormatarTamanho(BytesLiberados);

        private static string FormatarTamanho(
            long bytes)
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

    public class ResultadoDns
    {
        public bool Sucesso { get; set; }

        public string Mensagem { get; set; } = string.Empty;
    }

    public class ErroCache
    {
        public string Local { get; set; } = string.Empty;

        public string Caminho { get; set; } = string.Empty;

        public string Motivo { get; set; } = string.Empty;
    }
}