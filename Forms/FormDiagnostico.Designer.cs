namespace WinTuner.Forms
{
    partial class FormDiagnostico
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDiagnostico));
            SideBar = new Panel();
            dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();
            btnHistorico = new ReaLTaiizor.Controls.Button();
            btnOtimizacao = new ReaLTaiizor.Controls.Button();
            btnLimpeza = new ReaLTaiizor.Controls.Button();
            btnPainel = new ReaLTaiizor.Controls.Button();
            pictureBox1 = new PictureBox();
            lbl = new ReaLTaiizor.Controls.BigLabel();
            dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
            pnlNavegacao = new Panel();
            btnRede = new ReaLTaiizor.Controls.Button();
            btnIntegridade = new ReaLTaiizor.Controls.Button();
            btnVerificarDisco = new ReaLTaiizor.Controls.Button();
            btntnInfoComputador = new ReaLTaiizor.Controls.Button();
            pnlConteudo = new ReaLTaiizor.Controls.Panel();
            SideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlNavegacao.SuspendLayout();
            SuspendLayout();
            // 
            // SideBar
            // 
            SideBar.BackColor = Color.FromArgb(5, 5, 5);
            SideBar.Controls.Add(dungeonLabel2);
            SideBar.Controls.Add(btnHistorico);
            SideBar.Controls.Add(btnOtimizacao);
            SideBar.Controls.Add(btnLimpeza);
            SideBar.Controls.Add(btnPainel);
            SideBar.Controls.Add(pictureBox1);
            SideBar.Dock = DockStyle.Left;
            SideBar.Location = new Point(0, 0);
            SideBar.Name = "SideBar";
            SideBar.Size = new Size(220, 700);
            SideBar.TabIndex = 0;
            // 
            // dungeonLabel2
            // 
            dungeonLabel2.AutoSize = true;
            dungeonLabel2.BackColor = Color.Transparent;
            dungeonLabel2.Dock = DockStyle.Bottom;
            dungeonLabel2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            dungeonLabel2.ForeColor = Color.FromArgb(0, 200, 80);
            dungeonLabel2.Location = new Point(0, 685);
            dungeonLabel2.Name = "dungeonLabel2";
            dungeonLabel2.Padding = new Padding(12, 0, 0, 0);
            dungeonLabel2.Size = new Size(189, 15);
            dungeonLabel2.TabIndex = 5;
            dungeonLabel2.Text = "● SISTEMA OPERACIONAL";
            // 
            // btnHistorico
            // 
            btnHistorico.BackColor = Color.Transparent;
            btnHistorico.BorderColor = Color.FromArgb(32, 34, 37);
            btnHistorico.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnHistorico.EnteredColor = Color.FromArgb(32, 34, 37);
            btnHistorico.Font = new Font("Microsoft Sans Serif", 12F);
            btnHistorico.Image = null;
            btnHistorico.ImageAlign = ContentAlignment.MiddleLeft;
            btnHistorico.InactiveColor = Color.FromArgb(32, 34, 37);
            btnHistorico.Location = new Point(0, 0);
            btnHistorico.Name = "btnHistorico";
            btnHistorico.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnHistorico.PressedColor = Color.FromArgb(165, 37, 37);
            btnHistorico.Size = new Size(120, 40);
            btnHistorico.TabIndex = 6;
            btnHistorico.TextAlignment = StringAlignment.Center;
            btnHistorico.Click += btnHistorico_Click;
            // 
            // btnOtimizacao
            // 
            btnOtimizacao.BackColor = Color.Transparent;
            btnOtimizacao.BorderColor = Color.FromArgb(32, 34, 37);
            btnOtimizacao.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnOtimizacao.EnteredColor = Color.FromArgb(32, 34, 37);
            btnOtimizacao.Font = new Font("Microsoft Sans Serif", 12F);
            btnOtimizacao.Image = null;
            btnOtimizacao.ImageAlign = ContentAlignment.MiddleLeft;
            btnOtimizacao.InactiveColor = Color.FromArgb(32, 34, 37);
            btnOtimizacao.Location = new Point(0, 0);
            btnOtimizacao.Name = "btnOtimizacao";
            btnOtimizacao.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnOtimizacao.PressedColor = Color.FromArgb(165, 37, 37);
            btnOtimizacao.Size = new Size(120, 40);
            btnOtimizacao.TabIndex = 7;
            btnOtimizacao.TextAlignment = StringAlignment.Center;
            btnOtimizacao.Click += btnOtimizacao_Click;
            // 
            // btnLimpeza
            // 
            btnLimpeza.BackColor = Color.Transparent;
            btnLimpeza.BorderColor = Color.FromArgb(32, 34, 37);
            btnLimpeza.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnLimpeza.EnteredColor = Color.FromArgb(32, 34, 37);
            btnLimpeza.Font = new Font("Microsoft Sans Serif", 12F);
            btnLimpeza.Image = null;
            btnLimpeza.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpeza.InactiveColor = Color.FromArgb(32, 34, 37);
            btnLimpeza.Location = new Point(0, 0);
            btnLimpeza.Name = "btnLimpeza";
            btnLimpeza.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnLimpeza.PressedColor = Color.FromArgb(165, 37, 37);
            btnLimpeza.Size = new Size(120, 40);
            btnLimpeza.TabIndex = 8;
            btnLimpeza.TextAlignment = StringAlignment.Center;
            btnLimpeza.Click += btnLimpeza_Click;
            // 
            // btnPainel
            // 
            btnPainel.BackColor = Color.Transparent;
            btnPainel.BorderColor = Color.FromArgb(32, 34, 37);
            btnPainel.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnPainel.EnteredColor = Color.FromArgb(32, 34, 37);
            btnPainel.Font = new Font("Microsoft Sans Serif", 12F);
            btnPainel.Image = null;
            btnPainel.ImageAlign = ContentAlignment.MiddleLeft;
            btnPainel.InactiveColor = Color.FromArgb(32, 34, 37);
            btnPainel.Location = new Point(0, 0);
            btnPainel.Name = "btnPainel";
            btnPainel.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnPainel.PressedColor = Color.FromArgb(165, 37, 37);
            btnPainel.Size = new Size(120, 40);
            btnPainel.TabIndex = 9;
            btnPainel.TextAlignment = StringAlignment.Center;
            btnPainel.Click += btnPainel_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(10, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 125);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.BackColor = Color.Transparent;
            lbl.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(242, 242, 242);
            lbl.Location = new Point(250, 22);
            lbl.Name = "lbl";
            lbl.Size = new Size(288, 42);
            lbl.TabIndex = 6;
            lbl.Text = "DIAGNÓSTICO";
            // 
            // dungeonLabel1
            // 
            dungeonLabel1.AutoSize = true;
            dungeonLabel1.BackColor = Color.Transparent;
            dungeonLabel1.Font = new Font("Microsoft Sans Serif", 11F);
            dungeonLabel1.ForeColor = Color.FromArgb(145, 145, 145);
            dungeonLabel1.Location = new Point(254, 68);
            dungeonLabel1.Name = "dungeonLabel1";
            dungeonLabel1.Size = new Size(248, 18);
            dungeonLabel1.TabIndex = 7;
            dungeonLabel1.Text = "Verificação e análise do computador";
            // 
            // pnlNavegacao
            // 
            pnlNavegacao.BackColor = Color.FromArgb(26, 26, 26);
            pnlNavegacao.Controls.Add(btnRede);
            pnlNavegacao.Controls.Add(btnIntegridade);
            pnlNavegacao.Controls.Add(btnVerificarDisco);
            pnlNavegacao.Controls.Add(btntnInfoComputador);
            pnlNavegacao.Location = new Point(250, 105);
            pnlNavegacao.Name = "pnlNavegacao";
            pnlNavegacao.Padding = new Padding(8);
            pnlNavegacao.Size = new Size(1000, 58);
            pnlNavegacao.TabIndex = 8;
            // 
            // btnRede
            // 
            btnRede.BackColor = Color.Transparent;
            btnRede.BorderColor = Color.FromArgb(32, 34, 37);
            btnRede.Dock = DockStyle.Fill;
            btnRede.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnRede.EnteredColor = Color.FromArgb(32, 34, 37);
            btnRede.Font = new Font("Microsoft Sans Serif", 12F);
            btnRede.Image = null;
            btnRede.ImageAlign = ContentAlignment.MiddleLeft;
            btnRede.InactiveColor = Color.FromArgb(32, 34, 37);
            btnRede.Location = new Point(638, 8);
            btnRede.Name = "btnRede";
            btnRede.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnRede.PressedColor = Color.FromArgb(165, 37, 37);
            btnRede.Size = new Size(354, 42);
            btnRede.TabIndex = 0;
            btnRede.TextAlignment = StringAlignment.Center;
            btnRede.Click += btnRede_Click;
            // 
            // btnIntegridade
            // 
            btnIntegridade.BackColor = Color.Transparent;
            btnIntegridade.BorderColor = Color.FromArgb(32, 34, 37);
            btnIntegridade.Dock = DockStyle.Left;
            btnIntegridade.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnIntegridade.EnteredColor = Color.FromArgb(32, 34, 37);
            btnIntegridade.Font = new Font("Microsoft Sans Serif", 12F);
            btnIntegridade.Image = null;
            btnIntegridade.ImageAlign = ContentAlignment.MiddleLeft;
            btnIntegridade.InactiveColor = Color.FromArgb(32, 34, 37);
            btnIntegridade.Location = new Point(418, 8);
            btnIntegridade.Margin = new Padding(0, 0, 8, 0);
            btnIntegridade.Name = "btnIntegridade";
            btnIntegridade.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnIntegridade.PressedColor = Color.FromArgb(165, 37, 37);
            btnIntegridade.Size = new Size(220, 42);
            btnIntegridade.TabIndex = 1;
            btnIntegridade.TextAlignment = StringAlignment.Center;
            btnIntegridade.Click += btnIntegridade_Click;
            // 
            // btnVerificarDisco
            // 
            btnVerificarDisco.BackColor = Color.Transparent;
            btnVerificarDisco.BorderColor = Color.FromArgb(32, 34, 37);
            btnVerificarDisco.Dock = DockStyle.Left;
            btnVerificarDisco.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnVerificarDisco.EnteredColor = Color.FromArgb(32, 34, 37);
            btnVerificarDisco.Font = new Font("Microsoft Sans Serif", 12F);
            btnVerificarDisco.Image = null;
            btnVerificarDisco.ImageAlign = ContentAlignment.MiddleLeft;
            btnVerificarDisco.InactiveColor = Color.FromArgb(32, 34, 37);
            btnVerificarDisco.Location = new Point(228, 8);
            btnVerificarDisco.Margin = new Padding(0, 0, 8, 0);
            btnVerificarDisco.Name = "btnVerificarDisco";
            btnVerificarDisco.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnVerificarDisco.PressedColor = Color.FromArgb(165, 37, 37);
            btnVerificarDisco.Size = new Size(190, 42);
            btnVerificarDisco.TabIndex = 2;
            btnVerificarDisco.TextAlignment = StringAlignment.Center;
            btnVerificarDisco.Click += btnVerificarDisco_Click;
            // 
            // btntnInfoComputador
            // 
            btntnInfoComputador.BackColor = Color.Transparent;
            btntnInfoComputador.BorderColor = Color.FromArgb(32, 34, 37);
            btntnInfoComputador.Dock = DockStyle.Left;
            btntnInfoComputador.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btntnInfoComputador.EnteredColor = Color.FromArgb(32, 34, 37);
            btntnInfoComputador.Font = new Font("Microsoft Sans Serif", 12F);
            btntnInfoComputador.Image = null;
            btntnInfoComputador.ImageAlign = ContentAlignment.MiddleLeft;
            btntnInfoComputador.InactiveColor = Color.FromArgb(32, 34, 37);
            btntnInfoComputador.Location = new Point(8, 8);
            btntnInfoComputador.Margin = new Padding(0, 0, 8, 0);
            btntnInfoComputador.Name = "btntnInfoComputador";
            btntnInfoComputador.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btntnInfoComputador.PressedColor = Color.FromArgb(165, 37, 37);
            btntnInfoComputador.Size = new Size(220, 42);
            btntnInfoComputador.TabIndex = 3;
            btntnInfoComputador.TextAlignment = StringAlignment.Center;
            btntnInfoComputador.Click += btntnInfoComputador_Click;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlConteudo.BackColor = Color.FromArgb(15, 15, 15);
            pnlConteudo.EdgeColor = Color.FromArgb(58, 58, 58);
            pnlConteudo.Location = new Point(250, 178);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Padding = new Padding(8);
            pnlConteudo.Size = new Size(1000, 490);
            pnlConteudo.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pnlConteudo.TabIndex = 9;
            pnlConteudo.Text = "pnlConteudo";
            // 
            // FormDiagnostico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(1280, 700);
            Controls.Add(pnlConteudo);
            Controls.Add(pnlNavegacao);
            Controls.Add(dungeonLabel1);
            Controls.Add(lbl);
            Controls.Add(SideBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1100, 650);
            Name = "FormDiagnostico";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WinTuner - Diagnóstico";
            WindowState = FormWindowState.Maximized;
            Load += FormDiagnostico_Load;
            SideBar.ResumeLayout(false);
            SideBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlNavegacao.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigurarBotaoSidebar(
            ReaLTaiizor.Controls.Button botao,
            string texto,
            Point localizacao)
        {
            botao.BackColor = Color.FromArgb(5, 5, 5);
            botao.BorderColor = Color.FromArgb(5, 5, 5);
            botao.Cursor = Cursors.Hand;

            botao.EnteredBorderColor = Color.FromArgb(224, 0, 0);
            botao.EnteredColor = Color.FromArgb(30, 30, 30);

            botao.Font = new Font(
                "Microsoft Sans Serif",
                11F,
                FontStyle.Bold
            );

            botao.Image = null;
            botao.ImageAlign = ContentAlignment.MiddleLeft;
            botao.InactiveColor = Color.FromArgb(5, 5, 5);

            botao.Location = localizacao;

            botao.PressedBorderColor = Color.FromArgb(176, 0, 0);
            botao.PressedColor = Color.FromArgb(176, 0, 0);

            botao.Size = new Size(196, 44);
            botao.TabIndex = 0;
            botao.Text = texto;
            botao.TextAlignment = StringAlignment.Center;
        }

        private void ConfigurarBotaoModulo(
            ReaLTaiizor.Controls.Button botao,
            string texto)
        {
            botao.BackColor = Color.FromArgb(26, 26, 26);
            botao.BorderColor = Color.FromArgb(58, 58, 58);
            botao.Cursor = Cursors.Hand;

            botao.EnteredBorderColor = Color.FromArgb(208, 0, 0);
            botao.EnteredColor = Color.FromArgb(32, 32, 32);

            botao.Font = new Font(
                "Microsoft Sans Serif",
                9.5F,
                FontStyle.Bold
            );

            botao.Image = null;
            botao.ImageAlign = ContentAlignment.MiddleLeft;
            botao.InactiveColor = Color.FromArgb(26, 26, 26);

            botao.PressedBorderColor = Color.FromArgb(176, 0, 0);
            botao.PressedColor = Color.FromArgb(176, 0, 0);

            botao.Text = texto;
            botao.TextAlignment = StringAlignment.Center;
        }

        #endregion

        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel1;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2;

        private ReaLTaiizor.Controls.Button btnHistorico;
        private ReaLTaiizor.Controls.Button btnOtimizacao;
        private ReaLTaiizor.Controls.Button btnLimpeza;
        private ReaLTaiizor.Controls.Button btnPainel;

        private PictureBox pictureBox1;
        private Panel SideBar;

        private ReaLTaiizor.Controls.BigLabel lbl;

        private Panel pnlNavegacao;

        private ReaLTaiizor.Controls.Button btntnInfoComputador;
        private ReaLTaiizor.Controls.Button btnVerificarDisco;
        private ReaLTaiizor.Controls.Button btnIntegridade;
        private ReaLTaiizor.Controls.Button btnRede;

        private ReaLTaiizor.Controls.Panel pnlConteudo;
    }
}