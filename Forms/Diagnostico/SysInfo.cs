using WinTuner.Models;
using WinTuner.Services.Diagnosticos;

namespace WinTuner.Forms.Diagnostico
{
    public partial class SysInfo : Form
    {
        private readonly InformacoesPCService _informacoesPCService;
        public SysInfo()
        {
            InitializeComponent();

            _informacoesPCService = new InformacoesPCService();

            CarregarInformacoesPC();
        }

        private void CarregarInformacoesPC()
        {
            InformacaoPC informacoes = _informacoesPCService.ObterInformacoes();

            // Sistema operacional
            lblTipoSistema.Text = informacoes.NomeWindows;
            lblDadosVersao.Text = informacoes.Versao;
            lblDadosBuild.Text = informacoes.Build;
            lblDadosArquitetura.Text = informacoes.Arquitetura;

            // Processador
            lblDadosProcessador.Text = informacoes.Processador;

            // Placa de vídeo
            lblDadosFabricante.Text = informacoes.PlacaDeVideoNome;
            lblDadosModelo.Text = informacoes.PlacaDeVideoModelo;
            lblDadosMemoriaDedicada.Text = informacoes.PlacaDeVideoMemoria;

            // Memória RAM
            lblDadosMemoria.Text = informacoes.MemoriaFisicaTotal;
            lblDadosMemoriaUtilizada.Text = informacoes.MemoriaFisica;
            lblDadosMemoriaDisponivel.Text = informacoes.MemoriaFisicaDisponivel;

            // Placa-mãe
            lblDadosPlacaMae.Text = informacoes.PlacaMaeNome;
            lblDadosPlaca.Text = informacoes.PlacaMaeModelo;

            // Armazenamento
            lblArmazenamentoTotal.Text = informacoes.ArmazenamentoTotal;
            lblArmazenamentoDisponivel.Text = informacoes.ArmazenamentoDisponivel;

            // Memória virtual
            lblDadosMemoriaVirtual.Text = informacoes.MemoriaVirtualTotal;
            lblMemoriVirtualDisponivel.Text = informacoes.MemoriaVirtualDisponivel;
        }
    }
}
