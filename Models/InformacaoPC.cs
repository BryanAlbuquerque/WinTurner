namespace WinTuner.Models
{
    public class InformacaoPC
    {
        // Windows
        public string NomeWindows { get; set; } = string.Empty;
        public string Versao { get; set; } = string.Empty;
        public string Build { get; set; } = string.Empty;
        public string Arquitetura { get; set; } = string.Empty;
        public string Computador { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public string DiretorioWindows { get; set; } = string.Empty;
        public string DiretorioSistema { get; set; } = string.Empty;

        // Processador
        public string Processador { get; set; } = string.Empty;

        // Placa de vídeo
        public string PlacaDeVideoNome { get; set; } = string.Empty;
        public string PlacaDeVideoModelo { get; set; } = string.Empty;
        public string PlacaDeVideoMemoria { get; set; } = string.Empty;

        // Armazenamento
        public string ArmazenamentoTotal { get; set; } = string.Empty;
        public string ArmazenamentoDisponivel { get; set; } = string.Empty;

        // Placa-mãe
        public string PlacaMaeNome { get; set; } = string.Empty;
        public string PlacaMaeModelo { get; set; } = string.Empty;

        // Memória RAM
        public string MemoriaFisica { get; set; } = string.Empty;
        public string MemoriaFisicaTotal { get; set; } = string.Empty;
        public string MemoriaFisicaDisponivel { get; set; } = string.Empty;

        // Memória virtual
        public string MemoriaVirtualTotal { get; set; } = string.Empty;
        public string MemoriaVirtualDisponivel { get; set; } = string.Empty;
    }
}