using WinTuner.Services.Diagnosticos;

namespace WinTuner.Forms.Diagnostico
{
    public partial class IntegridadeWindows : Form
    {
        private readonly IntegridadeWindowsService _integridadeService;

        private CancellationTokenSource? _cancellationTokenSource;
        private bool _executando;

        public IntegridadeWindows()
        {
            InitializeComponent();

            _integridadeService = new IntegridadeWindowsService();

            ConfigurarEstadoInicial();
        }

        private void ConfigurarEstadoInicial()
        {
            lblStatus.Text = "Pronto para iniciar o diagnóstico.";
            lblStatus.ForeColor = Color.FromArgb(145, 145, 145);

            txtResultado.Clear();

            btnDiagnosticar.Enabled = true;
            btnReparar.Enabled = false;
            btnReparar.Visible = false;
        }

        private async void btnDiagnosticar_Click(object sender, EventArgs e)
        {
            if (_executando)
                return;

            DialogResult confirmacao = MessageBox.Show(
                "O Windows será analisado usando as ferramentas DISM e SFC.\n\n" +
                "O processo pode levar alguns minutos.\n\n" +
                "Deseja iniciar o diagnóstico?",
                "Diagnóstico de Integridade",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacao != DialogResult.Yes)
                return;

            await ExecutarDiagnosticoAsync();
        }

        private async Task ExecutarDiagnosticoAsync()
        {
            _executando = true;

            _cancellationTokenSource = new CancellationTokenSource();

            AlterarEstado(true);

            LimparResultado();

            try
            {
                AtualizarStatus(
                    "Verificando a integridade da imagem do Windows...",
                    Color.FromArgb(220, 180, 60)
                );

                EscreverResultado(
                    "========================================\r\n" +
                    " DIAGNÓSTICO DE INTEGRIDADE DO WINDOWS\r\n" +
                    "========================================\r\n\r\n"
                );

                EscreverResultado(
                    "Etapa 1 - DISM /Online /CheckHealth\r\n\r\n"
                );

                ResultadoIntegridade resultadoDism =
                    await _integridadeService.VerificarDismAsync(
                        _cancellationTokenSource.Token
                    );

                EscreverResultado(resultadoDism.Saida);
                EscreverResultado("\r\n\r\n");

                if (_cancellationTokenSource.IsCancellationRequested)
                {
                    MostrarCancelado();
                    return;
                }

                AtualizarStatus(
                    "Verificando os arquivos protegidos do Windows...",
                    Color.FromArgb(220, 180, 60)
                );

                EscreverResultado(
                    "Etapa 2 - SFC /SCANNOW\r\n\r\n"
                );

                ResultadoIntegridade resultadoSfc =
                    await _integridadeService.VerificarSfcAsync(
                        _cancellationTokenSource.Token
                    );

                EscreverResultado(resultadoSfc.Saida);

                if (_cancellationTokenSource.IsCancellationRequested)
                {
                    MostrarCancelado();
                    return;
                }

                bool requerReparo =
                    resultadoDism.RequerReparo ||
                    resultadoSfc.RequerReparo;

                if (resultadoDism.Sucesso && resultadoSfc.Sucesso)
                {
                    MostrarResultadoSaudavel();
                }
                else if (requerReparo)
                {
                    MostrarResultadoComProblema();
                }
                else
                {
                    MostrarResultadoAtencao();
                }
            }
            catch (OperationCanceledException)
            {
                MostrarCancelado();
            }
            catch (Exception ex)
            {
                MostrarErro(ex);
            }
            finally
            {
                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;

                _executando = false;

                AlterarEstado(false);
            }
        }

        private async void btnReparar_Click(object sender, EventArgs e)
        {
            if (_executando)
                return;

            DialogResult confirmacao = MessageBox.Show(
                "O Windows será reparado utilizando o DISM e o SFC.\n\n" +
                "O processo pode levar vários minutos.\n" +
                "Não desligue o computador durante a operação.\n\n" +
                "Deseja continuar?",
                "Reparar Windows",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacao != DialogResult.Yes)
                return;

            await ExecutarReparoAsync();
        }

        private async Task ExecutarReparoAsync()
        {
            _executando = true;

            _cancellationTokenSource = new CancellationTokenSource();

            AlterarEstado(true);

            btnReparar.Visible = false;

            LimparResultado();

            try
            {
                AtualizarStatus(
                    "Reparando a imagem do Windows...",
                    Color.FromArgb(220, 180, 60)
                );

                EscreverResultado(
                    "========================================\r\n" +
                    " REPARAÇÃO DO WINDOWS\r\n" +
                    "========================================\r\n\r\n"
                );

                EscreverResultado(
                    "Etapa 1 - DISM /Online /RestoreHealth\r\n\r\n"
                );

                ResultadoIntegridade resultadoDism =
                    await _integridadeService.RepararDismAsync(
                        _cancellationTokenSource.Token
                    );

                EscreverResultado(resultadoDism.Saida);
                EscreverResultado("\r\n\r\n");

                if (_cancellationTokenSource.IsCancellationRequested)
                {
                    MostrarCancelado();
                    return;
                }

                AtualizarStatus(
                    "Verificando e reparando os arquivos do Windows...",
                    Color.FromArgb(220, 180, 60)
                );

                EscreverResultado(
                    "Etapa 2 - SFC /SCANNOW\r\n\r\n"
                );

                ResultadoIntegridade resultadoSfc =
                    await _integridadeService.VerificarSfcAsync(
                        _cancellationTokenSource.Token
                    );

                EscreverResultado(resultadoSfc.Saida);

                if (_cancellationTokenSource.IsCancellationRequested)
                {
                    MostrarCancelado();
                    return;
                }

                if (resultadoDism.Sucesso && resultadoSfc.Sucesso)
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
                MostrarCancelado();
            }
            catch (Exception ex)
            {
                MostrarErro(ex);
            }
            finally
            {
                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;

                _executando = false;

                AlterarEstado(false);
            }
        }

        private void MostrarResultadoSaudavel()
        {
            AtualizarStatus(
                "Windows íntegro. Nenhum problema foi identificado.",
                Color.FromArgb(80, 180, 100)
            );

            btnReparar.Visible = false;
            btnReparar.Enabled = false;

            EscreverResultado(
                "\r\n\r\n----------------------------------------\r\n" +
                "RESULTADO FINAL\r\n" +
                "----------------------------------------\r\n" +
                "Nenhum problema de integridade foi identificado.\r\n"
            );
        }

        private void MostrarResultadoComProblema()
        {
            AtualizarStatus(
                "Problemas de integridade foram identificados.",
                Color.FromArgb(220, 80, 70)
            );

            btnReparar.Visible = true;
            btnReparar.Enabled = true;

            EscreverResultado(
                "\r\n\r\n----------------------------------------\r\n" +
                "RESULTADO FINAL\r\n" +
                "----------------------------------------\r\n" +
                "Foram identificados problemas que podem exigir reparo.\r\n" +
                "O botão REPARAR WINDOWS foi disponibilizado.\r\n"
            );
        }

        private void MostrarResultadoAtencao()
        {
            AtualizarStatus(
                "O diagnóstico terminou, mas requer atenção.",
                Color.FromArgb(220, 180, 60)
            );

            btnReparar.Visible = true;
            btnReparar.Enabled = true;

            EscreverResultado(
                "\r\n\r\n----------------------------------------\r\n" +
                "RESULTADO FINAL\r\n" +
                "----------------------------------------\r\n" +
                "Não foi possível confirmar que o sistema está íntegro.\r\n" +
                "Considere executar o reparo do Windows.\r\n"
            );
        }

        private void MostrarReparoConcluido()
        {
            AtualizarStatus(
                "Reparo concluído com sucesso.",
                Color.FromArgb(80, 180, 100)
            );

            btnReparar.Visible = false;
            btnReparar.Enabled = false;

            EscreverResultado(
                "\r\n\r\n----------------------------------------\r\n" +
                "REPARO CONCLUÍDO\r\n" +
                "----------------------------------------\r\n" +
                "O processo de reparo foi concluído.\r\n" +
                "O SFC foi executado novamente após o DISM.\r\n"
            );
        }

        private void MostrarReparoIncompleto()
        {
            AtualizarStatus(
                "O reparo terminou, mas ainda existem problemas.",
                Color.FromArgb(220, 80, 70)
            );

            btnReparar.Visible = true;
            btnReparar.Enabled = true;

            EscreverResultado(
                "\r\n\r\n----------------------------------------\r\n" +
                "REPARO INCOMPLETO\r\n" +
                "----------------------------------------\r\n" +
                "O Windows ainda pode apresentar problemas de integridade.\r\n" +
                "Consulte o resultado detalhado acima.\r\n"
            );
        }

        private void MostrarCancelado()
        {
            AtualizarStatus(
                "Operação cancelada.",
                Color.FromArgb(220, 180, 60)
            );

            btnReparar.Visible = false;
            btnReparar.Enabled = false;

            EscreverResultado(
                "\r\n\r\n----------------------------------------\r\n" +
                "OPERAÇÃO CANCELADA\r\n" +
                "----------------------------------------\r\n"
            );
        }

        private void MostrarErro(Exception ex)
        {
            AtualizarStatus(
                "Erro durante a operação.",
                Color.FromArgb(220, 80, 70)
            );

            btnReparar.Visible = false;
            btnReparar.Enabled = false;

            EscreverResultado(
                "\r\n\r\n----------------------------------------\r\n" +
                "ERRO\r\n" +
                "----------------------------------------\r\n" +
                $"{ex.Message}\r\n"
            );
        }

        private void AlterarEstado(bool executando)
        {
            btnDiagnosticar.Enabled = !executando;

            if (executando)
            {
                btnReparar.Enabled = false;
            }
        }

        private void AtualizarStatus(string mensagem, Color cor)
        {
            if (IsDisposed)
                return;

            lblStatus.Text = mensagem;
            lblStatus.ForeColor = cor;
        }

        private void LimparResultado()
        {
            txtResultado.Clear();
        }

        private void EscreverResultado(string texto)
        {
            if (txtResultado.IsDisposed)
                return;

            txtResultado.AppendText(texto);
            txtResultado.SelectionStart = txtResultado.TextLength;
            txtResultado.ScrollToCaret();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_executando)
            {
                MessageBox.Show(
                    "Existe uma operação em andamento.\n\n" +
                    "Aguarde a conclusão antes de fechar esta janela.",
                    "Operação em andamento",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                e.Cancel = true;
                return;
            }

            base.OnFormClosing(e);
        }
    }
}