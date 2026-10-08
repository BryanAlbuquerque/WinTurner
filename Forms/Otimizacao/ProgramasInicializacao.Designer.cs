
namespace WinTuner.Forms
{
    partial class ProgramasInicializacao
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlCabecalho;
        private System.Windows.Forms.Panel pnlAcoes;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblResumo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dgvProgramas;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnAtivar;
        private System.Windows.Forms.Button btnDesativar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlPrincipal = new System.Windows.Forms.Panel();
            pnlCabecalho = new System.Windows.Forms.Panel();
            pnlAcoes = new System.Windows.Forms.Panel();
            lblTitulo = new System.Windows.Forms.Label();
            lblSubtitulo = new System.Windows.Forms.Label();
            lblResumo = new System.Windows.Forms.Label();
            lblStatus = new System.Windows.Forms.Label();
            dgvProgramas = new System.Windows.Forms.DataGridView();
            btnAtualizar = new System.Windows.Forms.Button();
            btnAtivar = new System.Windows.Forms.Button();
            btnDesativar = new System.Windows.Forms.Button();

            pnlPrincipal.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            pnlAcoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProgramas).BeginInit();
            SuspendLayout();

            // FORMULÁRIO
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            ClientSize = new System.Drawing.Size(1000, 620);
            MinimumSize = new System.Drawing.Size(800, 450);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Programas de Inicialização";

            // PRINCIPAL
            pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlPrincipal.Padding = new System.Windows.Forms.Padding(20);
            pnlPrincipal.BackColor = BackColor;

            // CABEÇALHO
            pnlCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            pnlCabecalho.Height = 85;
            pnlCabecalho.BackColor = BackColor;

            lblTitulo.Text = "Programas de inicialização";
            lblTitulo.Font = new System.Drawing.Font(
                "Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(0, 0);
            lblTitulo.AutoSize = true;

            lblSubtitulo.Text =
                "Consulte os aplicativos configurados para iniciar com o Windows.";
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = System.Drawing.Color.Silver;
            lblSubtitulo.Location = new System.Drawing.Point(2, 42);
            lblSubtitulo.AutoSize = true;

            pnlCabecalho.Controls.Add(lblTitulo);
            pnlCabecalho.Controls.Add(lblSubtitulo);

            // AÇÕES
            pnlAcoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlAcoes.Height = 85;
            pnlAcoes.BackColor = BackColor;

            ConfigurarBotao(btnAtualizar, "Atualizar", 0, 10, 110);
            ConfigurarBotao(btnAtivar, "Ativar", 120, 10, 100);
            ConfigurarBotao(btnDesativar, "Desativar", 230, 10, 110);

            pnlAcoes.Controls.Add(btnAtualizar);
            pnlAcoes.Controls.Add(btnAtivar);
            pnlAcoes.Controls.Add(btnDesativar);

            // RESUMO
            lblResumo.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblResumo.Height = 25;
            lblResumo.ForeColor = System.Drawing.Color.Gainsboro;
            lblResumo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblResumo.Font = new System.Drawing.Font("Segoe UI", 9F);

            lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblStatus.Height = 23;
            lblStatus.ForeColor = System.Drawing.Color.Gray;
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 8F);

            // GRADE CLARA
            dgvProgramas.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvProgramas.BackgroundColor = System.Drawing.Color.White;
            dgvProgramas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dgvProgramas.GridColor = System.Drawing.Color.FromArgb(225, 225, 225);
            dgvProgramas.EnableHeadersVisualStyles = false;
            dgvProgramas.ColumnHeadersBorderStyle =
                System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dgvProgramas.CellBorderStyle =
                System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProgramas.RowHeadersVisible = false;
            dgvProgramas.AllowUserToAddRows = false;
            dgvProgramas.AllowUserToDeleteRows = false;
            dgvProgramas.AllowUserToResizeRows = false;
            dgvProgramas.ReadOnly = true;
            dgvProgramas.MultiSelect = false;
            dgvProgramas.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvProgramas.AutoGenerateColumns = false;
            dgvProgramas.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            dgvProgramas.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvProgramas.DefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(25, 25, 25);
            dgvProgramas.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(220, 235, 252);
            dgvProgramas.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.FromArgb(25, 25, 25);
            dgvProgramas.DefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F);
            dgvProgramas.DefaultCellStyle.Padding =
                new System.Windows.Forms.Padding(5, 3, 5, 3);

            dgvProgramas.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.White;
            dgvProgramas.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(50, 50, 50);
            dgvProgramas.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F);
            dgvProgramas.ColumnHeadersHeight = 34;
            dgvProgramas.RowTemplate.Height = 35;

            pnlPrincipal.Controls.Add(dgvProgramas);
            pnlPrincipal.Controls.Add(lblStatus);
            pnlPrincipal.Controls.Add(lblResumo);
            pnlPrincipal.Controls.Add(pnlAcoes);
            pnlPrincipal.Controls.Add(pnlCabecalho);

            Controls.Add(pnlPrincipal);

            pnlPrincipal.ResumeLayout(false);
            pnlCabecalho.ResumeLayout(false);
            pnlCabecalho.PerformLayout();
            pnlAcoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProgramas).EndInit();
            ResumeLayout(false);
        }

        #region CONFIGURAR BOTÃO

        private void ConfigurarBotao(
            System.Windows.Forms.Button botao,
            string texto,
            int x,
            int y,
            int largura)
        {
            botao.Text = texto;
            botao.Location = new System.Drawing.Point(x, y);
            botao.Size = new System.Drawing.Size(largura, 36);
            botao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            botao.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(70, 70, 70);
            botao.BackColor = System.Drawing.Color.FromArgb(35, 35, 35);
            botao.ForeColor = System.Drawing.Color.White;
            botao.Font = new System.Drawing.Font("Segoe UI", 9F);
            botao.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        #endregion
    }
}