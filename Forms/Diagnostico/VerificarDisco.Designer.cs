namespace WinTuner.Forms.Diagnostico
{
    partial class VerificarDisco
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
            panelHeader = new ReaLTaiizor.Controls.Panel();
            headerLabel1 = new ReaLTaiizor.Controls.HeaderLabel();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            panel1 = new ReaLTaiizor.Controls.Panel();
            label5 = new Label();
            lblDadosDisco02 = new Label();
            label1 = new Label();
            lblDadosDisco01 = new Label();
            lblBuild = new Label();
            panel2 = new ReaLTaiizor.Controls.Panel();
            label2 = new Label();
            label4 = new Label();
            lblProc = new Label();
            panel3 = new ReaLTaiizor.Controls.Panel();
            label3 = new Label();
            label7 = new Label();
            label9 = new Label();
            panelHeader.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelHeader.BackColor = Color.FromArgb(29, 29, 29);
            panelHeader.Controls.Add(headerLabel1);
            panelHeader.Controls.Add(bigLabel1);
            panelHeader.EdgeColor = Color.Red;
            panelHeader.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelHeader.Location = new Point(3, -6);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(5);
            panelHeader.Size = new Size(1001, 86);
            panelHeader.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panelHeader.TabIndex = 25;
            panelHeader.Text = "W";
            // 
            // headerLabel1
            // 
            headerLabel1.AutoSize = true;
            headerLabel1.BackColor = Color.Transparent;
            headerLabel1.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            headerLabel1.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel1.Location = new Point(71, 63);
            headerLabel1.Name = "headerLabel1";
            headerLabel1.Size = new Size(508, 18);
            headerLabel1.TabIndex = 1;
            headerLabel1.Text = "Analise a integridade e o sistema de arquivos do armazenamento. ";
            // 
            // bigLabel1
            // 
            bigLabel1.AutoSize = true;
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.Font = new Font("Castellar", 24.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bigLabel1.ForeColor = Color.Red;
            bigLabel1.Location = new Point(8, 15);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(506, 40);
            bigLabel1.TabIndex = 1;
            bigLabel1.Text = "VERIFICAÇÃO DO DISCO  ";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(29, 29, 29);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblDadosDisco02);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblDadosDisco01);
            panel1.Controls.Add(lblBuild);
            panel1.Cursor = Cursors.Hand;
            panel1.EdgeColor = Color.Red;
            panel1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(12, 107);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(446, 155);
            panel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel1.TabIndex = 26;
            panel1.Text = "W";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Red;
            label5.Location = new Point(29, 5);
            label5.Name = "label5";
            label5.Size = new Size(378, 32);
            label5.TabIndex = 11;
            label5.Text = "UNIDADES DE ARMAZENAMENTO";
            // 
            // lblDadosDisco02
            // 
            lblDadosDisco02.AutoSize = true;
            lblDadosDisco02.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblDadosDisco02.ForeColor = SystemColors.Control;
            lblDadosDisco02.Location = new Point(191, 112);
            lblDadosDisco02.Name = "lblDadosDisco02";
            lblDadosDisco02.Size = new Size(71, 16);
            lblDadosDisco02.TabIndex = 7;
            lblDadosDisco02.Text = "Arquitetura";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(8, 106);
            label1.Name = "label1";
            label1.Size = new Size(110, 24);
            label1.TabIndex = 6;
            label1.Text = "Unidade02";
            // 
            // lblDadosDisco01
            // 
            lblDadosDisco01.AutoSize = true;
            lblDadosDisco01.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblDadosDisco01.ForeColor = SystemColors.Control;
            lblDadosDisco01.Location = new Point(193, 63);
            lblDadosDisco01.Name = "lblDadosDisco01";
            lblDadosDisco01.Size = new Size(69, 16);
            lblDadosDisco01.TabIndex = 5;
            lblDadosDisco01.Text = "BuildValor";
            // 
            // lblBuild
            // 
            lblBuild.AutoSize = true;
            lblBuild.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblBuild.ForeColor = SystemColors.Control;
            lblBuild.Location = new Point(10, 55);
            lblBuild.Name = "lblBuild";
            lblBuild.Size = new Size(110, 24);
            lblBuild.TabIndex = 4;
            lblBuild.Text = "Unidade01";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(29, 29, 29);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(lblProc);
            panel2.Cursor = Cursors.Hand;
            panel2.EdgeColor = Color.Red;
            panel2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel2.Location = new Point(495, 107);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(498, 155);
            panel2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel2.TabIndex = 27;
            panel2.Text = "W";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.MidnightBlue;
            label2.Location = new Point(72, 89);
            label2.Name = "label2";
            label2.Size = new Size(291, 24);
            label2.TabIndex = 11;
            label2.Text = "● PROBLEMA ENCONTRADO";
            label2.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(222, 0);
            label4.Name = "label4";
            label4.Size = new Size(93, 32);
            label4.TabIndex = 10;
            label4.Text = "STATUS";
            // 
            // lblProc
            // 
            lblProc.AutoSize = true;
            lblProc.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblProc.ForeColor = Color.Yellow;
            lblProc.Location = new Point(36, 55);
            lblProc.Name = "lblProc";
            lblProc.Size = new Size(136, 24);
            lblProc.TabIndex = 8;
            lblProc.Text = "● SAUDÁVEL";
            lblProc.Visible = false;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(29, 29, 29);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label9);
            panel3.Cursor = Cursors.Hand;
            panel3.EdgeColor = Color.Red;
            panel3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel3.Location = new Point(253, 284);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(5);
            panel3.Size = new Size(524, 197);
            panel3.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel3.TabIndex = 27;
            panel3.Text = "W";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Red;
            label3.Location = new Point(163, 5);
            label3.Name = "label3";
            label3.Size = new Size(166, 32);
            label3.TabIndex = 11;
            label3.Text = "VERIFICAÇÕES";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(8, 61);
            label7.Name = "label7";
            label7.Size = new Size(246, 24);
            label7.TabIndex = 6;
            label7.Text = "✓ Metadados do volume  ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(8, 37);
            label9.Name = "label9";
            label9.Size = new Size(228, 24);
            label9.TabIndex = 4;
            label9.Text = "✓ Sistema de arquivos  ";
            // 
            // VerificarDisco
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 29, 29);
            ClientSize = new Size(1006, 681);
            Controls.Add(panel3);
            Controls.Add(panelHeader);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "VerificarDisco";
            Text = "VerificarDisco";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ReaLTaiizor.Controls.Panel panelHeader;
        private ReaLTaiizor.Controls.HeaderLabel headerLabel1;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.Panel panel1;
        private Label label5;
        private Label lblDadosDisco02;
        private Label label1;
        private Label lblDadosDisco01;
        private Label lblBuild;
        private ReaLTaiizor.Controls.Panel panel2;
        private Label label4;
        private Label lblProc;
        private Label label2;
        private ReaLTaiizor.Controls.Panel panel3;
        private Label label3;
        private Label label7;
        private Label label9;
    }
}