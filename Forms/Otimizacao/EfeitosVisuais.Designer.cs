namespace WinTuner.Forms.Otimizacao
{
    partial class EfeitosVisuais
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelPrincipal;

        private System.Windows.Forms.Panel panelCabecalho;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescricao;

        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPreset;
        private System.Windows.Forms.Label lblResumo;

        private System.Windows.Forms.Panel panelOpcoes;
        private System.Windows.Forms.TableLayoutPanel tabelaOpcoes;

        private System.Windows.Forms.CheckBox chkAbrirCaixasCombinacao;
        private System.Windows.Forms.CheckBox chkAnimacoesBarraTarefas;
        private System.Windows.Forms.CheckBox chkAnimarControlesElementos;
        private System.Windows.Forms.CheckBox chkAnimarJanelasMinMax;
        private System.Windows.Forms.CheckBox chkEsmaecerItensMenu;
        private System.Windows.Forms.CheckBox chkEsmaecerToolTips;
        private System.Windows.Forms.CheckBox chkEsmaecerMenus;
        private System.Windows.Forms.CheckBox chkHabilitarPeek;
        private System.Windows.Forms.CheckBox chkMostrarConteudoJanela;
        private System.Windows.Forms.CheckBox chkMostrarMiniaturas;
        private System.Windows.Forms.CheckBox chkRetanguloSelecao;
        private System.Windows.Forms.CheckBox chkSombrasJanelas;
        private System.Windows.Forms.CheckBox chkSombrasPonteiro;
        private System.Windows.Forms.CheckBox chkRolarListas;
        private System.Windows.Forms.CheckBox chkSalvarMiniaturas;
        private System.Windows.Forms.CheckBox chkSuavizacaoFontes;
        private System.Windows.Forms.CheckBox chkSombrasRotulos;

        private System.Windows.Forms.Panel panelPresets;
        private System.Windows.Forms.Label lblPresets;
        private System.Windows.Forms.FlowLayoutPanel painelBotoesPreset;

        private System.Windows.Forms.Button btnMelhorDesempenho;
        private System.Windows.Forms.Button btnEquilibrado;
        private System.Windows.Forms.Button btnMelhorAparencia;

        private System.Windows.Forms.Panel panelAcoes;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.ProgressBar progressBar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            panelPrincipal = new System.Windows.Forms.Panel();

            panelCabecalho = new System.Windows.Forms.Panel();
            lblTitulo = new System.Windows.Forms.Label();
            lblDescricao = new System.Windows.Forms.Label();

            panelStatus = new System.Windows.Forms.Panel();
            lblStatus = new System.Windows.Forms.Label();
            lblPreset = new System.Windows.Forms.Label();
            lblResumo = new System.Windows.Forms.Label();

            panelOpcoes = new System.Windows.Forms.Panel();
            tabelaOpcoes = new System.Windows.Forms.TableLayoutPanel();

            chkAbrirCaixasCombinacao = CriarCheckBox("Abrir caixas de combinação");
            chkAnimacoesBarraTarefas = CriarCheckBox("Animações na barra de tarefas");
            chkAnimarControlesElementos = CriarCheckBox("Animar controles e elementos no Windows");
            chkAnimarJanelasMinMax = CriarCheckBox("Animar janelas ao minimizar e maximizar");
            chkEsmaecerItensMenu = CriarCheckBox("Esmaecer itens de menu após clicados");
            chkEsmaecerToolTips = CriarCheckBox("Esmaecer ou deslizar dicas de ferramenta para a exibição");
            chkEsmaecerMenus = CriarCheckBox("Esmaecer ou deslizar menus para a exibição");
            chkHabilitarPeek = CriarCheckBox("Habilitar o Peek");
            chkMostrarConteudoJanela = CriarCheckBox("Mostrar conteúdo da janela ao arrastar");
            chkMostrarMiniaturas = CriarCheckBox("Mostrar miniaturas em vez de ícones");
            chkRetanguloSelecao = CriarCheckBox("Mostrar retângulo de seleção translúcido");
            chkSombrasJanelas = CriarCheckBox("Mostrar sombras sob janelas");
            chkSombrasPonteiro = CriarCheckBox("Mostrar sombras sob o ponteiro do mouse");
            chkRolarListas = CriarCheckBox("Rolar caixas de listagem suavemente");
            chkSalvarMiniaturas = CriarCheckBox("Salvar visualizações de miniaturas da barra de tarefas");
            chkSuavizacaoFontes = CriarCheckBox("Usar fontes de tela com cantos arredondados");
            chkSombrasRotulos = CriarCheckBox("Usar sombras subjacentes para rótulos de ícones na área de trabalho");

            panelPresets = new System.Windows.Forms.Panel();
            lblPresets = new System.Windows.Forms.Label();
            painelBotoesPreset = new System.Windows.Forms.FlowLayoutPanel();

            btnMelhorDesempenho = CriarBotao("Melhor desempenho");
            btnEquilibrado = CriarBotao("Equilibrado");
            btnMelhorAparencia = CriarBotao("Melhor aparência");

            panelAcoes = new System.Windows.Forms.Panel();
            btnAplicar = CriarBotao("Aplicar alterações");
            btnRestaurar = CriarBotao("Restaurar padrão");
            progressBar = new System.Windows.Forms.ProgressBar();

            SuspendLayout();

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(1180, 760);
            MinimumSize = new System.Drawing.Size(980, 620);
            Name = "EfeitosVisuais";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "WinTuner - Efeitos Visuais";

            // Painel principal (o Fill entra primeiro, depois os Top/Bottom)
            panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            panelPrincipal.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            panelPrincipal.Padding = new System.Windows.Forms.Padding(20);

            panelPrincipal.Controls.Add(panelOpcoes);
            panelPrincipal.Controls.Add(panelPresets);
            panelPrincipal.Controls.Add(panelAcoes);
            panelPrincipal.Controls.Add(panelStatus);
            panelPrincipal.Controls.Add(panelCabecalho);

            // Cabeçalho
            panelCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            panelCabecalho.Height = 78;
            panelCabecalho.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            panelCabecalho.Padding = new System.Windows.Forms.Padding(18);

            panelCabecalho.Controls.Add(lblTitulo);
            panelCabecalho.Controls.Add(lblDescricao);

            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(235, 65, 65);
            lblTitulo.Location = new System.Drawing.Point(18, 10);
            lblTitulo.Text = "EFEITOS VISUAIS";

            lblDescricao.AutoSize = false;
            lblDescricao.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            lblDescricao.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblDescricao.ForeColor = System.Drawing.Color.FromArgb(175, 175, 175);
            lblDescricao.Location = new System.Drawing.Point(20, 43);
            lblDescricao.Width = 850;
            lblDescricao.Height = 22;
            lblDescricao.Text = "Configure os efeitos visuais do Windows para equilibrar aparência e desempenho.";

            // Status
            panelStatus.Dock = System.Windows.Forms.DockStyle.Top;
            panelStatus.Height = 72;
            panelStatus.BackColor = System.Drawing.Color.FromArgb(28, 28, 28);
            panelStatus.Padding = new System.Windows.Forms.Padding(18);

            panelStatus.Controls.Add(lblStatus);
            panelStatus.Controls.Add(lblPreset);
            panelStatus.Controls.Add(lblResumo);

            lblStatus.AutoSize = true;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblStatus.ForeColor = System.Drawing.Color.FromArgb(190, 190, 190);
            lblStatus.Location = new System.Drawing.Point(18, 12);
            lblStatus.Text = "Carregando configurações...";

            lblPreset.AutoSize = true;
            lblPreset.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblPreset.ForeColor = System.Drawing.Color.FromArgb(235, 65, 65);
            lblPreset.Location = new System.Drawing.Point(18, 39);
            lblPreset.Text = "Personalizado";

            lblResumo.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;
            lblResumo.AutoSize = true;
            lblResumo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblResumo.ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
            lblResumo.Text = "0 de 17 efeitos visuais ativados";
            lblResumo.Top = 28;
            lblResumo.Left = 700;

            // Opções
            panelOpcoes.Dock = System.Windows.Forms.DockStyle.Fill;
            panelOpcoes.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            panelOpcoes.Padding = new System.Windows.Forms.Padding(10);

            panelOpcoes.Controls.Add(tabelaOpcoes);

            tabelaOpcoes.Dock = System.Windows.Forms.DockStyle.Fill;
            tabelaOpcoes.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            tabelaOpcoes.ColumnCount = 2;
            tabelaOpcoes.RowCount = 9;
            tabelaOpcoes.Padding = new System.Windows.Forms.Padding(4);

            tabelaOpcoes.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tabelaOpcoes.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

            for (int i = 0; i < 9; i++)
            {
                tabelaOpcoes.RowStyles.Add(
                    new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            }

            tabelaOpcoes.Controls.Add(chkAbrirCaixasCombinacao, 0, 0);
            tabelaOpcoes.Controls.Add(chkAnimacoesBarraTarefas, 1, 0);
            tabelaOpcoes.Controls.Add(chkAnimarControlesElementos, 0, 1);
            tabelaOpcoes.Controls.Add(chkAnimarJanelasMinMax, 1, 1);
            tabelaOpcoes.Controls.Add(chkEsmaecerItensMenu, 0, 2);
            tabelaOpcoes.Controls.Add(chkEsmaecerToolTips, 1, 2);
            tabelaOpcoes.Controls.Add(chkEsmaecerMenus, 0, 3);
            tabelaOpcoes.Controls.Add(chkHabilitarPeek, 1, 3);
            tabelaOpcoes.Controls.Add(chkMostrarConteudoJanela, 0, 4);
            tabelaOpcoes.Controls.Add(chkMostrarMiniaturas, 1, 4);
            tabelaOpcoes.Controls.Add(chkRetanguloSelecao, 0, 5);
            tabelaOpcoes.Controls.Add(chkSombrasJanelas, 1, 5);
            tabelaOpcoes.Controls.Add(chkSombrasPonteiro, 0, 6);
            tabelaOpcoes.Controls.Add(chkRolarListas, 1, 6);
            tabelaOpcoes.Controls.Add(chkSalvarMiniaturas, 0, 7);
            tabelaOpcoes.Controls.Add(chkSuavizacaoFontes, 1, 7);
            tabelaOpcoes.Controls.Add(chkSombrasRotulos, 0, 8);

            // Presets
            panelPresets.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelPresets.Height = 64;
            panelPresets.BackColor = System.Drawing.Color.FromArgb(28, 28, 28);
            panelPresets.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);

            panelPresets.Controls.Add(painelBotoesPreset);
            panelPresets.Controls.Add(lblPresets);

            lblPresets.Dock = System.Windows.Forms.DockStyle.Left;
            lblPresets.Width = 100;
            lblPresets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblPresets.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lblPresets.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);
            lblPresets.Text = "PRESETS:";

            painelBotoesPreset.Dock = System.Windows.Forms.DockStyle.Fill;
            painelBotoesPreset.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            painelBotoesPreset.WrapContents = false;
            painelBotoesPreset.BackColor = System.Drawing.Color.Transparent;

            painelBotoesPreset.Controls.Add(btnMelhorAparencia);
            painelBotoesPreset.Controls.Add(btnEquilibrado);
            painelBotoesPreset.Controls.Add(btnMelhorDesempenho);

            btnMelhorAparencia.Width = 150;
            btnMelhorAparencia.Height = 40;

            btnEquilibrado.Width = 130;
            btnEquilibrado.Height = 40;

            btnMelhorDesempenho.Width = 160;
            btnMelhorDesempenho.Height = 40;

            // Ações
            panelAcoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelAcoes.Height = 58;
            panelAcoes.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            panelAcoes.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);

            panelAcoes.Controls.Add(progressBar);
            panelAcoes.Controls.Add(btnRestaurar);
            panelAcoes.Controls.Add(btnAplicar);

            btnAplicar.Dock = System.Windows.Forms.DockStyle.Right;
            btnAplicar.Width = 180;
            btnAplicar.Height = 40;
            btnAplicar.BackColor = System.Drawing.Color.FromArgb(190, 40, 40);
            btnAplicar.ForeColor = System.Drawing.Color.White;
            btnAplicar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 60, 60);

            btnRestaurar.Dock = System.Windows.Forms.DockStyle.Right;
            btnRestaurar.Width = 155;
            btnRestaurar.Height = 40;

            progressBar.Dock = System.Windows.Forms.DockStyle.Left;
            progressBar.Width = 220;
            progressBar.Height = 12;
            progressBar.Visible = false;
            progressBar.Style = System.Windows.Forms.ProgressBarStyle.Blocks;

            // Finalização
            Controls.Add(panelPrincipal);

            ResumeLayout(false);
        }

        private System.Windows.Forms.CheckBox CriarCheckBox(string texto)
        {
            return new System.Windows.Forms.CheckBox
            {
                Text = texto,
                Dock = System.Windows.Forms.DockStyle.Fill,
                AutoSize = false,
                Margin = new System.Windows.Forms.Padding(8, 4, 8, 4),
                Padding = new System.Windows.Forms.Padding(8, 0, 4, 0),
                Font = new System.Drawing.Font("Segoe UI", 9F),
                ForeColor = System.Drawing.Color.FromArgb(220, 220, 220),
                BackColor = System.Drawing.Color.Transparent,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Cursor = System.Windows.Forms.Cursors.Hand
            };
        }

        private System.Windows.Forms.Button CriarBotao(string texto)
        {
            return new System.Windows.Forms.Button
            {
                Text = texto,
                Width = 140,
                Height = 40,
                Margin = new System.Windows.Forms.Padding(5, 0, 5, 0),
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                BackColor = System.Drawing.Color.FromArgb(35, 35, 35),
                ForeColor = System.Drawing.Color.FromArgb(225, 225, 225),
                Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold),
                Cursor = System.Windows.Forms.Cursors.Hand,
                FlatAppearance =
                {
                    BorderColor = System.Drawing.Color.FromArgb(65, 65, 65),
                    BorderSize = 1
                }
            };
        }
    }
}