using System.Diagnostics;
using System.Management;
using WinTurner.Models;

namespace WinTurner.Services
{
    public class SistemaService
    {
        private readonly PerformanceCounter _cpuCounter;

        public SistemaService()
        {
            _cpuCounter = new PerformanceCounter(
                "Processor",
                "% Processor Time",
                "_Total"
            );

            // Primeira leitura do PerformanceCounter
            _cpuCounter.NextValue();
        }

        public InformacoesSistema ObterInformacoes()
        {
            var memoria = ObterMemoria();
            var disco = ObterDisco();
            var gpu = ObterGpu();

            return new InformacoesSistema
            {
                CpuUso = ObterCpu(),
                RamUso = memoria.UsoPercentual,
                RamTotalGB = memoria.TotalGB,
                RamDisponivelGB = memoria.DisponivelGB,
                DiscoUso = disco.UsoPercentual,
                DiscoTotalGB = disco.TotalGB,
                DiscoDisponivelGB = disco.DisponivelGB,
                GpuNome = gpu
            };
        }

        private double ObterCpu()
        {
            return Math.Round(_cpuCounter.NextValue(), 1);
        }

        private (double TotalGB, double DisponivelGB, double UsoPercentual) ObterMemoria()
        {
            using var searcher = new ManagementObjectSearcher(
                "SELECT TotalVisibleMemorySize, FreePhysicalMemory FROM Win32_OperatingSystem"
            );

            foreach (ManagementObject obj in searcher.Get())
            {
                double totalKB = Convert.ToDouble(
                    obj["TotalVisibleMemorySize"]
                );

                double livreKB = Convert.ToDouble(
                    obj["FreePhysicalMemory"]
                );

                double totalGB = totalKB / 1024 / 1024;
                double livreGB = livreKB / 1024 / 1024;

                double uso = ((totalGB - livreGB) / totalGB) * 100;

                return (
                    Math.Round(totalGB, 2),
                    Math.Round(livreGB, 2),
                    Math.Round(uso, 1)
                );
            }

            return (0, 0, 0);
        }

        private (double TotalGB, double DisponivelGB, double UsoPercentual) ObterDisco()
        {
            DriveInfo drive = new DriveInfo("C:\\");

            double totalGB = drive.TotalSize / 1024.0 / 1024.0 / 1024.0;
            double disponivelGB = drive.AvailableFreeSpace / 1024.0 / 1024.0 / 1024.0;

            double usadoGB = totalGB - disponivelGB;

            double uso = (usadoGB / totalGB) * 100;

            return (
                Math.Round(totalGB, 2),
                Math.Round(disponivelGB, 2),
                Math.Round(uso, 1)
            );
        }

        private string ObterGpu()
        {
            using var searcher = new ManagementObjectSearcher(
                "SELECT Name FROM Win32_VideoController"
            );

            foreach (ManagementObject obj in searcher.Get())
            {
                string? nome = obj["Name"]?.ToString();

                if (!string.IsNullOrWhiteSpace(nome))
                    return nome;
            }

            return "GPU não identificada";
        }
    }
}