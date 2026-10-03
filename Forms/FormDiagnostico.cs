using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinTuner.Forms.Diagnostico;
using WinTuner.Services;

namespace WinTuner.Forms
{
    public partial class FormDiagnostico : Form
    {
        private Form? _formAtual;
        public FormDiagnostico()
        {
            InitializeComponent();
            AparenciaWindowsService.AplicarBarraEscura(this);
        }

        #region Botões de navegação SIDE BAR

        private void btnPainel_Click(object sender, EventArgs e)
        {
            FormPrincipal formPrincipal = new FormPrincipal();
            formPrincipal.Show();
            this.Hide();
        }

        private void btnLimpeza_Click(object sender, EventArgs e)
        {
            FormLimpeza formLimpeza = new FormLimpeza();
            formLimpeza.Show();
            this.Hide();
        }


        private void btnOtimizacao_Click(object sender, EventArgs e)
        {
            FormOtimizacao formOtimizacao = new FormOtimizacao();
            formOtimizacao.Show();
            this.Hide();

        }


        #endregion

        #region Botões de navegação TOP BAR

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

        private void FormDiagnostico_Load(object sender, EventArgs e)
        {
            AbrirFormulario(new SysInfo());
        }

        private void btntnInfoComputador_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new SysInfo());
        }

        private void btnVerificarDisco_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new VerificarDisco());
        }

        private void btnIntegridade_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new IntegridadeWindows());
        }

        private void btnRede_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new DiagnosticoRede());
        }

        #endregion


    }
}
