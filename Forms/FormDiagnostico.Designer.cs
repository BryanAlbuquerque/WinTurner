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
            pictureBox1 = new PictureBox();

            btnPainel = new ReaLTaiizor.Controls.Button();
            btnLimpeza = new ReaLTaiizor.Controls.Button();
            btnOtimizacao = new ReaLTaiizor.Controls.Button();
            btnHistorico = new ReaLTaiizor.Controls.Button();

            dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();

            lbl = new ReaLTaiizor.Controls.BigLabel();
            dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();

            pnlNavegacao = new Panel();

            btntnInfoComputador = new ReaLTaiizor.Controls.Button();
            btnVerificarDisco = new ReaLTaiizor.Controls.Button();
            btnIntegridade = new ReaLTaiizor.Controls.Button();
            btnRede = new ReaLTaiizor.Controls.Button();

            pnlConteudo = new ReaLTaiizor.Controls.Panel();

            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SideBar.SuspendLayout();
            pnlNavegacao.SuspendLayout();
            SuspendLayout();

            // SideBar
            SideBar.BackColor = Color.FromArgb(5, 5, 5);
            SideBar.Dock = DockStyle.Left;
            SideBar.Name = "SideBar";
            SideBar.Size = new Size(220, 700);
            SideBar.TabIndex = 0;

            // Logo
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(10, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 125);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;

            // Painel
            ConfigurarBotaoSidebar(
                btnPainel,
                "Painel de Controle",
                new Point(12, 165)
            );
            btnPainel.Name = "btnPainel";
            btnPainel.Click += btnPainel_Click;

            // Limpeza
            ConfigurarBotaoSidebar(
                btnLimpeza,
                "Limpeza",
                new Point(12, 219)
            );
            btnLimpeza.Name = "btnLimpeza";
            btnLimpeza.Click += btnLimpeza_Click;

            // Otimização
            ConfigurarBotaoSidebar(
                btnOtimizacao,
                "Otimização",
                new Point(12, 273)
            );
            btnOtimizacao.Name = "btnOtimizacao";
            btnOtimizacao.Click += btnOtimizacao_Click;

            // Histórico
            ConfigurarBotaoSidebar(
                btnHistorico,
                "Histórico",
                new Point(12, 327)
            );
            btnHistorico.Name = "btnHistorico";
            btnHistorico.Click += btnHistorico_Click;

            // Status
            dungeonLabel2.AutoSize = true;
            dungeonLabel2.BackColor = Color.Transparent;
            dungeonLabel2.Dock = DockStyle.Bottom;
            dungeonLabel2.Font = new Font(
                "Microsoft Sans Serif",
                9F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            dungeonLabel2.ForeColor = Color.FromArgb(0, 200, 80);
            dungeonLabel2.Location = new Point(0, 685);
            dungeonLabel2.Name = "dungeonLabel2";
            dungeonLabel2.Padding = new Padding(12, 0, 0, 0);
            dungeonLabel2.Size = new Size(220, 15);
            dungeonLabel2.TabIndex = 5;
            dungeonLabel2.Text = "● SISTEMA OPERACIONAL";

            SideBar.Controls.Add(dungeonLabel2);
            SideBar.Controls.Add(btnHistorico);
            SideBar.Controls.Add(btnOtimizacao);
            SideBar.Controls.Add(btnLimpeza);
            SideBar.Controls.Add(btnPainel);
            SideBar.Controls.Add(pictureBox1);

            // Título
            lbl.AutoSize = true;
            lbl.BackColor = Color.Transparent;
            lbl.Font = new Font(
                "Microsoft Sans Serif",
                27.75F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lbl.ForeColor = Color.FromArgb(242, 242, 242);
            lbl.Location = new Point(250, 22);
            lbl.Name = "lbl";
            lbl.Size = new Size(299, 42);
            lbl.TabIndex = 6;
            lbl.Text = "DIAGNÓSTICO";

            // Subtítulo
            dungeonLabel1.AutoSize = true;
            dungeonLabel1.BackColor = Color.Transparent;
            dungeonLabel1.Font = new Font(
                "Microsoft Sans Serif",
                11F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            dungeonLabel1.ForeColor = Color.FromArgb(145, 145, 145);
            dungeonLabel1.Location = new Point(254, 68);
            dungeonLabel1.Name = "dungeonLabel1";
            dungeonLabel1.Size = new Size(276, 18);
            dungeonLabel1.TabIndex = 7;
            dungeonLabel1.Text = "Verificação e análise do computador";

            // Barra de navegação
            pnlNavegacao.BackColor = Color.FromArgb(26, 26, 26);
            pnlNavegacao.Location = new Point(250, 105);
            pnlNavegacao.Name = "pnlNavegacao";
            pnlNavegacao.Padding = new Padding(8);
            pnlNavegacao.Size = new Size(1000, 58);
            pnlNavegacao.TabIndex = 8;

            // Informações do computador
            ConfigurarBotaoModulo(
                btntnInfoComputador,
                "INFO COMPUTADOR"
            );
            btntnInfoComputador.Dock = DockStyle.Left;
            btntnInfoComputador.Margin = new Padding(0, 0, 8, 0);
            btntnInfoComputador.Name = "btntnInfoComputador";
            btntnInfoComputador.Width = 220;
            btntnInfoComputador.Click += btntnInfoComputador_Click;

            // Verificação do disco
            ConfigurarBotaoModulo(
                btnVerificarDisco,
                "VERIFICAR DISCO"
            );
            btnVerificarDisco.Dock = DockStyle.Left;
            btnVerificarDisco.Margin = new Padding(0, 0, 8, 0);
            btnVerificarDisco.Name = "btnVerificarDisco";
            btnVerificarDisco.Width = 190;
            btnVerificarDisco.Click += btnVerificarDisco_Click;

            // Integridade
            ConfigurarBotaoModulo(
                btnIntegridade,
                "INTEGRIDADE WINDOWS"
            );
            btnIntegridade.Dock = DockStyle.Left;
            btnIntegridade.Margin = new Padding(0, 0, 8, 0);
            btnIntegridade.Name = "btnIntegridade";
            btnIntegridade.Width = 220;
            btnIntegridade.Click += btnIntegridade_Click;

            // Rede
            ConfigurarBotaoModulo(
                btnRede,
                "REDE"
            );
            btnRede.Dock = DockStyle.Fill;
            btnRede.Name = "btnRede";
            btnRede.Click += btnRede_Click;

            pnlNavegacao.Controls.Add(btnRede);
            pnlNavegacao.Controls.Add(btnIntegridade);
            pnlNavegacao.Controls.Add(btnVerificarDisco);
            pnlNavegacao.Controls.Add(btntnInfoComputador);

            // Área de conteúdo
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

            // FormDiagnostico
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

            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            SideBar.ResumeLayout(false);
            SideBar.PerformLayout();
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