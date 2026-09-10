using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinTuner.Forms
{
    public partial class FormLimpeza : Form
    {
        public FormLimpeza()
        {
            InitializeComponent();
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
    }
}
