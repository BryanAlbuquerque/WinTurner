using WinTuner.Forms.Otimizacao;
using WinTuner.Services;

namespace WinTuner.Forms
{
    public partial class FormOtimizacao : Form
    {

        private Form _formAtual;
        public FormOtimizacao()
        {
            InitializeComponent();
            AparenciaWindowsService.AplicarBarraEscura(this);
        }

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

        private void btnLimpeza_Click(object sender, EventArgs e)
        {
            FormLimpeza formLimpeza = new FormLimpeza();
            formLimpeza.Show();
            this.Hide();
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            FormHistorico formHistorico = new FormHistorico();
            formHistorico.Show();
            this.Hide();
        }

        private void FormOtimizacao_Load(object sender, EventArgs e)
        {
            // Vai chamar panel com uma inicialização de otimização
        }


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

        #region Botões TOP BAR
        private void btnDebloat_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Debloat());
        }

        private void btnEfeitos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new EfeitosVisuais());
        }

        private void btnInicializacao_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ProgramasInicializacao());
        }

        private void btnServicos_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new ServicosWindows());
        }

        private void btnEnergia_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new PlanoEnergia());
        }

        #endregion
    }
}
