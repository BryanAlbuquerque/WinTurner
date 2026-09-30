namespace WinTuner.Forms.Otimizacao
{
    partial class Debloat
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelCabecalho;
        private Label lblTitulo;
        private Label lblDescricao;

        private Panel panelResumo;
        private Panel panelResumoTotal;
        private Panel panelResumoInstalados;
        private Panel panelResumoRemoviveis;
        private Panel panelResumoProtegidos;
        private Panel panelResumoSelecionados;

        private Label lblTituloTotal;
        private Label lblTituloInstalados;
        private Label lblTituloRemoviveis;
        private Label lblTituloProtegidos;
        private Label lblTituloSelecionados;

        private Label lblTotal;
        private Label lblInstalados;
        private Label lblRemoviveis;
        private Label lblProtegidos;
        private Label lblSelecionados;

        private Panel panelFiltros;
        private Label lblPesquisa;
        private TextBox txtPesquisa;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private CheckBox chkSomenteRemoviveis;

        private Panel panelAcoes;
        private Button btnAnalisar;
        private Button btnSelecionarRemoviveis;
        private Button btnLimparSelecao;
        private Button btnRestaurar;
        private Button btnRemover;

        private Panel panelConteudo;
        private FlowLayoutPanel flowCards;

        private Panel panelRodape;
        private Label lblStatus;
        private ProgressBar progressBar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.panelCabecalho = new Panel();
            this.lblTitulo = new Label();
            this.lblDescricao = new Label();

            this.panelResumo = new Panel();

            this.panelResumoTotal = new Panel();
            this.panelResumoInstalados = new Panel();
            this.panelResumoRemoviveis = new Panel();
            this.panelResumoProtegidos = new Panel();
            this.panelResumoSelecionados = new Panel();

            this.lblTituloTotal = new Label();
            this.lblTituloInstalados = new Label();
            this.lblTituloRemoviveis = new Label();
            this.lblTituloProtegidos = new Label();
            this.lblTituloSelecionados = new Label();

            this.lblTotal = new Label();
            this.lblInstalados = new Label();
            this.lblRemoviveis = new Label();
            this.lblProtegidos = new Label();
            this.lblSelecionados = new Label();

            this.panelFiltros = new Panel();
            this.lblPesquisa = new Label();
            this.txtPesquisa = new TextBox();
            this.lblCategoria = new Label();
            this.cmbCategoria = new ComboBox();
            this.chkSomenteRemoviveis = new CheckBox();

            this.panelAcoes = new Panel();
            this.btnAnalisar = new Button();
            this.btnSelecionarRemoviveis = new Button();
            this.btnLimparSelecao = new Button();
            this.btnRestaurar = new Button();
            this.btnRemover = new Button();

            this.panelConteudo = new Panel();
            this.flowCards = new FlowLayoutPanel();

            this.panelRodape = new Panel();
            this.lblStatus = new Label();
            this.progressBar = new ProgressBar();

            this.panelCabecalho.SuspendLayout();
            this.panelResumo.SuspendLayout();
            this.panelResumoTotal.SuspendLayout();
            this.panelResumoInstalados.SuspendLayout();
            this.panelResumoRemoviveis.SuspendLayout();
            this.panelResumoProtegidos.SuspendLayout();
            this.panelResumoSelecionados.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.panelAcoes.SuspendLayout();
            this.panelConteudo.SuspendLayout();
            this.panelRodape.SuspendLayout();
            this.SuspendLayout();

            // 
            // Debloat
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(15, 15, 15);
            this.ClientSize = new Size(1180, 760);
            this.MinimumSize = new Size(980, 620);
            this.Name = "Debloat";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "WinTuner - Debloat do Windows";
            this.FormClosing += new FormClosingEventHandler(this.Debloat_FormClosing);

            // 
            // panelCabecalho
            // 
            this.panelCabecalho.BackColor = Color.FromArgb(23, 23, 23);
            this.panelCabecalho.Dock = DockStyle.Top;
            this.panelCabecalho.Height = 82;
            this.panelCabecalho.Padding = new Padding(24, 12, 24, 10);
            this.panelCabecalho.Name = "panelCabecalho";

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(242, 242, 242);
            this.lblTitulo.Location = new Point(24, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "DEBLOAT DO WINDOWS";

            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new Font("Segoe UI", 9.5F);
            this.lblDescricao.ForeColor = Color.FromArgb(145, 145, 145);
            this.lblDescricao.Location = new Point(27, 48);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Text = "Analise os aplicativos instalados, identifique componentes opcionais e gerencie o que pode ser removido.";

            this.panelCabecalho.Controls.Add(this.lblTitulo);
            this.panelCabecalho.Controls.Add(this.lblDescricao);

            // 
            // panelResumo
            // 
            this.panelResumo.BackColor = Color.FromArgb(15, 15, 15);
            this.panelResumo.Dock = DockStyle.Top;
            this.panelResumo.Height = 92;
            this.panelResumo.Padding = new Padding(16, 8, 16, 8);
            this.panelResumo.Name = "panelResumo";

            // 
            // panelResumoTotal
            // 
            this.panelResumoTotal.BackColor = Color.FromArgb(27, 27, 27);
            this.panelResumoTotal.Location = new Point(16, 8);
            this.panelResumoTotal.Size = new Size(210, 76);
            this.panelResumoTotal.Name = "panelResumoTotal";

            // 
            // lblTituloTotal
            // 
            this.lblTituloTotal.AutoSize = true;
            this.lblTituloTotal.Font = new Font("Segoe UI", 8.5F);
            this.lblTituloTotal.ForeColor = Color.FromArgb(145, 145, 145);
            this.lblTituloTotal.Location = new Point(14, 10);
            this.lblTituloTotal.Text = "TOTAL ENCONTRADO";

            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.FromArgb(242, 242, 242);
            this.lblTotal.Location = new Point(12, 30);
            this.lblTotal.Text = "0";

            this.panelResumoTotal.Controls.Add(this.lblTituloTotal);
            this.panelResumoTotal.Controls.Add(this.lblTotal);

            // 
            // panelResumoInstalados
            // 
            this.panelResumoInstalados.BackColor = Color.FromArgb(27, 27, 27);
            this.panelResumoInstalados.Location = new Point(236, 8);
            this.panelResumoInstalados.Size = new Size(210, 76);
            this.panelResumoInstalados.Name = "panelResumoInstalados";

            // 
            // lblTituloInstalados
            // 
            this.lblTituloInstalados.AutoSize = true;
            this.lblTituloInstalados.Font = new Font("Segoe UI", 8.5F);
            this.lblTituloInstalados.ForeColor = Color.FromArgb(145, 145, 145);
            this.lblTituloInstalados.Location = new Point(14, 10);
            this.lblTituloInstalados.Text = "INSTALADOS";

            // 
            // lblInstalados
            // 
            this.lblInstalados.AutoSize = true;
            this.lblInstalados.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            this.lblInstalados.ForeColor = Color.FromArgb(242, 242, 242);
            this.lblInstalados.Location = new Point(12, 30);
            this.lblInstalados.Text = "0";

            this.panelResumoInstalados.Controls.Add(this.lblTituloInstalados);
            this.panelResumoInstalados.Controls.Add(this.lblInstalados);

            // 
            // panelResumoRemoviveis
            // 
            this.panelResumoRemoviveis.BackColor = Color.FromArgb(27, 27, 27);
            this.panelResumoRemoviveis.Location = new Point(456, 8);
            this.panelResumoRemoviveis.Size = new Size(210, 76);
            this.panelResumoRemoviveis.Name = "panelResumoRemoviveis";

            // 
            // lblTituloRemoviveis
            // 
            this.lblTituloRemoviveis.AutoSize = true;
            this.lblTituloRemoviveis.Font = new Font("Segoe UI", 8.5F);
            this.lblTituloRemoviveis.ForeColor = Color.FromArgb(145, 145, 145);
            this.lblTituloRemoviveis.Location = new Point(14, 10);
            this.lblTituloRemoviveis.Text = "REMOVÍVEIS";

            // 
            // lblRemoviveis
            // 
            this.lblRemoviveis.AutoSize = true;
            this.lblRemoviveis.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            this.lblRemoviveis.ForeColor = Color.FromArgb(208, 0, 0);
            this.lblRemoviveis.Location = new Point(12, 30);
            this.lblRemoviveis.Text = "0";

            this.panelResumoRemoviveis.Controls.Add(this.lblTituloRemoviveis);
            this.panelResumoRemoviveis.Controls.Add(this.lblRemoviveis);

            // 
            // panelResumoProtegidos
            // 
            this.panelResumoProtegidos.BackColor = Color.FromArgb(27, 27, 27);
            this.panelResumoProtegidos.Location = new Point(676, 8);
            this.panelResumoProtegidos.Size = new Size(210, 76);
            this.panelResumoProtegidos.Name = "panelResumoProtegidos";

            // 
            // lblTituloProtegidos
            // 
            this.lblTituloProtegidos.AutoSize = true;
            this.lblTituloProtegidos.Font = new Font("Segoe UI", 8.5F);
            this.lblTituloProtegidos.ForeColor = Color.FromArgb(145, 145, 145);
            this.lblTituloProtegidos.Location = new Point(14, 10);
            this.lblTituloProtegidos.Text = "PROTEGIDOS";

            // 
            // lblProtegidos
            // 
            this.lblProtegidos.AutoSize = true;
            this.lblProtegidos.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            this.lblProtegidos.ForeColor = Color.FromArgb(242, 242, 242);
            this.lblProtegidos.Location = new Point(12, 30);
            this.lblProtegidos.Text = "0";

            this.panelResumoProtegidos.Controls.Add(this.lblTituloProtegidos);
            this.panelResumoProtegidos.Controls.Add(this.lblProtegidos);

            // 
            // panelResumoSelecionados
            // 
            this.panelResumoSelecionados.BackColor = Color.FromArgb(27, 27, 27);
            this.panelResumoSelecionados.Location = new Point(896, 8);
            this.panelResumoSelecionados.Size = new Size(210, 76);
            this.panelResumoSelecionados.Name = "panelResumoSelecionados";

            // 
            // lblTituloSelecionados
            // 
            this.lblTituloSelecionados.AutoSize = true;
            this.lblTituloSelecionados.Font = new Font("Segoe UI", 8.5F);
            this.lblTituloSelecionados.ForeColor = Color.FromArgb(145, 145, 145);
            this.lblTituloSelecionados.Location = new Point(14, 10);
            this.lblTituloSelecionados.Text = "SELECIONADOS";

            // 
            // lblSelecionados
            // 
            this.lblSelecionados.AutoSize = true;
            this.lblSelecionados.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            this.lblSelecionados.ForeColor = Color.FromArgb(242, 242, 242);
            this.lblSelecionados.Location = new Point(12, 30);
            this.lblSelecionados.Text = "0";

            this.panelResumoSelecionados.Controls.Add(this.lblTituloSelecionados);
            this.panelResumoSelecionados.Controls.Add(this.lblSelecionados);

            this.panelResumo.Controls.Add(this.panelResumoTotal);
            this.panelResumo.Controls.Add(this.panelResumoInstalados);
            this.panelResumo.Controls.Add(this.panelResumoRemoviveis);
            this.panelResumo.Controls.Add(this.panelResumoProtegidos);
            this.panelResumo.Controls.Add(this.panelResumoSelecionados);

            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = Color.FromArgb(23, 23, 23);
            this.panelFiltros.Dock = DockStyle.Top;
            this.panelFiltros.Height = 62;
            this.panelFiltros.Padding = new Padding(16, 8, 16, 8);
            this.panelFiltros.Name = "panelFiltros";

            // 
            // lblPesquisa
            // 
            this.lblPesquisa.AutoSize = true;
            this.lblPesquisa.Font = new Font("Segoe UI", 8.5F);
            this.lblPesquisa.ForeColor = Color.FromArgb(145, 145, 145);
            this.lblPesquisa.Location = new Point(18, 8);
            this.lblPesquisa.Text = "PESQUISA";

            // 
            // txtPesquisa
            // 
            this.txtPesquisa.BackColor = Color.FromArgb(27, 27, 27);
            this.txtPesquisa.BorderStyle = BorderStyle.FixedSingle;
            this.txtPesquisa.Font = new Font("Segoe UI", 9.5F);
            this.txtPesquisa.ForeColor = Color.FromArgb(242, 242, 242);
            this.txtPesquisa.Location = new Point(16, 28);
            this.txtPesquisa.Size = new Size(350, 24);
            this.txtPesquisa.Name = "txtPesquisa";

            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new Font("Segoe UI", 8.5F);
            this.lblCategoria.ForeColor = Color.FromArgb(145, 145, 145);
            this.lblCategoria.Location = new Point(386, 8);
            this.lblCategoria.Text = "CATEGORIA";

            // 
            // cmbCategoria
            // 
            this.cmbCategoria.BackColor = Color.FromArgb(27, 27, 27);
            this.cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategoria.FlatStyle = FlatStyle.Flat;
            this.cmbCategoria.Font = new Font("Segoe UI", 9F);
            this.cmbCategoria.ForeColor = Color.FromArgb(242, 242, 242);
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new Point(384, 27);
            this.cmbCategoria.Size = new Size(190, 23);
            this.cmbCategoria.Name = "cmbCategoria";

            // 
            // chkSomenteRemoviveis
            // 
            this.chkSomenteRemoviveis.AutoSize = true;
            this.chkSomenteRemoviveis.Cursor = Cursors.Hand;
            this.chkSomenteRemoviveis.Font = new Font("Segoe UI", 9F);
            this.chkSomenteRemoviveis.ForeColor = Color.FromArgb(180, 180, 180);
            this.chkSomenteRemoviveis.Location = new Point(600, 29);
            this.chkSomenteRemoviveis.Name = "chkSomenteRemoviveis";
            this.chkSomenteRemoviveis.Text = "Somente removíveis";
            this.chkSomenteRemoviveis.UseVisualStyleBackColor = false;
            this.chkSomenteRemoviveis.BackColor = Color.FromArgb(23, 23, 23);

            this.panelFiltros.Controls.Add(this.lblPesquisa);
            this.panelFiltros.Controls.Add(this.txtPesquisa);
            this.panelFiltros.Controls.Add(this.lblCategoria);
            this.panelFiltros.Controls.Add(this.cmbCategoria);
            this.panelFiltros.Controls.Add(this.chkSomenteRemoviveis);

            // 
            // panelAcoes
            // 
            this.panelAcoes.BackColor = Color.FromArgb(15, 15, 15);
            this.panelAcoes.Dock = DockStyle.Top;
            this.panelAcoes.Height = 58;
            this.panelAcoes.Padding = new Padding(16, 8, 16, 8);
            this.panelAcoes.Name = "panelAcoes";

            // 
            // btnAnalisar
            // 
            this.btnAnalisar.BackColor = Color.FromArgb(208, 0, 0);
            this.btnAnalisar.Cursor = Cursors.Hand;
            this.btnAnalisar.FlatAppearance.BorderSize = 0;
            this.btnAnalisar.FlatStyle = FlatStyle.Flat;
            this.btnAnalisar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.btnAnalisar.ForeColor = Color.White;
            this.btnAnalisar.Location = new Point(16, 8);
            this.btnAnalisar.Size = new Size(125, 38);
            this.btnAnalisar.Name = "btnAnalisar";
            this.btnAnalisar.Text = "ANALISAR";
            this.btnAnalisar.UseVisualStyleBackColor = false;
            this.btnAnalisar.Click += new EventHandler(this.btnAnalisar_Click);

            // 
            // btnSelecionarRemoviveis
            // 
            this.btnSelecionarRemoviveis.BackColor = Color.FromArgb(45, 45, 45);
            this.btnSelecionarRemoviveis.Cursor = Cursors.Hand;
            this.btnSelecionarRemoviveis.FlatAppearance.BorderSize = 0;
            this.btnSelecionarRemoviveis.FlatStyle = FlatStyle.Flat;
            this.btnSelecionarRemoviveis.Font = new Font("Segoe UI", 8.5F);
            this.btnSelecionarRemoviveis.ForeColor = Color.FromArgb(235, 235, 235);
            this.btnSelecionarRemoviveis.Location = new Point(151, 8);
            this.btnSelecionarRemoviveis.Size = new Size(165, 38);
            this.btnSelecionarRemoviveis.Name = "btnSelecionarRemoviveis";
            this.btnSelecionarRemoviveis.Text = "SELECIONAR REMOVÍVEIS";
            this.btnSelecionarRemoviveis.UseVisualStyleBackColor = false;
            this.btnSelecionarRemoviveis.Click += new EventHandler(this.btnSelecionarRemoviveis_Click);

            // 
            // btnLimparSelecao
            // 
            this.btnLimparSelecao.BackColor = Color.FromArgb(45, 45, 45);
            this.btnLimparSelecao.Cursor = Cursors.Hand;
            this.btnLimparSelecao.FlatAppearance.BorderSize = 0;
            this.btnLimparSelecao.FlatStyle = FlatStyle.Flat;
            this.btnLimparSelecao.Font = new Font("Segoe UI", 8.5F);
            this.btnLimparSelecao.ForeColor = Color.FromArgb(235, 235, 235);
            this.btnLimparSelecao.Location = new Point(326, 8);
            this.btnLimparSelecao.Size = new Size(135, 38);
            this.btnLimparSelecao.Name = "btnLimparSelecao";
            this.btnLimparSelecao.Text = "LIMPAR SELEÇÃO";
            this.btnLimparSelecao.UseVisualStyleBackColor = false;
            this.btnLimparSelecao.Click += new EventHandler(this.btnLimparSelecao_Click);

            // 
            // btnRestaurar
            // 
            this.btnRestaurar.BackColor = Color.FromArgb(45, 45, 45);
            this.btnRestaurar.Cursor = Cursors.Hand;
            this.btnRestaurar.FlatAppearance.BorderSize = 0;
            this.btnRestaurar.FlatStyle = FlatStyle.Flat;
            this.btnRestaurar.Font = new Font("Segoe UI", 8.5F);
            this.btnRestaurar.ForeColor = Color.FromArgb(235, 235, 235);
            this.btnRestaurar.Location = new Point(471, 8);
            this.btnRestaurar.Size = new Size(120, 38);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Text = "RESTAURAR";
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.Click += new EventHandler(this.btnRestaurar_Click);

            // 
            // btnRemover
            // 
            this.btnRemover.BackColor = Color.FromArgb(176, 0, 0);
            this.btnRemover.Cursor = Cursors.Hand;
            this.btnRemover.FlatAppearance.BorderSize = 0;
            this.btnRemover.FlatStyle = FlatStyle.Flat;
            this.btnRemover.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            this.btnRemover.ForeColor = Color.White;
            this.btnRemover.Location = new Point(601, 8);
            this.btnRemover.Size = new Size(180, 38);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Text = "REMOVER SELECIONADOS";
            this.btnRemover.UseVisualStyleBackColor = false;
            this.btnRemover.Click += new EventHandler(this.btnRemover_Click);

            this.panelAcoes.Controls.Add(this.btnAnalisar);
            this.panelAcoes.Controls.Add(this.btnSelecionarRemoviveis);
            this.panelAcoes.Controls.Add(this.btnLimparSelecao);
            this.panelAcoes.Controls.Add(this.btnRestaurar);
            this.panelAcoes.Controls.Add(this.btnRemover);

            // 
            // panelConteudo
            // 
            this.panelConteudo.BackColor = Color.FromArgb(15, 15, 15);
            this.panelConteudo.Dock = DockStyle.Fill;
            this.panelConteudo.Padding = new Padding(8, 0, 8, 0);
            this.panelConteudo.Name = "panelConteudo";

            // 
            // flowCards
            // 
            this.flowCards.AutoScroll = true;
            this.flowCards.BackColor = Color.FromArgb(15, 15, 15);
            this.flowCards.Dock = DockStyle.Fill;
            this.flowCards.FlowDirection = FlowDirection.LeftToRight;
            this.flowCards.Location = new Point(8, 0);
            this.flowCards.Name = "flowCards";
            this.flowCards.Padding = new Padding(8, 8, 8, 16);
            this.flowCards.Size = new Size(1164, 408);
            this.flowCards.TabIndex = 0;
            this.flowCards.WrapContents = true;

            this.panelConteudo.Controls.Add(this.flowCards);

            // 
            // panelRodape
            // 
            this.panelRodape.BackColor = Color.FromArgb(23, 23, 23);
            this.panelRodape.Dock = DockStyle.Bottom;
            this.panelRodape.Height = 48;
            this.panelRodape.Padding = new Padding(16, 8, 16, 8);
            this.panelRodape.Name = "panelRodape";

            // 
            // lblStatus
            // 
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.Font = new Font("Segoe UI", 8.5F);
            this.lblStatus.ForeColor = Color.FromArgb(145, 145, 145);
            this.lblStatus.Location = new Point(16, 14);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(650, 20);
            this.lblStatus.Text = "Pronto para analisar.";

            // 
            // progressBar
            // 
            this.progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.progressBar.Location = new Point(950, 14);
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new Size(210, 18);
            this.progressBar.Style = ProgressBarStyle.Continuous;

            this.panelRodape.Controls.Add(this.lblStatus);
            this.panelRodape.Controls.Add(this.progressBar);

            // 
            // Ordem dos controles
            // 
            this.Controls.Add(this.panelConteudo);
            this.Controls.Add(this.panelRodape);
            this.Controls.Add(this.panelAcoes);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelResumo);
            this.Controls.Add(this.panelCabecalho);

            this.panelCabecalho.ResumeLayout(false);
            this.panelCabecalho.PerformLayout();

            this.panelResumoTotal.ResumeLayout(false);
            this.panelResumoTotal.PerformLayout();

            this.panelResumoInstalados.ResumeLayout(false);
            this.panelResumoInstalados.PerformLayout();

            this.panelResumoRemoviveis.ResumeLayout(false);
            this.panelResumoRemoviveis.PerformLayout();

            this.panelResumoProtegidos.ResumeLayout(false);
            this.panelResumoProtegidos.PerformLayout();

            this.panelResumoSelecionados.ResumeLayout(false);
            this.panelResumoSelecionados.PerformLayout();

            this.panelResumo.ResumeLayout(false);

            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();

            this.panelAcoes.ResumeLayout(false);

            this.panelConteudo.ResumeLayout(false);

            this.panelRodape.ResumeLayout(false);

            this.ResumeLayout(false);
        }
    }
}