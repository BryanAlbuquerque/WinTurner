namespace WinTuner.Forms
{
    partial class FormDiagnostico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDiagnostico));
            dungeonLabel6 = new ReaLTaiizor.Controls.DungeonLabel();
            dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
            btnHistorico = new ReaLTaiizor.Controls.Button();
            btnOtimizacao = new ReaLTaiizor.Controls.Button();
            btnLimpeza = new ReaLTaiizor.Controls.Button();
            pictureBox1 = new PictureBox();
            SideBar = new Panel();
            dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();
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
            dungeonLabel6.Location = new Point(246, 45);
            dungeonLabel6.Name = "dungeonLabel6";
            dungeonLabel6.Size = new Size(687, 35);
            dungeonLabel6.TabIndex = 17;
            dungeonLabel6.Text = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━";
            // 
            // dungeonLabel1
            // 
            dungeonLabel1.AutoSize = true;
            dungeonLabel1.BackColor = Color.Transparent;
            dungeonLabel1.Font = new Font("Castellar", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel1.ForeColor = Color.FromArgb(119, 119, 119);
            dungeonLabel1.Location = new Point(231, 80);
            dungeonLabel1.Name = "dungeonLabel1";
            dungeonLabel1.Size = new Size(499, 23);
            dungeonLabel1.TabIndex = 16;
            dungeonLabel1.Text = "Verificação e Analise do Computador";
            // 
            // btnHistorico
            // 
            btnHistorico.BackColor = Color.Black;
            btnHistorico.BorderColor = Color.Transparent;
            btnHistorico.Cursor = Cursors.Hand;
            btnHistorico.EnteredBorderColor = Color.DarkGray;
            btnHistorico.EnteredColor = Color.FromArgb(32, 34, 37);
            btnHistorico.Font = new Font("Castellar", 12F, FontStyle.Bold);
            btnHistorico.Image = null;
            btnHistorico.ImageAlign = ContentAlignment.MiddleLeft;
            btnHistorico.InactiveColor = Color.Black;
            btnHistorico.Location = new Point(20, 375);
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
            btnOtimizacao.Font = new Font("Castellar", 12F, FontStyle.Bold);
            btnOtimizacao.Image = null;
            btnOtimizacao.ImageAlign = ContentAlignment.MiddleLeft;
            btnOtimizacao.InactiveColor = Color.Black;
            btnOtimizacao.Location = new Point(20, 305);
            btnOtimizacao.Name = "btnOtimizacao";
            btnOtimizacao.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnOtimizacao.PressedColor = Color.FromArgb(165, 37, 37);
            btnOtimizacao.Size = new Size(173, 40);
            btnOtimizacao.TabIndex = 10;
            btnOtimizacao.Text = "Otimização";
            btnOtimizacao.TextAlignment = StringAlignment.Center;
            btnOtimizacao.Click += btnOtimizacao_Click;
            // 
            // btnLimpeza
            // 
            btnLimpeza.BackColor = Color.Black;
            btnLimpeza.BorderColor = Color.Transparent;
            btnLimpeza.Cursor = Cursors.Hand;
            btnLimpeza.EnteredBorderColor = Color.DarkGray;
            btnLimpeza.EnteredColor = Color.FromArgb(32, 34, 37);
            btnLimpeza.Font = new Font("Castellar", 12F, FontStyle.Bold);
            btnLimpeza.Image = null;
            btnLimpeza.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpeza.InactiveColor = Color.Black;
            btnLimpeza.Location = new Point(20, 235);
            btnLimpeza.Name = "btnLimpeza";
            btnLimpeza.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnLimpeza.PressedColor = Color.FromArgb(165, 37, 37);
            btnLimpeza.Size = new Size(173, 40);
            btnLimpeza.TabIndex = 9;
            btnLimpeza.Text = "Limpeza";
            btnLimpeza.TextAlignment = StringAlignment.Center;
            btnLimpeza.Click += btnLimpeza_Click;
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
            SideBar.Controls.Add(btnPainel);
            SideBar.Controls.Add(btnHistorico);
            SideBar.Controls.Add(btnOtimizacao);
            SideBar.Controls.Add(btnLimpeza);
            SideBar.Controls.Add(pictureBox1);
            SideBar.Dock = DockStyle.Left;
            SideBar.Location = new Point(0, 0);
            SideBar.Name = "SideBar";
            SideBar.Size = new Size(212, 674);
            SideBar.TabIndex = 10;
            // 
            // dungeonLabel2
            // 
            dungeonLabel2.AutoSize = true;
            dungeonLabel2.BackColor = Color.Transparent;
            dungeonLabel2.Dock = DockStyle.Bottom;
            dungeonLabel2.Font = new Font("Castellar", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel2.ForeColor = Color.Lime;
            dungeonLabel2.Location = new Point(0, 660);
            dungeonLabel2.Name = "dungeonLabel2";
            dungeonLabel2.Size = new Size(201, 14);
            dungeonLabel2.TabIndex = 19;
            dungeonLabel2.Text = "⚫ SISTEMA OPERACIONAL";
            // 
            // btnPainel
            // 
            btnPainel.BackColor = Color.Black;
            btnPainel.BorderColor = Color.Transparent;
            btnPainel.Cursor = Cursors.Hand;
            btnPainel.EnteredBorderColor = Color.DarkGray;
            btnPainel.EnteredColor = Color.FromArgb(32, 34, 37);
            btnPainel.Font = new Font("Castellar", 12F, FontStyle.Bold);
            btnPainel.Image = null;
            btnPainel.ImageAlign = ContentAlignment.MiddleLeft;
            btnPainel.InactiveColor = Color.Black;
            btnPainel.Location = new Point(20, 167);
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
            lbl.Location = new Point(218, 9);
            lbl.Name = "lbl";
            lbl.Size = new Size(336, 44);
            lbl.TabIndex = 15;
            lbl.Text = "DIAGNÓSTICO ";
            // 
            // FormDiagnostico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 29, 29);
            ClientSize = new Size(1060, 674);
            Controls.Add(lbl);
            Controls.Add(dungeonLabel6);
            Controls.Add(dungeonLabel1);
            Controls.Add(SideBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormDiagnostico";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Diagnostico";
            WindowState = FormWindowState.Maximized;
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
        private ReaLTaiizor.Controls.Button btnLimpeza;
        private PictureBox pictureBox1;
        private Panel SideBar;
        private ReaLTaiizor.Controls.BigLabel lbl;
        private ReaLTaiizor.Controls.Button btnPainel;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2;
    }
}