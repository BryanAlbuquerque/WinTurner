namespace WinTuner.Forms.Diagnostico
{
    partial class IntegridadeWindows
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
            lblStatus = new Label();
            panelFerramentas = new Panel();
            btnReparar = new Button();
            btnDiagnosticar = new Button();
            lblDescricao = new Label();
            lblTitulo = new Label();
            panelPrincipal.SuspendLayout();
            panelResultado.SuspendLayout();
            panelFerramentas.SuspendLayout();
            SuspendLayout();

            // 
            // panelPrincipal
            // 
            panelPrincipal.BackColor = Color.FromArgb(15, 15, 15);
            panelPrincipal.Controls.Add(panelResultado);
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
            lblTitulo.Size = new Size(250, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Integridade do Windows";

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
            lblDescricao.Size = new Size(570, 15);
            lblDescricao.TabIndex = 1;
            lblDescricao.Text =
                "Verifique arquivos do sistema e a integridade da imagem do Windows.";

            // 
            // panelFerramentas
            // 
            panelFerramentas.BackColor = Color.FromArgb(23, 23, 23);
            panelFerramentas.BorderStyle = BorderStyle.FixedSingle;
            panelFerramentas.Controls.Add(btnReparar);
            panelFerramentas.Controls.Add(btnDiagnosticar);
            panelFerramentas.Controls.Add(lblStatus);
            panelFerramentas.Location = new Point(25, 100);
            panelFerramentas.Name = "panelFerramentas";
            panelFerramentas.Size = new Size(917, 115);
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
            lblStatus.Location = new Point(20, 18);
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
            btnDiagnosticar.Cursor = Cursors.Hand;
            btnDiagnosticar.ForeColor = Color.White;
            btnDiagnosticar.Location = new Point(20, 57);
            btnDiagnosticar.Name = "btnDiagnosticar";
            btnDiagnosticar.Size = new Size(270, 38);
            btnDiagnosticar.TabIndex = 1;
            btnDiagnosticar.Text = "EXECUTAR DIAGNÓSTICO";
            btnDiagnosticar.UseVisualStyleBackColor = false;
            btnDiagnosticar.Click += btnDiagnosticar_Click;

            // 
            // btnReparar
            // 
            btnReparar.BackColor = Color.FromArgb(70, 70, 70);
            btnReparar.FlatAppearance.BorderSize = 0;
            btnReparar.FlatAppearance.MouseDownBackColor =
                Color.FromArgb(50, 50, 50);
            btnReparar.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(90, 90, 90);
            btnReparar.FlatStyle = FlatStyle.Flat;
            btnReparar.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold
            );
            btnReparar.ForeColor = Color.White;
            btnReparar.Location = new Point(305, 57);
            btnReparar.Name = "btnReparar";
            btnReparar.Size = new Size(270, 38);
            btnReparar.TabIndex = 2;
            btnReparar.Text = "REPARAR WINDOWS";
            btnReparar.UseVisualStyleBackColor = false;
            btnReparar.Visible = false;
            btnReparar.Click += btnReparar_Click;

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
            panelResultado.Location = new Point(25, 235);
            panelResultado.Name = "panelResultado";
            panelResultado.Padding = new Padding(15);
            panelResultado.Size = new Size(917, 391);
            panelResultado.TabIndex = 3;

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
            lblResultadoTitulo.TabIndex = 0;
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
            txtResultado.Size = new Size(885, 325);
            txtResultado.TabIndex = 1;
            txtResultado.Text = "";

            // 
            // IntegridadeWindows
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(967, 651);
            Controls.Add(panelPrincipal);
            MinimumSize = new Size(850, 600);
            Name = "IntegridadeWindows";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Integridade do Windows";

            panelPrincipal.ResumeLayout(false);
            panelPrincipal.PerformLayout();
            panelResultado.ResumeLayout(false);
            panelResultado.PerformLayout();
            panelFerramentas.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelPrincipal;
        private Panel panelFerramentas;
        private Panel panelResultado;

        private Label lblTitulo;
        private Label lblDescricao;
        private Label lblStatus;
        private Label lblResultadoTitulo;

        private Button btnDiagnosticar;
        private Button btnReparar;

        private RichTextBox txtResultado;
    }
}