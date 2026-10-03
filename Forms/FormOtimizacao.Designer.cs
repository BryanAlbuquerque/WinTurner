namespace WinTuner.Forms
{
    partial class FormOtimizacao
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
                new System.ComponentModel.ComponentResourceManager(typeof(FormOtimizacao));

            SideBar = new Panel();

            dungeonLabel5 = new ReaLTaiizor.Controls.DungeonLabel();

            btnLimpeza = new ReaLTaiizor.Controls.Button();
            btnDiagnostico = new ReaLTaiizor.Controls.Button();
            btnPainel = new ReaLTaiizor.Controls.Button();

            pictureBox1 = new PictureBox();

            lbl = new ReaLTaiizor.Controls.BigLabel();
            dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();

            pnlNavegacao = new TableLayoutPanel();

            btnDebloat = new ReaLTaiizor.Controls.Button();
            btnEfeitos = new ReaLTaiizor.Controls.Button();
            btnInicializacao = new ReaLTaiizor.Controls.Button();
            btnServicos = new ReaLTaiizor.Controls.Button();
            btnEnergia = new ReaLTaiizor.Controls.Button();

            pnlConteudo = new ReaLTaiizor.Controls.Panel();

            dungeonLabel6 = new ReaLTaiizor.Controls.DungeonLabel();

            SideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlNavegacao.SuspendLayout();
            SuspendLayout();

            // 
            // SideBar
            // 
            SideBar.BackColor = Color.FromArgb(5, 5, 5);
            SideBar.Controls.Add(dungeonLabel5);
            SideBar.Controls.Add(btnLimpeza);
            SideBar.Controls.Add(btnDiagnostico);
            SideBar.Controls.Add(btnPainel);
            SideBar.Controls.Add(pictureBox1);
            SideBar.Dock = DockStyle.Left;
            SideBar.Location = new Point(0, 0);
            SideBar.Name = "SideBar";
            SideBar.Size = new Size(220, 700);
            SideBar.TabIndex = 0;

            // 
            // dungeonLabel5
            // 
            dungeonLabel5.AutoSize = true;
            dungeonLabel5.BackColor = Color.Transparent;
            dungeonLabel5.Dock = DockStyle.Bottom;
            dungeonLabel5.Font = new Font(
                "Microsoft Sans Serif",
                9F,
                FontStyle.Bold
            );
            dungeonLabel5.ForeColor = Color.FromArgb(0, 200, 80);
            dungeonLabel5.Location = new Point(0, 685);
            dungeonLabel5.Name = "dungeonLabel5";
            dungeonLabel5.Padding = new Padding(12, 0, 0, 0);
            dungeonLabel5.Size = new Size(220, 15);
            dungeonLabel5.TabIndex = 1;
            dungeonLabel5.Text = "● SISTEMA OPERACIONAL";

            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(10, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 125);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;

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
            // btnDiagnostico
            // 
            ConfigurarBotaoSidebar(
                btnDiagnostico,
                "Diagnóstico",
                new Point(12, 219)
            );

            btnDiagnostico.Name = "btnDiagnostico";
            btnDiagnostico.Click += btnDiagnostico_Click;

            // 
            // btnLimpeza
            // 
            ConfigurarBotaoSidebar(
                btnLimpeza,
                "Limpeza",
                new Point(12, 273)
            );

            btnLimpeza.Name = "btnLimpeza";
            btnLimpeza.Click += btnLimpeza_Click;

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
            lbl.Location = new Point(258, 22);
            lbl.Name = "lbl";
            lbl.Size = new Size(258, 42);
            lbl.TabIndex = 3;
            lbl.Text = "OTIMIZAÇÃO";

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
            dungeonLabel1.Location = new Point(262, 68);
            dungeonLabel1.Name = "dungeonLabel1";
            dungeonLabel1.Size = new Size(650, 18);
            dungeonLabel1.TabIndex = 4;
            dungeonLabel1.Text =
                "Ajuste o Windows para reduzir processos, efeitos e recursos desnecessários.";

            // 
            // dungeonLabel6
            // 
            dungeonLabel6.AutoSize = true;
            dungeonLabel6.BackColor = Color.Transparent;
            dungeonLabel6.Font = new Font(
                "Microsoft Sans Serif",
                21.75F,
                FontStyle.Bold
            );
            dungeonLabel6.ForeColor = Color.Maroon;
            dungeonLabel6.Location = new Point(0, 0);
            dungeonLabel6.Name = "dungeonLabel6";
            dungeonLabel6.Size = new Size(0, 0);
            dungeonLabel6.TabIndex = 5;
            dungeonLabel6.Text = "";
            dungeonLabel6.Visible = false;

            // 
            // pnlNavegacao
            // 
            pnlNavegacao.BackColor = Color.FromArgb(26, 26, 26);
            pnlNavegacao.ColumnCount = 5;
            pnlNavegacao.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 20F)
            );
            pnlNavegacao.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 20F)
            );
            pnlNavegacao.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 20F)
            );
            pnlNavegacao.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 20F)
            );
            pnlNavegacao.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 20F)
            );

            pnlNavegacao.Controls.Add(
                btnDebloat,
                0,
                0
            );

            pnlNavegacao.Controls.Add(
                btnEfeitos,
                1,
                0
            );

            pnlNavegacao.Controls.Add(
                btnInicializacao,
                2,
                0
            );

            pnlNavegacao.Controls.Add(
                btnServicos,
                3,
                0
            );

            pnlNavegacao.Controls.Add(
                btnEnergia,
                4,
                0
            );

            pnlNavegacao.Dock = DockStyle.None;
            pnlNavegacao.Location = new Point(250, 105);
            pnlNavegacao.Name = "pnlNavegacao";
            pnlNavegacao.Padding = new Padding(8);
            pnlNavegacao.RowCount = 1;
            pnlNavegacao.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F)
            );
            pnlNavegacao.Size = new Size(1000, 58);
            pnlNavegacao.TabIndex = 6;

            // 
            // btnDebloat
            // 
            ConfigurarBotaoModulo(
                btnDebloat,
                "DEBLOAT DO WINDOWS"
            );

            btnDebloat.Dock = DockStyle.Fill;
            btnDebloat.Margin = new Padding(3);
            btnDebloat.Name = "btnDebloat";
            btnDebloat.TabIndex = 0;
            btnDebloat.Click += btnDebloat_Click;

            // 
            // btnEfeitos
            // 
            ConfigurarBotaoModulo(
                btnEfeitos,
                "EFEITOS VISUAIS"
            );

            btnEfeitos.Dock = DockStyle.Fill;
            btnEfeitos.Margin = new Padding(3);
            btnEfeitos.Name = "btnEfeitos";
            btnEfeitos.TabIndex = 1;
            btnEfeitos.Click += btnEfeitos_Click;

            // 
            // btnInicializacao
            // 
            ConfigurarBotaoModulo(
                btnInicializacao,
                "INICIALIZAÇÃO"
            );

            btnInicializacao.Dock = DockStyle.Fill;
            btnInicializacao.Margin = new Padding(3);
            btnInicializacao.Name = "btnInicializacao";
            btnInicializacao.TabIndex = 2;
            btnInicializacao.Click += btnInicializacao_Click;

            // 
            // btnServicos
            // 
            ConfigurarBotaoModulo(
                btnServicos,
                "SERVIÇOS"
            );

            btnServicos.Dock = DockStyle.Fill;
            btnServicos.Margin = new Padding(3);
            btnServicos.Name = "btnServicos";
            btnServicos.TabIndex = 3;
            btnServicos.Click += btnServicos_Click_1;

            // 
            // btnEnergia
            // 
            ConfigurarBotaoModulo(
                btnEnergia,
                "PLANO DE ENERGIA"
            );

            btnEnergia.Dock = DockStyle.Fill;
            btnEnergia.Margin = new Padding(3);
            btnEnergia.Name = "btnEnergia";
            btnEnergia.TabIndex = 4;
            btnEnergia.Click += btnEnergia_Click;

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
            pnlConteudo.TabIndex = 7;
            pnlConteudo.Text = "pnlConteudo";

            // 
            // FormOtimizacao
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

            Name = "FormOtimizacao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WinTuner - Otimização";
            WindowState = FormWindowState.Maximized;

            Load += FormOtimizacao_Load;

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
                9F,
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

        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel6;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel1;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel5;

        private ReaLTaiizor.Controls.Button btnLimpeza;
        private ReaLTaiizor.Controls.Button btnDiagnostico;
        private ReaLTaiizor.Controls.Button btnPainel;

        private PictureBox pictureBox1;
        private Panel SideBar;

        private ReaLTaiizor.Controls.BigLabel lbl;

        private TableLayoutPanel pnlNavegacao;

        private ReaLTaiizor.Controls.Button btnDebloat;
        private ReaLTaiizor.Controls.Button btnEfeitos;
        private ReaLTaiizor.Controls.Button btnInicializacao;
        private ReaLTaiizor.Controls.Button btnServicos;
        private ReaLTaiizor.Controls.Button btnEnergia;

        private ReaLTaiizor.Controls.Panel pnlConteudo;
    }
}