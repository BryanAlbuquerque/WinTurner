using System.Diagnostics;
using System.Management;

namespace WinTurner.Services
{
    public class SistemaService
    {
        private readonly PerformanceCounter _cpuCounter;
        private readonly PerformanceCounter _ramCounter;
        private readonly PerformanceCounter _diskCounter;

        public SistemaService()
        {
            _cpuCounter = new PerformanceCounter(
                "Processor",
                "% Processor Time",
                "_Total"
            );

            _ramCounter = new PerformanceCounter(
                "Memory",
                "% Committed Bytes In Use"
            );

            _diskCounter = new PerformanceCounter(
                "PhysicalDisk",
                "% Disk Time",
                "_Total"
            );

            // Primeiras leituras necessárias para inicializar os contadores
            _cpuCounter.NextValue();
            _ramCounter.NextValue();
            _diskCounter.NextValue();
        }

        public InformacoesSistema ObterInformacoes()
        {
            var disco = ObterInformacoesDisco();
            var gpu = ObterGpu();

            return new InformacoesSistema
            {
                CpuUso = ObterCpu(),
                RamUso = ObterRam(),
                RamTotalGB = ObterRamTotal(),
                RamDisponivelGB = ObterRamDisponivel(),

                DiscoUso = ObterDiscoAtividade(),
                DiscoTotalGB = disco.TotalGB,
                DiscoDisponivelGB = disco.DisponivelGB,

                GpuNome = gpu
            };
        }

        private double ObterCpu()
        {
            return Math.Round(
                Math.Clamp(_cpuCounter.NextValue(), 0, 100),
                1
            );
        }

        private double ObterRam()
        {
            return Math.Round(
                Math.Clamp(_ramCounter.NextValue(), 0, 100),
                1
            );
        }

        private double ObterRamTotal()
        {
            using var searcher = new ManagementObjectSearcher(
                "SELECT TotalVisibleMemorySize FROM Win32_OperatingSystem"
            );

            foreach (ManagementObject obj in searcher.Get())
            {
                double totalKB = Convert.ToDouble(
                    obj["TotalVisibleMemorySize"]
                );

                return Math.Round(totalKB / 1024 / 1024, 2);
            }

            return 0;
        }

        private double ObterRamDisponivel()
        {
            using var searcher = new ManagementObjectSearcher(
                "SELECT FreePhysicalMemory FROM Win32_OperatingSystem"
            );

            foreach (ManagementObject obj in searcher.Get())
            {
                double livreKB = Convert.ToDouble(
                    obj["FreePhysicalMemory"]
                );

                return Math.Round(livreKB / 1024 / 1024, 2);
            }

            return 0;
        }

        private double ObterDiscoAtividade()
        {
            return Math.Round(
                Math.Clamp(_diskCounter.NextValue(), 0, 100),
                1
            );
        }

        private (double TotalGB, double DisponivelGB) ObterInformacoesDisco()
        {
            DriveInfo drive = new DriveInfo("C:\\");

            double totalGB =
                drive.TotalSize / 1024.0 / 1024.0 / 1024.0;

            double disponivelGB =
                drive.AvailableFreeSpace / 1024.0 / 1024.0 / 1024.0;

            return (
                Math.Round(totalGB, 2),
                Math.Round(disponivelGB, 2)
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