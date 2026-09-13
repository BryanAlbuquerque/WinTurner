namespace WinTuner.Forms.Diagnostico
{
    partial class SysInfo
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
            lblDadosArquitetura = new Label();
            label1 = new Label();
            lblDadosBuild = new Label();
            lblBuild = new Label();
            lblDadosVersao = new Label();
            lblVersao = new Label();
            lblTipoSistema = new Label();
            lblSistema = new Label();
            panel2 = new ReaLTaiizor.Controls.Panel();
            label4 = new Label();
            lblDadosProcessador = new Label();
            lblProc = new Label();
            panel3 = new ReaLTaiizor.Controls.Panel();
            lblDadosMemoriaDedicada = new Label();
            lblDadosModelo = new Label();
            lblDadosFabricante = new Label();
            label7 = new Label();
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel4 = new ReaLTaiizor.Controls.Panel();
            lblMemoriVirtualDisponivel = new Label();
            lblDadosMemoriaDisponivel = new Label();
            label23 = new Label();
            label8 = new Label();
            lblDadosMemoriaUtilizada = new Label();
            lblDadosMemoria = new Label();
            lblDadosMemoriaVirtual = new Label();
            label17 = new Label();
            label20 = new Label();
            label14 = new Label();
            label12 = new Label();
            label13 = new Label();
            panel5 = new ReaLTaiizor.Controls.Panel();
            lblDadosPlaca = new Label();
            label22 = new Label();
            label9 = new Label();
            lblDadosPlacaMae = new Label();
            label11 = new Label();
            panel6 = new ReaLTaiizor.Controls.Panel();
            label16 = new Label();
            lblArmazenamentoDisponivel = new Label();
            lblArmazenamentoTotal = new Label();
            label19 = new Label();
            label21 = new Label();
            panelHeader.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
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
            panelHeader.Location = new Point(3, 3);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(5);
            panelHeader.Size = new Size(1001, 86);
            panelHeader.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panelHeader.TabIndex = 0;
            panelHeader.Text = "W";
            // 
            // headerLabel1
            // 
            headerLabel1.AutoSize = true;
            headerLabel1.BackColor = Color.Transparent;
            headerLabel1.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            headerLabel1.ForeColor = Color.FromArgb(255, 255, 255);
            headerLabel1.Location = new Point(0, 63);
            headerLabel1.Name = "headerLabel1";
            headerLabel1.Size = new Size(421, 18);
            headerLabel1.TabIndex = 1;
            headerLabel1.Text = " Detalhes do sistema, hardware e recursos disponíveis";
            // 
            // bigLabel1
            // 
            bigLabel1.AutoSize = true;
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.Font = new Font("Castellar", 24.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bigLabel1.ForeColor = Color.Red;
            bigLabel1.Location = new Point(6, 6);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(729, 40);
            bigLabel1.TabIndex = 1;
            bigLabel1.Text = "INFORMAÇÕES DO COMPUTADOR     ";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(29, 29, 29);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblDadosArquitetura);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblDadosBuild);
            panel1.Controls.Add(lblBuild);
            panel1.Controls.Add(lblDadosVersao);
            panel1.Controls.Add(lblVersao);
            panel1.Controls.Add(lblTipoSistema);
            panel1.Controls.Add(lblSistema);
            panel1.Cursor = Cursors.Hand;
            panel1.EdgeColor = Color.Red;
            panel1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(12, 116);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(446, 220);
            panel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel1.TabIndex = 2;
            panel1.Text = "W";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Red;
            label5.Location = new Point(92, -3);
            label5.Name = "label5";
            label5.Size = new Size(270, 32);
            label5.TabIndex = 11;
            label5.Text = "SISTEMA OPERACIONAL";
            // 
            // lblDadosArquitetura
            // 
            lblDadosArquitetura.AutoSize = true;
            lblDadosArquitetura.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblDadosArquitetura.ForeColor = SystemColors.Control;
            lblDadosArquitetura.Location = new Point(169, 186);
            lblDadosArquitetura.Name = "lblDadosArquitetura";
            lblDadosArquitetura.Size = new Size(71, 16);
            lblDadosArquitetura.TabIndex = 7;
            lblDadosArquitetura.Text = "Arquitetura";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(10, 180);
            label1.Name = "label1";
            label1.Size = new Size(112, 24);
            label1.TabIndex = 6;
            label1.Text = "Arquitetura";
            // 
            // lblDadosBuild
            // 
            lblDadosBuild.AutoSize = true;
            lblDadosBuild.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblDadosBuild.ForeColor = SystemColors.Control;
            lblDadosBuild.Location = new Point(169, 141);
            lblDadosBuild.Name = "lblDadosBuild";
            lblDadosBuild.Size = new Size(69, 16);
            lblDadosBuild.TabIndex = 5;
            lblDadosBuild.Text = "BuildValor";
            // 
            // lblBuild
            // 
            lblBuild.AutoSize = true;
            lblBuild.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblBuild.ForeColor = SystemColors.Control;
            lblBuild.Location = new Point(10, 135);
            lblBuild.Name = "lblBuild";
            lblBuild.Size = new Size(57, 24);
            lblBuild.TabIndex = 4;
            lblBuild.Text = "Build";
            // 
            // lblDadosVersao
            // 
            lblDadosVersao.AutoSize = true;
            lblDadosVersao.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblDadosVersao.ForeColor = SystemColors.Control;
            lblDadosVersao.Location = new Point(169, 94);
            lblDadosVersao.Name = "lblDadosVersao";
            lblDadosVersao.Size = new Size(83, 16);
            lblDadosVersao.TabIndex = 3;
            lblDadosVersao.Text = "VersaoValor";
            // 
            // lblVersao
            // 
            lblVersao.AutoSize = true;
            lblVersao.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblVersao.ForeColor = SystemColors.Control;
            lblVersao.Location = new Point(10, 88);
            lblVersao.Name = "lblVersao";
            lblVersao.Size = new Size(76, 24);
            lblVersao.TabIndex = 2;
            lblVersao.Text = "Versão";
            // 
            // lblTipoSistema
            // 
            lblTipoSistema.AutoSize = true;
            lblTipoSistema.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblTipoSistema.ForeColor = SystemColors.Control;
            lblTipoSistema.Location = new Point(169, 53);
            lblTipoSistema.Name = "lblTipoSistema";
            lblTipoSistema.Size = new Size(84, 16);
            lblTipoSistema.TabIndex = 1;
            lblTipoSistema.Text = "TipoSistema";
            // 
            // lblSistema
            // 
            lblSistema.AutoSize = true;
            lblSistema.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblSistema.ForeColor = SystemColors.Control;
            lblSistema.Location = new Point(10, 47);
            lblSistema.Name = "lblSistema";
            lblSistema.Size = new Size(95, 24);
            lblSistema.TabIndex = 0;
            lblSistema.Text = "Windows";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(29, 29, 29);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(lblDadosProcessador);
            panel2.Controls.Add(lblProc);
            panel2.Cursor = Cursors.Hand;
            panel2.EdgeColor = Color.Red;
            panel2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel2.Location = new Point(495, 116);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(498, 94);
            panel2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel2.TabIndex = 3;
            panel2.Text = "W";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(111, 0);
            label4.Name = "label4";
            label4.Size = new Size(176, 32);
            label4.TabIndex = 10;
            label4.Text = "PROCESSADOR";
            // 
            // lblDadosProcessador
            // 
            lblDadosProcessador.AutoSize = true;
            lblDadosProcessador.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblDadosProcessador.ForeColor = SystemColors.Control;
            lblDadosProcessador.Location = new Point(203, 55);
            lblDadosProcessador.Name = "lblDadosProcessador";
            lblDadosProcessador.Size = new Size(84, 16);
            lblDadosProcessador.TabIndex = 9;
            lblDadosProcessador.Text = "TipoSistema";
            // 
            // lblProc
            // 
            lblProc.AutoSize = true;
            lblProc.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            lblProc.ForeColor = SystemColors.Control;
            lblProc.Location = new Point(8, 53);
            lblProc.Name = "lblProc";
            lblProc.Size = new Size(127, 24);
            lblProc.TabIndex = 8;
            lblProc.Text = "Processador";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(29, 29, 29);
            panel3.Controls.Add(lblDadosMemoriaDedicada);
            panel3.Controls.Add(lblDadosModelo);
            panel3.Controls.Add(lblDadosFabricante);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Cursor = Cursors.Hand;
            panel3.EdgeColor = Color.Red;
            panel3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel3.Location = new Point(14, 353);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(5);
            panel3.Size = new Size(475, 166);
            panel3.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel3.TabIndex = 3;
            panel3.Text = "W";
            // 
            // lblDadosMemoriaDedicada
            // 
            lblDadosMemoriaDedicada.AutoSize = true;
            lblDadosMemoriaDedicada.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblDadosMemoriaDedicada.ForeColor = SystemColors.Control;
            lblDadosMemoriaDedicada.Location = new Point(191, 125);
            lblDadosMemoriaDedicada.Name = "lblDadosMemoriaDedicada";
            lblDadosMemoriaDedicada.Size = new Size(60, 16);
            lblDadosMemoriaDedicada.TabIndex = 17;
            lblDadosMemoriaDedicada.Text = "memoria";
            // 
            // lblDadosModelo
            // 
            lblDadosModelo.AutoSize = true;
            lblDadosModelo.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblDadosModelo.ForeColor = SystemColors.Control;
            lblDadosModelo.Location = new Point(144, 86);
            lblDadosModelo.Name = "lblDadosModelo";
            lblDadosModelo.Size = new Size(53, 16);
            lblDadosModelo.TabIndex = 16;
            lblDadosModelo.Text = "modelo";
            // 
            // lblDadosFabricante
            // 
            lblDadosFabricante.AutoSize = true;
            lblDadosFabricante.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblDadosFabricante.ForeColor = SystemColors.Control;
            lblDadosFabricante.Location = new Point(131, 52);
            lblDadosFabricante.Name = "lblDadosFabricante";
            lblDadosFabricante.Size = new Size(66, 16);
            lblDadosFabricante.TabIndex = 15;
            lblDadosFabricante.Text = "fabricante";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(-2, 119);
            label7.Name = "label7";
            label7.Size = new Size(185, 24);
            label7.TabIndex = 14;
            label7.Text = "Memoria Dedicada";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(-2, 80);
            label6.Name = "label6";
            label6.Size = new Size(80, 24);
            label6.TabIndex = 13;
            label6.Text = "Modelo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(-2, 46);
            label3.Name = "label3";
            label3.Size = new Size(109, 24);
            label3.TabIndex = 12;
            label3.Text = "Fabricante";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Red;
            label2.Location = new Point(104, 5);
            label2.Name = "label2";
            label2.Size = new Size(202, 32);
            label2.TabIndex = 12;
            label2.Text = "PLACA DE VÍDEO ";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.FromArgb(29, 29, 29);
            panel4.Controls.Add(lblMemoriVirtualDisponivel);
            panel4.Controls.Add(lblDadosMemoriaDisponivel);
            panel4.Controls.Add(label23);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(lblDadosMemoriaUtilizada);
            panel4.Controls.Add(lblDadosMemoria);
            panel4.Controls.Add(lblDadosMemoriaVirtual);
            panel4.Controls.Add(label17);
            panel4.Controls.Add(label20);
            panel4.Controls.Add(label14);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(label13);
            panel4.Cursor = Cursors.Hand;
            panel4.EdgeColor = Color.Red;
            panel4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel4.Location = new Point(495, 235);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(5);
            panel4.Size = new Size(498, 275);
            panel4.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel4.TabIndex = 4;
            panel4.Text = "W";
            // 
            // lblMemoriVirtualDisponivel
            // 
            lblMemoriVirtualDisponivel.AutoSize = true;
            lblMemoriVirtualDisponivel.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblMemoriVirtualDisponivel.ForeColor = SystemColors.Control;
            lblMemoriVirtualDisponivel.Location = new Point(468, 238);
            lblMemoriVirtualDisponivel.Name = "lblMemoriVirtualDisponivel";
            lblMemoriVirtualDisponivel.Size = new Size(26, 16);
            lblMemoriVirtualDisponivel.TabIndex = 14;
            lblMemoriVirtualDisponivel.Text = "mb";
            // 
            // lblDadosMemoriaDisponivel
            // 
            lblDadosMemoriaDisponivel.AutoSize = true;
            lblDadosMemoriaDisponivel.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblDadosMemoriaDisponivel.ForeColor = SystemColors.Control;
            lblDadosMemoriaDisponivel.Location = new Point(383, 152);
            lblDadosMemoriaDisponivel.Name = "lblDadosMemoriaDisponivel";
            lblDadosMemoriaDisponivel.Size = new Size(60, 16);
            lblDadosMemoriaDisponivel.TabIndex = 23;
            lblDadosMemoriaDisponivel.Text = "memoria";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label23.ForeColor = SystemColors.Control;
            label23.Location = new Point(324, 232);
            label23.Name = "label23";
            label23.Size = new Size(119, 24);
            label23.TabIndex = 13;
            label23.Text = "Disponível :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Red;
            label8.Location = new Point(148, 0);
            label8.Name = "label8";
            label8.Size = new Size(188, 32);
            label8.TabIndex = 11;
            label8.Text = "MEMÓRIA RAM ";
            // 
            // lblDadosMemoriaUtilizada
            // 
            lblDadosMemoriaUtilizada.AutoSize = true;
            lblDadosMemoriaUtilizada.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblDadosMemoriaUtilizada.ForeColor = SystemColors.Control;
            lblDadosMemoriaUtilizada.Location = new Point(383, 102);
            lblDadosMemoriaUtilizada.Name = "lblDadosMemoriaUtilizada";
            lblDadosMemoriaUtilizada.Size = new Size(60, 16);
            lblDadosMemoriaUtilizada.TabIndex = 22;
            lblDadosMemoriaUtilizada.Text = "memoria";
            // 
            // lblDadosMemoria
            // 
            lblDadosMemoria.AutoSize = true;
            lblDadosMemoria.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblDadosMemoria.ForeColor = SystemColors.Control;
            lblDadosMemoria.Location = new Point(383, 54);
            lblDadosMemoria.Name = "lblDadosMemoria";
            lblDadosMemoria.Size = new Size(60, 16);
            lblDadosMemoria.TabIndex = 21;
            lblDadosMemoria.Text = "memoria";
            // 
            // lblDadosMemoriaVirtual
            // 
            lblDadosMemoriaVirtual.AutoSize = true;
            lblDadosMemoriaVirtual.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblDadosMemoriaVirtual.ForeColor = SystemColors.Control;
            lblDadosMemoriaVirtual.Location = new Point(103, 240);
            lblDadosMemoriaVirtual.Name = "lblDadosMemoriaVirtual";
            lblDadosMemoriaVirtual.Size = new Size(26, 16);
            lblDadosMemoriaVirtual.TabIndex = 9;
            lblDadosMemoriaVirtual.Text = "mb";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.ForeColor = Color.Red;
            label17.Location = new Point(112, 195);
            label17.Name = "label17";
            label17.Size = new Size(246, 32);
            label17.TabIndex = 10;
            label17.Text = "MEMÓRIA VIRTUAL    ";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label20.ForeColor = SystemColors.Control;
            label20.Location = new Point(8, 234);
            label20.Name = "label20";
            label20.Size = new Size(89, 24);
            label20.TabIndex = 8;
            label20.Text = "TOTAL :";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label14.ForeColor = SystemColors.Control;
            label14.Location = new Point(15, 46);
            label14.Name = "label14";
            label14.Size = new Size(179, 24);
            label14.TabIndex = 18;
            label14.Text = "Memória Instalada";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label12.ForeColor = SystemColors.Control;
            label12.Location = new Point(15, 146);
            label12.Name = "label12";
            label12.Size = new Size(192, 24);
            label12.TabIndex = 20;
            label12.Text = "Memória disponível";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label13.ForeColor = SystemColors.Control;
            label13.Location = new Point(15, 96);
            label13.Name = "label13";
            label13.Size = new Size(173, 24);
            label13.TabIndex = 19;
            label13.Text = "Memória utilizada";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel5.BackColor = Color.FromArgb(29, 29, 29);
            panel5.Controls.Add(lblDadosPlaca);
            panel5.Controls.Add(label22);
            panel5.Controls.Add(label9);
            panel5.Controls.Add(lblDadosPlacaMae);
            panel5.Controls.Add(label11);
            panel5.Cursor = Cursors.Hand;
            panel5.EdgeColor = Color.Red;
            panel5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel5.Location = new Point(12, 538);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(5);
            panel5.Size = new Size(446, 143);
            panel5.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel5.TabIndex = 11;
            panel5.Text = "W";
            // 
            // lblDadosPlaca
            // 
            lblDadosPlaca.AutoSize = true;
            lblDadosPlaca.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblDadosPlaca.ForeColor = SystemColors.Control;
            lblDadosPlaca.Location = new Point(164, 102);
            lblDadosPlaca.Name = "lblDadosPlaca";
            lblDadosPlaca.Size = new Size(35, 16);
            lblDadosPlaca.TabIndex = 12;
            lblDadosPlaca.Text = "Tipo";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label22.ForeColor = SystemColors.Control;
            label22.Location = new Point(8, 96);
            label22.Name = "label22";
            label22.Size = new Size(80, 24);
            label22.TabIndex = 11;
            label22.Text = "Modelo";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.Red;
            label9.Location = new Point(111, 0);
            label9.Name = "label9";
            label9.Size = new Size(140, 32);
            label9.TabIndex = 10;
            label9.Text = "PLACA MÃE";
            // 
            // lblDadosPlacaMae
            // 
            lblDadosPlacaMae.AutoSize = true;
            lblDadosPlacaMae.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblDadosPlacaMae.ForeColor = SystemColors.Control;
            lblDadosPlacaMae.Location = new Point(164, 53);
            lblDadosPlacaMae.Name = "lblDadosPlacaMae";
            lblDadosPlacaMae.Size = new Size(35, 16);
            lblDadosPlacaMae.TabIndex = 9;
            lblDadosPlacaMae.Text = "Tipo";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label11.ForeColor = SystemColors.Control;
            label11.Location = new Point(8, 47);
            label11.Name = "label11";
            label11.Size = new Size(109, 24);
            label11.TabIndex = 8;
            label11.Text = "Fabricante";
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel6.BackColor = Color.FromArgb(29, 29, 29);
            panel6.Controls.Add(label16);
            panel6.Controls.Add(lblArmazenamentoDisponivel);
            panel6.Controls.Add(lblArmazenamentoTotal);
            panel6.Controls.Add(label19);
            panel6.Controls.Add(label21);
            panel6.Cursor = Cursors.Hand;
            panel6.EdgeColor = Color.Red;
            panel6.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel6.Location = new Point(495, 533);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(5);
            panel6.Size = new Size(498, 148);
            panel6.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel6.TabIndex = 24;
            panel6.Text = "W";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ForeColor = Color.Red;
            label16.Location = new Point(112, 1);
            label16.Name = "label16";
            label16.Size = new Size(222, 32);
            label16.TabIndex = 11;
            label16.Text = "ARMAZENAMENTO";
            // 
            // lblArmazenamentoDisponivel
            // 
            lblArmazenamentoDisponivel.AutoSize = true;
            lblArmazenamentoDisponivel.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblArmazenamentoDisponivel.ForeColor = SystemColors.Control;
            lblArmazenamentoDisponivel.Location = new Point(349, 107);
            lblArmazenamentoDisponivel.Name = "lblArmazenamentoDisponivel";
            lblArmazenamentoDisponivel.Size = new Size(104, 16);
            lblArmazenamentoDisponivel.TabIndex = 22;
            lblArmazenamentoDisponivel.Text = "armazenamento";
            // 
            // lblArmazenamentoTotal
            // 
            lblArmazenamentoTotal.AutoSize = true;
            lblArmazenamentoTotal.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblArmazenamentoTotal.ForeColor = SystemColors.Control;
            lblArmazenamentoTotal.Location = new Point(349, 58);
            lblArmazenamentoTotal.Name = "lblArmazenamentoTotal";
            lblArmazenamentoTotal.Size = new Size(104, 16);
            lblArmazenamentoTotal.TabIndex = 21;
            lblArmazenamentoTotal.Text = "armazenamento";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label19.ForeColor = SystemColors.Control;
            label19.Location = new Point(15, 52);
            label19.Name = "label19";
            label19.Size = new Size(214, 24);
            label19.TabIndex = 18;
            label19.Text = "Armazenamento Total";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label21.ForeColor = SystemColors.Control;
            label21.Location = new Point(15, 101);
            label21.Name = "label21";
            label21.Size = new Size(181, 24);
            label21.TabIndex = 19;
            label21.Text = "Espaço disponivel";
            // 
            // SysInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 29, 29);
            ClientSize = new Size(1005, 765);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panelHeader);
            Name = "SysInfo";
            Text = "SysInfo";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.Panel panelHeader;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.HeaderLabel headerLabel1;
        private ReaLTaiizor.Controls.Panel panel1;
        private ReaLTaiizor.Controls.Panel panel2;
        private ReaLTaiizor.Controls.Panel panel3;
        private Label lblTipoSistema;
        private Label lblSistema;
        private Label lblVersao;
        private Label lblDadosVersao;
        private Label lblDadosBuild;
        private Label lblBuild;
        private Label lblDadosArquitetura;
        private Label label1;
        private ReaLTaiizor.Controls.Panel panel4;
        private Label label5;
        private Label label4;
        private Label lblDadosProcessador;
        private Label lblProc;
        private Label label2;
        private Label label7;
        private Label label6;
        private Label label3;
        private Label lblDadosMemoriaDedicada;
        private Label lblDadosModelo;
        private Label lblDadosFabricante;
        private Label label8;
        private Label lblDadosMemoriaDisponivel;
        private Label lblDadosMemoriaUtilizada;
        private Label lblDadosMemoria;
        private Label label14;
        private Label label12;
        private Label label13;
        private ReaLTaiizor.Controls.Panel panel5;
        private Label label9;
        private Label lblDadosPlacaMae;
        private Label label11;
        private ReaLTaiizor.Controls.Panel panel6;
        private Label label16;
        private Label lblArmazenamentoDisponivel;
        private Label lblArmazenamentoTotal;
        private Label label19;
        private Label label21;
        private Label lblDadosPlaca;
        private Label label22;
        private Label label17;
        private Label lblDadosMemoriaVirtual;
        private Label label20;
        private Label lblMemoriVirtualDisponivel;
        private Label label23;
    }
}