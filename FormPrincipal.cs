using WinTuner.Forms;

namespace WinTuner
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

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
    }
}
