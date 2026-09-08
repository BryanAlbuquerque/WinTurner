using WinTuner.Forms;
using WinTurner.Services;

namespace WinTuner
{
    public partial class FormPrincipal : Form
    {
        private readonly SistemaService _sistemaService;


        public FormPrincipal()
        {
            InitializeComponent();
            _sistemaService = new SistemaService();
        }

        #region Botões SideBar
        private void btnDiagnostico_Click(object sender, EventArgs e)
        {
            FormDiagnostico formDiagnostico = new FormDiagnostico();
            formDiagnostico.ShowDialog();
        }

        private void btnLimpeza_Click(object sender, EventArgs e)
        {
            FormLimpeza formLimpeza = new FormLimpeza();
            formLimpeza.ShowDialog();
        }

        private void btnOtimizacao_Click(object sender, EventArgs e)
        {
            FormOtimizacao formOtimizacao = new FormOtimizacao();
            formOtimizacao.ShowDialog();
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            FormHistorico formHistorico = new FormHistorico();
            formHistorico.ShowDialog();
        }

        #endregion

        private void timerSistema_Tick(object sender, EventArgs e)
        {
            AtualizarInformacoesSistema();
        }
        private void AtualizarInformacoesSistema()
        {
            var dados = _sistemaService.ObterInformacoes();

            lblCPU.Text = $"{dados.CpuUso:0}%";
            lblRAM.Text = $"{dados.RamUso:0}%";
            lblDISCO.Text = $"{dados.DiscoUso:0}%";
            lblGPU.Text = dados.GpuNome;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            AtualizarInformacoesSistema();
        }
    }
}
