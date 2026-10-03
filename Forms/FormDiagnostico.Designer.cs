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
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(FormDiagnostico));

            SideBar = new Panel();

            dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();

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
            dungeonLabel2.Font = new Font(
                "Microsoft Sans Serif",
                9F,
                FontStyle.Bold
            );
            dungeonLabel2.ForeColor = Color.FromArgb(0, 200, 80);
            dungeonLabel2.Location = new Point(0, 685);
            dungeonLabel2.Name = "dungeonLabel2";
            dungeonLabel2.Padding = new Padding(12, 0, 0, 0);
            dungeonLabel2.Size = new Size(220, 15);
            dungeonLabel2.TabIndex = 5;
            dungeonLabel2.Text = "● SISTEMA OPERACIONAL";

            // 
            // btnPainel
            // 
            ConfigurarBotaoSidebar(
                btnPainel,
                "Painel de Controle",
                new Point(12, 165)
            );

            btnPainel.Name = "btnPainel";
            btnPainel.Click += btnPainel_Click;

            // 
            // btnLimpeza
            // 
            ConfigurarBotaoSidebar(
                btnLimpeza,
                "Limpeza",
                new Point(12, 219)
            );

            btnLimpeza.Name = "btnLimpeza";
            btnLimpeza.Click += btnLimpeza_Click;

            // 
            // btnOtimizacao
            // 
            ConfigurarBotaoSidebar(
                btnOtimizacao,
                "Otimização",
                new Point(12, 273)
            );

            btnOtimizacao.Name = "btnOtimizacao";
            btnOtimizacao.Click += btnOtimizacao_Click;

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
            lbl.Font = new Font(
                "Microsoft Sans Serif",
                27.75F,
                FontStyle.Bold
            );
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
            dungeonLabel1.Font = new Font(
                "Microsoft Sans Serif",
                11F
            );
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
            // btntnInfoComputador
            // 
            ConfigurarBotaoModulo(
                btntnInfoComputador,
                "INFORMAÇÕES DO COMPUTADOR"
            );

            btntnInfoComputador.Dock = DockStyle.Left;
            btntnInfoComputador.Location = new Point(8, 8);
            btntnInfoComputador.Name = "btntnInfoComputador";
            btntnInfoComputador.Size = new Size(250, 42);
            btntnInfoComputador.TabIndex = 0;
            btntnInfoComputador.Click += btntnInfoComputador_Click;

            // 
            // btnVerificarDisco
            // 
            ConfigurarBotaoModulo(
                btnVerificarDisco,
                "VERIFICAR DISCO"
            );

            btnVerificarDisco.Dock = DockStyle.Left;
            btnVerificarDisco.Location = new Point(258, 8);
            btnVerificarDisco.Name = "btnVerificarDisco";
            btnVerificarDisco.Size = new Size(190, 42);
            btnVerificarDisco.TabIndex = 1;
            btnVerificarDisco.Click += btnVerificarDisco_Click;

            // 
            // btnIntegridade
            // 
            ConfigurarBotaoModulo(
                btnIntegridade,
                "INTEGRIDADE"
            );

            btnIntegridade.Dock = DockStyle.Left;
            btnIntegridade.Location = new Point(448, 8);
            btnIntegridade.Name = "btnIntegridade";
            btnIntegridade.Size = new Size(190, 42);
            btnIntegridade.TabIndex = 2;
            btnIntegridade.Click += btnIntegridade_Click;

            // 
            // btnRede
            // 
            ConfigurarBotaoModulo(
                btnRede,
                "REDE"
            );

            btnRede.Dock = DockStyle.Fill;
            btnRede.Location = new Point(638, 8);
            btnRede.Name = "btnRede";
            btnRede.Size = new Size(354, 42);
            btnRede.TabIndex = 3;
            btnRede.Click += btnRede_Click;

            // 
            // pnlConteudo
            // 
            pnlConteudo.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlConteudo.BackColor = Color.FromArgb(15, 15, 15);
            pnlConteudo.EdgeColor = Color.FromArgb(58, 58, 58);
            pnlConteudo.Location = new Point(250, 178);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Padding = new Padding(8);
            pnlConteudo.Size = new Size(1000, 490);
            pnlConteudo.SmoothingType =
                System.Drawing.Drawing2D.SmoothingMode.HighQuality;
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