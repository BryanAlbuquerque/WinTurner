namespace WinTurner.Models
{
    public class ProcessoInfo
    {
        public string Nome { get; set; } = string.Empty;
        public int Id { get; set; }
        public string Janela { get; set; } = string.Empty;
        public double MemoriaMB { get; set; }
    }
}