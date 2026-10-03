namespace WinTuner.Forms
{
    partial class FormLimpeza
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(FormLimpeza));

            SideBar = new Panel();
            pictureBox1 = new PictureBox();

            btnPainel = new ReaLTaiizor.Controls.Button();
            btnDiagnostico = new ReaLTaiizor.Controls.Button();
            btnOtimizacao = new ReaLTaiizor.Controls.Button();

            dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();

            lbl = new ReaLTaiizor.Controls.BigLabel();
            dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();

            pnlNavegacao = new Panel();

            btnArquivosTemp = new ReaLTaiizor.Controls.Button();
            btnArquivoInuteis = new ReaLTaiizor.Controls.Button();
            btnCache = new ReaLTaiizor.Controls.Button();
            btnLimpezaWin = new ReaLTaiizor.Controls.Button();

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

            // Painel de Controle
            ConfigurarBotao(
                btnPainel,
                "Painel de Controle",
                new Point(12, 165),
                new Size(196, 44)
            );

            btnPainel.Name = "btnPainel";
            btnPainel.Click += btnPainel_Click;

            // Diagnóstico
            ConfigurarBotao(
                btnDiagnostico,
                "Diagnóstico",
                new Point(12, 219),
                new Size(196, 44)
            );

            btnDiagnostico.Name = "btnDiagnostico";
            btnDiagnostico.Click += btnDiagnostico_Click;

            // Otimização
            ConfigurarBotao(
                btnOtimizacao,
                "Otimização",
                new Point(12, 273),
                new Size(196, 44)
            );

            btnOtimizacao.Name = "btnOtimizacao";
            btnOtimizacao.Click += btnOtimizacao_Click;

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
            SideBar.Controls.Add(btnOtimizacao);
            SideBar.Controls.Add(btnDiagnostico);
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
            lbl.Size = new Size(184, 42);
            lbl.TabIndex = 6;
            lbl.Text = "LIMPEZA";

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
            dungeonLabel1.Size = new Size(265, 18);
            dungeonLabel1.TabIndex = 7;
            dungeonLabel1.Text = "Limpeza e manutenção do sistema";

            // Navegação dos módulos
            pnlNavegacao.BackColor = Color.FromArgb(26, 26, 26);
            pnlNavegacao.Location = new Point(250, 105);
            pnlNavegacao.Name = "pnlNavegacao";
            pnlNavegacao.Padding = new Padding(8);
            pnlNavegacao.Size = new Size(1000, 58);
            pnlNavegacao.TabIndex = 8;

            // Arquivos temporários
            ConfigurarBotaoModulo(
                btnArquivosTemp,
                "ARQUIVOS TEMPORÁRIOS"
            );

            btnArquivosTemp.Dock = DockStyle.Left;
            btnArquivosTemp.Name = "btnArquivosTemp";
            btnArquivosTemp.Width = 230;
            btnArquivosTemp.Click += btnArquivosTemp_Click;

            // Arquivos inúteis
            ConfigurarBotaoModulo(
                btnArquivoInuteis,
                "ARQUIVOS INÚTEIS"
            );

            btnArquivoInuteis.Dock = DockStyle.Left;
            btnArquivoInuteis.Name = "btnArquivoInuteis";
            btnArquivoInuteis.Width = 190;
            btnArquivoInuteis.Click += btnArquivoInuteis_Click;

            // Navegadores e cache
            ConfigurarBotaoModulo(
                btnCache,
                "NAVEGADORES E CACHE"
            );

            btnCache.Dock = DockStyle.Left;
            btnCache.Name = "btnCache";
            btnCache.Width = 210;
            btnCache.Click += btnCache_Click;

            // Limpeza Windows
            ConfigurarBotaoModulo(
                btnLimpezaWin,
                "LIMPEZA WINDOWS"
            );

            btnLimpezaWin.Dock = DockStyle.Fill;
            btnLimpezaWin.Name = "btnLimpezaWin";
            btnLimpezaWin.Click += btnLimpezaWin_Click;

            pnlNavegacao.Controls.Add(btnLimpezaWin);
            pnlNavegacao.Controls.Add(btnCache);
            pnlNavegacao.Controls.Add(btnArquivoInuteis);
            pnlNavegacao.Controls.Add(btnArquivosTemp);

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

            // FormLimpeza
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

            Name = "FormLimpeza";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WinTuner - Limpeza";
            WindowState = FormWindowState.Maximized;

            Load += FormLimpeza_Load;

            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();

            SideBar.ResumeLayout(false);
            SideBar.PerformLayout();

            pnlNavegacao.ResumeLayout(false);

            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigurarBotao(
            ReaLTaiizor.Controls.Button botao,
            string texto,
            Point localizacao,
            Size tamanho)
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

            botao.Size = tamanho;
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

        private ReaLTaiizor.Controls.BigLabel lbl;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel1;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2;

        private ReaLTaiizor.Controls.Button btnPainel;
        private ReaLTaiizor.Controls.Button btnDiagnostico;
        private ReaLTaiizor.Controls.Button btnOtimizacao;

        private PictureBox pictureBox1;
        private Panel SideBar;

        private Panel pnlNavegacao;

        private ReaLTaiizor.Controls.Button btnArquivosTemp;
        private ReaLTaiizor.Controls.Button btnArquivoInuteis;
        private ReaLTaiizor.Controls.Button btnCache;
        private ReaLTaiizor.Controls.Button btnLimpezaWin;

        private ReaLTaiizor.Controls.Panel pnlConteudo;
    }
}