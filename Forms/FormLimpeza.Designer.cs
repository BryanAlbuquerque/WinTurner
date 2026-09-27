namespace WinTuner.Forms
{
    partial class FormLimpeza
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLimpeza));
            dungeonLabel6 = new ReaLTaiizor.Controls.DungeonLabel();
            dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
            btnHistorico = new ReaLTaiizor.Controls.Button();
            btnOtimizacao = new ReaLTaiizor.Controls.Button();
            pictureBox1 = new PictureBox();
            SideBar = new Panel();
            dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();
            btnDiagnostico = new ReaLTaiizor.Controls.Button();
            btnPainel = new ReaLTaiizor.Controls.Button();
            lbl = new ReaLTaiizor.Controls.BigLabel();
            pnlConteudo = new ReaLTaiizor.Controls.Panel();
            btnArquivosTemp = new ReaLTaiizor.Controls.Button();
            btnArquivoInuteis = new ReaLTaiizor.Controls.Button();
            btnCache = new ReaLTaiizor.Controls.Button();
            btnLimpezaWin = new ReaLTaiizor.Controls.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SideBar.SuspendLayout();
            SuspendLayout();
            // 
            // dungeonLabel6
            // 
            dungeonLabel6.AutoSize = true;
            dungeonLabel6.BackColor = Color.Transparent;
            dungeonLabel6.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel6.ForeColor = Color.Maroon;
            dungeonLabel6.Location = new Point(291, 45);
            dungeonLabel6.Name = "dungeonLabel6";
            dungeonLabel6.Size = new Size(639, 33);
            dungeonLabel6.TabIndex = 21;
            dungeonLabel6.Text = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━";
            // 
            // dungeonLabel1
            // 
            dungeonLabel1.AutoSize = true;
            dungeonLabel1.BackColor = Color.Transparent;
            dungeonLabel1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel1.ForeColor = Color.FromArgb(119, 119, 119);
            dungeonLabel1.Location = new Point(291, 78);
            dungeonLabel1.Name = "dungeonLabel1";
            dungeonLabel1.Size = new Size(245, 20);
            dungeonLabel1.TabIndex = 20;
            dungeonLabel1.Text = "LIMPEZA DO COMPUTADOR";
            // 
            // btnHistorico
            // 
            btnHistorico.BackColor = Color.Black;
            btnHistorico.BorderColor = Color.Transparent;
            btnHistorico.Cursor = Cursors.Hand;
            btnHistorico.EnteredBorderColor = Color.DarkGray;
            btnHistorico.EnteredColor = Color.FromArgb(32, 34, 37);
            btnHistorico.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnHistorico.Image = null;
            btnHistorico.ImageAlign = ContentAlignment.MiddleLeft;
            btnHistorico.InactiveColor = Color.Black;
            btnHistorico.Location = new Point(12, 426);
            btnHistorico.Name = "btnHistorico";
            btnHistorico.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnHistorico.PressedColor = Color.FromArgb(165, 37, 37);
            btnHistorico.Size = new Size(173, 40);
            btnHistorico.TabIndex = 11;
            btnHistorico.Text = "Historico";
            btnHistorico.TextAlignment = StringAlignment.Center;
            btnHistorico.Click += btnHistorico_Click;
            // 
            // btnOtimizacao
            // 
            btnOtimizacao.BackColor = Color.Black;
            btnOtimizacao.BorderColor = Color.Transparent;
            btnOtimizacao.Cursor = Cursors.Hand;
            btnOtimizacao.EnteredBorderColor = Color.DarkGray;
            btnOtimizacao.EnteredColor = Color.FromArgb(32, 34, 37);
            btnOtimizacao.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnOtimizacao.Image = null;
            btnOtimizacao.ImageAlign = ContentAlignment.MiddleLeft;
            btnOtimizacao.InactiveColor = Color.Black;
            btnOtimizacao.Location = new Point(12, 333);
            btnOtimizacao.Name = "btnOtimizacao";
            btnOtimizacao.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnOtimizacao.PressedColor = Color.FromArgb(165, 37, 37);
            btnOtimizacao.Size = new Size(173, 40);
            btnOtimizacao.TabIndex = 10;
            btnOtimizacao.Text = "Otimização";
            btnOtimizacao.TextAlignment = StringAlignment.Center;
            btnOtimizacao.Click += btnOtimizacao_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(194, 118);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // SideBar
            // 
            SideBar.BackColor = Color.Black;
            SideBar.Controls.Add(dungeonLabel2);
            SideBar.Controls.Add(btnDiagnostico);
            SideBar.Controls.Add(btnPainel);
            SideBar.Controls.Add(btnHistorico);
            SideBar.Controls.Add(btnOtimizacao);
            SideBar.Controls.Add(pictureBox1);
            SideBar.Dock = DockStyle.Left;
            SideBar.Location = new Point(0, 0);
            SideBar.Name = "SideBar";
            SideBar.Size = new Size(200, 673);
            SideBar.TabIndex = 18;
            // 
            // dungeonLabel2
            // 
            dungeonLabel2.AutoSize = true;
            dungeonLabel2.BackColor = Color.Transparent;
            dungeonLabel2.Dock = DockStyle.Bottom;
            dungeonLabel2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel2.ForeColor = Color.Lime;
            dungeonLabel2.Location = new Point(0, 658);
            dungeonLabel2.Name = "dungeonLabel2";
            dungeonLabel2.Size = new Size(185, 15);
            dungeonLabel2.TabIndex = 23;
            dungeonLabel2.Text = "⚫ SISTEMA OPERACIONAL";
            // 
            // btnDiagnostico
            // 
            btnDiagnostico.BackColor = Color.Black;
            btnDiagnostico.BorderColor = Color.Transparent;
            btnDiagnostico.Cursor = Cursors.Hand;
            btnDiagnostico.EnteredBorderColor = Color.DarkGray;
            btnDiagnostico.EnteredColor = Color.FromArgb(32, 34, 37);
            btnDiagnostico.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnDiagnostico.Image = null;
            btnDiagnostico.ImageAlign = ContentAlignment.MiddleLeft;
            btnDiagnostico.InactiveColor = Color.Black;
            btnDiagnostico.Location = new Point(12, 253);
            btnDiagnostico.Name = "btnDiagnostico";
            btnDiagnostico.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnDiagnostico.PressedColor = Color.FromArgb(165, 37, 37);
            btnDiagnostico.Size = new Size(173, 40);
            btnDiagnostico.TabIndex = 13;
            btnDiagnostico.Text = "Diagnostico";
            btnDiagnostico.TextAlignment = StringAlignment.Center;
            btnDiagnostico.Click += btnDiagnostico_Click;
            // 
            // btnPainel
            // 
            btnPainel.BackColor = Color.Black;
            btnPainel.BorderColor = Color.Transparent;
            btnPainel.Cursor = Cursors.Hand;
            btnPainel.EnteredBorderColor = Color.DarkGray;
            btnPainel.EnteredColor = Color.FromArgb(32, 34, 37);
            btnPainel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnPainel.Image = null;
            btnPainel.ImageAlign = ContentAlignment.MiddleLeft;
            btnPainel.InactiveColor = Color.Black;
            btnPainel.Location = new Point(12, 171);
            btnPainel.Name = "btnPainel";
            btnPainel.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnPainel.PressedColor = Color.FromArgb(165, 37, 37);
            btnPainel.Size = new Size(173, 40);
            btnPainel.TabIndex = 12;
            btnPainel.Text = "Painel de Controle";
            btnPainel.TextAlignment = StringAlignment.Center;
            btnPainel.Click += btnPainel_Click;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.BackColor = Color.Transparent;
            lbl.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl.ForeColor = Color.WhiteSmoke;
            lbl.Location = new Point(255, 9);
            lbl.Name = "lbl";
            lbl.Size = new Size(184, 42);
            lbl.TabIndex = 19;
            lbl.Text = "LIMPEZA";
            // 
            // pnlConteudo
            // 
            pnlConteudo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlConteudo.BackColor = Color.Black;
            pnlConteudo.EdgeColor = Color.FromArgb(32, 41, 50);
            pnlConteudo.Location = new Point(206, 178);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Padding = new Padding(5);
            pnlConteudo.Size = new Size(972, 495);
            pnlConteudo.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pnlConteudo.TabIndex = 23;
            pnlConteudo.Text = "panel1";
            // 
            // btnArquivosTemp
            // 
            btnArquivosTemp.BackColor = Color.Black;
            btnArquivosTemp.BorderColor = Color.Transparent;
            btnArquivosTemp.Cursor = Cursors.Hand;
            btnArquivosTemp.EnteredBorderColor = Color.DarkGray;
            btnArquivosTemp.EnteredColor = Color.FromArgb(32, 34, 37);
            btnArquivosTemp.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnArquivosTemp.Image = null;
            btnArquivosTemp.ImageAlign = ContentAlignment.MiddleLeft;
            btnArquivosTemp.InactiveColor = Color.FromArgb(29, 29, 29);
            btnArquivosTemp.Location = new Point(206, 129);
            btnArquivosTemp.Name = "btnArquivosTemp";
            btnArquivosTemp.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnArquivosTemp.PressedColor = Color.FromArgb(165, 37, 37);
            btnArquivosTemp.Size = new Size(241, 27);
            btnArquivosTemp.TabIndex = 21;
            btnArquivosTemp.Text = "ARQUIVOS TEMPORÁRIOS";
            btnArquivosTemp.TextAlignment = StringAlignment.Center;
            btnArquivosTemp.Click += btnArquivosTemp_Click;
            // 
            // btnArquivoInuteis
            // 
            btnArquivoInuteis.BackColor = Color.Black;
            btnArquivoInuteis.BorderColor = Color.Transparent;
            btnArquivoInuteis.Cursor = Cursors.Hand;
            btnArquivoInuteis.EnteredBorderColor = Color.DarkGray;
            btnArquivoInuteis.EnteredColor = Color.FromArgb(32, 34, 37);
            btnArquivoInuteis.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            btnArquivoInuteis.Image = null;
            btnArquivoInuteis.ImageAlign = ContentAlignment.MiddleLeft;
            btnArquivoInuteis.InactiveColor = Color.FromArgb(29, 29, 29);
            btnArquivoInuteis.Location = new Point(479, 129);
            btnArquivoInuteis.Name = "btnArquivoInuteis";
            btnArquivoInuteis.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnArquivoInuteis.PressedColor = Color.FromArgb(165, 37, 37);
            btnArquivoInuteis.Size = new Size(222, 27);
            btnArquivoInuteis.TabIndex = 24;
            btnArquivoInuteis.Text = "ARQUIVOS INÚTEIS";
            btnArquivoInuteis.TextAlignment = StringAlignment.Center;
            btnArquivoInuteis.Click += btnArquivoInuteis_Click;
            // 
            // btnCache
            // 
            btnCache.BackColor = Color.Black;
            btnCache.BorderColor = Color.Transparent;
            btnCache.Cursor = Cursors.Hand;
            btnCache.EnteredBorderColor = Color.DarkGray;
            btnCache.EnteredColor = Color.FromArgb(32, 34, 37);
            btnCache.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            btnCache.Image = null;
            btnCache.ImageAlign = ContentAlignment.MiddleLeft;
            btnCache.InactiveColor = Color.FromArgb(29, 29, 29);
            btnCache.Location = new Point(741, 129);
            btnCache.Name = "btnCache";
            btnCache.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnCache.PressedColor = Color.FromArgb(165, 37, 37);
            btnCache.Size = new Size(206, 27);
            btnCache.TabIndex = 25;
            btnCache.Text = "NAVEGADORES E CACHE";
            btnCache.TextAlignment = StringAlignment.Center;
            btnCache.Click += btnCache_Click;
            // 
            // btnLimpezaWin
            // 
            btnLimpezaWin.BackColor = Color.Black;
            btnLimpezaWin.BorderColor = Color.Transparent;
            btnLimpezaWin.Cursor = Cursors.Hand;
            btnLimpezaWin.EnteredBorderColor = Color.DarkGray;
            btnLimpezaWin.EnteredColor = Color.FromArgb(32, 34, 37);
            btnLimpezaWin.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            btnLimpezaWin.Image = null;
            btnLimpezaWin.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpezaWin.InactiveColor = Color.FromArgb(29, 29, 29);
            btnLimpezaWin.Location = new Point(991, 129);
            btnLimpezaWin.Name = "btnLimpezaWin";
            btnLimpezaWin.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnLimpezaWin.PressedColor = Color.FromArgb(165, 37, 37);
            btnLimpezaWin.Size = new Size(173, 27);
            btnLimpezaWin.TabIndex = 26;
            btnLimpezaWin.Text = "LIMPEZA WINDOWS";
            btnLimpezaWin.TextAlignment = StringAlignment.Center;
            btnLimpezaWin.Click += btnLimpezaWin_Click;
            // 
            // FormLimpeza
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 29, 29);
            ClientSize = new Size(1142, 673);
            Controls.Add(btnLimpezaWin);
            Controls.Add(btnCache);
            Controls.Add(btnArquivoInuteis);
            Controls.Add(btnArquivosTemp);
            Controls.Add(pnlConteudo);
            Controls.Add(dungeonLabel6);
            Controls.Add(dungeonLabel1);
            Controls.Add(SideBar);
            Controls.Add(lbl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormLimpeza";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Limpeza";
            WindowState = FormWindowState.Maximized;
            Load += FormLimpeza_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            SideBar.ResumeLayout(false);
            SideBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel6;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel1;
        private ReaLTaiizor.Controls.Button btnHistorico;
        private ReaLTaiizor.Controls.Button btnOtimizacao;
        private PictureBox pictureBox1;
        private Panel SideBar;
        private ReaLTaiizor.Controls.Button btnPainel;
        private ReaLTaiizor.Controls.BigLabel lbl;
        private ReaLTaiizor.Controls.Button btnDiagnostico;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2;
        private ReaLTaiizor.Controls.Panel pnlConteudo;
        private ReaLTaiizor.Controls.Button btnArquivosTemp;
        private ReaLTaiizor.Controls.Button btnArquivoInuteis;
        private ReaLTaiizor.Controls.Button btnCache;
        private ReaLTaiizor.Controls.Button btnLimpezaWin;
    }
}