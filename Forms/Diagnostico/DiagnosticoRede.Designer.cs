namespace WinTuner.Forms.Diagnostico
{
    partial class DiagnosticoRede
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelPrincipal = new Panel();
            panelResultado = new Panel();
            txtResultado = new RichTextBox();
            lblResultadoTitulo = new Label();
            panelInformacoes = new Panel();
            lblDNS = new Label();
            lblGateway = new Label();
            lblIPv6 = new Label();
            lblIPv4 = new Label();
            lblMAC = new Label();
            lblVelocidade = new Label();
            lblAdaptador = new Label();
            lblStatusConexao = new Label();
            lblDNSTitulo = new Label();
            lblGatewayTitulo = new Label();
            lblIPv6Titulo = new Label();
            lblIPv4Titulo = new Label();
            lblMACTitulo = new Label();
            lblVelocidadeTitulo = new Label();
            lblAdaptadorTitulo = new Label();
            lblStatusTitulo = new Label();
            panelFerramentas = new Panel();
            btnDiagnosticar = new Button();
            lblStatus = new Label();
            lblDescricao = new Label();
            lblTitulo = new Label();

            panelPrincipal.SuspendLayout();
            panelResultado.SuspendLayout();
            panelInformacoes.SuspendLayout();
            panelFerramentas.SuspendLayout();
            SuspendLayout();

            // 
            // panelPrincipal
            // 
            panelPrincipal.BackColor = Color.FromArgb(15, 15, 15);
            panelPrincipal.Controls.Add(panelResultado);
            panelPrincipal.Controls.Add(panelInformacoes);
            panelPrincipal.Controls.Add(panelFerramentas);
            panelPrincipal.Controls.Add(lblDescricao);
            panelPrincipal.Controls.Add(lblTitulo);
            panelPrincipal.Dock = DockStyle.Fill;
            panelPrincipal.Location = new Point(0, 0);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Padding = new Padding(25);
            panelPrincipal.Size = new Size(967, 651);
            panelPrincipal.TabIndex = 0;

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font(
                "Segoe UI Semibold",
                18F,
                FontStyle.Bold
            );
            lblTitulo.ForeColor = Color.FromArgb(235, 235, 235);
            lblTitulo.Location = new Point(25, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(198, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Diagnóstico de Rede";

            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Regular
            );
            lblDescricao.ForeColor = Color.FromArgb(145, 145, 145);
            lblDescricao.Location = new Point(28, 63);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(650, 15);
            lblDescricao.TabIndex = 1;
            lblDescricao.Text =
                "Analise a conexão, adaptadores, endereçamento e comunicação da rede.";

            // 
            // panelFerramentas
            // 
            panelFerramentas.BackColor = Color.FromArgb(23, 23, 23);
            panelFerramentas.BorderStyle = BorderStyle.FixedSingle;
            panelFerramentas.Controls.Add(btnDiagnosticar);
            panelFerramentas.Controls.Add(lblStatus);
            panelFerramentas.Location = new Point(25, 100);
            panelFerramentas.Name = "panelFerramentas";
            panelFerramentas.Size = new Size(917, 100);
            panelFerramentas.TabIndex = 2;

            // 
            // lblStatus
            // 
            lblStatus.AutoSize = false;
            lblStatus.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold
            );
            lblStatus.ForeColor = Color.FromArgb(145, 145, 145);
            lblStatus.Location = new Point(20, 15);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(870, 25);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Pronto para iniciar o diagnóstico.";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // btnDiagnosticar
            // 
            btnDiagnosticar.BackColor = Color.FromArgb(176, 0, 0);
            btnDiagnosticar.FlatAppearance.BorderSize = 0;
            btnDiagnosticar.FlatAppearance.MouseDownBackColor =
                Color.FromArgb(130, 0, 0);
            btnDiagnosticar.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(208, 0, 0);
            btnDiagnosticar.FlatStyle = FlatStyle.Flat;
            btnDiagnosticar.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold
            );
            btnDiagnosticar.ForeColor = Color.White;
            btnDiagnosticar.Location = new Point(20, 50);
            btnDiagnosticar.Name = "btnDiagnosticar";
            btnDiagnosticar.Size = new Size(270, 35);
            btnDiagnosticar.TabIndex = 1;
            btnDiagnosticar.Text = "EXECUTAR DIAGNÓSTICO";
            btnDiagnosticar.UseVisualStyleBackColor = false;
            btnDiagnosticar.Click += btnDiagnosticar_Click;

            // 
            // panelInformacoes
            // 
            panelInformacoes.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;
            panelInformacoes.BackColor = Color.FromArgb(23, 23, 23);
            panelInformacoes.BorderStyle = BorderStyle.FixedSingle;
            panelInformacoes.Controls.Add(lblDNS);
            panelInformacoes.Controls.Add(lblGateway);
            panelInformacoes.Controls.Add(lblIPv6);
            panelInformacoes.Controls.Add(lblIPv4);
            panelInformacoes.Controls.Add(lblMAC);
            panelInformacoes.Controls.Add(lblVelocidade);
            panelInformacoes.Controls.Add(lblAdaptador);
            panelInformacoes.Controls.Add(lblStatusConexao);
            panelInformacoes.Controls.Add(lblDNSTitulo);
            panelInformacoes.Controls.Add(lblGatewayTitulo);
            panelInformacoes.Controls.Add(lblIPv6Titulo);
            panelInformacoes.Controls.Add(lblIPv4Titulo);
            panelInformacoes.Controls.Add(lblMACTitulo);
            panelInformacoes.Controls.Add(lblVelocidadeTitulo);
            panelInformacoes.Controls.Add(lblAdaptadorTitulo);
            panelInformacoes.Controls.Add(lblStatusTitulo);
            panelInformacoes.Location = new Point(25, 215);
            panelInformacoes.Name = "panelInformacoes";
            panelInformacoes.Size = new Size(917, 155);
            panelInformacoes.TabIndex = 3;

            // 
            // lblStatusTitulo
            // 
            lblStatusTitulo.AutoSize = true;
            lblStatusTitulo.Font = new Font(
                "Segoe UI Semibold",
                8.5F,
                FontStyle.Bold
            );
            lblStatusTitulo.ForeColor = Color.FromArgb(145, 145, 145);
            lblStatusTitulo.Location = new Point(20, 15);
            lblStatusTitulo.Text = "STATUS";

            // 
            // lblStatusConexao
            // 
            lblStatusConexao.AutoSize = true;
            lblStatusConexao.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold
            );
            lblStatusConexao.ForeColor = Color.FromArgb(235, 235, 235);
            lblStatusConexao.Location = new Point(20, 34);
            lblStatusConexao.Text = "Não verificado";

            // 
            // lblAdaptadorTitulo
            // 
            lblAdaptadorTitulo.AutoSize = true;
            lblAdaptadorTitulo.Font = new Font(
                "Segoe UI Semibold",
                8.5F,
                FontStyle.Bold
            );
            lblAdaptadorTitulo.ForeColor = Color.FromArgb(145, 145, 145);
            lblAdaptadorTitulo.Location = new Point(235, 15);
            lblAdaptadorTitulo.Text = "ADAPTADOR";

            // 
            // lblAdaptador
            // 
            lblAdaptador.AutoSize = false;
            lblAdaptador.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold
            );
            lblAdaptador.ForeColor = Color.FromArgb(235, 235, 235);
            lblAdaptador.Location = new Point(235, 34);
            lblAdaptador.Size = new Size(260, 20);
            lblAdaptador.Text = "Não identificado";
            lblAdaptador.AutoEllipsis = true;

            // 
            // lblVelocidadeTitulo
            // 
            lblVelocidadeTitulo.AutoSize = true;
            lblVelocidadeTitulo.Font = new Font(
                "Segoe UI Semibold",
                8.5F,
                FontStyle.Bold
            );
            lblVelocidadeTitulo.ForeColor = Color.FromArgb(145, 145, 145);
            lblVelocidadeTitulo.Location = new Point(535, 15);
            lblVelocidadeTitulo.Text = "VELOCIDADE";

            // 
            // lblVelocidade
            // 
            lblVelocidade.AutoSize = true;
            lblVelocidade.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold
            );
            lblVelocidade.ForeColor = Color.FromArgb(235, 235, 235);
            lblVelocidade.Location = new Point(535, 34);
            lblVelocidade.Text = "-";

            // 
            // lblMACTitulo
            // 
            lblMACTitulo.AutoSize = true;
            lblMACTitulo.Font = new Font(
                "Segoe UI Semibold",
                8.5F,
                FontStyle.Bold
            );
            lblMACTitulo.ForeColor = Color.FromArgb(145, 145, 145);
            lblMACTitulo.Location = new Point(720, 15);
            lblMACTitulo.Text = "MAC";

            // 
            // lblMAC
            // 
            lblMAC.AutoSize = true;
            lblMAC.Font = new Font(
                "Consolas",
                9F,
                FontStyle.Regular
            );
            lblMAC.ForeColor = Color.FromArgb(235, 235, 235);
            lblMAC.Location = new Point(720, 34);
            lblMAC.Text = "-";

            // 
            // lblIPv4Titulo
            // 
            lblIPv4Titulo.AutoSize = true;
            lblIPv4Titulo.Font = new Font(
                "Segoe UI Semibold",
                8.5F,
                FontStyle.Bold
            );
            lblIPv4Titulo.ForeColor = Color.FromArgb(145, 145, 145);
            lblIPv4Titulo.Location = new Point(20, 78);
            lblIPv4Titulo.Text = "IPv4";

            // 
            // lblIPv4
            // 
            lblIPv4.AutoSize = true;
            lblIPv4.Font = new Font(
                "Consolas",
                9F,
                FontStyle.Regular
            );
            lblIPv4.ForeColor = Color.FromArgb(235, 235, 235);
            lblIPv4.Location = new Point(20, 98);
            lblIPv4.Text = "-";

            // 
            // lblIPv6Titulo
            // 
            lblIPv6Titulo.AutoSize = true;
            lblIPv6Titulo.Font = new Font(
                "Segoe UI Semibold",
                8.5F,
                FontStyle.Bold
            );
            lblIPv6Titulo.ForeColor = Color.FromArgb(145, 145, 145);
            lblIPv6Titulo.Location = new Point(160, 78);
            lblIPv6Titulo.Text = "IPv6";

            // 
            // lblIPv6
            // 
            lblIPv6.AutoSize = false;
            lblIPv6.Font = new Font(
                "Consolas",
                8.5F,
                FontStyle.Regular
            );
            lblIPv6.ForeColor = Color.FromArgb(235, 235, 235);
            lblIPv6.Location = new Point(160, 98);
            lblIPv6.Size = new Size(210, 20);
            lblIPv6.Text = "-";
            lblIPv6.AutoEllipsis = true;

            // 
            // lblGatewayTitulo
            // 
            lblGatewayTitulo.AutoSize = true;
            lblGatewayTitulo.Font = new Font(
                "Segoe UI Semibold",
                8.5F,
                FontStyle.Bold
            );
            lblGatewayTitulo.ForeColor = Color.FromArgb(145, 145, 145);
            lblGatewayTitulo.Location = new Point(405, 78);
            lblGatewayTitulo.Text = "GATEWAY";

            // 
            // lblGateway
            // 
            lblGateway.AutoSize = true;
            lblGateway.Font = new Font(
                "Consolas",
                9F,
                FontStyle.Regular
            );
            lblGateway.ForeColor = Color.FromArgb(235, 235, 235);
            lblGateway.Location = new Point(405, 98);
            lblGateway.Text = "-";

            // 
            // lblDNS
            // 
            lblDNS.AutoSize = false;
            lblDNS.Font = new Font(
                "Consolas",
                8.5F,
                FontStyle.Regular
            );
            lblDNS.ForeColor = Color.FromArgb(235, 235, 235);
            lblDNS.Location = new Point(590, 98);
            lblDNS.Size = new Size(290, 35);
            lblDNS.Text = "-";
            lblDNS.AutoEllipsis = true;

            // 
            // lblDNSTitulo
            // 
            lblDNSTitulo.AutoSize = true;
            lblDNSTitulo.Font = new Font(
                "Segoe UI Semibold",
                8.5F,
                FontStyle.Bold
            );
            lblDNSTitulo.ForeColor = Color.FromArgb(145, 145, 145);
            lblDNSTitulo.Location = new Point(590, 78);
            lblDNSTitulo.Text = "DNS";

            // 
            // panelResultado
            // 
            panelResultado.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;
            panelResultado.BackColor = Color.FromArgb(23, 23, 23);
            panelResultado.BorderStyle = BorderStyle.FixedSingle;
            panelResultado.Controls.Add(txtResultado);
            panelResultado.Controls.Add(lblResultadoTitulo);
            panelResultado.Location = new Point(25, 385);
            panelResultado.Name = "panelResultado";
            panelResultado.Padding = new Padding(15);
            panelResultado.Size = new Size(917, 241);
            panelResultado.TabIndex = 4;

            // 
            // lblResultadoTitulo
            // 
            lblResultadoTitulo.AutoSize = true;
            lblResultadoTitulo.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold
            );
            lblResultadoTitulo.ForeColor = Color.FromArgb(235, 235, 235);
            lblResultadoTitulo.Location = new Point(15, 15);
            lblResultadoTitulo.Name = "lblResultadoTitulo";
            lblResultadoTitulo.Size = new Size(68, 19);
            lblResultadoTitulo.Text = "Resultado";

            // 
            // txtResultado
            // 
            txtResultado.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;
            txtResultado.BackColor = Color.FromArgb(12, 12, 12);
            txtResultado.BorderStyle = BorderStyle.None;
            txtResultado.Font = new Font(
                "Consolas",
                9F,
                FontStyle.Regular
            );
            txtResultado.ForeColor = Color.FromArgb(210, 210, 210);
            txtResultado.Location = new Point(15, 45);
            txtResultado.Name = "txtResultado";
            txtResultado.ReadOnly = true;
            txtResultado.Size = new Size(885, 175);
            txtResultado.TabIndex = 0;
            txtResultado.Text = "";

            // 
            // DiagnosticoRede
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(967, 651);
            Controls.Add(panelPrincipal);
            MinimumSize = new Size(850, 600);
            Name = "DiagnosticoRede";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Diagnóstico de Rede";

            panelPrincipal.ResumeLayout(false);
            panelPrincipal.PerformLayout();
            panelResultado.ResumeLayout(false);
            panelResultado.PerformLayout();
            panelInformacoes.ResumeLayout(false);
            panelInformacoes.PerformLayout();
            panelFerramentas.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelPrincipal;
        private Panel panelFerramentas;
        private Panel panelInformacoes;
        private Panel panelResultado;

        private Label lblTitulo;
        private Label lblDescricao;
        private Label lblStatus;
        private Label lblResultadoTitulo;

        private Label lblStatusTitulo;
        private Label lblStatusConexao;

        private Label lblAdaptadorTitulo;
        private Label lblAdaptador;

        private Label lblVelocidadeTitulo;
        private Label lblVelocidade;

        private Label lblMACTitulo;
        private Label lblMAC;

        private Label lblIPv4Titulo;
        private Label lblIPv4;

        private Label lblIPv6Titulo;
        private Label lblIPv6;

        private Label lblGatewayTitulo;
        private Label lblGateway;

        private Label lblDNSTitulo;
        private Label lblDNS;

        private Button btnDiagnosticar;

        private RichTextBox txtResultado;
    }
}