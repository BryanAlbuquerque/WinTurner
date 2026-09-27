using System.Diagnostics;
using System.IO;
using WinTuner.Services.Diagnosticos;

namespace WinTuner.Forms.Diagnostico
{
    public partial class VerificarDisco : Form
    {
        private readonly VerificarDiscoService _verificarDiscoService;

        private CancellationTokenSource? _cancellationTokenSource;
        private Stopwatch? _stopwatch;

        private bool _reparando;

        public VerificarDisco()
        {
            InitializeComponent();

            _verificarDiscoService =
                new VerificarDiscoService();

            CarregarUnidades();
            ConfigurarEstadoInicial();
        }

        private void ConfigurarEstadoInicial()
        {
            lblStatus.Text =
                "● AGUARDANDO";

            lblStatus.ForeColor =
                Color.FromArgb(145, 145, 145);

            lblDescricaoStatus.Text =
                "Selecione uma unidade e clique em \"VERIFICAR DISCO\" para iniciar a análise.";

            lblEtapa1.Text =
                "○ Sistema de arquivos";

            lblEtapa2.Text =
                "○ Metadados do volume";

            lblEtapa3.Text =
                "○ Integridade da unidade";

            lblEtapa1.ForeColor =
                Color.FromArgb(145, 145, 145);

            lblEtapa2.ForeColor =
                Color.FromArgb(145, 145, 145);

            lblEtapa3.ForeColor =
                Color.FromArgb(145, 145, 145);

            progressBar.Style =
                ProgressBarStyle.Marquee;

            progressBar.MarqueeAnimationSpeed =
                25;

            progressBar.Visible =
                false;

            btnVerificar.Visible =
                true;

            btnVerificar.Enabled =
                true;

            btnReparar.Visible =
                false;

            btnReparar.Enabled =
                false;
        }

        private void CarregarUnidades()
        {
            cmbUnidades.Items.Clear();

            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.DriveType != DriveType.Fixed)
                        continue;

                    if (!drive.IsReady)
                        continue;

                    string unidade =
                        drive.Name.TrimEnd('\\');

                    string volume =
                        string.IsNullOrWhiteSpace(
                            drive.VolumeLabel)
                            ? "Sem nome"
                            : drive.VolumeLabel;

                    string sistemaArquivos;

                    try
                    {
                        sistemaArquivos =
                            drive.DriveFormat;
                    }
                    catch
                    {
                        sistemaArquivos =
                            "Desconhecido";
                    }

                    cmbUnidades.Items.Add(
                        new UnidadeItem
                        {
                            Unidade =
                                unidade,

                            Volume =
                                volume,

                            SistemaArquivos =
                                sistemaArquivos
                        });
                }

                if (cmbUnidades.Items.Count > 0)
                {
                    cmbUnidades.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show(
                        "Nenhuma unidade de armazenamento disponível foi encontrada.",
                        "WinTurner",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Não foi possível carregar as unidades.\n\n{ex.Message}",
                    "WinTurner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cmbUnidades_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (_cancellationTokenSource != null ||
                _reparando)
            {
                return;
            }

            if (cmbUnidades.SelectedItem is not UnidadeItem item)
                return;

            CarregarInformacoesDisco(item);

            ResetarResultadoParaNovaUnidade();
        }

        private void CarregarInformacoesDisco(
            UnidadeItem item)
        {
            try
            {
                DriveInfo drive =
                    new DriveInfo(
                        item.Unidade + "\\");

                if (!drive.IsReady)
                    return;

                double totalGB =
                    drive.TotalSize /
                    1024.0 /
                    1024.0 /
                    1024.0;

                double disponivelGB =
                    drive.AvailableFreeSpace /
                    1024.0 /
                    1024.0 /
                    1024.0;

                double utilizadoGB =
                    totalGB -
                    disponivelGB;

                lblDadosDisco01.Text =
                    item.Unidade;

                lblDadosDisco02.Text =
                    string.IsNullOrWhiteSpace(
                        drive.VolumeLabel)
                        ? "Sem nome"
                        : drive.VolumeLabel;

                lblSistemaArquivos.Text =
                    drive.DriveFormat;

                lblCapacidade.Text =
                    $"{totalGB:0.00} GB";

                lblUtilizado.Text =
                    $"{utilizadoGB:0.00} GB";

                lblDisponivel.Text =
                    $"{disponivelGB:0.00} GB";
            }
            catch
            {
                lblDadosDisco01.Text =
                    item.Unidade;

                lblDadosDisco02.Text =
                    "Não identificado";

                lblSistemaArquivos.Text =
                    "Não identificado";

                lblCapacidade.Text =
                    "-";

                lblUtilizado.Text =
                    "-";

                lblDisponivel.Text =
                    "-";
            }
        }

        private void ResetarResultadoParaNovaUnidade()
        {
            MostrarBotaoReparar(false);

            lblStatus.Text =
                "● AGUARDANDO";

            lblStatus.ForeColor =
                Color.FromArgb(145, 145, 145);

            lblDescricaoStatus.Text =
                "Selecione a unidade e clique em \"VERIFICAR DISCO\" para iniciar uma nova análise.";

            lblEtapa1.Text =
                "○ Sistema de arquivos";

            lblEtapa2.Text =
                "○ Metadados do volume";

            lblEtapa3.Text =
                "○ Integridade da unidade";

            lblEtapa1.ForeColor =
                Color.FromArgb(145, 145, 145);

            lblEtapa2.ForeColor =
                Color.FromArgb(145, 145, 145);

            lblEtapa3.ForeColor =
                Color.FromArgb(145, 145, 145);

            lblResultado.Text =
                "Aguardando uma verificação do sistema de arquivos.";
        }

        private async void btnVerificar_Click(
            object sender,
            EventArgs e)
        {
            if (_cancellationTokenSource != null ||
                _reparando)
            {
                return;
            }

            if (cmbUnidades.SelectedItem is not UnidadeItem item)
            {
                MessageBox.Show(
                    "Selecione uma unidade para verificar.",
                    "WinTurner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                _cancellationTokenSource =
                    new CancellationTokenSource();

                _stopwatch =
                    Stopwatch.StartNew();

                MostrarBotaoReparar(false);

                AlterarEstado(true);

                LimparResultado();

                lblStatus.Text =
                    "● VERIFICANDO";

                lblStatus.ForeColor =
                    Color.FromArgb(230, 170, 60);

                lblDescricaoStatus.Text =
                    $"O Windows está verificando a unidade {item.Unidade}. " +
                    "Esse processo pode levar alguns minutos.";

                AtualizarEtapa(
                    lblEtapa1,
                    "● Analisando sistema de arquivos",
                    Color.FromArgb(230, 170, 60));

                AtualizarEtapa(
                    lblEtapa2,
                    "○ Aguardando",
                    Color.FromArgb(145, 145, 145));

                AtualizarEtapa(
                    lblEtapa3,
                    "○ Aguardando",
                    Color.FromArgb(145, 145, 145));

                EscreverResultado(
                    "WINTURNER - VERIFICAÇÃO DO DISCO\r\n" +
                    "============================================\r\n\r\n");

                EscreverResultado(
                    $"Unidade: {item.Unidade}\r\n");

                EscreverResultado(
                    $"Volume: {item.Volume}\r\n");

                EscreverResultado(
                    $"Sistema de arquivos: {item.SistemaArquivos}\r\n");

                EscreverResultado(
                    $"Início: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\r\n\r\n");

                if (item.SistemaArquivos.Equals(
                        "NTFS",
                        StringComparison.OrdinalIgnoreCase))
                {
                    EscreverResultado(
                        "Modo de verificação: ONLINE /SCAN\r\n");

                    EscreverResultado(
                        "O volume NTFS será analisado sem desmontar a unidade.\r\n\r\n");
                }
                else
                {
                    EscreverResultado(
                        "Modo de verificação: CHKDSK\r\n\r\n");
                }

                EscreverResultado(
                    "Executando CHKDSK...\r\n\r\n");

                var progresso =
                    new Progress<string>(
                        linha =>
                        {
                            if (IsDisposed)
                                return;

                            EscreverResultado(
                                linha +
                                Environment.NewLine);
                        });

                ResultadoVerificacaoDisco resultado =
                    await _verificarDiscoService.VerificarAsync(
                        item.Unidade,
                        progresso,
                        _cancellationTokenSource.Token);

                _stopwatch.Stop();

                EscreverResultado(
                    "\r\n============================================\r\n");

                EscreverResultado(
                    $"Código de saída: {resultado.CodigoSaida}\r\n");

                EscreverResultado(
                    $"Tempo total: {resultado.Duracao:mm\\:ss}\r\n");

                EscreverResultado(
                    $"Resultado: {resultado.Mensagem}\r\n");

                AtualizarEtapasConclusao(
                    resultado);

                if (resultado.RequerReparo)
                {
                    MostrarResultadoComProblema();
                }
                else if (resultado.Sucesso)
                {
                    MostrarResultadoSaudavel();
                }
                else
                {
                    MostrarResultadoAtencao();
                }
            }
            catch (OperationCanceledException)
            {
                _stopwatch?.Stop();

                lblStatus.Text =
                    "● CANCELADO";

                lblStatus.ForeColor =
                    Color.FromArgb(230, 170, 60);

                lblDescricaoStatus.Text =
                    "A verificação foi cancelada.";

                AtualizarEtapa(
                    lblEtapa1,
                    "● Verificação cancelada",
                    Color.FromArgb(230, 170, 60));

                AtualizarEtapa(
                    lblEtapa2,
                    "○ Não concluído",
                    Color.FromArgb(145, 145, 145));

                AtualizarEtapa(
                    lblEtapa3,
                    "○ Não concluído",
                    Color.FromArgb(145, 145, 145));

                EscreverResultado(
                    "\r\n\r\nA verificação foi cancelada.");
            }
            catch (Exception ex)
            {
                _stopwatch?.Stop();

                lblStatus.Text =
                    "● ERRO";

                lblStatus.ForeColor =
                    Color.FromArgb(230, 75, 75);

                lblDescricaoStatus.Text =
                    "Ocorreu um erro durante a verificação.";

                AtualizarEtapa(
                    lblEtapa1,
                    "● Erro na verificação",
                    Color.FromArgb(230, 75, 75));

                AtualizarEtapa(
                    lblEtapa2,
                    "○ Não concluído",
                    Color.FromArgb(145, 145, 145));

                AtualizarEtapa(
                    lblEtapa3,
                    "○ Não concluído",
                    Color.FromArgb(145, 145, 145));

                EscreverResultado(
                    $"\r\n\r\nERRO:\r\n{ex.Message}");

                MessageBox.Show(
                    $"Não foi possível verificar o disco.\n\n{ex.Message}",
                    "WinTurner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _stopwatch?.Stop();

                _cancellationTokenSource?.Dispose();

                _cancellationTokenSource =
                    null;

                AlterarEstado(false);
            }
        }

        private async void btnReparar_Click(
            object sender,
            EventArgs e)
        {
            if (_cancellationTokenSource != null ||
                _reparando)
            {
                return;
            }

            if (cmbUnidades.SelectedItem is not UnidadeItem item)
            {
                MessageBox.Show(
                    "Selecione uma unidade para reparar.",
                    "WinTurner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult confirmacao =
                MessageBox.Show(
                    $"Foram encontrados indícios de problemas na unidade {item.Unidade}.\n\n" +
                    "O WinTurner executará o CHKDSK /F com privilégios de administrador.\n\n" +
                    "Se a unidade estiver sendo utilizada pelo Windows, " +
                    "o reparo poderá ser agendado automaticamente para a próxima reinicialização.\n\n" +
                    "Deseja continuar?",
                    "Reparar erros",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (confirmacao != DialogResult.Yes)
                return;

            try
            {
                _reparando =
                    true;

                _stopwatch =
                    Stopwatch.StartNew();

                AlterarEstado(true);

                btnReparar.Text =
                    "REPARANDO...";

                lblStatus.Text =
                    "● REPARANDO";

                lblStatus.ForeColor =
                    Color.FromArgb(230, 170, 60);

                lblDescricaoStatus.Text =
                    $"O Windows está reparando a unidade {item.Unidade}. " +
                    "Não interrompa o processo.";

                AtualizarEtapa(
                    lblEtapa1,
                    "● Verificando sistema de arquivos",
                    Color.FromArgb(230, 170, 60));

                AtualizarEtapa(
                    lblEtapa2,
                    "● Corrigindo erros",
                    Color.FromArgb(230, 170, 60));

                AtualizarEtapa(
                    lblEtapa3,
                    "○ Aguardando conclusão",
                    Color.FromArgb(145, 145, 145));

                EscreverResultado(
                    "\r\n\r\n" +
                    "============================================\r\n");

                EscreverResultado(
                    "WINTURNER - REPARO DO DISCO\r\n" +
                    "============================================\r\n\r\n");

                EscreverResultado(
                    $"Unidade: {item.Unidade}\r\n");

                EscreverResultado(
                    $"Volume: {item.Volume}\r\n");

                EscreverResultado(
                    $"Sistema de arquivos: {item.SistemaArquivos}\r\n");

                EscreverResultado(
                    $"Início: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\r\n\r\n");

                EscreverResultado(
                    "Executando CHKDSK /F...\r\n\r\n");

                var progresso =
                    new Progress<string>(
                        linha =>
                        {
                            if (IsDisposed)
                                return;

                            EscreverResultado(
                                linha +
                                Environment.NewLine);
                        });

                ResultadoVerificacaoDisco resultado =
                    await _verificarDiscoService.RepararAsync(
                        item.Unidade,
                        progresso,
                        CancellationToken.None);

                _stopwatch.Stop();

                EscreverResultado(
                    "\r\n============================================\r\n");

                EscreverResultado(
                    $"Código de saída: {resultado.CodigoSaida}\r\n");

                EscreverResultado(
                    $"Tempo total: {resultado.Duracao:mm\\:ss}\r\n");

                EscreverResultado(
                    $"Resultado: {resultado.Mensagem}\r\n");

                if (resultado.ReparoAgendado)
                {
                    MostrarReparoAgendado();
                }
                else if (resultado.CodigoSaida == 0 ||
                         resultado.CodigoSaida == 1)
                {
                    MostrarReparoConcluido();
                }
                else
                {
                    MostrarReparoIncompleto();
                }
            }
            catch (OperationCanceledException)
            {
                _stopwatch?.Stop();

                MostrarReparoCancelado();
            }
            catch (Exception ex)
            {
                _stopwatch?.Stop();

                lblStatus.Text =
                    "● ERRO";

                lblStatus.ForeColor =
                    Color.FromArgb(230, 75, 75);

                lblDescricaoStatus.Text =
                    "Ocorreu um erro durante o processo de reparo.";

                AtualizarEtapa(
                    lblEtapa1,
                    "● Erro no reparo",
                    Color.FromArgb(230, 75, 75));

                AtualizarEtapa(
                    lblEtapa2,
                    "○ Não concluído",
                    Color.FromArgb(145, 145, 145));

                AtualizarEtapa(
                    lblEtapa3,
                    "○ Consulte o resultado",
                    Color.FromArgb(230, 170, 60));

                EscreverResultado(
                    $"\r\n\r\nERRO:\r\n{ex.Message}");

                MessageBox.Show(
                    $"Não foi possível reparar a unidade.\n\n{ex.Message}",
                    "WinTurner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _stopwatch?.Stop();

                _reparando =
                    false;

                btnReparar.Text =
                    "REPARAR ERROS";

                AlterarEstado(false);
            }
        }

        private void AtualizarEtapasConclusao(
            ResultadoVerificacaoDisco resultado)
        {
            if (resultado.RequerReparo)
            {
                AtualizarEtapa(
                    lblEtapa1,
                    "● Problemas identificados",
                    Color.FromArgb(230, 75, 75));

                AtualizarEtapa(
                    lblEtapa2,
                    "● Reparo recomendado",
                    Color.FromArgb(230, 170, 60));

                AtualizarEtapa(
                    lblEtapa3,
                    "● Ação necessária",
                    Color.FromArgb(230, 170, 60));

                return;
            }

            if (resultado.Sucesso)
            {
                AtualizarEtapa(
                    lblEtapa1,
                    "● Sistema de arquivos OK",
                    Color.FromArgb(70, 200, 110));

                AtualizarEtapa(
                    lblEtapa2,
                    "● Metadados do volume OK",
                    Color.FromArgb(70, 200, 110));

                AtualizarEtapa(
                    lblEtapa3,
                    "● Integridade verificada",
                    Color.FromArgb(70, 200, 110));

                return;
            }

            AtualizarEtapa(
                lblEtapa1,
                "● Verificação concluída",
                Color.FromArgb(230, 170, 60));

            AtualizarEtapa(
                lblEtapa2,
                "● Consulte o resultado",
                Color.FromArgb(230, 170, 60));

            AtualizarEtapa(
                lblEtapa3,
                "○ Nenhuma ação automática",
                Color.FromArgb(145, 145, 145));
        }

        private void MostrarResultadoSaudavel()
        {
            MostrarBotaoReparar(false);

            lblStatus.Text =
                "● SAUDÁVEL";

            lblStatus.ForeColor =
                Color.FromArgb(70, 200, 110);

            lblDescricaoStatus.Text =
                "A verificação foi concluída e não foram " +
                "detectados problemas pelo CHKDSK.";
        }

        private void MostrarResultadoComProblema()
        {
            MostrarBotaoReparar(true);

            lblStatus.Text =
                "● ATENÇÃO";

            lblStatus.ForeColor =
                Color.FromArgb(230, 75, 75);

            lblDescricaoStatus.Text =
                "O CHKDSK identificou problemas que podem exigir reparo. " +
                "Use o botão \"REPARAR ERROS\" para solicitar a correção.";
        }

        private void MostrarResultadoAtencao()
        {
            MostrarBotaoReparar(false);

            lblStatus.Text =
                "● ATENÇÃO";

            lblStatus.ForeColor =
                Color.FromArgb(230, 170, 60);

            lblDescricaoStatus.Text =
                "A verificação terminou com uma condição que requer atenção. " +
                "Consulte o resultado detalhado.";
        }

        private void MostrarReparoAgendado()
        {
            MostrarBotaoReparar(false);

            lblStatus.Text =
                "● REPARO AGENDADO";

            lblStatus.ForeColor =
                Color.FromArgb(230, 170, 60);

            lblDescricaoStatus.Text =
                "A unidade está em uso pelo Windows e não pôde ser bloqueada. " +
                "O reparo foi agendado para a próxima reinicialização. " +
                "Reinicie o computador para executar a correção.";

            AtualizarEtapa(
                lblEtapa1,
                "● Problemas identificados",
                Color.FromArgb(230, 75, 75));

            AtualizarEtapa(
                lblEtapa2,
                "● Reparo agendado",
                Color.FromArgb(230, 170, 60));

            AtualizarEtapa(
                lblEtapa3,
                "● Aguardando reinicialização",
                Color.FromArgb(230, 170, 60));

            EscreverResultado(
                "\r\n\r\n" +
                "ATENÇÃO:\r\n" +
                "O reparo não foi executado imediatamente porque a unidade " +
                "está em uso pelo Windows.\r\n\r\n" +
                "O CHKDSK foi agendado para a próxima reinicialização.\r\n\r\n" +
                "Reinicie o computador para concluir o reparo.");
        }

        private void MostrarReparoConcluido()
        {
            MostrarBotaoReparar(false);

            lblStatus.Text =
                "● REPARO CONCLUÍDO";

            lblStatus.ForeColor =
                Color.FromArgb(70, 200, 110);

            lblDescricaoStatus.Text =
                "O CHKDSK concluiu o processo de reparo da unidade.";

            AtualizarEtapa(
                lblEtapa1,
                "● Sistema de arquivos processado",
                Color.FromArgb(70, 200, 110));

            AtualizarEtapa(
                lblEtapa2,
                "● Erros corrigidos",
                Color.FromArgb(70, 200, 110));

            AtualizarEtapa(
                lblEtapa3,
                "● Operação finalizada",
                Color.FromArgb(70, 200, 110));
        }

        private void MostrarReparoCancelado()
        {
            MostrarBotaoReparar(true);

            lblStatus.Text =
                "● CANCELADO";

            lblStatus.ForeColor =
                Color.FromArgb(230, 170, 60);

            lblDescricaoStatus.Text =
                "O processo de reparo foi cancelado.";

            AtualizarEtapa(
                lblEtapa1,
                "● Reparo não concluído",
                Color.FromArgb(230, 170, 60));

            AtualizarEtapa(
                lblEtapa2,
                "○ Aguardando reparo",
                Color.FromArgb(145, 145, 145));

            AtualizarEtapa(
                lblEtapa3,
                "○ Não concluído",
                Color.FromArgb(145, 145, 145));
        }

        private void MostrarReparoIncompleto()
        {
            MostrarBotaoReparar(true);

            lblStatus.Text =
                "● REPARO INCOMPLETO";

            lblStatus.ForeColor =
                Color.FromArgb(230, 75, 75);

            lblDescricaoStatus.Text =
                "O Windows não conseguiu concluir o reparo. " +
                "Consulte o resultado detalhado.";

            AtualizarEtapa(
                lblEtapa1,
                "● Problemas encontrados",
                Color.FromArgb(230, 75, 75));

            AtualizarEtapa(
                lblEtapa2,
                "● Reparo não concluído",
                Color.FromArgb(230, 75, 75));

            AtualizarEtapa(
                lblEtapa3,
                "● Consulte o resultado",
                Color.FromArgb(230, 170, 60));
        }

        private void MostrarBotaoReparar(
            bool mostrar)
        {
            btnReparar.Visible =
                mostrar;

            btnVerificar.Visible =
                !mostrar;

            btnReparar.Enabled =
                mostrar &&
                !_reparando &&
                _cancellationTokenSource == null;

            btnVerificar.Enabled =
                !mostrar &&
                !_reparando &&
                _cancellationTokenSource == null;
        }

        private void AlterarEstado(
            bool emOperacao)
        {
            cmbUnidades.Enabled =
                !emOperacao;

            btnAtualizar.Enabled =
                !emOperacao;

            progressBar.Visible =
                emOperacao;

            btnVerificar.Enabled =
                !emOperacao &&
                btnVerificar.Visible &&
                !_reparando;

            btnReparar.Enabled =
                !emOperacao &&
                btnReparar.Visible &&
                !_reparando;
        }

        private void AtualizarEtapa(
            Label label,
            string texto,
            Color cor)
        {
            label.Text =
                texto;

            label.ForeColor =
                cor;
        }

        private void LimparResultado()
        {
            lblResultado.Text =
                "Executando verificação...\r\n\r\n";
        }

        private void EscreverResultado(
            string texto)
        {
            if (IsDisposed)
                return;

            lblResultado.Text +=
                texto;

            lblResultado.Refresh();
        }

        private void btnAtualizar_Click(
            object sender,
            EventArgs e)
        {
            if (_cancellationTokenSource != null ||
                _reparando)
            {
                return;
            }

            CarregarUnidades();

            if (cmbUnidades.SelectedItem is UnidadeItem item)
            {
                CarregarInformacoesDisco(item);

                ResetarResultadoParaNovaUnidade();
            }
        }

        protected override void OnFormClosing(
            FormClosingEventArgs e)
        {
            if (_reparando)
            {
                MessageBox.Show(
                    "Aguarde o término do reparo antes de fechar esta janela.",
                    "WinTurner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                e.Cancel = true;

                return;
            }

            _cancellationTokenSource?.Cancel();

            base.OnFormClosing(e);
        }

        private sealed class UnidadeItem
        {
            public string Unidade { get; set; } =
                string.Empty;

            public string Volume { get; set; } =
                string.Empty;

            public string SistemaArquivos { get; set; } =
                string.Empty;

            public override string ToString()
            {
                return
                    $"{Unidade}  •  {Volume}  •  {SistemaArquivos}";
            }
        }
    }
}