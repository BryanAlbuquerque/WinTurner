using WinTuner.Forms.Limpeza;

namespace WinTuner.Forms
{
    public partial class FormLimpeza : Form
    {
        private Form? _formAtual;
        public FormLimpeza()
        {
            InitializeComponent();


        }

        #region Botões de Navegação SIDE BAR
        private void btnPainel_Click(object sender, EventArgs e)
        {
            FormPrincipal formPrincipal = new FormPrincipal();
            formPrincipal.Show();
            this.Hide();
        }

        private void btnDiagnostico_Click(object sender, EventArgs e)
        {
            FormDiagnostico formDiagnostico = new FormDiagnostico();
            formDiagnostico.Show();
            this.Hide();
        }

        private void btnOtimizacao_Click(object sender, EventArgs e)
        {
            FormOtimizacao formOtimizacao = new FormOtimizacao();
            formOtimizacao.Show();
            this.Hide();
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            FormHistorico formHistorico = new FormHistorico();
            formHistorico.Show();
            this.Hide();
        }
        #endregion


        #region Botões de Navegação TOP BAR
        private void AbrirFormulario(Form formulario)
        {
            if (_formAtual != null)
            {
                _formAtual.Close();
                _formAtual.Dispose();
            }

            _formAtual = formulario;

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            pnlConteudo.Controls.Clear();
            pnlConteudo.Controls.Add(formulario);

            formulario.Show();
        }

        private void btnArquivosTemp_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ArquivosTemp());
        }

        private void btnArquivoInuteis_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ArquivosInuteis());
        }

        private void btnCache_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Cache());
        }

        private void btnLimpezaWin_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new LimpezaWin());
        }
        #endregion

    }
}
