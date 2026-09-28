using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WinTuner.Services.Limpeza
{
    public class ArquivosInuteisService
    {
        private static readonly string[] ExtensoesInuteis =
        {
            ".tmp",
            ".temp",
            ".bak",
            ".old",
            ".dmp"
        };

        public async Task<ResultadoAnaliseInuteis> AnalisarAsync(
            IProgress<string>? progresso = null,
            CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
            {
                var resultado =
                    new ResultadoAnaliseInuteis();

                List<LocalInuteis> locais =
                    ObterLocais();

                foreach (LocalInuteis local in locais)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    progresso?.Report(
                        $"Analisando {local.Nome}...");

                    ResultadoLocalInuteis resultadoLocal =
                        AnalisarLocal(
                            local,
                            progresso,
                            cancellationToken);

                    resultado.Locais.Add(
                        resultadoLocal);

                    resultado.TotalArquivos +=
                        resultadoLocal.QuantidadeArquivos;

                    resultado.TotalBytes +=
                        resultadoLocal.TamanhoBytes;

                    resultado.TotalErros +=
                        resultadoLocal.QuantidadeErros;
                }

                progresso?.Report(
                    "Análise concluída.");

                return resultado;

            }, cancellationToken);
        }

        public async Task<ResultadoLimpezaInuteis> LimparAsync(
            IEnumerable<ResultadoLocalInuteis> locaisSelecionados,
            IProgress<string>? progresso = null,
            CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
            {
                var resultado =
                    new ResultadoLimpezaInuteis();

                List<ResultadoLocalInuteis> locais =
                    locaisSelecionados.ToList();

                foreach (ResultadoLocalInuteis local in locais)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    progresso?.Report(
                        $"Limpando {local.Nome}...");

                    resultado.LocaisProcessados++;

                    LimparLocal(
                        local,
                        resultado,
                        progresso,
                        cancellationToken);
                }

                progresso?.Report(
                    "Limpeza concluída.");

                return resultado;

            }, cancellationToken);
        }

        private ResultadoLocalInuteis AnalisarLocal(
            LocalInuteis local,
            IProgress<string>? progresso,
            CancellationToken cancellationToken)
        {
            var resultado =
                new ResultadoLocalInuteis
                {
                    Nome = local.Nome,
                    Caminho = local.Caminho,
                    Disponivel = false
                };

            if (!Directory.Exists(local.Caminho))
                return resultado;

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

                        if (!ExtensaoPermitida(
                                arquivo.Extension))
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
            ResultadoLocalInuteis local,
            ResultadoLimpezaInuteis resultado,
            IProgress<string>? progresso,
            CancellationToken cancellationToken)
        {
            if (!Directory.Exists(local.Caminho))
            {
                resultado.LocaisComErro++;

                resultado.Erros.Add(
                    new ErroLimpezaInuteis
                    {
                        Local = local.Nome,
                        Caminho = local.Caminho,
                        Motivo = "A pasta não foi encontrada."
                    });

                return;
            }

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

                        if (!ExtensaoPermitida(
                                arquivo.Extension))
                            continue;

                        long tamanho =
                            arquivo.Length;

                        File.Delete(caminho);

                        resultado.ArquivosExcluidos++;

                        resultado.BytesLiberados +=
                            tamanho;

                        progresso?.Report(
                            $"Excluído: {arquivo.Name}");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        resultado.ArquivosComErro++;

                        resultado.Erros.Add(
                            new ErroLimpezaInuteis
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
                            new ErroLimpezaInuteis
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
                            new ErroLimpezaInuteis
                            {
                                Local = local.Nome,
                                Caminho = caminho,
                                Motivo = ex.Message
                            });
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                resultado.LocaisComErro++;

                resultado.Erros.Add(
                    new ErroLimpezaInuteis
                    {
                        Local = local.Nome,
                        Caminho = local.Caminho,
                        Motivo = "Acesso negado à pasta."
                    });
            }
            catch (IOException ex)
            {
                resultado.LocaisComErro++;

                resultado.Erros.Add(
                    new ErroLimpezaInuteis
                    {
                        Local = local.Nome,
                        Caminho = local.Caminho,
                        Motivo = ex.Message
                    });
            }
        }

        private static bool ExtensaoPermitida(
            string extensao)
        {
            return ExtensoesInuteis.Any(
                x => string.Equals(
                    x,
                    extensao,
                    StringComparison.OrdinalIgnoreCase));
        }

        private List<LocalInuteis> ObterLocais()
        {
            string windows =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.Windows);

            string localAppData =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData);

            string programData =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.CommonApplicationData);

            return new List<LocalInuteis>
            {
                new LocalInuteis
                {
                    Nome = "Relatórios de Erros",
                    Caminho = Path.Combine(
                        programData,
                        "Microsoft",
                        "Windows",
                        "WER"),
                    SelecionadoPorPadrao = true
                },

                new LocalInuteis
                {
                    Nome = "Crash Dumps",
                    Caminho = Path.Combine(
                        localAppData,
                        "CrashDumps"),
                    SelecionadoPorPadrao = true
                },

                new LocalInuteis
                {
                    Nome = "Minidumps do Windows",
                    Caminho = Path.Combine(
                        windows,
                        "Minidump"),
                    SelecionadoPorPadrao = false
                }
            };
        }
    }

    public class LocalInuteis
    {
        public string Nome { get; set; } = string.Empty;

        public string Caminho { get; set; } = string.Empty;

        public bool SelecionadoPorPadrao { get; set; }
    }

    public class ResultadoAnaliseInuteis
    {
        public List<ResultadoLocalInuteis> Locais { get; set; } =
            new();

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
                return
                    $"{bytes / 1024.0 / 1024.0:0.00} MB";

            return
                $"{bytes / 1024.0 / 1024.0 / 1024.0:0.00} GB";
        }
    }

    public class ResultadoLocalInuteis
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

        private static string FormatarTamanho(
            long bytes)
        {
            if (bytes < 1024)
                return $"{bytes} B";

            if (bytes < 1024 * 1024)
                return $"{bytes / 1024.0:0.00} KB";

            if (bytes < 1024 * 1024 * 1024)
                return
                    $"{bytes / 1024.0 / 1024.0:0.00} MB";

            return
                $"{bytes / 1024.0 / 1024.0 / 1024.0:0.00} GB";
        }
    }

    public class ResultadoLimpezaInuteis
    {
        public int LocaisProcessados { get; set; }

        public int LocaisComErro { get; set; }

        public int ArquivosExcluidos { get; set; }

        public int ArquivosComErro { get; set; }

        public long BytesLiberados { get; set; }

        public List<ErroLimpezaInuteis> Erros { get; set; } =
            new();

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
                return
                    $"{bytes / 1024.0 / 1024.0:0.00} MB";

            return
                $"{bytes / 1024.0 / 1024.0 / 1024.0:0.00} GB";
        }
    }

    public class ErroLimpezaInuteis
    {
        public string Local { get; set; } = string.Empty;

        public string Caminho { get; set; } = string.Empty;

        public string Motivo { get; set; } = string.Empty;
    }
}