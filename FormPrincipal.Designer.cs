namespace WinTuner
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            SideBar = new Panel();
            button5 = new ReaLTaiizor.Controls.Button();
            button4 = new ReaLTaiizor.Controls.Button();
            button3 = new ReaLTaiizor.Controls.Button();
            button2 = new ReaLTaiizor.Controls.Button();
            button1 = new ReaLTaiizor.Controls.Button();
            pictureBox1 = new PictureBox();
            PanelCPU = new FlowLayoutPanel();
            dungeonLabel3 = new ReaLTaiizor.Controls.DungeonLabel();
            PanelRam = new FlowLayoutPanel();
            dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();
            PanelDisco = new FlowLayoutPanel();
            dungeonLabel4 = new ReaLTaiizor.Controls.DungeonLabel();
            PanelGPU = new FlowLayoutPanel();
            dungeonLabel5 = new ReaLTaiizor.Controls.DungeonLabel();
            lbl = new ReaLTaiizor.Controls.BigLabel();
            dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
            dungeonLabel6 = new ReaLTaiizor.Controls.DungeonLabel();
            dungeonLabel7 = new ReaLTaiizor.Controls.DungeonLabel();
            SideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            PanelCPU.SuspendLayout();
            PanelRam.SuspendLayout();
            PanelDisco.SuspendLayout();
            PanelGPU.SuspendLayout();
            SuspendLayout();
            // 
            // SideBar
            // 
            SideBar.BackColor = Color.Black;
            SideBar.Controls.Add(button5);
            SideBar.Controls.Add(button4);
            SideBar.Controls.Add(button3);
            SideBar.Controls.Add(button2);
            SideBar.Controls.Add(button1);
            SideBar.Controls.Add(pictureBox1);
            SideBar.Dock = DockStyle.Left;
            SideBar.Location = new Point(0, 0);
            SideBar.Name = "SideBar";
            SideBar.Size = new Size(200, 668);
            SideBar.TabIndex = 0;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.BorderColor = Color.FromArgb(32, 34, 37);
            button5.EnteredBorderColor = Color.Maroon;
            button5.EnteredColor = Color.FromArgb(32, 34, 37);
            button5.Font = new Font("Microsoft Sans Serif", 12F);
            button5.Image = null;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.InactiveColor = Color.FromArgb(32, 34, 37);
            button5.Location = new Point(38, 424);
            button5.Name = "button5";
            button5.PressedBorderColor = Color.FromArgb(165, 37, 37);
            button5.PressedColor = Color.FromArgb(165, 37, 37);
            button5.Size = new Size(120, 40);
            button5.TabIndex = 11;
            button5.Text = "Historico";
            button5.TextAlignment = StringAlignment.Center;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.BorderColor = Color.FromArgb(32, 34, 37);
            button4.EnteredBorderColor = Color.Maroon;
            button4.EnteredColor = Color.FromArgb(32, 34, 37);
            button4.Font = new Font("Microsoft Sans Serif", 12F);
            button4.Image = null;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.InactiveColor = Color.FromArgb(32, 34, 37);
            button4.Location = new Point(38, 358);
            button4.Name = "button4";
            button4.PressedBorderColor = Color.FromArgb(165, 37, 37);
            button4.PressedColor = Color.FromArgb(165, 37, 37);
            button4.Size = new Size(120, 40);
            button4.TabIndex = 10;
            button4.Text = "Otimização";
            button4.TextAlignment = StringAlignment.Center;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.BorderColor = Color.FromArgb(32, 34, 37);
            button3.EnteredBorderColor = Color.Maroon;
            button3.EnteredColor = Color.FromArgb(32, 34, 37);
            button3.Font = new Font("Microsoft Sans Serif", 12F);
            button3.Image = null;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.InactiveColor = Color.FromArgb(32, 34, 37);
            button3.Location = new Point(38, 295);
            button3.Name = "button3";
            button3.PressedBorderColor = Color.FromArgb(165, 37, 37);
            button3.PressedColor = Color.FromArgb(165, 37, 37);
            button3.Size = new Size(120, 40);
            button3.TabIndex = 9;
            button3.Text = "Limpeza";
            button3.TextAlignment = StringAlignment.Center;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.BorderColor = Color.FromArgb(32, 34, 37);
            button2.EnteredBorderColor = Color.Maroon;
            button2.EnteredColor = Color.FromArgb(32, 34, 37);
            button2.Font = new Font("Microsoft Sans Serif", 12F);
            button2.Image = null;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.InactiveColor = Color.FromArgb(32, 34, 37);
            button2.Location = new Point(38, 228);
            button2.Name = "button2";
            button2.PressedBorderColor = Color.FromArgb(165, 37, 37);
            button2.PressedColor = Color.FromArgb(165, 37, 37);
            button2.Size = new Size(120, 40);
            button2.TabIndex = 8;
            button2.Text = "Diagnostico";
            button2.TextAlignment = StringAlignment.Center;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BorderColor = Color.FromArgb(32, 34, 37);
            button1.EnteredBorderColor = Color.Maroon;
            button1.EnteredColor = Color.FromArgb(32, 34, 37);
            button1.Font = new Font("Microsoft Sans Serif", 12F);
            button1.Image = null;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.InactiveColor = Color.FromArgb(32, 34, 37);
            button1.Location = new Point(38, 162);
            button1.Name = "button1";
            button1.PressedBorderColor = Color.FromArgb(165, 37, 37);
            button1.PressedColor = Color.FromArgb(165, 37, 37);
            button1.Size = new Size(120, 40);
            button1.TabIndex = 7;
            button1.Text = "Dashboard";
            button1.TextAlignment = StringAlignment.Center;
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
            // PanelCPU
            // 
            PanelCPU.BackColor = Color.FromArgb(21, 21, 21);
            PanelCPU.BorderStyle = BorderStyle.FixedSingle;
            PanelCPU.Controls.Add(dungeonLabel3);
            PanelCPU.Location = new Point(210, 125);
            PanelCPU.Name = "PanelCPU";
            PanelCPU.Size = new Size(195, 100);
            PanelCPU.TabIndex = 1;
            // 
            // dungeonLabel3
            // 
            dungeonLabel3.BackColor = Color.Transparent;
            dungeonLabel3.Font = new Font("Castellar", 14.25F, FontStyle.Bold);
            dungeonLabel3.ForeColor = Color.Maroon;
            dungeonLabel3.Location = new Point(3, 0);
            dungeonLabel3.Name = "dungeonLabel3";
            dungeonLabel3.Size = new Size(159, 20);
            dungeonLabel3.TabIndex = 8;
            dungeonLabel3.Text = "CPU";
            // 
            // PanelRam
            // 
            PanelRam.BackColor = Color.FromArgb(21, 21, 21);
            PanelRam.BorderStyle = BorderStyle.FixedSingle;
            PanelRam.Controls.Add(dungeonLabel2);
            PanelRam.Location = new Point(428, 125);
            PanelRam.Name = "PanelRam";
            PanelRam.Size = new Size(195, 100);
            PanelRam.TabIndex = 2;
            // 
            // dungeonLabel2
            // 
            dungeonLabel2.BackColor = Color.Transparent;
            dungeonLabel2.Font = new Font("Castellar", 14.25F, FontStyle.Bold);
            dungeonLabel2.ForeColor = Color.Maroon;
            dungeonLabel2.Location = new Point(3, 0);
            dungeonLabel2.Name = "dungeonLabel2";
            dungeonLabel2.Size = new Size(159, 20);
            dungeonLabel2.TabIndex = 7;
            dungeonLabel2.Text = "RAM";
            // 
            // PanelDisco
            // 
            PanelDisco.BackColor = Color.FromArgb(21, 21, 21);
            PanelDisco.BorderStyle = BorderStyle.FixedSingle;
            PanelDisco.Controls.Add(dungeonLabel4);
            PanelDisco.Location = new Point(650, 125);
            PanelDisco.Name = "PanelDisco";
            PanelDisco.Size = new Size(195, 100);
            PanelDisco.TabIndex = 3;
            // 
            // dungeonLabel4
            // 
            dungeonLabel4.BackColor = Color.Transparent;
            dungeonLabel4.Font = new Font("Castellar", 14.25F, FontStyle.Bold);
            dungeonLabel4.ForeColor = Color.Maroon;
            dungeonLabel4.Location = new Point(3, 0);
            dungeonLabel4.Name = "dungeonLabel4";
            dungeonLabel4.Size = new Size(159, 20);
            dungeonLabel4.TabIndex = 8;
            dungeonLabel4.Text = "DISCO";
            // 
            // PanelGPU
            // 
            PanelGPU.BackColor = Color.FromArgb(21, 21, 21);
            PanelGPU.BorderStyle = BorderStyle.FixedSingle;
            PanelGPU.Controls.Add(dungeonLabel5);
            PanelGPU.FlowDirection = FlowDirection.TopDown;
            PanelGPU.Location = new Point(873, 125);
            PanelGPU.Name = "PanelGPU";
            PanelGPU.Size = new Size(195, 100);
            PanelGPU.TabIndex = 4;
            // 
            // dungeonLabel5
            // 
            dungeonLabel5.BackColor = Color.Transparent;
            dungeonLabel5.Font = new Font("Castellar", 14.25F, FontStyle.Bold);
            dungeonLabel5.ForeColor = Color.Maroon;
            dungeonLabel5.Location = new Point(3, 0);
            dungeonLabel5.Name = "dungeonLabel5";
            dungeonLabel5.Size = new Size(159, 20);
            dungeonLabel5.TabIndex = 9;
            dungeonLabel5.Text = "GPU";
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.BackColor = Color.Transparent;
            lbl.Font = new Font("Castellar", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl.ForeColor = Color.WhiteSmoke;
            lbl.Location = new Point(214, 11);
            lbl.Name = "lbl";
            lbl.Size = new Size(290, 44);
            lbl.TabIndex = 5;
            lbl.Text = "Dashboard";
            // 
            // dungeonLabel1
            // 
            dungeonLabel1.AutoSize = true;
            dungeonLabel1.BackColor = Color.Transparent;
            dungeonLabel1.Font = new Font("Castellar", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel1.ForeColor = Color.FromArgb(119, 119, 119);
            dungeonLabel1.Location = new Point(322, 71);
            dungeonLabel1.Name = "dungeonLabel1";
            dungeonLabel1.Size = new Size(261, 19);
            dungeonLabel1.TabIndex = 6;
            dungeonLabel1.Text = "Visão geral do sistema";
            // 
            // dungeonLabel6
            // 
            dungeonLabel6.AutoSize = true;
            dungeonLabel6.BackColor = Color.Transparent;
            dungeonLabel6.Font = new Font("Castellar", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel6.ForeColor = Color.Maroon;
            dungeonLabel6.Location = new Point(232, 36);
            dungeonLabel6.Name = "dungeonLabel6";
            dungeonLabel6.Size = new Size(351, 35);
            dungeonLabel6.TabIndex = 7;
            dungeonLabel6.Text = "━━━━━━━━━━━━━━━━━━━━━━━━";
            // 
            // dungeonLabel7
            // 
            dungeonLabel7.AutoSize = true;
            dungeonLabel7.BackColor = Color.Transparent;
            dungeonLabel7.Font = new Font("Castellar", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel7.ForeColor = Color.White;
            dungeonLabel7.Location = new Point(252, 295);
            dungeonLabel7.Name = "dungeonLabel7";
            dungeonLabel7.Size = new Size(331, 23);
            dungeonLabel7.TabIndex = 8;
            dungeonLabel7.Text = "Aplicativos em Execução";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 29, 29);
            ClientSize = new Size(1060, 668);
            Controls.Add(dungeonLabel7);
            Controls.Add(lbl);
            Controls.Add(dungeonLabel6);
            Controls.Add(dungeonLabel1);
            Controls.Add(PanelGPU);
            Controls.Add(PanelDisco);
            Controls.Add(PanelRam);
            Controls.Add(PanelCPU);
            Controls.Add(SideBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormPrincipal";
            Text = "WinTurner";
            WindowState = FormWindowState.Maximized;
            SideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            PanelCPU.ResumeLayout(false);
            PanelRam.ResumeLayout(false);
            PanelDisco.ResumeLayout(false);
            PanelGPU.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel SideBar;
        private PictureBox pictureBox1;
        private FlowLayoutPanel PanelCPU;
        private FlowLayoutPanel PanelRam;
        private FlowLayoutPanel PanelDisco;
        private FlowLayoutPanel PanelGPU;
        private ReaLTaiizor.Controls.BigLabel lbl;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel1;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel3;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel4;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel5;
        private ReaLTaiizor.Controls.Button button1;
        private ReaLTaiizor.Controls.Button button5;
        private ReaLTaiizor.Controls.Button button4;
        private ReaLTaiizor.Controls.Button button3;
        private ReaLTaiizor.Controls.Button button2;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel6;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel7;
    }
}
