namespace WinTuner.Forms.Diagnostico
{
    partial class VerificarDisco
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            _cancellationTokenSource?.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new ReaLTaiizor.Controls.Panel();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            headerLabel1 = new ReaLTaiizor.Controls.HeaderLabel();

            panelDisco = new ReaLTaiizor.Controls.Panel();
            lblTituloDisco = new Label();
            lblUnidade = new Label();
            lblDadosDisco01 = new Label();
            lblVolume = new Label();
            lblDadosDisco02 = new Label();
            lblSistemaArquivos = new Label();
            lblCapacidade = new Label();
            lblUtilizado = new Label();
            lblDisponivel = new Label();
            lblTituloSistemaArquivos = new Label();
            lblTituloCapacidade = new Label();
            lblTituloUtilizado = new Label();
            lblTituloDisponivel = new Label();

            panelStatus = new ReaLTaiizor.Controls.Panel();
            lblTituloStatus = new Label();
            lblStatus = new Label();
            lblDescricaoStatus = new Label();

            panelVerificacao = new ReaLTaiizor.Controls.Panel();
            lblTituloVerificacao = new Label();
            lblEtapa1 = new Label();
            lblEtapa2 = new Label();
            lblEtapa3 = new Label();
            btnVerificar = new Button();
            progressBar = new ProgressBar();

            panelResultado = new ReaLTaiizor.Controls.Panel();
            lblTituloResultado = new Label();
            lblResultado = new Label();

            panelHeader.SuspendLayout();
            panelDisco.SuspendLayout();
            panelStatus.SuspendLayout();
            panelVerificacao.SuspendLayout();
            panelResultado.SuspendLayout();
            SuspendLayout();

            Color fundo = Color.FromArgb(15, 15, 15);
            Color card = Color.FromArgb(23, 23, 23);
            Color card2 = Color.FromArgb(26, 26, 26);
            Color borda = Color.FromArgb(48, 48, 48);
            Color vermelho = Color.FromArgb(220, 35, 35);
            Color texto = Color.FromArgb(235, 235, 235);
            Color textoSecundario = Color.FromArgb(145, 145, 145);

            // 
            // panelHeader
            // 
            panelHeader.BackColor = card2;
            panelHeader.Controls.Add(bigLabel1);
            panelHeader.Controls.Add(headerLabel1);
            panelHeader.EdgeColor = vermelho;
            panelHeader.Location = new Point(12, 12);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(5);
            panelHeader.Size = new Size(981, 100);
            panelHeader.SmoothingType =
                System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panelHeader.TabIndex = 0;

            // 
            // bigLabel1
            // 
            bigLabel1.AutoSize = true;
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.Font =
                new Font("Segoe UI Semibold", 21F, FontStyle.Bold);
            bigLabel1.ForeColor = vermelho;
            bigLabel1.Location = new Point(22, 17);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(310, 38);
            bigLabel1.TabIndex = 0;
            bigLabel1.Text = "Verificação do disco";

            // 
            // headerLabel1
            // 
            headerLabel1.AutoSize = true;
            headerLabel1.BackColor = Color.Transparent;
            headerLabel1.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Regular);
            headerLabel1.ForeColor = textoSecundario;
            headerLabel1.Location = new Point(24, 62);
            headerLabel1.Name = "headerLabel1";
            headerLabel1.Size = new Size(510, 17);
            headerLabel1.TabIndex = 1;
            headerLabel1.Text =
                "Analise a integridade e o sistema de arquivos do armazenamento.";

            // 
            // panelDisco
            // 
            panelDisco.BackColor = card;
            panelDisco.Controls.Add(lblTituloDisco);
            panelDisco.Controls.Add(lblUnidade);
            panelDisco.Controls.Add(lblDadosDisco01);
            panelDisco.Controls.Add(lblVolume);
            panelDisco.Controls.Add(lblDadosDisco02);
            panelDisco.Controls.Add(lblTituloSistemaArquivos);
            panelDisco.Controls.Add(lblSistemaArquivos);
            panelDisco.Controls.Add(lblTituloCapacidade);
            panelDisco.Controls.Add(lblCapacidade);
            panelDisco.Controls.Add(lblTituloUtilizado);
            panelDisco.Controls.Add(lblUtilizado);
            panelDisco.Controls.Add(lblTituloDisponivel);
            panelDisco.Controls.Add(lblDisponivel);
            panelDisco.EdgeColor = borda;
            panelDisco.Location = new Point(12, 128);
            panelDisco.Name = "panelDisco";
            panelDisco.Padding = new Padding(5);
            panelDisco.Size = new Size(480, 220);
            panelDisco.SmoothingType =
                System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panelDisco.TabIndex = 1;

            // Título
            lblTituloDisco.AutoSize = true;
            lblTituloDisco.BackColor = Color.Transparent;
            lblTituloDisco.Font =
                new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTituloDisco.ForeColor = vermelho;
            lblTituloDisco.Location = new Point(20, 15);
            lblTituloDisco.Name = "lblTituloDisco";
            lblTituloDisco.Size = new Size(178, 19);
            lblTituloDisco.TabIndex = 0;
            lblTituloDisco.Text = "UNIDADE DE ARMAZENAMENTO";

            // Unidade
            ConfigurarLabel(
                lblUnidade,
                "Unidade",
                new Point(20, 54),
                textoSecundario
            );

            ConfigurarValor(
                lblDadosDisco01,
                new Point(150, 51),
                290,
                25
            );

            // Volume
            ConfigurarLabel(
                lblVolume,
                "Volume",
                new Point(20, 86),
                textoSecundario
            );

            ConfigurarValor(
                lblDadosDisco02,
                new Point(150, 83),
                290,
                25
            );

            // Sistema
            ConfigurarLabel(
                lblTituloSistemaArquivos,
                "Sistema de arquivos",
                new Point(20, 118),
                textoSecundario
            );

            ConfigurarValor(
                lblSistemaArquivos,
                new Point(150, 115),
                290,
                25
            );

            // Capacidade
            ConfigurarLabel(
                lblTituloCapacidade,
                "Capacidade",
                new Point(20, 150),
                textoSecundario
            );

            ConfigurarValor(
                lblCapacidade,
                new Point(150, 147),
                290,
                25
            );

            // Espaço
            ConfigurarLabel(
                lblTituloUtilizado,
                "Utilizado",
                new Point(20, 182),
                textoSecundario
            );

            ConfigurarValor(
                lblUtilizado,
                new Point(150, 179),
                135,
                25
            );

            ConfigurarLabel(
                lblTituloDisponivel,
                "Disponível",
                new Point(290, 182),
                textoSecundario
            );

            ConfigurarValor(
                lblDisponivel,
                new Point(360, 179),
                80,
                25,
                ContentAlignment.MiddleRight
            );

            // 
            // panelStatus
            // 
            panelStatus.BackColor = card;
            panelStatus.Controls.Add(lblTituloStatus);
            panelStatus.Controls.Add(lblStatus);
            panelStatus.Controls.Add(lblDescricaoStatus);
            panelStatus.EdgeColor = borda;
            panelStatus.Location = new Point(508, 128);
            panelStatus.Name = "panelStatus";
            panelStatus.Padding = new Padding(5);
            panelStatus.Size = new Size(485, 220);
            panelStatus.SmoothingType =
                System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panelStatus.TabIndex = 2;

            lblTituloStatus.AutoSize = true;
            lblTituloStatus.BackColor = Color.Transparent;
            lblTituloStatus.Font =
                new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTituloStatus.ForeColor = vermelho;
            lblTituloStatus.Location = new Point(20, 15);
            lblTituloStatus.Name = "lblTituloStatus";
            lblTituloStatus.Size = new Size(57, 19);
            lblTituloStatus.TabIndex = 0;
            lblTituloStatus.Text = "STATUS";

            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font =
                new Font("Segoe UI Semibold", 17F, FontStyle.Bold);
            lblStatus.ForeColor = textoSecundario;
            lblStatus.Location = new Point(20, 58);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(190, 31);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "● AGUARDANDO";

            lblDescricaoStatus.AutoSize = false;
            lblDescricaoStatus.BackColor = Color.Transparent;
            lblDescricaoStatus.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblDescricaoStatus.ForeColor = textoSecundario;
            lblDescricaoStatus.Location = new Point(20, 104);
            lblDescricaoStatus.Name = "lblDescricaoStatus";
            lblDescricaoStatus.Size = new Size(435, 70);
            lblDescricaoStatus.TabIndex = 2;
            lblDescricaoStatus.Text =
                "Nenhuma verificação foi executada nesta sessão.";

            // 
            // panelVerificacao
            // 
            panelVerificacao.BackColor = card;
            panelVerificacao.Controls.Add(lblTituloVerificacao);
            panelVerificacao.Controls.Add(lblEtapa1);
            panelVerificacao.Controls.Add(lblEtapa2);
            panelVerificacao.Controls.Add(lblEtapa3);
            panelVerificacao.Controls.Add(progressBar);
            panelVerificacao.Controls.Add(btnVerificar);
            panelVerificacao.EdgeColor = borda;
            panelVerificacao.Location = new Point(12, 365);
            panelVerificacao.Name = "panelVerificacao";
            panelVerificacao.Padding = new Padding(5);
            panelVerificacao.Size = new Size(480, 245);
            panelVerificacao.SmoothingType =
                System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panelVerificacao.TabIndex = 3;

            lblTituloVerificacao.AutoSize = true;
            lblTituloVerificacao.BackColor = Color.Transparent;
            lblTituloVerificacao.Font =
                new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTituloVerificacao.ForeColor = vermelho;
            lblTituloVerificacao.Location = new Point(20, 15);
            lblTituloVerificacao.Name = "lblTituloVerificacao";
            lblTituloVerificacao.Size = new Size(101, 19);
            lblTituloVerificacao.TabIndex = 0;
            lblTituloVerificacao.Text = "VERIFICAÇÕES";

            ConfigurarEtapa(
                lblEtapa1,
                "○ Sistema de arquivos",
                new Point(20, 54)
            );

            ConfigurarEtapa(
                lblEtapa2,
                "○ Metadados do volume",
                new Point(20, 84)
            );

            ConfigurarEtapa(
                lblEtapa3,
                "○ Integridade da unidade",
                new Point(20, 114)
            );

            progressBar.Location = new Point(20, 153);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(440, 8);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.TabIndex = 4;
            progressBar.Value = 0;

            btnVerificar.BackColor = vermelho;
            btnVerificar.FlatAppearance.BorderSize = 0;
            btnVerificar.FlatAppearance.MouseDownBackColor =
                Color.FromArgb(170, 25, 25);
            btnVerificar.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(240, 45, 45);
            btnVerificar.FlatStyle = FlatStyle.Flat;
            btnVerificar.Font =
                new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnVerificar.ForeColor = Color.White;
            btnVerificar.Cursor = Cursors.Hand;
            btnVerificar.Location = new Point(20, 185);
            btnVerificar.Name = "btnVerificar";
            btnVerificar.Size = new Size(440, 40);
            btnVerificar.TabIndex = 5;
            btnVerificar.Text = "VERIFICAR DISCO";
            btnVerificar.UseVisualStyleBackColor = false;
            btnVerificar.Click += btnVerificar_Click;

            // 
            // panelResultado
            // 
            panelResultado.BackColor = card;
            panelResultado.Controls.Add(lblTituloResultado);
            panelResultado.Controls.Add(lblResultado);
            panelResultado.EdgeColor = borda;
            panelResultado.Location = new Point(508, 365);
            panelResultado.Name = "panelResultado";
            panelResultado.Padding = new Padding(5);
            panelResultado.Size = new Size(485, 245);
            panelResultado.SmoothingType =
                System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panelResultado.TabIndex = 4;

            lblTituloResultado.AutoSize = true;
            lblTituloResultado.BackColor = Color.Transparent;
            lblTituloResultado.Font =
                new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTituloResultado.ForeColor = vermelho;
            lblTituloResultado.Location = new Point(20, 15);
            lblTituloResultado.Name = "lblTituloResultado";
            lblTituloResultado.Size = new Size(82, 19);
            lblTituloResultado.TabIndex = 0;
            lblTituloResultado.Text = "RESULTADO";

            lblResultado.BackColor = Color.Transparent;
            lblResultado.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblResultado.ForeColor = textoSecundario;
            lblResultado.Location = new Point(20, 53);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(440, 160);
            lblResultado.TabIndex = 1;
            lblResultado.Text =
                "Aguardando uma verificação do sistema de arquivos.";

            // 
            // VerificarDisco
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = fundo;
            ClientSize = new Size(1005, 635);
            Controls.Add(panelResultado);
            Controls.Add(panelVerificacao);
            Controls.Add(panelStatus);
            Controls.Add(panelDisco);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1020, 680);
            Name = "VerificarDisco";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WinTurner - Verificação do Disco";

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelDisco.ResumeLayout(false);
            panelDisco.PerformLayout();
            panelStatus.ResumeLayout(false);
            panelStatus.PerformLayout();
            panelVerificacao.ResumeLayout(false);
            panelVerificacao.PerformLayout();
            panelResultado.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void ConfigurarLabel(
            Label label,
            string texto,
            Point localizacao,
            Color cor)
        {
            label.AutoSize = true;
            label.BackColor = Color.Transparent;
            label.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Regular);
            label.ForeColor = cor;
            label.Location = localizacao;
            label.Text = texto;
        }

        private void ConfigurarValor(
            Label label,
            Point localizacao,
            int largura,
            int altura,
            ContentAlignment alinhamento =
                ContentAlignment.MiddleLeft)
        {
            label.AutoSize = false;
            label.BackColor = Color.Transparent;
            label.Font =
                new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(235, 235, 235);
            label.Location = localizacao;
            label.Size = new Size(largura, altura);
            label.TextAlign = alinhamento;
            label.AutoEllipsis = true;
        }

        private void ConfigurarEtapa(
            Label label,
            string texto,
            Point localizacao)
        {
            label.AutoSize = true;
            label.BackColor = Color.Transparent;
            label.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Regular);
            label.ForeColor = Color.FromArgb(145, 145, 145);
            label.Location = localizacao;
            label.Text = texto;
        }

        #endregion

        private ReaLTaiizor.Controls.Panel panelHeader;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.HeaderLabel headerLabel1;

        private ReaLTaiizor.Controls.Panel panelDisco;
        private Label lblTituloDisco;
        private Label lblUnidade;
        private Label lblDadosDisco01;
        private Label lblVolume;
        private Label lblDadosDisco02;
        private Label lblTituloSistemaArquivos;
        private Label lblSistemaArquivos;
        private Label lblTituloCapacidade;
        private Label lblCapacidade;
        private Label lblTituloUtilizado;
        private Label lblUtilizado;
        private Label lblTituloDisponivel;
        private Label lblDisponivel;

        private ReaLTaiizor.Controls.Panel panelStatus;
        private Label lblTituloStatus;
        private Label lblStatus;
        private Label lblDescricaoStatus;

        private ReaLTaiizor.Controls.Panel panelVerificacao;
        private Label lblTituloVerificacao;
        private Label lblEtapa1;
        private Label lblEtapa2;
        private Label lblEtapa3;
        private ProgressBar progressBar;
        private Button btnVerificar;

        private ReaLTaiizor.Controls.Panel panelResultado;
        private Label lblTituloResultado;
        private Label lblResultado;
    }
}