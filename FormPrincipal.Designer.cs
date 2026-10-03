using System.Drawing;
using System.Windows.Forms;

namespace WinTuner
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel SideBar;
        private PictureBox pictureBox1;

        private ReaLTaiizor.Controls.BigLabel lbl;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel1;

        private ReaLTaiizor.Controls.Button btnDiagnostico;
        private ReaLTaiizor.Controls.Button btnLimpeza;
        private ReaLTaiizor.Controls.Button btnOtimizacao;

        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel3;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel4;
        private ReaLTaiizor.Controls.DungeonLabel lblGpuNome;

        private ReaLTaiizor.Controls.DungeonLabel lblCPU;
        private ReaLTaiizor.Controls.DungeonLabel lblRAM;
        private ReaLTaiizor.Controls.DungeonLabel lblDISCO;
        private ReaLTaiizor.Controls.DungeonLabel lblGPU;

        private System.Windows.Forms.Timer timerSistema;

        private ReaLTaiizor.Controls.PoisonDataGridView dgvProcessos;

        private ReaLTaiizor.Controls.Panel panel1;
        private ReaLTaiizor.Controls.Panel panel2;
        private ReaLTaiizor.Controls.Panel panel3;
        private ReaLTaiizor.Controls.Panel panel4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(
                    typeof(FormPrincipal));

            DataGridViewCellStyle headerStyle =
                new DataGridViewCellStyle();

            DataGridViewCellStyle cellStyle =
                new DataGridViewCellStyle();

            DataGridViewCellStyle rowHeaderStyle =
                new DataGridViewCellStyle();

            SideBar = new Panel();
            pictureBox1 = new PictureBox();

            btnDiagnostico =
                new ReaLTaiizor.Controls.Button();

            btnLimpeza =
                new ReaLTaiizor.Controls.Button();

            btnOtimizacao =
                new ReaLTaiizor.Controls.Button();


            lbl =
                new ReaLTaiizor.Controls.BigLabel();

            dungeonLabel1 =
                new ReaLTaiizor.Controls.DungeonLabel();

            panel1 =
                new ReaLTaiizor.Controls.Panel();

            panel2 =
                new ReaLTaiizor.Controls.Panel();

            panel3 =
                new ReaLTaiizor.Controls.Panel();

            panel4 =
                new ReaLTaiizor.Controls.Panel();

            dungeonLabel3 =
                new ReaLTaiizor.Controls.DungeonLabel();

            dungeonLabel2 =
                new ReaLTaiizor.Controls.DungeonLabel();

            dungeonLabel4 =
                new ReaLTaiizor.Controls.DungeonLabel();

            lblGpuNome =
                new ReaLTaiizor.Controls.DungeonLabel();

            lblCPU =
                new ReaLTaiizor.Controls.DungeonLabel();

            lblRAM =
                new ReaLTaiizor.Controls.DungeonLabel();

            lblDISCO =
                new ReaLTaiizor.Controls.DungeonLabel();

            lblGPU =
                new ReaLTaiizor.Controls.DungeonLabel();

            dgvProcessos =
                new ReaLTaiizor.Controls.PoisonDataGridView();

            timerSistema =
                new System.Windows.Forms.Timer(components);

            SideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();

            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)dgvProcessos).BeginInit();

            SuspendLayout();

            // FormPrincipal
            AutoScaleDimensions =
                new SizeF(7F, 15F);

            AutoScaleMode =
                AutoScaleMode.Font;

            BackColor =
                Color.FromArgb(15, 15, 15);

            ClientSize =
                new Size(1280, 720);

            MinimumSize =
                new Size(1100, 650);

            StartPosition =
                FormStartPosition.CenterScreen;

            Name =
                "FormPrincipal";

            Text =
                "WinTurner";

            Icon =
                (Icon)resources.GetObject("$this.Icon");

            WindowState =
                FormWindowState.Maximized;

            Load +=
                FormPrincipal_Load;

            // SideBar
            SideBar.BackColor =
                Color.FromArgb(5, 5, 5);

            SideBar.Dock =
                DockStyle.Left;

            SideBar.Width =
                220;

            SideBar.Padding =
                new Padding(15, 15, 15, 20);

            SideBar.Controls.Add(
                btnOtimizacao);

            SideBar.Controls.Add(
                btnLimpeza);

            SideBar.Controls.Add(
                btnDiagnostico);

            SideBar.Controls.Add(
                pictureBox1);

            // Logo
            pictureBox1.Dock =
                DockStyle.Top;

            pictureBox1.Size = new Size(200, 125);

            pictureBox1.SizeMode =
                PictureBoxSizeMode.Zoom;

            pictureBox1.Margin =
                new Padding(0);

            pictureBox1.TabStop =
                false;

            pictureBox1.Image =
                (Image)resources.GetObject("pictureBox1.Image");

            // Botões
            ConfigurarBotao(
                btnDiagnostico,
                "Diagnóstico",
                170);

            ConfigurarBotao(
                btnLimpeza,
                "Limpeza",
                225);

            ConfigurarBotao(
                btnOtimizacao,
                "Otimização",
                280);

            btnDiagnostico.Click +=
                btnDiagnostico_Click;

            btnLimpeza.Click +=
                btnLimpeza_Click;

            btnOtimizacao.Click +=
                btnOtimizacao_Click;

            // Título
            lbl.AutoSize =
                false;

            lbl.Dock =
                DockStyle.Top;

            lbl.Height =
                58;

            lbl.Font =
                new Font(
                    "Segoe UI Semibold",
                    24F,
                    FontStyle.Bold);

            lbl.ForeColor =
                Color.FromArgb(242, 242, 242);

            lbl.Text =
                "PAINEL DE CONTROLE";

            lbl.TextAlign =
                ContentAlignment.MiddleLeft;

            lbl.Padding =
                new Padding(28, 0, 0, 0);

            // Subtítulo
            dungeonLabel1.AutoSize =
                false;

            dungeonLabel1.Dock =
                DockStyle.Top;

            dungeonLabel1.Height =
                32;

            dungeonLabel1.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Regular);

            dungeonLabel1.ForeColor =
                Color.FromArgb(145, 145, 145);

            dungeonLabel1.Text =
                "Visão geral do sistema";

            dungeonLabel1.TextAlign =
                ContentAlignment.MiddleLeft;

            dungeonLabel1.Padding =
                new Padding(30, 0, 0, 0);

            // Cards
            ConfigurarCard(
                panel1,
                dungeonLabel3,
                lblCPU,
                "CPU",
                "0%");

            ConfigurarCard(
                panel2,
                dungeonLabel2,
                lblRAM,
                "RAM",
                "0%");

            ConfigurarCard(
                panel3,
                dungeonLabel4,
                lblDISCO,
                "DISCO",
                "0%");

            ConfigurarCard(
                panel4,
                lblGpuNome,
                lblGPU,
                "GPU",
                "Não identificada");

            // Container dos cards
            TableLayoutPanel painelCards =
                new TableLayoutPanel();

            painelCards.Dock =
                DockStyle.Top;

            painelCards.Height =
                125;

            painelCards.Padding =
                new Padding(28, 12, 28, 10);

            painelCards.BackColor =
                Color.FromArgb(15, 15, 15);

            painelCards.ColumnCount =
                4;

            painelCards.RowCount =
                1;

            painelCards.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    25F));

            painelCards.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    25F));

            painelCards.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    25F));

            painelCards.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    25F));

            painelCards.RowStyles.Add(
                new RowStyle(
                    SizeType.Percent,
                    100F));

            painelCards.Controls.Add(
                panel1,
                0,
                0);

            painelCards.Controls.Add(
                panel2,
                1,
                0);

            painelCards.Controls.Add(
                panel3,
                2,
                0);

            painelCards.Controls.Add(
                panel4,
                3,
                0);

            // Título dos processos
            ReaLTaiizor.Controls.DungeonLabel lblTituloProcessos =
                new ReaLTaiizor.Controls.DungeonLabel();

            lblTituloProcessos.AutoSize =
                false;

            lblTituloProcessos.Dock =
                DockStyle.Top;

            lblTituloProcessos.Height =
                45;

            lblTituloProcessos.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            lblTituloProcessos.ForeColor =
                Color.FromArgb(235, 235, 235);

            lblTituloProcessos.Text =
                "Aplicativos em execução";

            lblTituloProcessos.TextAlign =
                ContentAlignment.MiddleLeft;

            lblTituloProcessos.Padding =
                new Padding(30, 0, 0, 0);

            // Área da tabela
            Panel painelProcessos =
                new Panel();

            painelProcessos.Dock =
                DockStyle.Fill;

            painelProcessos.BackColor =
                Color.FromArgb(15, 15, 15);

            painelProcessos.Padding =
                new Padding(28, 0, 28, 20);

            painelProcessos.Controls.Add(
                dgvProcessos);

            painelProcessos.Controls.Add(
                lblTituloProcessos);

            // Tabela
            dgvProcessos.Dock =
                DockStyle.Fill;

            dgvProcessos.BackgroundColor =
                Color.FromArgb(25, 25, 25);

            dgvProcessos.BorderStyle =
                BorderStyle.FixedSingle;

            dgvProcessos.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvProcessos.GridColor =
                Color.FromArgb(48, 48, 48);

            dgvProcessos.EnableHeadersVisualStyles =
                false;

            dgvProcessos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvProcessos.MultiSelect =
                false;

            dgvProcessos.AllowUserToAddRows =
                false;

            dgvProcessos.AllowUserToDeleteRows =
                false;

            dgvProcessos.AllowUserToResizeRows =
                false;

            dgvProcessos.RowHeadersVisible =
                false;

            dgvProcessos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvProcessos.RowTemplate.Height =
                34;

            dgvProcessos.Font =
                new Font(
                    "Segoe UI",
                    9F);

            headerStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            headerStyle.BackColor =
                Color.FromArgb(176, 0, 0);

            headerStyle.ForeColor =
                Color.White;

            headerStyle.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            headerStyle.SelectionBackColor =
                Color.FromArgb(176, 0, 0);

            headerStyle.SelectionForeColor =
                Color.White;

            headerStyle.Padding =
                new Padding(8, 0, 8, 0);

            dgvProcessos.ColumnHeadersDefaultCellStyle =
                headerStyle;

            dgvProcessos.ColumnHeadersHeight =
                38;

            cellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            cellStyle.BackColor =
                Color.FromArgb(25, 25, 25);

            cellStyle.ForeColor =
                Color.FromArgb(225, 225, 225);

            cellStyle.SelectionBackColor =
                Color.FromArgb(55, 20, 20);

            cellStyle.SelectionForeColor =
                Color.White;

            cellStyle.Padding =
                new Padding(8, 0, 8, 0);

            dgvProcessos.DefaultCellStyle =
                cellStyle;

            rowHeaderStyle.BackColor =
                Color.FromArgb(25, 25, 25);

            rowHeaderStyle.ForeColor =
                Color.White;

            dgvProcessos.RowHeadersDefaultCellStyle =
                rowHeaderStyle;

            // Timer
            timerSistema.Interval =
                1000;

            timerSistema.Enabled =
                true;

            // Controles principais
            Controls.Add(
                painelProcessos);

            Controls.Add(
                painelCards);

            Controls.Add(
                dungeonLabel1);

            Controls.Add(
                lbl);

            Controls.Add(
                SideBar);

            SideBar.ResumeLayout(false);
            SideBar.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)pictureBox1)
                .EndInit();

            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)dgvProcessos)
                .EndInit();

            ResumeLayout(false);
        }

        private void ConfigurarBotao(
            ReaLTaiizor.Controls.Button botao,
            string texto,
            int top)
        {
            botao.BackColor =
                Color.FromArgb(5, 5, 5);

            botao.BorderColor =
                Color.Transparent;

            botao.Cursor =
                Cursors.Hand;

            botao.EnteredBorderColor =
                Color.FromArgb(176, 0, 0);

            botao.EnteredColor =
                Color.FromArgb(28, 28, 28);

            botao.InactiveColor =
                Color.FromArgb(5, 5, 5);

            botao.PressedBorderColor =
                Color.FromArgb(208, 0, 0);

            botao.PressedColor =
                Color.FromArgb(90, 0, 0);

            botao.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            botao.ForeColor =
                Color.FromArgb(225, 225, 225);

            botao.Image =
                null;

            botao.ImageAlign =
                ContentAlignment.MiddleLeft;

            botao.Location =
                new Point(15, top);

            botao.Size =
                new Size(190, 44);

            botao.Text =
                texto;

            botao.TextAlignment =
                StringAlignment.Center;
        }

        private void ConfigurarCard(
            ReaLTaiizor.Controls.Panel painel,
            ReaLTaiizor.Controls.DungeonLabel titulo,
            ReaLTaiizor.Controls.DungeonLabel valor,
            string nome,
            string valorInicial)
        {
            painel.Dock =
                DockStyle.Fill;

            painel.Margin =
                new Padding(6);

            painel.Padding =
                new Padding(14);

            painel.BackColor =
                Color.FromArgb(28, 28, 28);

            painel.EdgeColor =
                Color.FromArgb(55, 55, 55);

            painel.SmoothingType =
                System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            titulo.Dock =
                DockStyle.Top;

            titulo.Height =
                28;

            titulo.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            titulo.ForeColor =
                Color.FromArgb(208, 0, 0);

            titulo.Text =
                nome;

            titulo.TextAlign =
                ContentAlignment.MiddleLeft;

            valor.Dock =
                DockStyle.Fill;

            valor.Font =
                new Font(
                    "Segoe UI Semibold",
                    16F,
                    FontStyle.Bold);

            valor.ForeColor =
                Color.FromArgb(242, 242, 242);

            valor.Text =
                valorInicial;

            valor.TextAlign =
                ContentAlignment.MiddleLeft;

            painel.Controls.Add(
                valor);

            painel.Controls.Add(
                titulo);
        }
    }
}