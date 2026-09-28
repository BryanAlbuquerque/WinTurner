using System.Drawing;
using System.Windows.Forms;

namespace WinTuner.Forms.Limpeza
{
    partial class ArquivosInuteis
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel panelCabecalho;
        private Label lblTitulo;
        private Label lblDescricao;

        private Panel panelResumo;
        private TableLayoutPanel tabelaResumo;

        private Panel panelResumoLocais;
        private Label lblTituloLocais;
        private Label lblLocaisSelecionados;

        private Panel panelResumoArquivos;
        private Label lblTituloArquivos;
        private Label lblArquivosEncontrados;

        private Panel panelResumoEspaco;
        private Label lblTituloEspaco;
        private Label lblEspacoLiberavel;

        private Panel panelAcoes;
        private Button btnAnalisar;
        private Button btnLimpar;

        private FlowLayoutPanel flowCards;

        private Panel panelRodape;
        private Label lblStatus;

        private Panel progressBar;
        private Panel progressBarIndicador;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components =
                new System.ComponentModel.Container();

            panelCabecalho = new Panel();
            lblTitulo = new Label();
            lblDescricao = new Label();

            panelResumo = new Panel();
            tabelaResumo = new TableLayoutPanel();

            panelResumoLocais = new Panel();
            lblTituloLocais = new Label();
            lblLocaisSelecionados = new Label();

            panelResumoArquivos = new Panel();
            lblTituloArquivos = new Label();
            lblArquivosEncontrados = new Label();

            panelResumoEspaco = new Panel();
            lblTituloEspaco = new Label();
            lblEspacoLiberavel = new Label();

            panelAcoes = new Panel();
            btnAnalisar = new Button();
            btnLimpar = new Button();

            flowCards = new FlowLayoutPanel();

            panelRodape = new Panel();
            lblStatus = new Label();

            progressBar = new Panel();
            progressBarIndicador = new Panel();

            panelCabecalho.SuspendLayout();

            panelResumo.SuspendLayout();
            tabelaResumo.SuspendLayout();

            panelResumoLocais.SuspendLayout();
            panelResumoArquivos.SuspendLayout();
            panelResumoEspaco.SuspendLayout();

            panelAcoes.SuspendLayout();
            panelRodape.SuspendLayout();
            progressBar.SuspendLayout();

            SuspendLayout();

            // Form

            AutoScaleDimensions =
                new SizeF(7F, 15F);

            AutoScaleMode =
                AutoScaleMode.Font;

            BackColor =
                Color.FromArgb(
                    15,
                    15,
                    15);

            ClientSize =
                new Size(
                    1100,
                    700);

            MinimumSize =
                new Size(
                    950,
                    600);

            StartPosition =
                FormStartPosition.CenterScreen;

            Text =
                "WinTurner - Arquivos Inúteis";

            FormClosing +=
                ArquivosInuteis_FormClosing;

            // Cabeçalho

            panelCabecalho.BackColor =
                Color.FromArgb(
                    23,
                    23,
                    23);

            panelCabecalho.BorderStyle =
                BorderStyle.FixedSingle;

            panelCabecalho.Dock =
                DockStyle.Top;

            panelCabecalho.Height =
                88;

            panelCabecalho.Padding =
                new Padding(
                    24,
                    12,
                    24,
                    10);

            lblTitulo.Dock =
                DockStyle.Top;

            lblTitulo.Height =
                38;

            lblTitulo.Font =
                new Font(
                    "Segoe UI Semibold",
                    18F,
                    FontStyle.Bold);

            lblTitulo.ForeColor =
                Color.FromArgb(
                    242,
                    242,
                    242);

            lblTitulo.Text =
                "ARQUIVOS INÚTEIS";

            lblTitulo.TextAlign =
                ContentAlignment.MiddleLeft;

            lblDescricao.Dock =
                DockStyle.Fill;

            lblDescricao.Font =
                new Font(
                    "Segoe UI",
                    9.5F);

            lblDescricao.ForeColor =
                Color.FromArgb(
                    145,
                    145,
                    145);

            lblDescricao.Text =
                "Encontre arquivos temporários, backups e relatórios que podem ser removidos.";

            lblDescricao.TextAlign =
                ContentAlignment.MiddleLeft;

            panelCabecalho.Controls.Add(
                lblDescricao);

            panelCabecalho.Controls.Add(
                lblTitulo);

            // Resumo

            panelResumo.BackColor =
                Color.FromArgb(
                    23,
                    23,
                    23);

            panelResumo.BorderStyle =
                BorderStyle.FixedSingle;

            panelResumo.Dock =
                DockStyle.Top;

            panelResumo.Height =
                96;

            panelResumo.Padding =
                new Padding(
                    10);

            tabelaResumo.Dock =
                DockStyle.Fill;

            tabelaResumo.ColumnCount =
                3;

            tabelaResumo.RowCount =
                1;

            tabelaResumo.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    33.33F));

            tabelaResumo.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    33.33F));

            tabelaResumo.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    33.34F));

            tabelaResumo.RowStyles.Add(
                new RowStyle(
                    SizeType.Percent,
                    100F));

            // Locais

            panelResumoLocais.BackColor =
                Color.FromArgb(
                    27,
                    27,
                    27);

            panelResumoLocais.Dock =
                DockStyle.Fill;

            panelResumoLocais.Margin =
                new Padding(
                    0,
                    0,
                    5,
                    0);

            lblTituloLocais.Dock =
                DockStyle.Top;

            lblTituloLocais.Height =
                30;

            lblTituloLocais.Font =
                new Font(
                    "Segoe UI",
                    8.5F);

            lblTituloLocais.ForeColor =
                Color.FromArgb(
                    145,
                    145,
                    145);

            lblTituloLocais.Text =
                "CATEGORIAS SELECIONADAS";

            lblTituloLocais.TextAlign =
                ContentAlignment.BottomLeft;

            lblLocaisSelecionados.Dock =
                DockStyle.Fill;

            lblLocaisSelecionados.Font =
                new Font(
                    "Segoe UI Semibold",
                    22F,
                    FontStyle.Bold);

            lblLocaisSelecionados.ForeColor =
                Color.FromArgb(
                    242,
                    242,
                    242);

            lblLocaisSelecionados.Text =
                "0";

            lblLocaisSelecionados.TextAlign =
                ContentAlignment.MiddleLeft;

            panelResumoLocais.Controls.Add(
                lblLocaisSelecionados);

            panelResumoLocais.Controls.Add(
                lblTituloLocais);

            // Arquivos

            panelResumoArquivos.BackColor =
                Color.FromArgb(
                    27,
                    27,
                    27);

            panelResumoArquivos.Dock =
                DockStyle.Fill;

            panelResumoArquivos.Margin =
                new Padding(
                    5,
                    0,
                    5,
                    0);

            lblTituloArquivos.Dock =
                DockStyle.Top;

            lblTituloArquivos.Height =
                30;

            lblTituloArquivos.Font =
                new Font(
                    "Segoe UI",
                    8.5F);

            lblTituloArquivos.ForeColor =
                Color.FromArgb(
                    145,
                    145,
                    145);

            lblTituloArquivos.Text =
                "ARQUIVOS ENCONTRADOS";

            lblTituloArquivos.TextAlign =
                ContentAlignment.BottomLeft;

            lblArquivosEncontrados.Dock =
                DockStyle.Fill;

            lblArquivosEncontrados.Font =
                new Font(
                    "Segoe UI Semibold",
                    22F,
                    FontStyle.Bold);

            lblArquivosEncontrados.ForeColor =
                Color.FromArgb(
                    242,
                    242,
                    242);

            lblArquivosEncontrados.Text =
                "0";

            lblArquivosEncontrados.TextAlign =
                ContentAlignment.MiddleLeft;

            panelResumoArquivos.Controls.Add(
                lblArquivosEncontrados);

            panelResumoArquivos.Controls.Add(
                lblTituloArquivos);

            // Espaço

            panelResumoEspaco.BackColor =
                Color.FromArgb(
                    27,
                    27,
                    27);

            panelResumoEspaco.Dock =
                DockStyle.Fill;

            panelResumoEspaco.Margin =
                new Padding(
                    5,
                    0,
                    0,
                    0);

            lblTituloEspaco.Dock =
                DockStyle.Top;

            lblTituloEspaco.Height =
                30;

            lblTituloEspaco.Font =
                new Font(
                    "Segoe UI",
                    8.5F);

            lblTituloEspaco.ForeColor =
                Color.FromArgb(
                    145,
                    145,
                    145);

            lblTituloEspaco.Text =
                "ESPAÇO RECUPERÁVEL";

            lblTituloEspaco.TextAlign =
                ContentAlignment.BottomLeft;

            lblEspacoLiberavel.Dock =
                DockStyle.Fill;

            lblEspacoLiberavel.Font =
                new Font(
                    "Segoe UI Semibold",
                    22F,
                    FontStyle.Bold);

            lblEspacoLiberavel.ForeColor =
                Color.FromArgb(
                    208,
                    0,
                    0);

            lblEspacoLiberavel.Text =
                "0 B";

            lblEspacoLiberavel.TextAlign =
                ContentAlignment.MiddleLeft;

            panelResumoEspaco.Controls.Add(
                lblEspacoLiberavel);

            panelResumoEspaco.Controls.Add(
                lblTituloEspaco);

            tabelaResumo.Controls.Add(
                panelResumoLocais,
                0,
                0);

            tabelaResumo.Controls.Add(
                panelResumoArquivos,
                1,
                0);

            tabelaResumo.Controls.Add(
                panelResumoEspaco,
                2,
                0);

            panelResumo.Controls.Add(
                tabelaResumo);

            // Ações

            panelAcoes.BackColor =
                Color.FromArgb(
                    15,
                    15,
                    15);

            panelAcoes.Dock =
                DockStyle.Top;

            panelAcoes.Height =
                62;

            panelAcoes.Padding =
                new Padding(
                    10);

            btnAnalisar.BackColor =
                Color.FromArgb(
                    176,
                    0,
                    0);

            btnAnalisar.Dock =
                DockStyle.Left;

            btnAnalisar.Width =
                150;

            btnAnalisar.FlatAppearance.BorderSize =
                0;

            btnAnalisar.FlatStyle =
                FlatStyle.Flat;

            btnAnalisar.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            btnAnalisar.ForeColor =
                Color.White;

            btnAnalisar.Cursor =
                Cursors.Hand;

            btnAnalisar.Text =
                "ANALISAR";

            btnAnalisar.UseVisualStyleBackColor =
                false;

            btnAnalisar.Click +=
                btnAnalisar_Click;

            btnLimpar.BackColor =
                Color.FromArgb(
                    208,
                    0,
                    0);

            btnLimpar.Dock =
                DockStyle.Right;

            btnLimpar.Width =
                185;

            btnLimpar.FlatAppearance.BorderSize =
                0;

            btnLimpar.FlatStyle =
                FlatStyle.Flat;

            btnLimpar.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            btnLimpar.ForeColor =
                Color.White;

            btnLimpar.Cursor =
                Cursors.Hand;

            btnLimpar.Text =
                "LIMPAR SELECIONADOS";

            btnLimpar.UseVisualStyleBackColor =
                false;

            btnLimpar.Click +=
                btnLimpar_Click;

            panelAcoes.Controls.Add(
                btnLimpar);

            panelAcoes.Controls.Add(
                btnAnalisar);

            // Cards

            flowCards.BackColor =
                Color.FromArgb(
                    15,
                    15,
                    15);

            flowCards.Dock =
                DockStyle.Fill;

            flowCards.AutoScroll =
                true;

            flowCards.FlowDirection =
                FlowDirection.LeftToRight;

            flowCards.WrapContents =
                true;

            flowCards.Padding =
                new Padding(
                    10,
                    8,
                    10,
                    15);

            // Rodapé

            panelRodape.BackColor =
                Color.FromArgb(
                    23,
                    23,
                    23);

            panelRodape.BorderStyle =
                BorderStyle.FixedSingle;

            panelRodape.Dock =
                DockStyle.Bottom;

            panelRodape.Height =
                48;

            panelRodape.Padding =
                new Padding(
                    15,
                    0,
                    15,
                    0);

            lblStatus.Dock =
                DockStyle.Fill;

            lblStatus.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblStatus.ForeColor =
                Color.FromArgb(
                    145,
                    145,
                    145);

            lblStatus.Text =
                "Clique em ANALISAR para procurar arquivos inúteis.";

            lblStatus.TextAlign =
                ContentAlignment.MiddleLeft;

            lblStatus.AutoEllipsis =
                true;

            // Barra de carregamento

            progressBar.BackColor =
                Color.FromArgb(
                    35,
                    35,
                    35);

            progressBar.Dock =
                DockStyle.Right;

            progressBar.Width =
                220;

            progressBar.Height =
                8;

            progressBar.Visible =
                false;

            progressBarIndicador.BackColor =
                Color.FromArgb(
                    208,
                    0,
                    0);

            progressBarIndicador.Dock =
                DockStyle.Left;

            progressBarIndicador.Width =
                65;

            progressBar.Controls.Add(
                progressBarIndicador);

            panelRodape.Controls.Add(
                progressBar);

            panelRodape.Controls.Add(
                lblStatus);

            // Controles principais

            Controls.Add(
                flowCards);

            Controls.Add(
                panelRodape);

            Controls.Add(
                panelAcoes);

            Controls.Add(
                panelResumo);

            Controls.Add(
                panelCabecalho);

            panelCabecalho.ResumeLayout(false);
            panelCabecalho.PerformLayout();

            panelResumoLocais.ResumeLayout(false);
            panelResumoArquivos.ResumeLayout(false);
            panelResumoEspaco.ResumeLayout(false);

            tabelaResumo.ResumeLayout(false);
            panelResumo.ResumeLayout(false);

            panelAcoes.ResumeLayout(false);

            progressBar.ResumeLayout(false);
            panelRodape.ResumeLayout(false);

            ResumeLayout(false);
        }
    }
}