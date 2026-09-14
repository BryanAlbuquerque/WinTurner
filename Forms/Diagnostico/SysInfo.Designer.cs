namespace WinTuner.Forms.Diagnostico
{
    partial class SysInfo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new ReaLTaiizor.Controls.Panel();
            headerLabel1 = new ReaLTaiizor.Controls.HeaderLabel();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();

            panel1 = new ReaLTaiizor.Controls.Panel();
            label5 = new Label();
            lblSistema = new Label();
            lblTipoSistema = new Label();
            lblVersao = new Label();
            lblDadosVersao = new Label();
            lblBuild = new Label();
            lblDadosBuild = new Label();
            label1 = new Label();
            lblDadosArquitetura = new Label();

            panel2 = new ReaLTaiizor.Controls.Panel();
            label4 = new Label();
            lblProc = new Label();
            lblDadosProcessador = new Label();

            panel3 = new ReaLTaiizor.Controls.Panel();
            label2 = new Label();
            label3 = new Label();
            lblDadosFabricante = new Label();
            label6 = new Label();
            lblDadosModelo = new Label();
            label7 = new Label();
            lblDadosMemoriaDedicada = new Label();

            panel4 = new ReaLTaiizor.Controls.Panel();
            label8 = new Label();
            label14 = new Label();
            lblDadosMemoria = new Label();
            label13 = new Label();
            lblDadosMemoriaUtilizada = new Label();
            label12 = new Label();
            lblDadosMemoriaDisponivel = new Label();
            label17 = new Label();
            label20 = new Label();
            lblDadosMemoriaVirtual = new Label();
            label23 = new Label();
            lblMemoriVirtualDisponivel = new Label();

            panel5 = new ReaLTaiizor.Controls.Panel();
            label9 = new Label();
            label11 = new Label();
            lblDadosPlacaMae = new Label();
            label22 = new Label();
            lblDadosPlaca = new Label();

            panel6 = new ReaLTaiizor.Controls.Panel();
            label16 = new Label();
            label19 = new Label();
            lblArmazenamentoTotal = new Label();
            label21 = new Label();
            lblArmazenamentoDisponivel = new Label();

            panelHeader.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();

            // 
            // Cores
            // 
            Color fundo = Color.FromArgb(15, 15, 15);
            Color card = Color.FromArgb(23, 23, 23);
            Color card2 = Color.FromArgb(26, 26, 26);
            Color borda = Color.FromArgb(48, 48, 48);
            Color vermelho = Color.FromArgb(220, 35, 35);
            Color texto = Color.FromArgb(235, 235, 235);
            Color textoSecundario = Color.FromArgb(145, 145, 145);
            Color destaque = Color.FromArgb(255, 255, 255);

            // 
            // panelHeader
            // 
            panelHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelHeader.BackColor = card2;
            panelHeader.Controls.Add(headerLabel1);
            panelHeader.Controls.Add(bigLabel1);
            panelHeader.EdgeColor = vermelho;
            panelHeader.Location = new Point(12, 12);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(5);
            panelHeader.Size = new Size(981, 100);
            panelHeader.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panelHeader.TabIndex = 0;

            // 
            // bigLabel1
            // 
            bigLabel1.AutoSize = true;
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.Font = new Font("Segoe UI Semibold", 21F, FontStyle.Bold);
            bigLabel1.ForeColor = vermelho;
            bigLabel1.Location = new Point(22, 17);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(360, 38);
            bigLabel1.TabIndex = 0;
            bigLabel1.Text = "Informações do computador";

            // 
            // headerLabel1
            // 
            headerLabel1.AutoSize = true;
            headerLabel1.BackColor = Color.Transparent;
            headerLabel1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            headerLabel1.ForeColor = textoSecundario;
            headerLabel1.Location = new Point(24, 62);
            headerLabel1.Name = "headerLabel1";
            headerLabel1.Size = new Size(370, 17);
            headerLabel1.TabIndex = 1;
            headerLabel1.Text = "Detalhes do sistema, hardware e recursos disponíveis";

            // 
            // panel1 - Sistema operacional
            // 
            panel1.BackColor = card;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblSistema);
            panel1.Controls.Add(lblTipoSistema);
            panel1.Controls.Add(lblVersao);
            panel1.Controls.Add(lblDadosVersao);
            panel1.Controls.Add(lblBuild);
            panel1.Controls.Add(lblDadosBuild);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblDadosArquitetura);
            panel1.EdgeColor = borda;
            panel1.Location = new Point(12, 128);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(470, 220);
            panel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel1.TabIndex = 1;

            // Título
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label5.ForeColor = vermelho;
            label5.Location = new Point(20, 16);
            label5.Name = "label5";
            label5.Size = new Size(151, 19);
            label5.TabIndex = 0;
            label5.Text = "SISTEMA OPERACIONAL";

            // Labels
            ConfigurarLabel(lblSistema, "Windows", new Point(20, 54), texto, 10F, FontStyle.Regular);
            ConfigurarLabel(lblVersao, "Versão", new Point(20, 92), texto, 10F, FontStyle.Regular);
            ConfigurarLabel(lblBuild, "Build", new Point(20, 130), texto, 10F, FontStyle.Regular);
            ConfigurarLabel(label1, "Arquitetura", new Point(20, 168), texto, 10F, FontStyle.Regular);

            // Valores
            ConfigurarValor(lblTipoSistema, new Point(165, 52), 285, 24);
            ConfigurarValor(lblDadosVersao, new Point(165, 90), 285, 24);
            ConfigurarValor(lblDadosBuild, new Point(165, 128), 285, 24);
            ConfigurarValor(lblDadosArquitetura, new Point(165, 166), 285, 24);

            // 
            // panel2 - Processador
            // 
            panel2.BackColor = card;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(lblProc);
            panel2.Controls.Add(lblDadosProcessador);
            panel2.EdgeColor = borda;
            panel2.Location = new Point(498, 128);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(495, 100);
            panel2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel2.TabIndex = 2;

            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label4.ForeColor = vermelho;
            label4.Location = new Point(20, 15);
            label4.Name = "label4";
            label4.Size = new Size(101, 19);
            label4.TabIndex = 0;
            label4.Text = "PROCESSADOR";

            ConfigurarLabel(lblProc, "Processador", new Point(20, 53), texto, 10F, FontStyle.Regular);
            ConfigurarValor(lblDadosProcessador, new Point(125, 51), 350, 25);

            // 
            // panel3 - GPU
            // 
            panel3.BackColor = card;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(lblDadosFabricante);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(lblDadosModelo);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(lblDadosMemoriaDedicada);
            panel3.EdgeColor = borda;
            panel3.Location = new Point(12, 365);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(5);
            panel3.Size = new Size(470, 166);
            panel3.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel3.TabIndex = 3;

            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label2.ForeColor = vermelho;
            label2.Location = new Point(20, 15);
            label2.Name = "label2";
            label2.Size = new Size(110, 19);
            label2.TabIndex = 0;
            label2.Text = "PLACA DE VÍDEO";

            ConfigurarLabel(label3, "Fabricante", new Point(20, 54), textoSecundario, 9.5F, FontStyle.Regular);
            ConfigurarLabel(label6, "Modelo", new Point(20, 87), textoSecundario, 9.5F, FontStyle.Regular);
            ConfigurarLabel(label7, "Memória dedicada", new Point(20, 120), textoSecundario, 9.5F, FontStyle.Regular);

            ConfigurarValor(lblDadosFabricante, new Point(145, 52), 300, 23);
            ConfigurarValor(lblDadosModelo, new Point(145, 85), 300, 23);
            ConfigurarValor(lblDadosMemoriaDedicada, new Point(145, 118), 300, 23);

            // 
            // panel4 - Memória
            // 
            panel4.BackColor = card;
            panel4.Controls.Add(label8);
            panel4.Controls.Add(label14);
            panel4.Controls.Add(lblDadosMemoria);
            panel4.Controls.Add(label13);
            panel4.Controls.Add(lblDadosMemoriaUtilizada);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(lblDadosMemoriaDisponivel);
            panel4.Controls.Add(label17);
            panel4.Controls.Add(label20);
            panel4.Controls.Add(lblDadosMemoriaVirtual);
            panel4.Controls.Add(label23);
            panel4.Controls.Add(lblMemoriVirtualDisponivel);
            panel4.EdgeColor = borda;
            panel4.Location = new Point(498, 245);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(5);
            panel4.Size = new Size(495, 286);
            panel4.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel4.TabIndex = 4;

            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label8.ForeColor = vermelho;
            label8.Location = new Point(20, 15);
            label8.Name = "label8";
            label8.Size = new Size(100, 19);
            label8.TabIndex = 0;
            label8.Text = "MEMÓRIA RAM";

            ConfigurarLabel(label14, "Memória instalada", new Point(20, 54), textoSecundario, 9.5F, FontStyle.Regular);
            ConfigurarLabel(label13, "Memória utilizada", new Point(20, 88), textoSecundario, 9.5F, FontStyle.Regular);
            ConfigurarLabel(label12, "Memória disponível", new Point(20, 122), textoSecundario, 9.5F, FontStyle.Regular);

            ConfigurarValor(lblDadosMemoria, new Point(220, 52), 240, 23, ContentAlignment.MiddleRight);
            ConfigurarValor(lblDadosMemoriaUtilizada, new Point(220, 86), 240, 23, ContentAlignment.MiddleRight);
            ConfigurarValor(lblDadosMemoriaDisponivel, new Point(220, 120), 240, 23, ContentAlignment.MiddleRight);

            label17.AutoSize = true;
            label17.BackColor = Color.Transparent;
            label17.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label17.ForeColor = vermelho;
            label17.Location = new Point(20, 163);
            label17.Name = "label17";
            label17.Size = new Size(120, 15);
            label17.TabIndex = 10;
            label17.Text = "MEMÓRIA VIRTUAL";

            ConfigurarLabel(label20, "Total", new Point(20, 202), textoSecundario, 9.5F, FontStyle.Regular);
            ConfigurarLabel(label23, "Disponível", new Point(245, 202), textoSecundario, 9.5F, FontStyle.Regular);

            ConfigurarValor(lblDadosMemoriaVirtual, new Point(80, 200), 140, 23, ContentAlignment.MiddleRight);
            ConfigurarValor(lblMemoriVirtualDisponivel, new Point(320, 200), 140, 23, ContentAlignment.MiddleRight);

            // 
            // panel5 - Placa mãe
            // 
            panel5.BackColor = card;
            panel5.Controls.Add(label9);
            panel5.Controls.Add(label11);
            panel5.Controls.Add(lblDadosPlacaMae);
            panel5.Controls.Add(label22);
            panel5.Controls.Add(lblDadosPlaca);
            panel5.EdgeColor = borda;
            panel5.Location = new Point(12, 548);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(5);
            panel5.Size = new Size(470, 133);
            panel5.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel5.TabIndex = 5;

            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label9.ForeColor = vermelho;
            label9.Location = new Point(20, 15);
            label9.Name = "label9";
            label9.Size = new Size(89, 19);
            label9.TabIndex = 0;
            label9.Text = "PLACA-MÃE";

            ConfigurarLabel(label11, "Fabricante", new Point(20, 53), textoSecundario, 9.5F, FontStyle.Regular);
            ConfigurarLabel(label22, "Modelo", new Point(20, 88), textoSecundario, 9.5F, FontStyle.Regular);

            ConfigurarValor(lblDadosPlacaMae, new Point(125, 51), 320, 23);
            ConfigurarValor(lblDadosPlaca, new Point(125, 86), 320, 23);

            // 
            // panel6 - Armazenamento
            // 
            panel6.BackColor = card;
            panel6.Controls.Add(label16);
            panel6.Controls.Add(label19);
            panel6.Controls.Add(lblArmazenamentoTotal);
            panel6.Controls.Add(label21);
            panel6.Controls.Add(lblArmazenamentoDisponivel);
            panel6.EdgeColor = borda;
            panel6.Location = new Point(498, 548);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(5);
            panel6.Size = new Size(495, 133);
            panel6.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel6.TabIndex = 6;

            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label16.ForeColor = vermelho;
            label16.Location = new Point(20, 15);
            label16.Name = "label16";
            label16.Size = new Size(113, 19);
            label16.TabIndex = 0;
            label16.Text = "ARMAZENAMENTO";

            ConfigurarLabel(label19, "Capacidade total", new Point(20, 53), textoSecundario, 9.5F, FontStyle.Regular);
            ConfigurarLabel(label21, "Espaço disponível", new Point(20, 88), textoSecundario, 9.5F, FontStyle.Regular);

            ConfigurarValor(
                lblArmazenamentoTotal,
                new Point(275, 51),
                185,
                23,
                ContentAlignment.MiddleRight
            );

            ConfigurarValor(
                lblArmazenamentoDisponivel,
                new Point(275, 86),
                185,
                23,
                ContentAlignment.MiddleRight
            );

            // 
            // SysInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = fundo;
            ClientSize = new Size(1005, 765);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1020, 720);
            Name = "SysInfo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WinTurner - Informações do Computador";

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

        private void ConfigurarLabel(
            Label label,
            string texto,
            Point localizacao,
            Color cor,
            float tamanho,
            FontStyle estilo)
        {
            label.AutoSize = true;
            label.BackColor = Color.Transparent;
            label.Font = new Font("Segoe UI", tamanho, estilo);
            label.ForeColor = cor;
            label.Location = localizacao;
            label.Text = texto;
        }

        private void ConfigurarValor(
            Label label,
            Point localizacao,
            int largura,
            int altura,
            ContentAlignment alinhamento = ContentAlignment.MiddleLeft)
        {
            label.AutoSize = false;
            label.BackColor = Color.Transparent;
            label.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(235, 235, 235);
            label.Location = localizacao;
            label.Size = new Size(largura, altura);
            label.TextAlign = alinhamento;
            label.AutoEllipsis = true;
        }

        #endregion

        private ReaLTaiizor.Controls.Panel panelHeader;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.HeaderLabel headerLabel1;

        private ReaLTaiizor.Controls.Panel panel1;
        private Label label5;
        private Label lblSistema;
        private Label lblTipoSistema;
        private Label lblVersao;
        private Label lblDadosVersao;
        private Label lblBuild;
        private Label lblDadosBuild;
        private Label label1;
        private Label lblDadosArquitetura;

        private ReaLTaiizor.Controls.Panel panel2;
        private Label label4;
        private Label lblProc;
        private Label lblDadosProcessador;

        private ReaLTaiizor.Controls.Panel panel3;
        private Label label2;
        private Label label3;
        private Label lblDadosFabricante;
        private Label label6;
        private Label lblDadosModelo;
        private Label label7;
        private Label lblDadosMemoriaDedicada;

        private ReaLTaiizor.Controls.Panel panel4;
        private Label label8;
        private Label label14;
        private Label lblDadosMemoria;
        private Label label13;
        private Label lblDadosMemoriaUtilizada;
        private Label label12;
        private Label lblDadosMemoriaDisponivel;
        private Label label17;
        private Label label20;
        private Label lblDadosMemoriaVirtual;
        private Label label23;
        private Label lblMemoriVirtualDisponivel;

        private ReaLTaiizor.Controls.Panel panel5;
        private Label label9;
        private Label label11;
        private Label lblDadosPlacaMae;
        private Label label22;
        private Label lblDadosPlaca;

        private ReaLTaiizor.Controls.Panel panel6;
        private Label label16;
        private Label label19;
        private Label lblArmazenamentoTotal;
        private Label label21;
        private Label lblArmazenamentoDisponivel;
    }
}