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
            btnLimpeza = new ReaLTaiizor.Controls.Button();
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
            dungeonLabel6.Location = new Point(252, 46);
            dungeonLabel6.Name = "dungeonLabel6";
            dungeonLabel6.Size = new Size(687, 35);
            dungeonLabel6.TabIndex = 25;
            dungeonLabel6.Text = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━";
            // 
            // dungeonLabel1
            // 
            dungeonLabel1.AutoSize = true;
            dungeonLabel1.BackColor = Color.Transparent;
            dungeonLabel1.Font = new Font("Castellar", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel1.ForeColor = Color.FromArgb(119, 119, 119);
            dungeonLabel1.Location = new Point(252, 81);
            dungeonLabel1.Name = "dungeonLabel1";
            dungeonLabel1.Size = new Size(362, 19);
            dungeonLabel1.TabIndex = 24;
            dungeonLabel1.Text = "DESATIVAR ITENS NÃO UTILIZADOS ";
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
            // btnLimpeza
            // 
            btnLimpeza.BackColor = Color.Black;
            btnLimpeza.BorderColor = Color.Transparent;
            btnLimpeza.Cursor = Cursors.Hand;
            btnLimpeza.EnteredBorderColor = Color.DarkGray;
            btnLimpeza.EnteredColor = Color.FromArgb(32, 34, 37);
            btnLimpeza.Font = new Font("Microsoft Sans Serif", 12F);
            btnLimpeza.Image = null;
            btnLimpeza.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpeza.InactiveColor = Color.FromArgb(32, 34, 37);
            btnLimpeza.Location = new Point(12, 331);
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
            lbl.Location = new Point(216, 10);
            lbl.Name = "lbl";
            lbl.Size = new Size(301, 44);
            lbl.TabIndex = 23;
            lbl.Text = "OTIMIZAÇÃO";
            // 
            // FormOtimizacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 29, 29);
            ClientSize = new Size(1049, 676);
            Controls.Add(dungeonLabel6);
            Controls.Add(dungeonLabel1);
            Controls.Add(SideBar);
            Controls.Add(lbl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormOtimizacao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Otimização";
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
        private PictureBox pictureBox1;
        private Panel SideBar;
        private ReaLTaiizor.Controls.Button btnDiagnostico;
        private ReaLTaiizor.Controls.Button btnPainel;
        private ReaLTaiizor.Controls.BigLabel lbl;
        private ReaLTaiizor.Controls.Button btnLimpeza;
    }
}