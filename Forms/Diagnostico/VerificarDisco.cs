using System.Diagnostics;
using System.Text;

namespace WinTuner.Forms.Diagnostico
{
    public partial class VerificarDisco : Form
    {
        private CancellationTokenSource? _cancellationTokenSource;
        private bool _verificando;

        public VerificarDisco()
        {
            InitializeComponent();

            CarregarUnidade();
            ConfigurarEstadoInicial();
        }

        private void CarregarUnidade()
        {
            try
            {
                DriveInfo? unidadePrincipal = DriveInfo
                    .GetDrives()
                    .FirstOrDefault(d =>
                        d.IsReady &&
                        d.DriveType == DriveType.Fixed &&
                        d.Name.Equals(@"C:\", StringComparison.OrdinalIgnoreCase));

                unidadePrincipal ??= DriveInfo
                    .GetDrives()
                    .FirstOrDefault(d =>
                        d.IsReady &&
                        d.DriveType == DriveType.Fixed);

                if (unidadePrincipal == null)
                {
                    lblDadosDisco01.Text = "Nenhuma unidade encontrada";
                    lblDadosDisco02.Text = "Nenhuma unidade disponível";

                    lblCapacidade.Text = "--";
                    lblUtilizado.Text = "--";
                    lblDisponivel.Text = "--";
                    lblSistemaArquivos.Text = "--";

                    return;
                }

                CarregarInformacoesUnidade(unidadePrincipal);
            }
            catch (Exception ex)
            {
                lblDadosDisco01.Text = "Erro ao carregar unidade";
                lblDadosDisco02.Text = ex.Message;

                lblCapacidade.Text = "--";
                lblUtilizado.Text = "--";
                lblDisponivel.Text = "--";
                lblSistemaArquivos.Text = "--";
            }
        }

        private void CarregarInformacoesUnidade(DriveInfo unidade)
        {
            double totalGB = unidade.TotalSize / 1024d / 1024d / 1024d;
            double disponivelGB = unidade.AvailableFreeSpace / 1024d / 1024d / 1024d;
            double utilizadoGB = totalGB - disponivelGB;

            double percentualUso = totalGB > 0
                ? (utilizadoGB / totalGB) * 100
                : 0;

            lblDadosDisco01.Text = unidade.Name;
            lblDadosDisco02.Text = string.IsNullOrWhiteSpace(unidade.VolumeLabel)
                ? "Sem nome"
                : unidade.VolumeLabel;

            lblCapacidade.Text = $"{totalGB:N1} GB";
            lblUtilizado.Text = $"{utilizadoGB:N1} GB ({percentualUso:N0}%)";
            lblDisponivel.Text = $"{disponivelGB:N1} GB";
            lblSistemaArquivos.Text = unidade.DriveFormat;
        }

        private void ConfigurarEstadoInicial()
        {
            lblStatus.Text = "● AGUARDANDO";
            lblStatus.ForeColor = Color.FromArgb(145, 145, 145);

            lblDescricaoStatus.Text =
                "Nenhuma verificação foi executada nesta sessão.";

            lblResultado.Text =
                "Aguardando uma verificação do sistema de arquivos.";

            lblResultado.ForeColor = Color.FromArgb(145, 145, 145);

            lblEtapa1.Text = "○ Sistema de arquivos";
            lblEtapa2.Text = "○ Metadados do volume";
            lblEtapa3.Text = "○ Integridade da unidade";

            lblEtapa1.ForeColor = Color.FromArgb(145, 145, 145);
            lblEtapa2.ForeColor = Color.FromArgb(145, 145, 145);
            lblEtapa3.ForeColor = Color.FromArgb(145, 145, 145);

            progressBar.Value = 0;

            btnVerificar.Enabled = true;
        }

        private async void btnVerificar_Click(object? sender, EventArgs e)
        {
            if (_verificando)
                return;

            await VerificarUnidadeAsync();
        }

        private async Task VerificarUnidadeAsync()
        {
            _verificando = true;

            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                btnVerificar.Enabled = false;

                progressBar.Style = ProgressBarStyle.Marquee;
                progressBar.MarqueeAnimationSpeed = 25;

                AtualizarStatus(
                    "● VERIFICANDO",
                    Color.FromArgb(235, 170, 45),
                    "O Windows está analisando o sistema de arquivos."
                );

                lblResultado.Text = "Iniciando verificação...";
                lblResultado.ForeColor = Color.FromArgb(220, 220, 220);

                lblEtapa1.Text = "● Sistema de arquivos";
                lblEtapa1.ForeColor = Color.FromArgb(220, 35, 35);

                lblEtapa2.Text = "○ Metadados do volume";
                lblEtapa2.ForeColor = Color.FromArgb(145, 145, 145);

                lblEtapa3.Text = "○ Integridade da unidade";
                lblEtapa3.ForeColor = Color.FromArgb(145, 145, 145);

                string unidade = ObterUnidade();

                if (string.IsNullOrWhiteSpace(unidade))
                {
                    throw new InvalidOperationException(
                        "Não foi possível identificar uma unidade válida."
                    );
                }

                lblResultado.Text =
                    $"Executando análise na unidade {unidade}...\r\n\r\n" +
                    "Isso pode levar alguns minutos.";

                string resultado = await ExecutarChkdskAsync(
                    unidade,
                    _cancellationTokenSource.Token
                );

                lblEtapa1.Text = "✓ Sistema de arquivos";
                lblEtapa1.ForeColor = Color.FromArgb(80, 190, 100);

                lblEtapa2.Text = "✓ Metadados do volume";
                lblEtapa2.ForeColor = Color.FromArgb(80, 190, 100);

                lblEtapa3.Text = "✓ Integridade da unidade";
                lblEtapa3.ForeColor = Color.FromArgb(80, 190, 100);

                progressBar.Style = ProgressBarStyle.Continuous;
                progressBar.Value = 100;

                InterpretarResultado(resultado);
            }
            catch (OperationCanceledException)
            {
                progressBar.Style = ProgressBarStyle.Continuous;
                progressBar.Value = 0;

                AtualizarStatus(
                    "● CANCELADO",
                    Color.FromArgb(145, 145, 145),
                    "A verificação foi cancelada."
                );

                lblResultado.Text =
                    "A operação foi cancelada pelo usuário.";

                lblResultado.ForeColor = Color.FromArgb(145, 145, 145);
            }
            catch (Exception ex)
            {
                progressBar.Style = ProgressBarStyle.Continuous;
                progressBar.Value = 0;

                AtualizarStatus(
                    "● ERRO",
                    Color.FromArgb(220, 35, 35),
                    "Não foi possível concluir a verificação."
                );

                lblResultado.Text =
                    $"Erro durante a verificação:\r\n\r\n{ex.Message}";

                lblResultado.ForeColor = Color.FromArgb(220, 80, 80);
            }
            finally
            {
                _verificando = false;
                btnVerificar.Enabled = true;
            }
        }

        private string ObterUnidade()
        {
            DriveInfo? unidade = DriveInfo
                .GetDrives()
                .FirstOrDefault(d =>
                    d.IsReady &&
                    d.DriveType == DriveType.Fixed &&
                    d.Name.Equals(@"C:\", StringComparison.OrdinalIgnoreCase));

            unidade ??= DriveInfo
                .GetDrives()
                .FirstOrDefault(d =>
                    d.IsReady &&
                    d.DriveType == DriveType.Fixed);

            return unidade?.Name.TrimEnd('\\') ?? string.Empty;
        }

        private async Task<string> ExecutarChkdskAsync(
            string unidade,
            CancellationToken cancellationToken)
        {
            var saida = new StringBuilder();

            using Process processo = new Process();

            processo.StartInfo = new ProcessStartInfo
            {
                FileName = "chkdsk.exe",
                Arguments = $"{unidade} /scan",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardOutputEncoding = Encoding.Default,
                StandardErrorEncoding = Encoding.Default
            };

            processo.OutputDataReceived += (_, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.Data))
                {
                    lock (saida)
                    {
                        saida.AppendLine(e.Data);
                    }

                    BeginInvoke(() =>
                    {
                        lblResultado.Text = e.Data;
                    });
                }
            };

            processo.ErrorDataReceived += (_, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.Data))
                {
                    lock (saida)
                    {
                        saida.AppendLine(e.Data);
                    }
                }
            };

            if (!processo.Start())
            {
                throw new InvalidOperationException(
                    "Não foi possível iniciar o CHKDSK."
                );
            }

            processo.BeginOutputReadLine();
            processo.BeginErrorReadLine();

            await processo.WaitForExitAsync(cancellationToken);

            return saida.ToString();
        }

        private void InterpretarResultado(string resultado)
        {
            string texto = resultado.ToLowerInvariant();

            bool encontrouProblema =
                texto.Contains("found problems")
                || texto.Contains("problemas")
                || texto.Contains("errors")
                || texto.Contains("erros")
                || texto.Contains("corrupt")
                || texto.Contains("corromp");

            if (encontrouProblema)
            {
                AtualizarStatus(
                    "● ATENÇÃO",
                    Color.FromArgb(235, 170, 45),
                    "A verificação identificou possíveis problemas."
                );

                lblResultado.Text =
                    "A verificação encontrou informações que precisam de atenção.\r\n\r\n" +
                    "Consulte o resultado detalhado abaixo para verificar " +
                    "se é necessário executar uma operação de reparo.";

                lblResultado.ForeColor = Color.FromArgb(235, 170, 45);
            }
            else
            {
                AtualizarStatus(
                    "● SAUDÁVEL",
                    Color.FromArgb(80, 190, 100),
                    "Nenhum problema relevante foi identificado."
                );

                lblResultado.Text =
                    "A verificação foi concluída com sucesso.\r\n\r\n" +
                    "O sistema de arquivos não apresentou problemas " +
                    "que exijam intervenção imediata.";

                lblResultado.ForeColor = Color.FromArgb(80, 190, 100);
            }
        }

        private void AtualizarStatus(
            string status,
            Color cor,
            string descricao)
        {
            lblStatus.Text = status;
            lblStatus.ForeColor = cor;

            lblDescricaoStatus.Text = descricao;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_verificando)
            {
                DialogResult resposta = MessageBox.Show(
                    "Uma verificação do disco está em andamento.\r\n\r\n" +
                    "Deseja realmente fechar o WinTurner?",
                    "Verificação em andamento",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resposta != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }

                _cancellationTokenSource?.Cancel();
            }

            base.OnFormClosing(e);
        }
    }
}