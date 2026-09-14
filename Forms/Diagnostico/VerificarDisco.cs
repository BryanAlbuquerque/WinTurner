using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WinTurner.Services.Diagnosticos;

namespace WinTuner.Forms.Diagnostico
{
    public partial class VerificarDisco : Form
    {
        private readonly VerificarDiscoService _verificarDiscoService;

        private CancellationTokenSource? _cancellationTokenSource;
        private Stopwatch? _stopwatch;

        public VerificarDisco()
        {
            InitializeComponent();

            _verificarDiscoService = new VerificarDiscoService();

            CarregarUnidades();
            ConfigurarEstadoInicial();
        }

        private void ConfigurarEstadoInicial()
        {
            lblStatus.Text = "● AGUARDANDO";
            lblStatus.ForeColor = Color.FromArgb(145, 145, 145);

            lblDescricaoStatus.Text =
                "Selecione uma unidade e clique em \"VERIFICAR DISCO\" para iniciar a análise.";

            lblEtapa1.Text = "○ Sistema de arquivos";
            lblEtapa2.Text = "○ Metadados do volume";
            lblEtapa3.Text = "○ Integridade da unidade";

            lblEtapa1.ForeColor = Color.FromArgb(145, 145, 145);
            lblEtapa2.ForeColor = Color.FromArgb(145, 145, 145);
            lblEtapa3.ForeColor = Color.FromArgb(145, 145, 145);

            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 25;
            progressBar.Visible = false;

            btnVerificar.Enabled = true;
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

                    string unidade = drive.Name.TrimEnd('\\');

                    string volume = string.IsNullOrWhiteSpace(drive.VolumeLabel)
                        ? "Sem nome"
                        : drive.VolumeLabel;

                    cmbUnidades.Items.Add(
                        new UnidadeItem
                        {
                            Unidade = unidade,
                            Volume = volume,
                            SistemaArquivos = drive.DriveFormat
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
            if (cmbUnidades.SelectedItem is not UnidadeItem item)
                return;

            CarregarInformacoesDisco(item);
        }

        private void CarregarInformacoesDisco(UnidadeItem item)
        {
            try
            {
                DriveInfo drive = new DriveInfo(item.Unidade + "\\");

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

                double utilizadoGB = totalGB - disponivelGB;

                lblDadosDisco01.Text = item.Unidade;

                lblDadosDisco02.Text =
                    string.IsNullOrWhiteSpace(drive.VolumeLabel)
                        ? "Sem nome"
                        : drive.VolumeLabel;

                lblSistemaArquivos.Text = drive.DriveFormat;
                lblCapacidade.Text = $"{totalGB:0.00} GB";
                lblUtilizado.Text = $"{utilizadoGB:0.00} GB";
                lblDisponivel.Text = $"{disponivelGB:0.00} GB";
            }
            catch
            {
                lblDadosDisco01.Text = item.Unidade;
                lblDadosDisco02.Text = "Não identificado";
                lblSistemaArquivos.Text = "Não identificado";
                lblCapacidade.Text = "-";
                lblUtilizado.Text = "-";
                lblDisponivel.Text = "-";
            }
        }

        private async void btnVerificar_Click(
            object sender,
            EventArgs e)
        {
            if (_cancellationTokenSource != null)
                return;

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

                _stopwatch = Stopwatch.StartNew();

                AlterarEstado(true);
                LimparResultado();

                lblStatus.Text = "● VERIFICANDO";
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
                    $"Sistema de arquivos: {item.SistemaArquivos}\r\n");

                EscreverResultado(
                    $"Início: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\r\n\r\n");

                EscreverResultado(
                    "Executando CHKDSK...\r\n\r\n");

                var progresso = new Progress<string>(
                    linha =>
                    {
                        EscreverResultado(
                            linha + Environment.NewLine);
                    });

                ResultadoVerificacaoDisco resultado =
                    await _verificarDiscoService.VerificarAsync(
                        item.Unidade,
                        progresso,
                        _cancellationTokenSource.Token);

                _stopwatch.Stop();

                if (resultado.Sucesso)
                {
                    lblStatus.Text = "● SAUDÁVEL";
                    lblStatus.ForeColor =
                        Color.FromArgb(70, 200, 110);

                    lblDescricaoStatus.Text =
                        "A verificação foi concluída e não foram " +
                        "detectados problemas pelo CHKDSK.";

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
                }
                else
                {
                    lblStatus.Text = "● ATENÇÃO";
                    lblStatus.ForeColor =
                        Color.FromArgb(230, 75, 75);

                    lblDescricaoStatus.Text =
                        "O CHKDSK terminou indicando que a unidade " +
                        "precisa de atenção. Consulte o resultado abaixo.";

                    AtualizarEtapa(
                        lblEtapa1,
                        "● Verificação concluída com atenção",
                        Color.FromArgb(230, 75, 75));

                    AtualizarEtapa(
                        lblEtapa2,
                        "● Volume analisado",
                        Color.FromArgb(230, 170, 60));

                    AtualizarEtapa(
                        lblEtapa3,
                        "● Consulte o resultado",
                        Color.FromArgb(230, 170, 60));
                }

                EscreverResultado(
                    "\r\n============================================\r\n");

                EscreverResultado(
                    $"Código de saída: {resultado.CodigoSaida}\r\n");

                EscreverResultado(
                    $"Tempo total: {resultado.Duracao:mm\\:ss}\r\n");

                EscreverResultado(
                    $"Resultado: {resultado.Mensagem}\r\n");
            }
            catch (OperationCanceledException)
            {
                _stopwatch?.Stop();

                lblStatus.Text = "● CANCELADO";
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
                    "\r\n\r\nA verificação foi cancelada pelo usuário.");
            }
            catch (Exception ex)
            {
                _stopwatch?.Stop();

                lblStatus.Text = "● ERRO";
                lblStatus.ForeColor =
                    Color.FromArgb(230, 75, 75);

                lblDescricaoStatus.Text =
                    "Ocorreu um erro durante a verificação.";

                AtualizarEtapa(
                    lblEtapa1,
                    "● Erro na verificação",
                    Color.FromArgb(230, 75, 75));

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
                _cancellationTokenSource = null;

                AlterarEstado(false);
            }
        }

        private void AlterarEstado(bool verificando)
        {
            cmbUnidades.Enabled = !verificando;
            btnVerificar.Enabled = !verificando;
            btnAtualizar.Enabled = !verificando;
            progressBar.Visible = verificando;
        }

        private void AtualizarEtapa(
            Label label,
            string texto,
            Color cor)
        {
            label.Text = texto;
            label.ForeColor = cor;
        }

        private void LimparResultado()
        {
            lblResultado.Text =
                "Executando verificação...\r\n\r\n";
        }

        private void EscreverResultado(string texto)
        {
            lblResultado.Text += texto;
        }

        private void btnAtualizar_Click(
            object sender,
            EventArgs e)
        {
            if (_cancellationTokenSource != null)
                return;

            CarregarUnidades();
        }

        protected override void OnFormClosing(
            FormClosingEventArgs e)
        {
            _cancellationTokenSource?.Cancel();

            base.OnFormClosing(e);
        }

        private sealed class UnidadeItem
        {
            public string Unidade { get; set; } = string.Empty;

            public string Volume { get; set; } = string.Empty;

            public string SistemaArquivos { get; set; } =
                string.Empty;

            public override string ToString()
            {
                return $"{Unidade}  •  {Volume}  •  {SistemaArquivos}";
            }
        }
    }
}