using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinTuner.Services;

namespace WinTuner.Forms.Otimizacao
{
    public partial class EfeitosVisuais : Form
    {
        private readonly OtimizacaoEfeitosVisuaisService _service;

        private bool _processando;
        private bool _carregando;
        private bool _fechamentoForcado;

        public EfeitosVisuais()
        {
            InitializeComponent();

            _service =
                new OtimizacaoEfeitosVisuaisService();

            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            Shown += EfeitosVisuais_Shown;
            FormClosing += EfeitosVisuais_FormClosing;
            Resize += EfeitosVisuais_Resize;

            btnAplicar.Click += btnAplicar_Click;
            btnMelhorDesempenho.Click += btnMelhorDesempenho_Click;
            btnEquilibrado.Click += btnEquilibrado_Click;
            btnMelhorAparencia.Click += btnMelhorAparencia_Click;
            btnRestaurar.Click += btnRestaurar_Click;

            chkAbrirCaixasCombinacao.CheckedChanged += Configuracao_CheckedChanged;
            chkAnimacoesBarraTarefas.CheckedChanged += Configuracao_CheckedChanged;
            chkAnimarControlesElementos.CheckedChanged += Configuracao_CheckedChanged;
            chkAnimarJanelasMinMax.CheckedChanged += Configuracao_CheckedChanged;
            chkEsmaecerItensMenu.CheckedChanged += Configuracao_CheckedChanged;
            chkEsmaecerToolTips.CheckedChanged += Configuracao_CheckedChanged;
            chkEsmaecerMenus.CheckedChanged += Configuracao_CheckedChanged;
            chkHabilitarPeek.CheckedChanged += Configuracao_CheckedChanged;
            chkMostrarConteudoJanela.CheckedChanged += Configuracao_CheckedChanged;
            chkMostrarMiniaturas.CheckedChanged += Configuracao_CheckedChanged;
            chkRetanguloSelecao.CheckedChanged += Configuracao_CheckedChanged;
            chkSombrasJanelas.CheckedChanged += Configuracao_CheckedChanged;
            chkSombrasPonteiro.CheckedChanged += Configuracao_CheckedChanged;
            chkRolarListas.CheckedChanged += Configuracao_CheckedChanged;
            chkSalvarMiniaturas.CheckedChanged += Configuracao_CheckedChanged;
            chkSuavizacaoFontes.CheckedChanged += Configuracao_CheckedChanged;
            chkSombrasRotulos.CheckedChanged += Configuracao_CheckedChanged;
        }

        private async void EfeitosVisuais_Shown(
            object? sender,
            EventArgs e)
        {
            await CarregarAsync();
        }

        private async Task CarregarAsync()
        {
            try
            {
                _carregando = true;

                AlterarInterface(true);

                lblStatus.Text =
                    "Lendo configurações de efeitos visuais...";

                var config =
                    await _service.ObterConfiguracaoAsync();

                AplicarNaInterface(config);

                lblPreset.Text =
                    config.Preset;

                lblStatus.Text =
                    "Configurações carregadas.";

                AtualizarResumo();
            }
            catch (Exception ex)
            {
                lblStatus.Text =
                    "Erro ao carregar configurações.";

                MessageBox.Show(
                    "Não foi possível carregar as configurações.\n\n" +
                    ex.Message,
                    "WinTuner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _carregando = false;

                AlterarInterface(false);
            }
        }

        private void AplicarNaInterface(
            OtimizacaoEfeitosVisuaisService.ConfiguracaoEfeitos config)
        {
            _carregando = true;

            try
            {
                chkAbrirCaixasCombinacao.Checked =
                    config.AbrirCaixasCombinacao;

                chkAnimacoesBarraTarefas.Checked =
                    config.AnimacoesBarraTarefas;

                chkAnimarControlesElementos.Checked =
                    config.AnimarControlesElementos;

                chkAnimarJanelasMinMax.Checked =
                    config.AnimarJanelasMinMax;

                chkEsmaecerItensMenu.Checked =
                    config.EsmaecerItensMenu;

                chkEsmaecerToolTips.Checked =
                    config.EsmaecerToolTips;

                chkEsmaecerMenus.Checked =
                    config.EsmaecerMenus;

                chkHabilitarPeek.Checked =
                    config.HabilitarPeek;

                chkMostrarConteudoJanela.Checked =
                    config.MostrarConteudoJanelaArrastar;

                chkMostrarMiniaturas.Checked =
                    config.MostrarMiniaturas;

                chkRetanguloSelecao.Checked =
                    config.RetanguloSelecaoTranslucido;

                chkSombrasJanelas.Checked =
                    config.SombrasJanelas;

                chkSombrasPonteiro.Checked =
                    config.SombrasPonteiro;

                chkRolarListas.Checked =
                    config.RolarListasSuavemente;

                chkSalvarMiniaturas.Checked =
                    config.SalvarMiniaturasBarraTarefas;

                chkSuavizacaoFontes.Checked =
                    config.SuavizacaoFontes;

                chkSombrasRotulos.Checked =
                    config.SombrasRotulosDesktop;

                lblPreset.Text =
                    config.Preset;

                AtualizarResumo();
            }
            finally
            {
                _carregando = false;
            }
        }

        private OtimizacaoEfeitosVisuaisService.ConfiguracaoEfeitos
            ObterDaInterface()
        {
            return new OtimizacaoEfeitosVisuaisService.ConfiguracaoEfeitos
            {
                AbrirCaixasCombinacao =
                    chkAbrirCaixasCombinacao.Checked,

                AnimacoesBarraTarefas =
                    chkAnimacoesBarraTarefas.Checked,

                AnimarControlesElementos =
                    chkAnimarControlesElementos.Checked,

                AnimarJanelasMinMax =
                    chkAnimarJanelasMinMax.Checked,

                EsmaecerItensMenu =
                    chkEsmaecerItensMenu.Checked,

                EsmaecerToolTips =
                    chkEsmaecerToolTips.Checked,

                EsmaecerMenus =
                    chkEsmaecerMenus.Checked,

                HabilitarPeek =
                    chkHabilitarPeek.Checked,

                MostrarConteudoJanelaArrastar =
                    chkMostrarConteudoJanela.Checked,

                MostrarMiniaturas =
                    chkMostrarMiniaturas.Checked,

                RetanguloSelecaoTranslucido =
                    chkRetanguloSelecao.Checked,

                SombrasJanelas =
                    chkSombrasJanelas.Checked,

                SombrasPonteiro =
                    chkSombrasPonteiro.Checked,

                RolarListasSuavemente =
                    chkRolarListas.Checked,

                SalvarMiniaturasBarraTarefas =
                    chkSalvarMiniaturas.Checked,

                SuavizacaoFontes =
                    chkSuavizacaoFontes.Checked,

                SombrasRotulosDesktop =
                    chkSombrasRotulos.Checked,

                Preset =
                    "Personalizado",

                ModoVisualFX =
                    3
            };
        }

        private async void btnAplicar_Click(
            object? sender,
            EventArgs e)
        {
            await AplicarConfiguracaoAsync();
        }

        private async Task AplicarConfiguracaoAsync()
        {
            if (_processando)
                return;

            try
            {
                AlterarInterface(true);

                lblStatus.Text =
                    "Aplicando configurações personalizadas...";

                var configuracao =
                    ObterDaInterface();

                var resultado =
                    await _service.AplicarConfiguracaoAsync(
                        configuracao);

                if (!resultado.Sucesso)
                {
                    lblStatus.Text =
                        "A confirmação apresentou diferenças.";

                    MessageBox.Show(
                        resultado.Mensagem,
                        "WinTuner",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                var atual =
                    await _service.ObterConfiguracaoAsync();

                AplicarNaInterface(atual);

                lblStatus.Text =
                    "Configurações aplicadas e confirmadas.";

                AtualizarResumo();

                MessageBox.Show(
                    resultado.Mensagem,
                    "WinTuner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text =
                    "Erro durante a aplicação.";

                MessageBox.Show(
                    "Não foi possível aplicar as configurações.\n\n" +
                    ex.Message,
                    "WinTuner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                AlterarInterface(false);
            }
        }

        private async void btnMelhorDesempenho_Click(
            object? sender,
            EventArgs e)
        {
            await AplicarPresetAsync(
                "Melhor desempenho");
        }

        private async void btnEquilibrado_Click(
            object? sender,
            EventArgs e)
        {
            await AplicarPresetAsync(
                "Equilibrado");
        }

        private async void btnMelhorAparencia_Click(
            object? sender,
            EventArgs e)
        {
            await AplicarPresetAsync(
                "Melhor aparência");
        }

        private async void btnRestaurar_Click(
            object? sender,
            EventArgs e)
        {
            if (_processando)
                return;

            DialogResult resposta =
                MessageBox.Show(
                    "Deseja devolver o controle dos efeitos visuais ao Windows?",
                    "Restaurar padrão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resposta != DialogResult.Yes)
                return;

            try
            {
                AlterarInterface(true);

                lblStatus.Text =
                    "Restaurando o controle padrão do Windows...";

                var resultado =
                    await _service.AplicarPresetAsync(
                        "Padrão do Windows");

                if (!resultado.Sucesso)
                {
                    MessageBox.Show(
                        resultado.Mensagem,
                        "WinTuner",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                var atual =
                    await _service.ObterConfiguracaoAsync();

                AplicarNaInterface(atual);

                lblStatus.Text =
                    "Controle devolvido ao Windows.";

                AtualizarResumo();

                MessageBox.Show(
                    resultado.Mensagem,
                    "WinTuner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text =
                    "Erro ao restaurar o padrão.";

                MessageBox.Show(
                    ex.Message,
                    "WinTuner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                AlterarInterface(false);
            }
        }

        private async Task AplicarPresetAsync(
            string preset)
        {
            if (_processando)
                return;

            try
            {
                AlterarInterface(true);

                lblStatus.Text =
                    $"Aplicando: {preset}...";

                var resultado =
                    await _service.AplicarPresetAsync(
                        preset);

                if (!resultado.Sucesso)
                {
                    lblStatus.Text =
                        "A confirmação apresentou diferenças.";

                    MessageBox.Show(
                        resultado.Mensagem,
                        "WinTuner",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                var atual =
                    await _service.ObterConfiguracaoAsync();

                AplicarNaInterface(atual);

                lblPreset.Text =
                    atual.Preset;

                lblStatus.Text =
                    $"{atual.Preset} aplicado.";

                AtualizarResumo();

                MessageBox.Show(
                    resultado.Mensagem,
                    "WinTuner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text =
                    "Erro ao aplicar preset.";

                MessageBox.Show(
                    ex.Message,
                    "WinTuner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                AlterarInterface(false);
            }
        }

        private void Configuracao_CheckedChanged(
            object? sender,
            EventArgs e)
        {
            if (_carregando ||
                _processando)
            {
                return;
            }

            lblPreset.Text =
                "Personalizado";

            AtualizarResumo();
        }

        private void AtualizarResumo()
        {
            CheckBox[] checkboxes =
            {
                chkAbrirCaixasCombinacao,
                chkAnimacoesBarraTarefas,
                chkAnimarControlesElementos,
                chkAnimarJanelasMinMax,
                chkEsmaecerItensMenu,
                chkEsmaecerToolTips,
                chkEsmaecerMenus,
                chkHabilitarPeek,
                chkMostrarConteudoJanela,
                chkMostrarMiniaturas,
                chkRetanguloSelecao,
                chkSombrasJanelas,
                chkSombrasPonteiro,
                chkRolarListas,
                chkSalvarMiniaturas,
                chkSuavizacaoFontes,
                chkSombrasRotulos
            };

            int ativos = 0;

            foreach (CheckBox check in checkboxes)
            {
                if (check.Checked)
                    ativos++;
            }

            lblResumo.Text =
                $"{ativos} de 17 efeitos visuais ativados";
        }

        private void AlterarInterface(
            bool processando)
        {
            _processando =
                processando;

            CheckBox[] checkboxes =
            {
                chkAbrirCaixasCombinacao,
                chkAnimacoesBarraTarefas,
                chkAnimarControlesElementos,
                chkAnimarJanelasMinMax,
                chkEsmaecerItensMenu,
                chkEsmaecerToolTips,
                chkEsmaecerMenus,
                chkHabilitarPeek,
                chkMostrarConteudoJanela,
                chkMostrarMiniaturas,
                chkRetanguloSelecao,
                chkSombrasJanelas,
                chkSombrasPonteiro,
                chkRolarListas,
                chkSalvarMiniaturas,
                chkSuavizacaoFontes,
                chkSombrasRotulos
            };

            foreach (CheckBox check in checkboxes)
            {
                check.Enabled =
                    !processando;
            }

            btnAplicar.Enabled =
                !processando;

            btnMelhorDesempenho.Enabled =
                !processando;

            btnEquilibrado.Enabled =
                !processando;

            btnMelhorAparencia.Enabled =
                !processando;

            btnRestaurar.Enabled =
                !processando;

            progressBar.Visible =
                processando;

            progressBar.Style =
                processando
                    ? ProgressBarStyle.Marquee
                    : ProgressBarStyle.Blocks;
        }

        private void EfeitosVisuais_Resize(
            object? sender,
            EventArgs e)
        {
            if (lblResumo == null ||
                panelStatus == null)
            {
                return;
            }

            lblResumo.Left =
                Math.Max(
                    10,
                    panelStatus.ClientSize.Width -
                    lblResumo.Width -
                    18);

            lblResumo.Top =
                28;
        }

        private void EfeitosVisuais_FormClosing(
            object? sender,
            FormClosingEventArgs e)
        {
            if (!_processando ||
                _fechamentoForcado)
            {
                return;
            }

            DialogResult resposta =
                MessageBox.Show(
                    "Existe uma operação em andamento.\n\n" +
                    "Fechar agora pode interromper a confirmação das configurações.\n\n" +
                    "Deseja realmente fechar o WinTuner?",
                    "WinTuner",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (resposta == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            /*
             * Não cancela a Task em execução porque o serviço
             * está executando alterações reais no Windows.
             *
             * O fechamento é permitido somente depois da
             * confirmação explícita do usuário.
             */
            _fechamentoForcado = true;
        }
    }
}