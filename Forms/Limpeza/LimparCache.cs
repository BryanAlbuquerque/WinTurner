using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinTuner.Services;
using WinTuner.Services.Limpeza;

namespace WinTuner.Forms.Limpeza
{
    public partial class LimparCache : Form
    {
        private readonly LimparCacheService _limparCacheService;

        private CancellationTokenSource? _cancellationTokenSource;

        private List<ResultadoCache> _locais =
            new();

        private bool _processando;

        public LimparCache()
        {
            InitializeComponent();

            _limparCacheService =
                new LimparCacheService();

            AparenciaWindowsService
                .AplicarBarraEscura(this);

            ConfigurarEstadoInicial();
        }

        private void ConfigurarEstadoInicial()
        {
            lblStatus.Text =
                "Clique em ANALISAR para verificar os caches.";

            lblStatus.ForeColor =
                Color.FromArgb(145, 145, 145);

            lblLocaisSelecionados.Text =
                "0";

            lblArquivosEncontrados.Text =
                "0";

            lblEspacoLiberavel.Text =
                "0 B";

            btnLimpar.Enabled =
                false;

            btnLimparDns.Enabled =
                true;

            progressBar.Visible =
                false;
        }

        private async void btnAnalisar_Click(
            object sender,
            EventArgs e)
        {
            if (_processando)
                return;

            await AnalisarAsync();
        }

        private async Task AnalisarAsync()
        {
            _processando = true;

            _cancellationTokenSource?.Dispose();

            _cancellationTokenSource =
                new CancellationTokenSource();

            try
            {
                AlterarEstadoProcessamento(true);

                lblStatus.Text =
                    "Iniciando análise dos caches...";

                var progresso =
                    new Progress<string>(
                        mensagem =>
                        {
                            lblStatus.Text =
                                mensagem;
                        });

                ResultadoAnaliseCache resultado =
                    await _limparCacheService
                        .AnalisarAsync(
                            progresso,
                            _cancellationTokenSource.Token);

                _locais =
                    resultado.Locais;

                AplicarResultado(
                    resultado);

                lblStatus.Text =
                    "Análise concluída.";

                lblStatus.ForeColor =
                    Color.FromArgb(76, 175, 80);
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text =
                    "Análise cancelada.";

                lblStatus.ForeColor =
                    Color.FromArgb(220, 35, 35);
            }
            catch (Exception ex)
            {
                lblStatus.Text =
                    "Erro durante a análise.";

                lblStatus.ForeColor =
                    Color.FromArgb(220, 35, 35);

                MessageBox.Show(
                    $"Não foi possível concluir a análise.\n\n{ex.Message}",
                    "WinTurner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _processando = false;

                AlterarEstadoProcessamento(false);
            }
        }

        private void AplicarResultado(
            ResultadoAnaliseCache resultado)
        {
            LimparCards();

            foreach (ResultadoCache local
                     in resultado.Locais)
            {
                local.Selecionado =
                    true;

                CriarCardLocal(local);
            }

            AtualizarResumo();
        }

        private void CriarCardLocal(
            ResultadoCache local)
        {
            Panel card =
                new Panel
                {
                    Width = 325,
                    Height = 175,
                    BackColor =
                        Color.FromArgb(23, 23, 23),
                    BorderStyle =
                        BorderStyle.FixedSingle,
                    Margin =
                        new Padding(0, 0, 15, 15),
                    Tag = local
                };

            CheckBox checkBox =
                new CheckBox
                {
                    AutoSize = false,
                    Width = 30,
                    Height = 30,
                    Location =
                        new Point(15, 15),
                    Checked =
                        local.Selecionado,
                    ForeColor =
                        Color.White,
                    BackColor =
                        Color.FromArgb(23, 23, 23),
                    Tag = local
                };

            checkBox.CheckedChanged +=
                CardCheckBox_CheckedChanged;

            Label lblNome =
                new Label
                {
                    AutoSize = false,
                    Location =
                        new Point(52, 13),
                    Size =
                        new Size(250, 30),
                    Font =
                        new Font(
                            "Segoe UI Semibold",
                            11F,
                            FontStyle.Bold),
                    ForeColor =
                        Color.FromArgb(235, 235, 235),
                    Text =
                        local.Nome
                };

            Label lblCaminho =
                new Label
                {
                    AutoEllipsis = true,
                    Location =
                        new Point(17, 55),
                    Size =
                        new Size(285, 35),
                    Font =
                        new Font(
                            "Segoe UI",
                            8F),
                    ForeColor =
                        Color.FromArgb(145, 145, 145),
                    Text =
                        local.Caminho
                };

            Label lblArquivos =
                new Label
                {
                    AutoSize = false,
                    Location =
                        new Point(17, 105),
                    Size =
                        new Size(130, 40),
                    Font =
                        new Font(
                            "Segoe UI Semibold",
                            9F,
                            FontStyle.Bold),
                    ForeColor =
                        Color.FromArgb(235, 235, 235),
                    Text =
                        $"{local.QuantidadeArquivos:N0}\nARQUIVOS"
                };

            Label lblTamanho =
                new Label
                {
                    AutoSize = false,
                    Location =
                        new Point(165, 105),
                    Size =
                        new Size(135, 40),
                    Font =
                        new Font(
                            "Segoe UI Semibold",
                            9F,
                            FontStyle.Bold),
                    ForeColor =
                        Color.FromArgb(208, 0, 0),
                    Text =
                        $"{local.TamanhoFormatado}\nRECUPERÁVEL"
                };

            if (!local.Disponivel)
            {
                lblNome.ForeColor =
                    Color.FromArgb(120, 120, 120);

                lblCaminho.Text =
                    "Cache não encontrado.";

                lblArquivos.Text =
                    "INDISPONÍVEL";

                lblTamanho.Text =
                    "-";

                checkBox.Enabled =
                    false;

                local.Selecionado =
                    false;
            }

            if (local.QuantidadeErros > 0)
            {
                Label lblAviso =
                    new Label
                    {
                        AutoSize = false,
                        Location =
                            new Point(17, 145),
                        Size =
                            new Size(285, 20),
                        Font =
                            new Font(
                                "Segoe UI",
                                8F),
                        ForeColor =
                            Color.FromArgb(230, 160, 60),
                        Text =
                            $"{local.QuantidadeErros} item(ns) não puderam ser analisados."
                    };

                card.Controls.Add(
                    lblAviso);
            }

            card.Controls.Add(
                checkBox);

            card.Controls.Add(
                lblNome);

            card.Controls.Add(
                lblCaminho);

            card.Controls.Add(
                lblArquivos);

            card.Controls.Add(
                lblTamanho);

            flowCards.Controls.Add(
                card);
        }

        private void CardCheckBox_CheckedChanged(
            object? sender,
            EventArgs e)
        {
            if (sender is CheckBox checkBox &&
                checkBox.Tag is ResultadoCache local)
            {
                local.Selecionado =
                    checkBox.Checked;

                AtualizarResumo();
            }
        }

        private void AtualizarResumo()
        {
            List<ResultadoCache> selecionados =
                _locais
                    .Where(
                        x =>
                            x.Selecionado &&
                            x.Disponivel)
                    .ToList();

            int arquivos =
                selecionados.Sum(
                    x => x.QuantidadeArquivos);

            long bytes =
                selecionados.Sum(
                    x => x.TamanhoBytes);

            lblLocaisSelecionados.Text =
                selecionados.Count.ToString();

            lblArquivosEncontrados.Text =
                arquivos.ToString("N0");

            lblEspacoLiberavel.Text =
                FormatarTamanho(bytes);

            btnLimpar.Enabled =
                !_processando &&
                selecionados.Any(
                    x =>
                        x.QuantidadeArquivos > 0);
        }

        private async void btnLimpar_Click(
            object sender,
            EventArgs e)
        {
            if (_processando)
                return;

            List<ResultadoCache> selecionados =
                _locais
                    .Where(
                        x =>
                            x.Selecionado &&
                            x.Disponivel &&
                            x.QuantidadeArquivos > 0)
                    .ToList();

            if (selecionados.Count == 0)
            {
                MessageBox.Show(
                    "Selecione pelo menos um cache com arquivos para limpar.",
                    "WinTurner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            int arquivos =
                selecionados.Sum(
                    x => x.QuantidadeArquivos);

            long bytes =
                selecionados.Sum(
                    x => x.TamanhoBytes);

            DialogResult confirmacao =
                MessageBox.Show(
                    $"A limpeza irá remover os arquivos de cache selecionados.\n\n" +
                    $"Arquivos encontrados: {arquivos:N0}\n" +
                    $"Espaço potencialmente liberado: {FormatarTamanho(bytes)}\n\n" +
                    "Arquivos em uso serão ignorados.\n\n" +
                    "Deseja continuar?",
                    "Confirmar limpeza",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (confirmacao != DialogResult.Yes)
                return;

            await LimparAsync(
                selecionados);
        }

        private async Task LimparAsync(
            List<ResultadoCache> selecionados)
        {
            _processando = true;

            _cancellationTokenSource?.Dispose();

            _cancellationTokenSource =
                new CancellationTokenSource();

            try
            {
                AlterarEstadoProcessamento(true);

                lblStatus.Text =
                    "Iniciando limpeza dos caches...";

                var progresso =
                    new Progress<string>(
                        mensagem =>
                        {
                            lblStatus.Text =
                                mensagem;
                        });

                ResultadoLimpezaCache resultado =
                    await _limparCacheService
                        .LimparAsync(
                            selecionados,
                            progresso,
                            _cancellationTokenSource.Token);

                MostrarResultado(
                    resultado);

                lblStatus.Text =
                    "Limpeza de cache concluída.";

                lblStatus.ForeColor =
                    resultado.ArquivosComErro > 0
                        ? Color.FromArgb(230, 160, 60)
                        : Color.FromArgb(76, 175, 80);

                await AnalisarAsync();
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text =
                    "Limpeza cancelada.";

                lblStatus.ForeColor =
                    Color.FromArgb(220, 35, 35);
            }
            catch (Exception ex)
            {
                lblStatus.Text =
                    "Erro durante a limpeza.";

                lblStatus.ForeColor =
                    Color.FromArgb(220, 35, 35);

                MessageBox.Show(
                    $"Não foi possível concluir a limpeza.\n\n{ex.Message}",
                    "WinTurner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _processando = false;

                AlterarEstadoProcessamento(false);
            }
        }

        private async void btnLimparDns_Click(
            object sender,
            EventArgs e)
        {
            if (_processando)
                return;

            try
            {
                _processando = true;

                AlterarEstadoProcessamento(true);

                lblStatus.Text =
                    "Limpando cache DNS...";

                var progresso =
                    new Progress<string>(
                        mensagem =>
                        {
                            lblStatus.Text =
                                mensagem;
                        });

                ResultadoDns resultado =
                    await _limparCacheService
                        .LimparDnsAsync(
                            progresso);

                MessageBox.Show(
                    resultado.Mensagem,
                    "Cache DNS",
                    MessageBoxButtons.OK,
                    resultado.Sucesso
                        ? MessageBoxIcon.Information
                        : MessageBoxIcon.Warning);

                lblStatus.Text =
                    resultado.Sucesso
                        ? "Cache DNS limpo com sucesso."
                        : "Não foi possível limpar o cache DNS.";

                lblStatus.ForeColor =
                    resultado.Sucesso
                        ? Color.FromArgb(76, 175, 80)
                        : Color.FromArgb(230, 160, 60);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao limpar o cache DNS.\n\n{ex.Message}",
                    "WinTurner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _processando = false;

                AlterarEstadoProcessamento(false);
            }
        }

        private void MostrarResultado(
            ResultadoLimpezaCache resultado)
        {
            MessageBox.Show(
                $"Limpeza concluída.\n\n" +
                $"Arquivos excluídos: " +
                $"{resultado.ArquivosExcluidos:N0}\n" +
                $"Arquivos com erro: " +
                $"{resultado.ArquivosComErro:N0}\n" +
                $"Espaço liberado: " +
                $"{resultado.EspacoLiberado}",
                "Resultado da limpeza",
                MessageBoxButtons.OK,
                resultado.ArquivosComErro > 0
                    ? MessageBoxIcon.Warning
                    : MessageBoxIcon.Information);
        }

        private void AlterarEstadoProcessamento(
            bool processando)
        {
            progressBar.Visible =
                processando;

            btnAnalisar.Enabled =
                !processando;

            btnLimparDns.Enabled =
                !processando;

            flowCards.Enabled =
                !processando;

            btnLimpar.Enabled =
                !processando &&
                _locais.Any(
                    x =>
                        x.Selecionado &&
                        x.Disponivel &&
                        x.QuantidadeArquivos > 0);
        }

        private void LimparCards()
        {
            foreach (Control controle in
                     flowCards.Controls
                         .Cast<Control>()
                         .ToList())
            {
                controle.Dispose();
            }

            flowCards.Controls.Clear();
        }

        private static string FormatarTamanho(
            long bytes)
        {
            if (bytes < 1024)
                return $"{bytes} B";

            if (bytes < 1024 * 1024)
                return $"{bytes / 1024.0:0.00} KB";

            if (bytes < 1024 * 1024 * 1024)
                return $"{bytes / 1024.0 / 1024.0:0.00} MB";

            return $"{bytes / 1024.0 / 1024.0 / 1024.0:0.00} GB";
        }

        private void LimparCache_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            if (_processando)
            {
                e.Cancel = true;

                MessageBox.Show(
                    "A operação ainda está em andamento.\n\n" +
                    "Aguarde a conclusão antes de fechar.",
                    "WinTuner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }
    }
}