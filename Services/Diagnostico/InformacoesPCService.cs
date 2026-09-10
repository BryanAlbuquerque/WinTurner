using Microsoft.Win32;
using System.Management;
using System.Runtime.InteropServices;
using WinTuner.Models;

namespace WinTuner.Services.Diagnosticos
{
    public class InformacoesPCService
    {
        public InformacaoPC ObterInformacoes()
        {
            var informacoes = new InformacaoPC();

            PreencherInformacoesWindows(informacoes);
            PreencherInformacoesProcessador(informacoes);
            PreencherInformacoesGpu(informacoes);
            PreencherInformacoesArmazenamento(informacoes);
            PreencherInformacoesPlacaMae(informacoes);
            PreencherInformacoesMemoria(informacoes);

            return informacoes;
        }

        private void PreencherInformacoesWindows(InformacaoPC informacoes)
        {
            informacoes.NomeWindows = ObterNomeWindows();
            informacoes.Versao = Environment.OSVersion.Version.ToString();
            informacoes.Build = Environment.OSVersion.Version.Build.ToString();
            informacoes.Arquitetura = ObterArquitetura();
            informacoes.Computador = Environment.MachineName;
            informacoes.Usuario = Environment.UserName;
            informacoes.DiretorioWindows = Environment.GetFolderPath(
                Environment.SpecialFolder.Windows
            );
            informacoes.DiretorioSistema = Environment.SystemDirectory;
        }

        private string ObterNomeWindows()
        {
            try
            {
                using RegistryKey? chave = Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\Microsoft\Windows NT\CurrentVersion"
                );

                string? nome = chave?.GetValue("ProductName")?.ToString();
                string? displayVersion = chave?.GetValue("DisplayVersion")?.ToString();

                if (string.IsNullOrWhiteSpace(nome))
                    return "Windows não identificado";

                if (!string.IsNullOrWhiteSpace(displayVersion))
                    return $"{nome} {displayVersion}";

                return nome;
            }
            catch
            {
                return "Windows não identificado";
            }
        }

        private string ObterArquitetura()
        {
            return RuntimeInformation.OSArchitecture switch
            {
                Architecture.X64 => "64 bits",
                Architecture.X86 => "32 bits",
                Architecture.Arm64 => "ARM64",
                Architecture.Arm => "ARM",
                _ => RuntimeInformation.OSArchitecture.ToString()
            };
        }

        private void PreencherInformacoesProcessador(InformacaoPC informacoes)
        {
            try
            {
                using var searcher = new ManagementObjectSearcher(
                    "SELECT Name FROM Win32_Processor"
                );

                foreach (ManagementObject obj in searcher.Get())
                {
                    string? nome = obj["Name"]?.ToString();

                    if (!string.IsNullOrWhiteSpace(nome))
                    {
                        informacoes.Processador = nome.Trim();
                        return;
                    }
                }

                informacoes.Processador = "Processador não identificado";
            }
            catch
            {
                informacoes.Processador = "Processador não identificado";
            }
        }

        private void PreencherInformacoesGpu(InformacaoPC informacoes)
        {
            try
            {
                using var searcher = new ManagementObjectSearcher(
                    "SELECT Name, AdapterRAM FROM Win32_VideoController"
                );

                var placas = new List<string>();
                ulong maiorMemoriaBytes = 0;

                foreach (ManagementObject obj in searcher.Get())
                {
                    string? nome = obj["Name"]?.ToString();

                    if (!string.IsNullOrWhiteSpace(nome))
                    {
                        placas.Add(nome.Trim());
                    }

                    if (obj["AdapterRAM"] != null)
                    {
                        try
                        {
                            ulong memoriaBytes = Convert.ToUInt64(obj["AdapterRAM"]);

                            if (memoriaBytes > maiorMemoriaBytes)
                            {
                                maiorMemoriaBytes = memoriaBytes;
                            }
                        }
                        catch
                        {
                            // Algumas GPUs/drivers podem não informar AdapterRAM corretamente.
                        }
                    }
                }

                if (placas.Count == 0)
                {
                    informacoes.PlacaDeVideoNome = "GPU não identificada";
                    informacoes.PlacaDeVideoModelo = "Não identificado";
                    informacoes.PlacaDeVideoMemoria = "Não identificada";
                    return;
                }

                informacoes.PlacaDeVideoNome = string.Join(" | ", placas);
                informacoes.PlacaDeVideoModelo = placas.First();

                informacoes.PlacaDeVideoMemoria = maiorMemoriaBytes > 0
                    ? FormatarBytes(maiorMemoriaBytes)
                    : "Não identificada";
            }
            catch
            {
                informacoes.PlacaDeVideoNome = "GPU não identificada";
                informacoes.PlacaDeVideoModelo = "Não identificado";
                informacoes.PlacaDeVideoMemoria = "Não identificada";
            }
        }

        private void PreencherInformacoesArmazenamento(InformacaoPC informacoes)
        {
            try
            {
                long totalBytes = 0;
                long disponivelBytes = 0;

                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    try
                    {
                        if (!drive.IsReady)
                            continue;

                        if (drive.DriveType != DriveType.Fixed)
                            continue;

                        totalBytes += drive.TotalSize;
                        disponivelBytes += drive.AvailableFreeSpace;
                    }
                    catch
                    {
                        // Ignora unidades indisponíveis.
                    }
                }

                informacoes.ArmazenamentoTotal = totalBytes > 0
                    ? FormatarBytes((ulong)totalBytes)
                    : "Não identificado";

                informacoes.ArmazenamentoDisponivel = disponivelBytes > 0
                    ? FormatarBytes((ulong)disponivelBytes)
                    : "Não identificado";
            }
            catch
            {
                informacoes.ArmazenamentoTotal = "Não identificado";
                informacoes.ArmazenamentoDisponivel = "Não identificado";
            }
        }

        private void PreencherInformacoesPlacaMae(InformacaoPC informacoes)
        {
            try
            {
                using var searcher = new ManagementObjectSearcher(
                    "SELECT Manufacturer, Product FROM Win32_BaseBoard"
                );

                foreach (ManagementObject obj in searcher.Get())
                {
                    string fabricante = obj["Manufacturer"]?.ToString()?.Trim()
                        ?? "Não identificado";

                    string modelo = obj["Product"]?.ToString()?.Trim()
                        ?? "Não identificado";

                    informacoes.PlacaMaeNome = fabricante;
                    informacoes.PlacaMaeModelo = modelo;

                    return;
                }

                informacoes.PlacaMaeNome = "Não identificada";
                informacoes.PlacaMaeModelo = "Não identificado";
            }
            catch
            {
                informacoes.PlacaMaeNome = "Não identificada";
                informacoes.PlacaMaeModelo = "Não identificado";
            }
        }

        private void PreencherInformacoesMemoria(InformacaoPC informacoes)
        {
            try
            {
                using var searcher = new ManagementObjectSearcher(
                    "SELECT TotalVisibleMemorySize, FreePhysicalMemory, " +
                    "TotalVirtualMemorySize, FreeVirtualMemory " +
                    "FROM Win32_OperatingSystem"
                );

                foreach (ManagementObject obj in searcher.Get())
                {
                    ulong memoriaFisicaTotalKB =
                        Convert.ToUInt64(obj["TotalVisibleMemorySize"]);

                    ulong memoriaFisicaDisponivelKB =
                        Convert.ToUInt64(obj["FreePhysicalMemory"]);

                    ulong memoriaVirtualTotalKB =
                        Convert.ToUInt64(obj["TotalVirtualMemorySize"]);

                    ulong memoriaVirtualDisponivelKB =
                        Convert.ToUInt64(obj["FreeVirtualMemory"]);

                    ulong memoriaFisicaUsadaKB =
                        memoriaFisicaTotalKB - memoriaFisicaDisponivelKB;

                    informacoes.MemoriaFisica =
                        FormatarKilobytes(memoriaFisicaUsadaKB);

                    informacoes.MemoriaFisicaTotal =
                        FormatarKilobytes(memoriaFisicaTotalKB);

                    informacoes.MemoriaFisicaDisponivel =
                        FormatarKilobytes(memoriaFisicaDisponivelKB);

                    informacoes.MemoriaVirtualTotal =
                        FormatarKilobytes(memoriaVirtualTotalKB);

                    informacoes.MemoriaVirtualDisponivel =
                        FormatarKilobytes(memoriaVirtualDisponivelKB);

                    return;
                }

                DefinirMemoriaNaoIdentificada(informacoes);
            }
            catch
            {
                DefinirMemoriaNaoIdentificada(informacoes);
            }
        }

        private void DefinirMemoriaNaoIdentificada(InformacaoPC informacoes)
        {
            informacoes.MemoriaFisica = "Não identificada";
            informacoes.MemoriaFisicaTotal = "Não identificada";
            informacoes.MemoriaFisicaDisponivel = "Não identificada";
            informacoes.MemoriaVirtualTotal = "Não identificada";
            informacoes.MemoriaVirtualDisponivel = "Não identificada";
        }

        private string FormatarKilobytes(ulong kilobytes)
        {
            ulong bytes = kilobytes * 1024;

            return FormatarBytes(bytes);
        }

        private string FormatarBytes(ulong bytes)
        {
            const double KB = 1024;
            const double MB = KB * 1024;
            const double GB = MB * 1024;
            const double TB = GB * 1024;

            if (bytes >= TB)
                return $"{bytes / TB:0.##} TB";

            if (bytes >= GB)
                return $"{bytes / GB:0.##} GB";

            if (bytes >= MB)
                return $"{bytes / MB:0.##} MB";

            if (bytes >= KB)
                return $"{bytes / KB:0.##} KB";

            return $"{bytes} bytes";
        }
    }
}