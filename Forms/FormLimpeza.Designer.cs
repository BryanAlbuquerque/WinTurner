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
            btnDiagnostico = new ReaLTaiizor.Controls.Button();
            btnPainel = new ReaLTaiizor.Controls.Button();
            lbl = new ReaLTaiizor.Controls.BigLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SideBar.SuspendLayout();
            SuspendLayout();
            // 
            // dungeonLabel6
            // 
            dungeonLabel6.AutoSize = true;
            dungeonLabel6.BackColor = Color.Transparent;
            dungeonLabel6.Font = new Font("Castellar", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel6.ForeColor = Color.Maroon;
            dungeonLabel6.Location = new Point(291, 45);
            dungeonLabel6.Name = "dungeonLabel6";
            dungeonLabel6.Size = new Size(687, 35);
            dungeonLabel6.TabIndex = 21;
            dungeonLabel6.Text = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━";
            // 
            // dungeonLabel1
            // 
            dungeonLabel1.AutoSize = true;
            dungeonLabel1.BackColor = Color.Transparent;
            dungeonLabel1.Font = new Font("Castellar", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel1.ForeColor = Color.FromArgb(119, 119, 119);
            dungeonLabel1.Location = new Point(291, 80);
            dungeonLabel1.Name = "dungeonLabel1";
            dungeonLabel1.Size = new Size(278, 19);
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
            btnHistorico.Font = new Font("Microsoft Sans Serif", 12F);
            btnHistorico.Image = null;
            btnHistorico.ImageAlign = ContentAlignment.MiddleLeft;
            btnHistorico.InactiveColor = Color.FromArgb(32, 34, 37);
            btnHistorico.Location = new Point(12, 401);
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
            btnOtimizacao.Font = new Font("Microsoft Sans Serif", 12F);
            btnOtimizacao.Image = null;
            btnOtimizacao.ImageAlign = ContentAlignment.MiddleLeft;
            btnOtimizacao.InactiveColor = Color.FromArgb(32, 34, 37);
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
            // btnDiagnostico
            // 
            btnDiagnostico.BackColor = Color.Black;
            btnDiagnostico.BorderColor = Color.Transparent;
            btnDiagnostico.Cursor = Cursors.Hand;
            btnDiagnostico.EnteredBorderColor = Color.DarkGray;
            btnDiagnostico.EnteredColor = Color.FromArgb(32, 34, 37);
            btnDiagnostico.Font = new Font("Microsoft Sans Serif", 12F);
            btnDiagnostico.Image = null;
            btnDiagnostico.ImageAlign = ContentAlignment.MiddleLeft;
            btnDiagnostico.InactiveColor = Color.FromArgb(32, 34, 37);
            btnDiagnostico.Location = new Point(12, 264);
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
            btnPainel.Font = new Font("Microsoft Sans Serif", 12F);
            btnPainel.Image = null;
            btnPainel.ImageAlign = ContentAlignment.MiddleLeft;
            btnPainel.InactiveColor = Color.FromArgb(32, 34, 37);
            btnPainel.Location = new Point(12, 199);
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
            lbl.Font = new Font("Castellar", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl.ForeColor = Color.WhiteSmoke;
            lbl.Location = new Point(255, 9);
            lbl.Name = "lbl";
            lbl.Size = new Size(201, 44);
            lbl.TabIndex = 19;
            lbl.Text = "LIMPEZA";
            // 
            // FormLimpeza
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 29, 29);
            ClientSize = new Size(1038, 673);
            Controls.Add(dungeonLabel6);
            Controls.Add(dungeonLabel1);
            Controls.Add(SideBar);
            Controls.Add(lbl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormLimpeza";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Limpeza";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            SideBar.ResumeLayout(false);
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
    }
}