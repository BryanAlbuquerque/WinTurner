using System.Drawing;
using System.Windows.Forms;

namespace WinTuner.Forms.Limpeza
{
    partial class LimparCache
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel panelCabecalho;
        private Label lblTitulo;
        private Label lblDescricao;

        private Panel panelResumo;

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
        private Button btnLimparDns;

        private FlowLayoutPanel flowCards;

        private Panel panelRodape;
        private Label lblStatus;
        private ProgressBar progressBar;

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
            btnLimparDns = new Button();

            flowCards = new FlowLayoutPanel();

            panelRodape = new Panel();
            lblStatus = new Label();
            progressBar = new ProgressBar();

            panelCabecalho.SuspendLayout();

            panelResumo.SuspendLayout();
            panelResumoLocais.SuspendLayout();
            panelResumoArquivos.SuspendLayout();
            panelResumoEspaco.SuspendLayout();

            panelAcoes.SuspendLayout();

            panelRodape.SuspendLayout();

            SuspendLayout();

            // Form

            AutoScaleDimensions =
                new SizeF(7F, 15F);

            AutoScaleMode =
                AutoScaleMode.Font;

            BackColor =
                Color.FromArgb(15, 15, 15);

            ClientSize =
                new Size(1100, 700);

            MinimumSize =
                new Size(950, 600);

            StartPosition =
                FormStartPosition.CenterScreen;

            Text =
                "WinTurner - Limpar Cache";

            FormClosing +=
                LimparCache_FormClosing;

            // Cabeçalho

            panelCabecalho.BackColor =
                Color.FromArgb(23, 23, 23);

            panelCabecalho.BorderStyle =
                BorderStyle.FixedSingle;

            panelCabecalho.Dock =
                DockStyle.Top;

            panelCabecalho.Height =
                88;

            panelCabecalho.Padding =
                new Padding(24, 10, 24, 8);

            lblTitulo.Dock =
                DockStyle.Top;

            lblTitulo.Height =
                36;

            lblTitulo.Font =
                new Font(
                    "Segoe UI Semibold",
                    18F,
                    FontStyle.Bold);

            lblTitulo.ForeColor =
                Color.FromArgb(242, 242, 242);

            lblTitulo.Text =
                "LIMPAR CACHE";

            lblTitulo.TextAlign =
                ContentAlignment.MiddleLeft;

            lblDescricao.Dock =
                DockStyle.Fill;

            lblDescricao.Font =
                new Font(
                    "Segoe UI",
                    9.5F);

            lblDescricao.ForeColor =
                Color.FromArgb(145, 145, 145);

            lblDescricao.Text =
                "Analise e remova arquivos temporários de cache dos navegadores.";

            lblDescricao.TextAlign =
                ContentAlignment.MiddleLeft;

            panelCabecalho.Controls.Add(
                lblDescricao);

            panelCabecalho.Controls.Add(
                lblTitulo);

            // Resumo

            panelResumo.BackColor =
                Color.FromArgb(23, 23, 23);

            panelResumo.BorderStyle =
                BorderStyle.FixedSingle;

            panelResumo.Dock =
                DockStyle.Top;

            panelResumo.Height =
                100;

            panelResumo.Padding =
                new Padding(12);

            // Resumo - locais

            panelResumoLocais.BackColor =
                Color.FromArgb(27, 27, 27);

            panelResumoLocais.Dock =
                DockStyle.Left;

            panelResumoLocais.Width =
                250;

            // Resumo - arquivos

            panelResumoArquivos.BackColor =
                Color.FromArgb(27, 27, 27);

            panelResumoArquivos.Dock =
                DockStyle.Left;

            panelResumoArquivos.Width =
                280;

            // Resumo - espaço

            panelResumoEspaco.BackColor =
                Color.FromArgb(27, 27, 27);

            panelResumoEspaco.Dock =
                DockStyle.Fill;

            // Título locais

            lblTituloLocais.Dock =
                DockStyle.Top;

            lblTituloLocais.Height =
                30;

            lblTituloLocais.Font =
                new Font(
                    "Segoe UI",
                    8.5F);

            lblTituloLocais.ForeColor =
                Color.FromArgb(145, 145, 145);

            lblTituloLocais.Text =
                "CACHES ENCONTRADOS";

            lblTituloLocais.TextAlign =
                ContentAlignment.BottomLeft;

            // Valor locais

            lblLocaisSelecionados.Dock =
                DockStyle.Fill;

            lblLocaisSelecionados.Font =
                new Font(
                    "Segoe UI Semibold",
                    22F,
                    FontStyle.Bold);

            lblLocaisSelecionados.ForeColor =
                Color.FromArgb(242, 242, 242);

            lblLocaisSelecionados.Text =
                "0";

            lblLocaisSelecionados.TextAlign =
                ContentAlignment.MiddleLeft;

            panelResumoLocais.Controls.Add(
                lblLocaisSelecionados);

            panelResumoLocais.Controls.Add(
                lblTituloLocais);

            // Título arquivos

            lblTituloArquivos.Dock =
                DockStyle.Top;

            lblTituloArquivos.Height =
                30;

            lblTituloArquivos.Font =
                new Font(
                    "Segoe UI",
                    8.5F);

            lblTituloArquivos.ForeColor =
                Color.FromArgb(145, 145, 145);

            lblTituloArquivos.Text =
                "ARQUIVOS DE CACHE";

            lblTituloArquivos.TextAlign =
                ContentAlignment.BottomLeft;

            // Valor arquivos

            lblArquivosEncontrados.Dock =
                DockStyle.Fill;

            lblArquivosEncontrados.Font =
                new Font(
                    "Segoe UI Semibold",
                    22F,
                    FontStyle.Bold);

            lblArquivosEncontrados.ForeColor =
                Color.FromArgb(242, 242, 242);

            lblArquivosEncontrados.Text =
                "0";

            lblArquivosEncontrados.TextAlign =
                ContentAlignment.MiddleLeft;

            panelResumoArquivos.Controls.Add(
                lblArquivosEncontrados);

            panelResumoArquivos.Controls.Add(
                lblTituloArquivos);

            // Título espaço

            lblTituloEspaco.Dock =
                DockStyle.Top;

            lblTituloEspaco.Height =
                30;

            lblTituloEspaco.Font =
                new Font(
                    "Segoe UI",
                    8.5F);

            lblTituloEspaco.ForeColor =
                Color.FromArgb(145, 145, 145);

            lblTituloEspaco.Text =
                "ESPAÇO RECUPERÁVEL";

            lblTituloEspaco.TextAlign =
                ContentAlignment.BottomLeft;

            // Valor espaço

            lblEspacoLiberavel.Dock =
                DockStyle.Fill;

            lblEspacoLiberavel.Font =
                new Font(
                    "Segoe UI Semibold",
                    22F,
                    FontStyle.Bold);

            lblEspacoLiberavel.ForeColor =
                Color.FromArgb(208, 0, 0);

            lblEspacoLiberavel.Text =
                "0 B";

            lblEspacoLiberavel.TextAlign =
                ContentAlignment.MiddleLeft;

            panelResumoEspaco.Controls.Add(
                lblEspacoLiberavel);

            panelResumoEspaco.Controls.Add(
                lblTituloEspaco);

            panelResumo.Controls.Add(
                panelResumoEspaco);

            panelResumo.Controls.Add(
                panelResumoArquivos);

            panelResumo.Controls.Add(
                panelResumoLocais);

            // Ações

            panelAcoes.BackColor =
                Color.FromArgb(15, 15, 15);

            panelAcoes.Dock =
                DockStyle.Top;

            panelAcoes.Height =
                64;

            panelAcoes.Padding =
                new Padding(12, 10, 12, 10);

            // Botão analisar

            btnAnalisar.BackColor =
                Color.FromArgb(176, 0, 0);

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

            // Botão DNS

            btnLimparDns.BackColor =
                Color.FromArgb(45, 45, 45);

            btnLimparDns.Dock =
                DockStyle.Left;

            btnLimparDns.Width =
                170;

            btnLimparDns.Margin =
                new Padding(10, 0, 0, 0);

            btnLimparDns.FlatAppearance.BorderSize =
                0;

            btnLimparDns.FlatStyle =
                FlatStyle.Flat;

            btnLimparDns.Font =
                new Font(
                    "Segoe UI Semibold",
                    8.5F,
                    FontStyle.Bold);

            btnLimparDns.ForeColor =
                Color.FromArgb(235, 235, 235);

            btnLimparDns.Cursor =
                Cursors.Hand;

            btnLimparDns.Text =
                "LIMPAR CACHE DNS";

            btnLimparDns.UseVisualStyleBackColor =
                false;

            btnLimparDns.Click +=
                btnLimparDns_Click;

            // Botão limpar

            btnLimpar.BackColor =
                Color.FromArgb(208, 0, 0);

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
                btnLimparDns);

            panelAcoes.Controls.Add(
                btnAnalisar);

            // Cards

            flowCards.BackColor =
                Color.FromArgb(15, 15, 15);

            flowCards.Dock =
                DockStyle.Fill;

            flowCards.AutoScroll =
                true;

            flowCards.FlowDirection =
                FlowDirection.LeftToRight;

            flowCards.WrapContents =
                true;

            flowCards.Padding =
                new Padding(12, 8, 12, 20);

            flowCards.Margin =
                new Padding(0);

            // Rodapé

            panelRodape.BackColor =
                Color.FromArgb(23, 23, 23);

            panelRodape.BorderStyle =
                BorderStyle.FixedSingle;

            panelRodape.Dock =
                DockStyle.Bottom;

            panelRodape.Height =
                50;

            panelRodape.Padding =
                new Padding(15, 0, 15, 0);

            // Status

            lblStatus.Dock =
                DockStyle.Fill;

            lblStatus.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblStatus.ForeColor =
                Color.FromArgb(145, 145, 145);

            lblStatus.Text =
                "Clique em ANALISAR para verificar os caches.";

            lblStatus.TextAlign =
                ContentAlignment.MiddleLeft;

            lblStatus.AutoEllipsis =
                true;

            // Barra de progresso

            progressBar.Dock =
                DockStyle.Right;

            progressBar.Width =
                220;

            progressBar.Style =
                ProgressBarStyle.Marquee;

            progressBar.MarqueeAnimationSpeed =
                25;

            progressBar.Visible =
                false;

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

            panelResumoLocais.ResumeLayout(false);
            panelResumoArquivos.ResumeLayout(false);
            panelResumoEspaco.ResumeLayout(false);
            panelResumo.ResumeLayout(false);

            panelAcoes.ResumeLayout(false);

            panelRodape.ResumeLayout(false);

            ResumeLayout(false);
        }
    }
}