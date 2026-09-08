namespace WinTurner.Models
{
    public class InformacoesSistema
    {
        public double CpuUso { get; set; }

        public double RamUso { get; set; }
        public double RamTotalGB { get; set; }
        public double RamDisponivelGB { get; set; }

        public double DiscoUso { get; set; }
        public double DiscoTotalGB { get; set; }
        public double DiscoDisponivelGB { get; set; }

        public string GpuNome { get; set; } = string.Empty;
    }
}