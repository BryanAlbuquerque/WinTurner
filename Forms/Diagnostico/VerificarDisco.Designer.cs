using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static ReaLTaiizor.Drawing.Poison.PoisonPaint;
using static System.Net.Mime.MediaTypeNames;

namespace WinTuner.Forms.Diagnostico
{
    partial class VerificarDisco
    {
        private System.ComponentModel.IContainer components = null!;

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
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            headerLabel1 = new ReaLTaiizor.Controls.HeaderLabel();
            panelDisco = new ReaLTaiizor.Controls.Panel();
            lblTituloDisco = new Label();
            cmbUnidades = new ComboBox();
            btnAtualizar = new Button();
            lblUnidade = new Label();
            lblDadosDisco01 = new Label();
            lblVolume = new Label();
            lblDadosDisco02 = new Label();
            lblTituloSistemaArquivos = new Label();
            lblSistemaArquivos = new Label();
            lblTituloCapacidade = new Label();
            lblCapacidade = new Label();
            lblTituloUtilizado = new Label();
            lblUtilizado = new Label();
            lblTituloDisponivel = new Label();
            lblDisponivel = new Label();
            panelStatus = new ReaLTaiizor.Controls.Panel();
            lblTituloStatus = new Label();
            lblStatus = new Label();
            lblDescricaoStatus = new Label();
            panelVerificacao = new ReaLTaiizor.Controls.Panel();
            lblTituloVerificacao = new Label();
            lblEtapa1 = new Label();
            lblEtapa2 = new Label();
            lblEtapa3 = new Label();
            progressBar = new ProgressBar();
            btnVerificar = new Button();
            panelResultado = new ReaLTaiizor.Controls.Panel();
            lblTituloResultado = new Label();
            lblResultado = new Label();
            panelHeader.SuspendLayout();
            panelDisco.SuspendLayout();
            panelStatus.SuspendLayout();
            panelVerificacao.SuspendLayout();
            panelResultado.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(26, 26, 26);
            panelHeader.Controls.Add(bigLabel1);
            panelHeader.Controls.Add(headerLabel1);
            panelHeader.EdgeColor = Color.FromArgb(220, 35, 35);
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
            bigLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 21F, FontStyle.Bold);
            bigLabel1.ForeColor = Color.FromArgb(220, 35, 35);
            bigLabel1.Location = new Point(22, 17);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(271, 38);
            bigLabel1.TabIndex = 0;
            bigLabel1.Text = "Verificação do disco";
            // 
            // headerLabel1
            // 
            headerLabel1.AutoSize = true;
            headerLabel1.BackColor = Color.Transparent;
            headerLabel1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            headerLabel1.ForeColor = Color.FromArgb(145, 145, 145);
            headerLabel1.Location = new Point(24, 62);
            headerLabel1.Name = "headerLabel1";
            headerLabel1.Size = new Size(396, 17);
            headerLabel1.TabIndex = 1;
            headerLabel1.Text = "Analise a integridade e o sistema de arquivos do armazenamento.";
            // 
            // panelDisco
            // 
            panelDisco.BackColor = Color.FromArgb(23, 23, 23);
            panelDisco.Controls.Add(lblTituloDisco);
            panelDisco.Controls.Add(cmbUnidades);
            panelDisco.Controls.Add(btnAtualizar);
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
            panelDisco.EdgeColor = Color.FromArgb(48, 48, 48);
            panelDisco.Location = new Point(12, 128);
            panelDisco.Name = "panelDisco";
            panelDisco.Padding = new Padding(5);
            panelDisco.Size = new Size(480, 250);
            panelDisco.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panelDisco.TabIndex = 1;
            // 
            // lblTituloDisco
            // 
            lblTituloDisco.AutoSize = true;
            lblTituloDisco.BackColor = Color.Transparent;
            lblTituloDisco.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTituloDisco.ForeColor = Color.FromArgb(220, 35, 35);
            lblTituloDisco.Location = new Point(20, 15);
            lblTituloDisco.Name = "lblTituloDisco";
            lblTituloDisco.Size = new Size(219, 19);
            lblTituloDisco.TabIndex = 0;
            lblTituloDisco.Text = "UNIDADE DE ARMAZENAMENTO";
            // 
            // cmbUnidades
            // 
            cmbUnidades.BackColor = Color.FromArgb(30, 30, 30);
            cmbUnidades.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnidades.FlatStyle = FlatStyle.Flat;
            cmbUnidades.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbUnidades.ForeColor = Color.FromArgb(235, 235, 235);
            cmbUnidades.FormattingEnabled = true;
            cmbUnidades.Location = new Point(20, 43);
            cmbUnidades.Name = "cmbUnidades";
            cmbUnidades.Size = new Size(300, 23);
            cmbUnidades.TabIndex = 1;
            cmbUnidades.SelectedIndexChanged += cmbUnidades_SelectedIndexChanged;
            // 
            // btnAtualizar
            // 
            btnAtualizar.BackColor = Color.FromArgb(40, 40, 40);
            btnAtualizar.Cursor = Cursors.Hand;
            btnAtualizar.FlatAppearance.BorderColor = Color.FromArgb(65, 65, 65);
            btnAtualizar.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 50, 50);
            btnAtualizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 55);
            btnAtualizar.FlatStyle = FlatStyle.Flat;
            btnAtualizar.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnAtualizar.ForeColor = Color.FromArgb(235, 235, 235);
            btnAtualizar.Location = new Point(330, 42);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(110, 25);
            btnAtualizar.TabIndex = 2;
            btnAtualizar.Text = "ATUALIZAR";
            btnAtualizar.UseVisualStyleBackColor = false;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // lblUnidade
            // 
            lblUnidade.Location = new Point(0, 0);
            lblUnidade.Name = "lblUnidade";
            lblUnidade.Size = new Size(100, 23);
            lblUnidade.TabIndex = 3;
            // 
            // lblDadosDisco01
            // 
            lblDadosDisco01.Location = new Point(0, 0);
            lblDadosDisco01.Name = "lblDadosDisco01";
            lblDadosDisco01.Size = new Size(100, 23);
            lblDadosDisco01.TabIndex = 4;
            // 
            // lblVolume
            // 
            lblVolume.Location = new Point(0, 0);
            lblVolume.Name = "lblVolume";
            lblVolume.Size = new Size(100, 23);
            lblVolume.TabIndex = 5;
            // 
            // lblDadosDisco02
            // 
            lblDadosDisco02.Location = new Point(0, 0);
            lblDadosDisco02.Name = "lblDadosDisco02";
            lblDadosDisco02.Size = new Size(100, 23);
            lblDadosDisco02.TabIndex = 6;
            // 
            // lblTituloSistemaArquivos
            // 
            lblTituloSistemaArquivos.Location = new Point(0, 0);
            lblTituloSistemaArquivos.Name = "lblTituloSistemaArquivos";
            lblTituloSistemaArquivos.Size = new Size(100, 23);
            lblTituloSistemaArquivos.TabIndex = 7;
            // 
            // lblSistemaArquivos
            // 
            lblSistemaArquivos.Location = new Point(0, 0);
            lblSistemaArquivos.Name = "lblSistemaArquivos";
            lblSistemaArquivos.Size = new Size(100, 23);
            lblSistemaArquivos.TabIndex = 8;
            // 
            // lblTituloCapacidade
            // 
            lblTituloCapacidade.Location = new Point(0, 0);
            lblTituloCapacidade.Name = "lblTituloCapacidade";
            lblTituloCapacidade.Size = new Size(100, 23);
            lblTituloCapacidade.TabIndex = 9;
            // 
            // lblCapacidade
            // 
            lblCapacidade.Location = new Point(0, 0);
            lblCapacidade.Name = "lblCapacidade";
            lblCapacidade.Size = new Size(100, 23);
            lblCapacidade.TabIndex = 10;
            // 
            // lblTituloUtilizado
            // 
            lblTituloUtilizado.Location = new Point(0, 0);
            lblTituloUtilizado.Name = "lblTituloUtilizado";
            lblTituloUtilizado.Size = new Size(100, 23);
            lblTituloUtilizado.TabIndex = 11;
            // 
            // lblUtilizado
            // 
            lblUtilizado.Location = new Point(0, 0);
            lblUtilizado.Name = "lblUtilizado";
            lblUtilizado.Size = new Size(100, 23);
            lblUtilizado.TabIndex = 12;
            // 
            // lblTituloDisponivel
            // 
            lblTituloDisponivel.Location = new Point(0, 0);
            lblTituloDisponivel.Name = "lblTituloDisponivel";
            lblTituloDisponivel.Size = new Size(100, 23);
            lblTituloDisponivel.TabIndex = 13;
            // 
            // lblDisponivel
            // 
            lblDisponivel.Location = new Point(0, 0);
            lblDisponivel.Name = "lblDisponivel";
            lblDisponivel.Size = new Size(100, 23);
            lblDisponivel.TabIndex = 14;
            // 
            // panelStatus
            // 
            panelStatus.BackColor = Color.FromArgb(23, 23, 23);
            panelStatus.Controls.Add(lblTituloStatus);
            panelStatus.Controls.Add(lblStatus);
            panelStatus.Controls.Add(lblDescricaoStatus);
            panelStatus.EdgeColor = Color.FromArgb(48, 48, 48);
            panelStatus.Location = new Point(508, 128);
            panelStatus.Name = "panelStatus";
            panelStatus.Padding = new Padding(5);
            panelStatus.Size = new Size(485, 250);
            panelStatus.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panelStatus.TabIndex = 2;
            // 
            // lblTituloStatus
            // 
            lblTituloStatus.AutoSize = true;
            lblTituloStatus.BackColor = Color.Transparent;
            lblTituloStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTituloStatus.ForeColor = Color.FromArgb(220, 35, 35);
            lblTituloStatus.Location = new Point(20, 15);
            lblTituloStatus.Name = "lblTituloStatus";
            lblTituloStatus.Size = new Size(58, 19);
            lblTituloStatus.TabIndex = 0;
            lblTituloStatus.Text = "STATUS";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(145, 145, 145);
            lblStatus.Location = new Point(20, 58);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(194, 31);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "● AGUARDANDO";
            // 
            // lblDescricaoStatus
            // 
            lblDescricaoStatus.BackColor = Color.Transparent;
            lblDescricaoStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblDescricaoStatus.ForeColor = Color.FromArgb(145, 145, 145);
            lblDescricaoStatus.Location = new Point(20, 104);
            lblDescricaoStatus.Name = "lblDescricaoStatus";
            lblDescricaoStatus.Size = new Size(435, 95);
            lblDescricaoStatus.TabIndex = 2;
            lblDescricaoStatus.Text = "Nenhuma verificação foi executada nesta sessão.";
            // 
            // panelVerificacao
            // 
            panelVerificacao.BackColor = Color.FromArgb(23, 23, 23);
            panelVerificacao.Controls.Add(lblTituloVerificacao);
            panelVerificacao.Controls.Add(lblEtapa1);
            panelVerificacao.Controls.Add(lblEtapa2);
            panelVerificacao.Controls.Add(lblEtapa3);
            panelVerificacao.Controls.Add(progressBar);
            panelVerificacao.Controls.Add(btnVerificar);
            panelVerificacao.EdgeColor = Color.FromArgb(48, 48, 48);
            panelVerificacao.Location = new Point(12, 395);
            panelVerificacao.Name = "panelVerificacao";
            panelVerificacao.Padding = new Padding(5);
            panelVerificacao.Size = new Size(480, 245);
            panelVerificacao.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panelVerificacao.TabIndex = 3;
            // 
            // lblTituloVerificacao
            // 
            lblTituloVerificacao.AutoSize = true;
            lblTituloVerificacao.BackColor = Color.Transparent;
            lblTituloVerificacao.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTituloVerificacao.ForeColor = Color.FromArgb(220, 35, 35);
            lblTituloVerificacao.Location = new Point(20, 15);
            lblTituloVerificacao.Name = "lblTituloVerificacao";
            lblTituloVerificacao.Size = new Size(102, 19);
            lblTituloVerificacao.TabIndex = 0;
            lblTituloVerificacao.Text = "VERIFICAÇÕES";
            // 
            // lblEtapa1
            // 
            lblEtapa1.Location = new Point(0, 0);
            lblEtapa1.Name = "lblEtapa1";
            lblEtapa1.Size = new Size(100, 23);
            lblEtapa1.TabIndex = 1;
            // 
            // lblEtapa2
            // 
            lblEtapa2.Location = new Point(0, 0);
            lblEtapa2.Name = "lblEtapa2";
            lblEtapa2.Size = new Size(100, 23);
            lblEtapa2.TabIndex = 2;
            // 
            // lblEtapa3
            // 
            lblEtapa3.Location = new Point(0, 0);
            lblEtapa3.Name = "lblEtapa3";
            lblEtapa3.Size = new Size(100, 23);
            lblEtapa3.TabIndex = 3;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(20, 151);
            progressBar.MarqueeAnimationSpeed = 25;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(440, 8);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 4;
            progressBar.Visible = false;
            // 
            // btnVerificar
            // 
            btnVerificar.BackColor = Color.FromArgb(220, 35, 35);
            btnVerificar.Cursor = Cursors.Hand;
            btnVerificar.FlatAppearance.BorderSize = 0;
            btnVerificar.FlatAppearance.MouseDownBackColor = Color.FromArgb(170, 25, 25);
            btnVerificar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 45, 45);
            btnVerificar.FlatStyle = FlatStyle.Flat;
            btnVerificar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnVerificar.ForeColor = Color.White;
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
            panelResultado.BackColor = Color.FromArgb(23, 23, 23);
            panelResultado.Controls.Add(lblTituloResultado);
            panelResultado.Controls.Add(lblResultado);
            panelResultado.EdgeColor = Color.FromArgb(48, 48, 48);
            panelResultado.Location = new Point(508, 395);
            panelResultado.Name = "panelResultado";
            panelResultado.Padding = new Padding(5);
            panelResultado.Size = new Size(485, 245);
            panelResultado.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panelResultado.TabIndex = 4;
            // 
            // lblTituloResultado
            // 
            lblTituloResultado.AutoSize = true;
            lblTituloResultado.BackColor = Color.Transparent;
            lblTituloResultado.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTituloResultado.ForeColor = Color.FromArgb(220, 35, 35);
            lblTituloResultado.Location = new Point(20, 15);
            lblTituloResultado.Name = "lblTituloResultado";
            lblTituloResultado.Size = new Size(86, 19);
            lblTituloResultado.TabIndex = 0;
            lblTituloResultado.Text = "RESULTADO";
            // 
            // lblResultado
            // 
            lblResultado.BackColor = Color.FromArgb(18, 18, 18);
            lblResultado.BorderStyle = BorderStyle.FixedSingle;
            lblResultado.Font = new System.Drawing.Font("Consolas", 8.5F);
            lblResultado.ForeColor = Color.FromArgb(145, 145, 145);
            lblResultado.Location = new Point(20, 48);
            lblResultado.Name = "lblResultado";
            lblResultado.Padding = new Padding(10);
            lblResultado.Size = new Size(440, 165);
            lblResultado.TabIndex = 1;
            lblResultado.Text = "Aguardando uma verificação do sistema de arquivos.";
            // 
            // VerificarDisco
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(1009, 671);
            Controls.Add(panelResultado);
            Controls.Add(panelVerificacao);
            Controls.Add(panelStatus);
            Controls.Add(panelDisco);
            Controls.Add(panelHeader);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            MinimumSize = new Size(1020, 710);
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
            panelResultado.PerformLayout();
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
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Regular);
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
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    9.5F,
                    FontStyle.Bold);
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
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Regular);
            label.ForeColor = Color.FromArgb(145, 145, 145);
            label.Location = localizacao;
            label.Text = texto;
        }

        #endregion

        private ReaLTaiizor.Controls.Panel panelHeader = null!;
        private ReaLTaiizor.Controls.BigLabel bigLabel1 = null!;
        private ReaLTaiizor.Controls.HeaderLabel headerLabel1 = null!;

        private ReaLTaiizor.Controls.Panel panelDisco = null!;
        private Label lblTituloDisco = null!;
        private Label lblUnidade = null!;
        private Label lblDadosDisco01 = null!;
        private Label lblVolume = null!;
        private Label lblDadosDisco02 = null!;
        private Label lblTituloSistemaArquivos = null!;
        private Label lblSistemaArquivos = null!;
        private Label lblTituloCapacidade = null!;
        private Label lblCapacidade = null!;
        private Label lblTituloUtilizado = null!;
        private Label lblUtilizado = null!;
        private Label lblTituloDisponivel = null!;
        private Label lblDisponivel = null!;
        private ComboBox cmbUnidades = null!;
        private Button btnAtualizar = null!;

        private ReaLTaiizor.Controls.Panel panelStatus = null!;
        private Label lblTituloStatus = null!;
        private Label lblStatus = null!;
        private Label lblDescricaoStatus = null!;

        private ReaLTaiizor.Controls.Panel panelVerificacao = null!;
        private Label lblTituloVerificacao = null!;
        private Label lblEtapa1 = null!;
        private Label lblEtapa2 = null!;
        private Label lblEtapa3 = null!;
        private ProgressBar progressBar = null!;
        private Button btnVerificar = null!;

        private ReaLTaiizor.Controls.Panel panelResultado = null!;
        private Label lblTituloResultado = null!;
        private Label lblResultado = null!;
    }
}