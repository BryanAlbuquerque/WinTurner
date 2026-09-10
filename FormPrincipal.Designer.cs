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
            btnHistorico = new ReaLTaiizor.Controls.Button();
            btnOtimizacao = new ReaLTaiizor.Controls.Button();
            btnLimpeza = new ReaLTaiizor.Controls.Button();
            btnDiagnostico = new ReaLTaiizor.Controls.Button();
            pictureBox1 = new PictureBox();
            PanelCPU = new FlowLayoutPanel();
            dungeonLabel3 = new ReaLTaiizor.Controls.DungeonLabel();
            lblCPU = new ReaLTaiizor.Controls.DungeonLabel();
            PanelRam = new FlowLayoutPanel();
            dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();
            lblRAM = new ReaLTaiizor.Controls.DungeonLabel();
            PanelDisco = new FlowLayoutPanel();
            dungeonLabel4 = new ReaLTaiizor.Controls.DungeonLabel();
            lblDISCO = new ReaLTaiizor.Controls.DungeonLabel();
            PanelGPU = new FlowLayoutPanel();
            lblGpuNome = new ReaLTaiizor.Controls.DungeonLabel();
            lblGPU = new ReaLTaiizor.Controls.DungeonLabel();
            lbl = new ReaLTaiizor.Controls.BigLabel();
            dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
            dungeonLabel6 = new ReaLTaiizor.Controls.DungeonLabel();
            dungeonLabel7 = new ReaLTaiizor.Controls.DungeonLabel();
            timerSistema = new System.Windows.Forms.Timer(components);
            dgvProcessos = new ReaLTaiizor.Controls.PoisonDataGridView();
            SideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            PanelCPU.SuspendLayout();
            PanelRam.SuspendLayout();
            PanelDisco.SuspendLayout();
            PanelGPU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProcessos).BeginInit();
            SuspendLayout();
            // 
            // SideBar
            // 
            SideBar.BackColor = Color.Black;
            SideBar.Controls.Add(btnHistorico);
            SideBar.Controls.Add(btnOtimizacao);
            SideBar.Controls.Add(btnLimpeza);
            SideBar.Controls.Add(btnDiagnostico);
            SideBar.Controls.Add(pictureBox1);
            SideBar.Dock = DockStyle.Left;
            SideBar.Location = new Point(0, 0);
            SideBar.Name = "SideBar";
            SideBar.Size = new Size(200, 668);
            SideBar.TabIndex = 0;
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
            btnHistorico.Location = new Point(12, 440);
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
            btnOtimizacao.Location = new Point(12, 362);
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
            btnLimpeza.Font = new Font("Microsoft Sans Serif", 12F);
            btnLimpeza.Image = null;
            btnLimpeza.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpeza.InactiveColor = Color.FromArgb(32, 34, 37);
            btnLimpeza.Location = new Point(12, 284);
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
            btnDiagnostico.Font = new Font("Microsoft Sans Serif", 12F);
            btnDiagnostico.Image = null;
            btnDiagnostico.ImageAlign = ContentAlignment.MiddleLeft;
            btnDiagnostico.InactiveColor = Color.FromArgb(32, 34, 37);
            btnDiagnostico.Location = new Point(12, 208);
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
            PanelCPU.Controls.Add(lblCPU);
            PanelCPU.Location = new Point(333, 149);
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
            // lblCPU
            // 
            lblCPU.BackColor = Color.Transparent;
            lblCPU.Font = new Font("Castellar", 14.25F, FontStyle.Bold);
            lblCPU.ForeColor = Color.Maroon;
            lblCPU.ImageAlign = ContentAlignment.BottomCenter;
            lblCPU.Location = new Point(3, 20);
            lblCPU.Name = "lblCPU";
            lblCPU.Size = new Size(159, 20);
            lblCPU.TabIndex = 10;
            lblCPU.Text = "Dados CPU";
            lblCPU.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PanelRam
            // 
            PanelRam.BackColor = Color.FromArgb(21, 21, 21);
            PanelRam.BorderStyle = BorderStyle.FixedSingle;
            PanelRam.Controls.Add(dungeonLabel2);
            PanelRam.Controls.Add(lblRAM);
            PanelRam.Location = new Point(580, 148);
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
            // lblRAM
            // 
            lblRAM.BackColor = Color.Transparent;
            lblRAM.Font = new Font("Castellar", 14.25F, FontStyle.Bold);
            lblRAM.ForeColor = Color.Maroon;
            lblRAM.ImageAlign = ContentAlignment.BottomCenter;
            lblRAM.Location = new Point(3, 20);
            lblRAM.Name = "lblRAM";
            lblRAM.Size = new Size(159, 20);
            lblRAM.TabIndex = 11;
            lblRAM.Text = "Dados RAM";
            lblRAM.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PanelDisco
            // 
            PanelDisco.BackColor = Color.FromArgb(21, 21, 21);
            PanelDisco.BorderStyle = BorderStyle.FixedSingle;
            PanelDisco.Controls.Add(dungeonLabel4);
            PanelDisco.Controls.Add(lblDISCO);
            PanelDisco.Location = new Point(823, 148);
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
            // lblDISCO
            // 
            lblDISCO.BackColor = Color.Transparent;
            lblDISCO.Font = new Font("Castellar", 14.25F, FontStyle.Bold);
            lblDISCO.ForeColor = Color.Maroon;
            lblDISCO.ImageAlign = ContentAlignment.BottomCenter;
            lblDISCO.Location = new Point(3, 20);
            lblDISCO.Name = "lblDISCO";
            lblDISCO.Size = new Size(159, 20);
            lblDISCO.TabIndex = 12;
            lblDISCO.Text = "DataDisco";
            lblDISCO.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PanelGPU
            // 
            PanelGPU.BackColor = Color.FromArgb(21, 21, 21);
            PanelGPU.BorderStyle = BorderStyle.FixedSingle;
            PanelGPU.Controls.Add(lblGpuNome);
            PanelGPU.Controls.Add(lblGPU);
            PanelGPU.FlowDirection = FlowDirection.TopDown;
            PanelGPU.Location = new Point(1073, 148);
            PanelGPU.Name = "PanelGPU";
            PanelGPU.Size = new Size(195, 100);
            PanelGPU.TabIndex = 4;
            // 
            // lblGpuNome
            // 
            lblGpuNome.BackColor = Color.Transparent;
            lblGpuNome.Font = new Font("Castellar", 14.25F, FontStyle.Bold);
            lblGpuNome.ForeColor = Color.Maroon;
            lblGpuNome.Location = new Point(3, 0);
            lblGpuNome.Name = "lblGpuNome";
            lblGpuNome.Size = new Size(159, 20);
            lblGpuNome.TabIndex = 9;
            lblGpuNome.Text = "GPU";
            // 
            // lblGPU
            // 
            lblGPU.BackColor = Color.Transparent;
            lblGPU.Font = new Font("Castellar", 14.25F, FontStyle.Bold);
            lblGPU.ForeColor = Color.Maroon;
            lblGPU.ImageAlign = ContentAlignment.BottomCenter;
            lblGPU.Location = new Point(3, 20);
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
            lbl.Font = new Font("Castellar", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl.ForeColor = Color.WhiteSmoke;
            lbl.Location = new Point(214, 11);
            lbl.Name = "lbl";
            lbl.Size = new Size(488, 44);
            lbl.TabIndex = 5;
            lbl.Text = "PAINEL DE CONTROLE";
            // 
            // dungeonLabel1
            // 
            dungeonLabel1.AutoSize = true;
            dungeonLabel1.BackColor = Color.Transparent;
            dungeonLabel1.Font = new Font("Castellar", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel1.ForeColor = Color.FromArgb(119, 119, 119);
            dungeonLabel1.Location = new Point(228, 115);
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
            dungeonLabel6.Location = new Point(292, 45);
            dungeonLabel6.Name = "dungeonLabel6";
            dungeonLabel6.Size = new Size(687, 35);
            dungeonLabel6.TabIndex = 7;
            dungeonLabel6.Text = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━";
            // 
            // dungeonLabel7
            // 
            dungeonLabel7.AutoSize = true;
            dungeonLabel7.BackColor = Color.Transparent;
            dungeonLabel7.Font = new Font("Castellar", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dungeonLabel7.ForeColor = Color.White;
            dungeonLabel7.Location = new Point(228, 323);
            dungeonLabel7.Name = "dungeonLabel7";
            dungeonLabel7.Size = new Size(331, 23);
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
            dgvProcessos.Size = new Size(1040, 285);
            dgvProcessos.TabIndex = 9;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 29, 29);
            ClientSize = new Size(1299, 668);
            Controls.Add(dgvProcessos);
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
            Load += FormPrincipal_Load;
            SideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            PanelCPU.ResumeLayout(false);
            PanelRam.ResumeLayout(false);
            PanelDisco.ResumeLayout(false);
            PanelGPU.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProcessos).EndInit();
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
    }
}
