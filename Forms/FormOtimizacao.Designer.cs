namespace WinTuner.Forms
{
    partial class FormOtimizacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOtimizacao));
            dungeonLabel6 = new ReaLTaiizor.Controls.DungeonLabel();
            dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
            btnHistorico = new ReaLTaiizor.Controls.Button();
            pictureBox1 = new PictureBox();
            SideBar = new Panel();
            dungeonLabel5 = new ReaLTaiizor.Controls.DungeonLabel();
            btnLimpeza = new ReaLTaiizor.Controls.Button();
            btnDiagnostico = new ReaLTaiizor.Controls.Button();
            btnPainel = new ReaLTaiizor.Controls.Button();
            lbl = new ReaLTaiizor.Controls.BigLabel();
            btnDebloat = new ReaLTaiizor.Controls.Button();
            pnlConteudo = new ReaLTaiizor.Controls.Panel();
            btnEfeitos = new ReaLTaiizor.Controls.Button();
            btnInicializacao = new ReaLTaiizor.Controls.Button();
            btnServicos = new ReaLTaiizor.Controls.Button();
            btnEnergia = new ReaLTaiizor.Controls.Button();
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
            dungeonLabel6.Location = new Point(252, 46);
            dungeonLabel6.Name = "dungeonLabel6";
            dungeonLabel6.Size = new Size(639, 33);
            dungeonLabel6.TabIndex = 25;
            dungeonLabel6.Text = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━";
            // 
            // dungeonLabel1
            // 
            dungeonLabel1.AutoSize = true;
            dungeonLabel1.BackColor = Color.Transparent;
            dungeonLabel1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel1.ForeColor = Color.FromArgb(119, 119, 119);
            dungeonLabel1.Location = new Point(252, 81);
            dungeonLabel1.Name = "dungeonLabel1";
            dungeonLabel1.Size = new Size(628, 20);
            dungeonLabel1.TabIndex = 24;
            dungeonLabel1.Text = "Ajuste o Windows para reduzir processos, efeitos e recursos desnecessários.";
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
            btnHistorico.Location = new Point(12, 421);
            btnHistorico.Name = "btnHistorico";
            btnHistorico.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnHistorico.PressedColor = Color.FromArgb(165, 37, 37);
            btnHistorico.Size = new Size(173, 40);
            btnHistorico.TabIndex = 11;
            btnHistorico.Text = "Historico";
            btnHistorico.TextAlignment = StringAlignment.Center;
            btnHistorico.Click += btnHistorico_Click;
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
            SideBar.Controls.Add(dungeonLabel5);
            SideBar.Controls.Add(btnLimpeza);
            SideBar.Controls.Add(btnDiagnostico);
            SideBar.Controls.Add(btnPainel);
            SideBar.Controls.Add(btnHistorico);
            SideBar.Controls.Add(pictureBox1);
            SideBar.Dock = DockStyle.Left;
            SideBar.Location = new Point(0, 0);
            SideBar.Name = "SideBar";
            SideBar.Size = new Size(200, 676);
            SideBar.TabIndex = 22;
            // 
            // dungeonLabel5
            // 
            dungeonLabel5.AutoSize = true;
            dungeonLabel5.BackColor = Color.Transparent;
            dungeonLabel5.Dock = DockStyle.Bottom;
            dungeonLabel5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel5.ForeColor = Color.Lime;
            dungeonLabel5.Location = new Point(0, 661);
            dungeonLabel5.Name = "dungeonLabel5";
            dungeonLabel5.Size = new Size(185, 15);
            dungeonLabel5.TabIndex = 21;
            dungeonLabel5.Text = "⚫ SISTEMA OPERACIONAL";
            // 
            // btnLimpeza
            // 
            btnLimpeza.BackColor = Color.Black;
            btnLimpeza.BorderColor = Color.Transparent;
            btnLimpeza.Cursor = Cursors.Hand;
            btnLimpeza.EnteredBorderColor = Color.DarkGray;
            btnLimpeza.EnteredColor = Color.FromArgb(32, 34, 37);
            btnLimpeza.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnLimpeza.Image = null;
            btnLimpeza.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpeza.InactiveColor = Color.Black;
            btnLimpeza.Location = new Point(12, 335);
            btnLimpeza.Name = "btnLimpeza";
            btnLimpeza.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnLimpeza.PressedColor = Color.FromArgb(165, 37, 37);
            btnLimpeza.Size = new Size(173, 40);
            btnLimpeza.TabIndex = 14;
            btnLimpeza.Text = "Limpeza";
            btnLimpeza.TextAlignment = StringAlignment.Center;
            btnLimpeza.Click += btnLimpeza_Click;
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
            btnDiagnostico.Location = new Point(12, 257);
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
            btnPainel.Location = new Point(12, 176);
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
            lbl.Location = new Point(216, 10);
            lbl.Name = "lbl";
            lbl.Size = new Size(258, 42);
            lbl.TabIndex = 23;
            lbl.Text = "OTIMIZAÇÃO";
            // 
            // btnDebloat
            // 
            btnDebloat.BackColor = Color.Black;
            btnDebloat.BorderColor = Color.Transparent;
            btnDebloat.Cursor = Cursors.Hand;
            btnDebloat.EnteredBorderColor = Color.DarkGray;
            btnDebloat.EnteredColor = Color.FromArgb(32, 34, 37);
            btnDebloat.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDebloat.Image = null;
            btnDebloat.ImageAlign = ContentAlignment.MiddleLeft;
            btnDebloat.InactiveColor = Color.FromArgb(29, 29, 29);
            btnDebloat.Location = new Point(203, 121);
            btnDebloat.Name = "btnDebloat";
            btnDebloat.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnDebloat.PressedColor = Color.FromArgb(165, 37, 37);
            btnDebloat.Size = new Size(178, 27);
            btnDebloat.TabIndex = 26;
            btnDebloat.Text = "Debloat do Windows ";
            btnDebloat.TextAlignment = StringAlignment.Center;
            btnDebloat.Click += btnDebloat_Click;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlConteudo.BackColor = Color.FromArgb(21, 21, 21);
            pnlConteudo.EdgeColor = Color.FromArgb(32, 41, 50);
            pnlConteudo.Location = new Point(206, 169);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Padding = new Padding(5);
            pnlConteudo.Size = new Size(1143, 495);
            pnlConteudo.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pnlConteudo.TabIndex = 27;
            pnlConteudo.Text = "panel1";
            // 
            // btnEfeitos
            // 
            btnEfeitos.BackColor = Color.Black;
            btnEfeitos.BorderColor = Color.Transparent;
            btnEfeitos.Cursor = Cursors.Hand;
            btnEfeitos.EnteredBorderColor = Color.DarkGray;
            btnEfeitos.EnteredColor = Color.FromArgb(32, 34, 37);
            btnEfeitos.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEfeitos.Image = null;
            btnEfeitos.ImageAlign = ContentAlignment.MiddleLeft;
            btnEfeitos.InactiveColor = Color.FromArgb(29, 29, 29);
            btnEfeitos.Location = new Point(387, 122);
            btnEfeitos.Name = "btnEfeitos";
            btnEfeitos.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnEfeitos.PressedColor = Color.FromArgb(165, 37, 37);
            btnEfeitos.Size = new Size(221, 27);
            btnEfeitos.TabIndex = 28;
            btnEfeitos.Text = "Efeitos visuais do Windows";
            btnEfeitos.TextAlignment = StringAlignment.Center;
            btnEfeitos.Click += btnEfeitos_Click;
            // 
            // btnInicializacao
            // 
            btnInicializacao.BackColor = Color.Black;
            btnInicializacao.BorderColor = Color.Transparent;
            btnInicializacao.Cursor = Cursors.Hand;
            btnInicializacao.EnteredBorderColor = Color.DarkGray;
            btnInicializacao.EnteredColor = Color.FromArgb(32, 34, 37);
            btnInicializacao.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInicializacao.Image = null;
            btnInicializacao.ImageAlign = ContentAlignment.MiddleLeft;
            btnInicializacao.InactiveColor = Color.FromArgb(29, 29, 29);
            btnInicializacao.Location = new Point(614, 122);
            btnInicializacao.Name = "btnInicializacao";
            btnInicializacao.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnInicializacao.PressedColor = Color.FromArgb(165, 37, 37);
            btnInicializacao.Size = new Size(234, 28);
            btnInicializacao.TabIndex = 29;
            btnInicializacao.Text = "Programas de inicialização";
            btnInicializacao.TextAlignment = StringAlignment.Center;
            btnInicializacao.Click += btnInicializacao_Click;
            // 
            // btnServicos
            // 
            btnServicos.BackColor = Color.Black;
            btnServicos.BorderColor = Color.Transparent;
            btnServicos.Cursor = Cursors.Hand;
            btnServicos.EnteredBorderColor = Color.DarkGray;
            btnServicos.EnteredColor = Color.FromArgb(32, 34, 37);
            btnServicos.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnServicos.Image = null;
            btnServicos.ImageAlign = ContentAlignment.MiddleLeft;
            btnServicos.InactiveColor = Color.FromArgb(29, 29, 29);
            btnServicos.Location = new Point(854, 122);
            btnServicos.Name = "btnServicos";
            btnServicos.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnServicos.PressedColor = Color.FromArgb(165, 37, 37);
            btnServicos.Size = new Size(241, 28);
            btnServicos.TabIndex = 30;
            btnServicos.Text = "Serviços do Windows";
            btnServicos.TextAlignment = StringAlignment.Center;
            btnServicos.Click += btnServicos_Click_1;
            // 
            // btnEnergia
            // 
            btnEnergia.BackColor = Color.Black;
            btnEnergia.BorderColor = Color.Transparent;
            btnEnergia.Cursor = Cursors.Hand;
            btnEnergia.EnteredBorderColor = Color.DarkGray;
            btnEnergia.EnteredColor = Color.FromArgb(32, 34, 37);
            btnEnergia.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEnergia.Image = null;
            btnEnergia.ImageAlign = ContentAlignment.MiddleLeft;
            btnEnergia.InactiveColor = Color.FromArgb(29, 29, 29);
            btnEnergia.Location = new Point(1101, 121);
            btnEnergia.Name = "btnEnergia";
            btnEnergia.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnEnergia.PressedColor = Color.FromArgb(165, 37, 37);
            btnEnergia.Size = new Size(241, 28);
            btnEnergia.TabIndex = 31;
            btnEnergia.Text = "Plano de energia";
            btnEnergia.TextAlignment = StringAlignment.Center;
            btnEnergia.Click += btnEnergia_Click;
            // 
            // FormOtimizacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 29, 29);
            ClientSize = new Size(1352, 676);
            Controls.Add(lbl);
            Controls.Add(btnEnergia);
            Controls.Add(btnServicos);
            Controls.Add(btnInicializacao);
            Controls.Add(btnEfeitos);
            Controls.Add(pnlConteudo);
            Controls.Add(btnDebloat);
            Controls.Add(dungeonLabel6);
            Controls.Add(dungeonLabel1);
            Controls.Add(SideBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormOtimizacao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Otimização";
            WindowState = FormWindowState.Maximized;
            Load += FormOtimizacao_Load;
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
        private PictureBox pictureBox1;
        private Panel SideBar;
        private ReaLTaiizor.Controls.Button btnDiagnostico;
        private ReaLTaiizor.Controls.Button btnPainel;
        private ReaLTaiizor.Controls.BigLabel lbl;
        private ReaLTaiizor.Controls.Button btnLimpeza;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel5;
        private ReaLTaiizor.Controls.Button btnDebloat;
        private ReaLTaiizor.Controls.Panel pnlConteudo;
        private ReaLTaiizor.Controls.Button btnEfeitos;
        private ReaLTaiizor.Controls.Button btnInicializacao;
        private ReaLTaiizor.Controls.Button btnServicos;
        private ReaLTaiizor.Controls.Button btnEnergia;
    }
}