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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            SideBar = new Panel();
            dungeonLabel8 = new ReaLTaiizor.Controls.DungeonLabel();
            dungeonLabel5 = new ReaLTaiizor.Controls.DungeonLabel();
            btnHistorico = new ReaLTaiizor.Controls.Button();
            btnOtimizacao = new ReaLTaiizor.Controls.Button();
            btnLimpeza = new ReaLTaiizor.Controls.Button();
            btnDiagnostico = new ReaLTaiizor.Controls.Button();
            pictureBox1 = new PictureBox();
            dungeonLabel3 = new ReaLTaiizor.Controls.DungeonLabel();
            lblCPU = new ReaLTaiizor.Controls.DungeonLabel();
            dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();
            lblRAM = new ReaLTaiizor.Controls.DungeonLabel();
            dungeonLabel4 = new ReaLTaiizor.Controls.DungeonLabel();
            lblDISCO = new ReaLTaiizor.Controls.DungeonLabel();
            lblGpuNome = new ReaLTaiizor.Controls.DungeonLabel();
            lblGPU = new ReaLTaiizor.Controls.DungeonLabel();
            lbl = new ReaLTaiizor.Controls.BigLabel();
            dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
            dungeonLabel6 = new ReaLTaiizor.Controls.DungeonLabel();
            dungeonLabel7 = new ReaLTaiizor.Controls.DungeonLabel();
            timerSistema = new System.Windows.Forms.Timer(components);
            dgvProcessos = new ReaLTaiizor.Controls.PoisonDataGridView();
            panel1 = new ReaLTaiizor.Controls.Panel();
            panel2 = new ReaLTaiizor.Controls.Panel();
            panel3 = new ReaLTaiizor.Controls.Panel();
            panel4 = new ReaLTaiizor.Controls.Panel();
            SideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProcessos).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // SideBar
            // 
            SideBar.BackColor = Color.Black;
            SideBar.Controls.Add(dungeonLabel8);
            SideBar.Controls.Add(dungeonLabel5);
            SideBar.Controls.Add(btnHistorico);
            SideBar.Controls.Add(btnOtimizacao);
            SideBar.Controls.Add(btnLimpeza);
            SideBar.Controls.Add(btnDiagnostico);
            SideBar.Controls.Add(pictureBox1);
            SideBar.Dock = DockStyle.Left;
            SideBar.Location = new Point(0, 0);
            SideBar.Name = "SideBar";
            SideBar.Size = new Size(222, 651);
            SideBar.TabIndex = 0;
            // 
            // dungeonLabel8
            // 
            dungeonLabel8.AutoSize = true;
            dungeonLabel8.BackColor = Color.Transparent;
            dungeonLabel8.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel8.ForeColor = Color.Maroon;
            dungeonLabel8.Location = new Point(-2, 136);
            dungeonLabel8.Name = "dungeonLabel8";
            dungeonLabel8.Size = new Size(210, 33);
            dungeonLabel8.TabIndex = 10;
            dungeonLabel8.Text = "━━━━━━━━━━━━━━━";
            // 
            // dungeonLabel5
            // 
            dungeonLabel5.AutoSize = true;
            dungeonLabel5.BackColor = Color.Transparent;
            dungeonLabel5.Dock = DockStyle.Bottom;
            dungeonLabel5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel5.ForeColor = Color.Lime;
            dungeonLabel5.Location = new Point(0, 636);
            dungeonLabel5.Name = "dungeonLabel5";
            dungeonLabel5.Size = new Size(185, 15);
            dungeonLabel5.TabIndex = 20;
            dungeonLabel5.Text = "⚫ SISTEMA OPERACIONAL";
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
            btnHistorico.Location = new Point(25, 428);
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
            btnOtimizacao.Location = new Point(25, 347);
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
            btnLimpeza.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnLimpeza.Image = null;
            btnLimpeza.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpeza.InactiveColor = Color.Black;
            btnLimpeza.Location = new Point(25, 277);
            btnLimpeza.Name = "btnLimpeza";
            btnLimpeza.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnLimpeza.PressedColor = Color.FromArgb(165, 37, 37);
            btnLimpeza.Size = new Size(173, 40);
            btnLimpeza.TabIndex = 9;
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
            btnDiagnostico.Location = new Point(25, 209);
            btnDiagnostico.Name = "btnDiagnostico";
            btnDiagnostico.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnDiagnostico.PressedColor = Color.FromArgb(165, 37, 37);
            btnDiagnostico.Size = new Size(173, 40);
            btnDiagnostico.TabIndex = 8;
            btnDiagnostico.Text = "Diagnostico";
            btnDiagnostico.TextAlignment = StringAlignment.Center;
            btnDiagnostico.Click += btnDiagnostico_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(205, 141);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // dungeonLabel3
            // 
            dungeonLabel3.BackColor = Color.Transparent;
            dungeonLabel3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dungeonLabel3.ForeColor = Color.Maroon;
            dungeonLabel3.Location = new Point(8, 5);
            dungeonLabel3.Name = "dungeonLabel3";
            dungeonLabel3.Size = new Size(159, 20);
            dungeonLabel3.TabIndex = 8;
            dungeonLabel3.Text = "CPU";
            // 
            // lblCPU
            // 
            lblCPU.BackColor = Color.Transparent;
            lblCPU.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblCPU.ForeColor = Color.Maroon;
            lblCPU.ImageAlign = ContentAlignment.BottomCenter;
            lblCPU.Location = new Point(53, 41);
            lblCPU.Name = "lblCPU";
            lblCPU.Size = new Size(159, 20);
            lblCPU.TabIndex = 10;
            lblCPU.Text = "Dados CPU";
            lblCPU.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dungeonLabel2
            // 
            dungeonLabel2.BackColor = Color.Transparent;
            dungeonLabel2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dungeonLabel2.ForeColor = Color.Maroon;
            dungeonLabel2.Location = new Point(9, 5);
            dungeonLabel2.Name = "dungeonLabel2";
            dungeonLabel2.Size = new Size(159, 20);
            dungeonLabel2.TabIndex = 7;
            dungeonLabel2.Text = "RAM";
            // 
            // lblRAM
            // 
            lblRAM.BackColor = Color.Transparent;
            lblRAM.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblRAM.ForeColor = Color.Maroon;
            lblRAM.ImageAlign = ContentAlignment.BottomCenter;
            lblRAM.Location = new Point(45, 41);
            lblRAM.Name = "lblRAM";
            lblRAM.Size = new Size(159, 20);
            lblRAM.TabIndex = 11;
            lblRAM.Text = "Dados RAM";
            lblRAM.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dungeonLabel4
            // 
            dungeonLabel4.BackColor = Color.Transparent;
            dungeonLabel4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            dungeonLabel4.ForeColor = Color.Maroon;
            dungeonLabel4.Location = new Point(8, 5);
            dungeonLabel4.Name = "dungeonLabel4";
            dungeonLabel4.Size = new Size(159, 20);
            dungeonLabel4.TabIndex = 8;
            dungeonLabel4.Text = "DISCO";
            // 
            // lblDISCO
            // 
            lblDISCO.BackColor = Color.Transparent;
            lblDISCO.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblDISCO.ForeColor = Color.Maroon;
            lblDISCO.ImageAlign = ContentAlignment.BottomCenter;
            lblDISCO.Location = new Point(46, 41);
            lblDISCO.Name = "lblDISCO";
            lblDISCO.Size = new Size(159, 20);
            lblDISCO.TabIndex = 12;
            lblDISCO.Text = "DataDisco";
            lblDISCO.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGpuNome
            // 
            lblGpuNome.BackColor = Color.Transparent;
            lblGpuNome.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblGpuNome.ForeColor = Color.Maroon;
            lblGpuNome.Location = new Point(0, 5);
            lblGpuNome.Name = "lblGpuNome";
            lblGpuNome.Size = new Size(159, 20);
            lblGpuNome.TabIndex = 9;
            lblGpuNome.Text = "GPU";
            // 
            // lblGPU
            // 
            lblGPU.BackColor = Color.Transparent;
            lblGPU.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblGPU.ForeColor = Color.Maroon;
            lblGPU.ImageAlign = ContentAlignment.BottomCenter;
            lblGPU.Location = new Point(8, 41);
            lblGPU.Name = "lblGPU";
            lblGPU.Size = new Size(159, 20);
            lblGPU.TabIndex = 13;
            lblGPU.Text = "Dados GPU";
            lblGPU.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.BackColor = Color.Transparent;
            lbl.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl.ForeColor = Color.WhiteSmoke;
            lbl.Location = new Point(228, 9);
            lbl.Name = "lbl";
            lbl.Size = new Size(448, 42);
            lbl.TabIndex = 5;
            lbl.Text = "PAINEL DE CONTROLE";
            // 
            // dungeonLabel1
            // 
            dungeonLabel1.AutoSize = true;
            dungeonLabel1.BackColor = Color.Transparent;
            dungeonLabel1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel1.ForeColor = Color.FromArgb(119, 119, 119);
            dungeonLabel1.Location = new Point(228, 102);
            dungeonLabel1.Name = "dungeonLabel1";
            dungeonLabel1.Size = new Size(191, 20);
            dungeonLabel1.TabIndex = 6;
            dungeonLabel1.Text = "Visão geral do sistema";
            // 
            // dungeonLabel6
            // 
            dungeonLabel6.AutoSize = true;
            dungeonLabel6.BackColor = Color.Transparent;
            dungeonLabel6.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel6.ForeColor = Color.Maroon;
            dungeonLabel6.Location = new Point(292, 45);
            dungeonLabel6.Name = "dungeonLabel6";
            dungeonLabel6.Size = new Size(639, 33);
            dungeonLabel6.TabIndex = 7;
            dungeonLabel6.Text = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━";
            // 
            // dungeonLabel7
            // 
            dungeonLabel7.AutoSize = true;
            dungeonLabel7.BackColor = Color.Transparent;
            dungeonLabel7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel7.ForeColor = Color.White;
            dungeonLabel7.Location = new Point(228, 323);
            dungeonLabel7.Name = "dungeonLabel7";
            dungeonLabel7.Size = new Size(245, 24);
            dungeonLabel7.TabIndex = 8;
            dungeonLabel7.Text = "Aplicativos em Execução";
            // 
            // timerSistema
            // 
            timerSistema.Enabled = true;
            // 
            // dgvProcessos
            // 
            dgvProcessos.AllowUserToResizeRows = false;
            dgvProcessos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProcessos.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvProcessos.BorderStyle = BorderStyle.None;
            dgvProcessos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvProcessos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProcessos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProcessos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProcessos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProcessos.EnableHeadersVisualStyles = false;
            dgvProcessos.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvProcessos.GridColor = Color.FromArgb(255, 255, 255);
            dgvProcessos.Location = new Point(228, 371);
            dgvProcessos.Name = "dgvProcessos";
            dgvProcessos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvProcessos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvProcessos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvProcessos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProcessos.Size = new Size(965, 268);
            dgvProcessos.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(21, 21, 21);
            panel1.Controls.Add(lblCPU);
            panel1.Controls.Add(dungeonLabel3);
            panel1.EdgeColor = Color.FromArgb(32, 41, 50);
            panel1.Location = new Point(268, 148);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(244, 95);
            panel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel1.TabIndex = 10;
            panel1.Text = "panel1";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(21, 21, 21);
            panel2.Controls.Add(lblRAM);
            panel2.Controls.Add(dungeonLabel2);
            panel2.EdgeColor = Color.FromArgb(32, 41, 50);
            panel2.Location = new Point(553, 148);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(245, 95);
            panel2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel2.TabIndex = 11;
            panel2.Text = "panel2";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(21, 21, 21);
            panel3.Controls.Add(lblDISCO);
            panel3.Controls.Add(dungeonLabel4);
            panel3.EdgeColor = Color.FromArgb(32, 41, 50);
            panel3.Location = new Point(854, 148);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(5);
            panel3.Size = new Size(235, 95);
            panel3.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel3.TabIndex = 12;
            panel3.Text = "panel3";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(21, 21, 21);
            panel4.Controls.Add(lblGPU);
            panel4.Controls.Add(lblGpuNome);
            panel4.EdgeColor = Color.FromArgb(32, 41, 50);
            panel4.Location = new Point(1136, 148);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(5);
            panel4.Size = new Size(248, 95);
            panel4.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel4.TabIndex = 13;
            panel4.Text = "panel4";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 29, 29);
            ClientSize = new Size(1224, 651);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dgvProcessos);
            Controls.Add(dungeonLabel7);
            Controls.Add(lbl);
            Controls.Add(dungeonLabel6);
            Controls.Add(dungeonLabel1);
            Controls.Add(SideBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormPrincipal";
            Text = "WinTurner";
            WindowState = FormWindowState.Maximized;
            Load += FormPrincipal_Load;
            SideBar.ResumeLayout(false);
            SideBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProcessos).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel SideBar;
        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.BigLabel lbl;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel1;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel3;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel4;
        private ReaLTaiizor.Controls.DungeonLabel lblGpuNome;
        private ReaLTaiizor.Controls.Button btnHistorico;
        private ReaLTaiizor.Controls.Button btnOtimizacao;
        private ReaLTaiizor.Controls.Button btnLimpeza;
        private ReaLTaiizor.Controls.Button btnDiagnostico;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel6;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel7;
        private ReaLTaiizor.Controls.DungeonLabel lblCPU;
        private ReaLTaiizor.Controls.DungeonLabel lblRAM;
        private ReaLTaiizor.Controls.DungeonLabel lblDISCO;
        private ReaLTaiizor.Controls.DungeonLabel lblGPU;
        private System.Windows.Forms.Timer timerSistema;
        private ReaLTaiizor.Controls.PoisonDataGridView dgvProcessos;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel5;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel8;
        private ReaLTaiizor.Controls.Panel panel1;
        private ReaLTaiizor.Controls.Panel panel2;
        private ReaLTaiizor.Controls.Panel panel3;
        private ReaLTaiizor.Controls.Panel panel4;
    }
}
