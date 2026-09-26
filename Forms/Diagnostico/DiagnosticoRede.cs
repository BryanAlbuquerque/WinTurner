using WinTuner.Services.Diagnosticos;

namespace WinTuner.Forms.Diagnostico
{
    public partial class DiagnosticoRede : Form
    {
        private readonly VerificarRedeService _verificarRedeService;

        private CancellationTokenSource? _cancellationTokenSource;
        private bool _executando;

        public DiagnosticoRede()
        {
            InitializeComponent();

            _verificarRedeService = new VerificarRedeService();

            ConfigurarEstadoInicial();
        }

        private void ConfigurarEstadoInicial()
        {
            lblStatus.Text = "Pronto para iniciar o diagnóstico.";
            lblStatus.ForeColor = Color.FromArgb(145, 145, 145);

            lblStatusConexao.Text = "Não verificado";
            lblAdaptador.Text = "Não identificado";
            lblVelocidade.Text = "-";
            lblMAC.Text = "-";
            lblIPv4.Text = "-";
            lblIPv6.Text = "-";
            lblGateway.Text = "-";
            lblDNS.Text = "-";

            txtResultado.Clear();

            btnDiagnosticar.Enabled = true;
        }

        private async void btnDiagnosticar_Click(object sender, EventArgs e)
        {
            if (_executando)
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
                    "Identificando o adaptador de rede...",
                    Color.FromArgb(220, 180, 60)
                );

                ResultadoRede resultado =
                    await _verificarRedeService.DiagnosticarAsync(
                        _cancellationTokenSource.Token
                    );

                if (_cancellationTokenSource.IsCancellationRequested)
                {
                    MostrarCancelado();
                    return;
                }

                CarregarInformacoes(resultado);

                MostrarResultado(resultado);
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

        private void CarregarInformacoes(ResultadoRede resultado)
        {
            lblStatusConexao.Text = resultado.StatusConexao;
            lblAdaptador.Text = resultado.NomeAdaptador;
            lblVelocidade.Text = resultado.Velocidade;
            lblMAC.Text = resultado.MacAddress;
            lblIPv4.Text = resultado.IPv4;
            lblIPv6.Text = resultado.IPv6;
            lblGateway.Text = resultado.Gateway;
            lblDNS.Text = resultado.Dns;
        }

        private void MostrarResultado(ResultadoRede resultado)
        {
            EscreverResultado(
                "========================================\r\n" +
                " DIAGNÓSTICO DE REDE\r\n" +
                "========================================\r\n\r\n"
            );

            EscreverResultado(
                $"Adaptador : {resultado.NomeAdaptador}\r\n" +
                $"Status    : {resultado.StatusConexao}\r\n" +
                $"IPv4      : {resultado.IPv4}\r\n" +
                $"IPv6      : {resultado.IPv6}\r\n" +
                $"Gateway   : {resultado.Gateway}\r\n" +
                $"DNS       : {resultado.Dns}\r\n" +
                $"MAC       : {resultado.MacAddress}\r\n" +
                $"Velocidade: {resultado.Velocidade}\r\n\r\n"
            );

            EscreverResultado(
                "----------------------------------------\r\n" +
                " TESTES DE CONECTIVIDADE\r\n" +
                "----------------------------------------\r\n"
            );

            EscreverResultado(
                $"Gateway   : {FormatarResultadoTeste(resultado.TesteGateway)}\r\n"
            );

            EscreverResultado(
                $"Internet  : {FormatarResultadoTeste(resultado.TesteInternet)}\r\n"
            );

            EscreverResultado(
                $"DNS       : {FormatarResultadoTeste(resultado.TesteDns)}\r\n\r\n"
            );

            EscreverResultado(
                "----------------------------------------\r\n" +
                " RESULTADO FINAL\r\n" +
                "----------------------------------------\r\n"
            );

            if (resultado.RedeFuncionando)
            {
                AtualizarStatus(
                    "Conexão de rede funcionando normalmente.",
                    Color.FromArgb(80, 180, 100)
                );

                EscreverResultado(
                    "A conexão de rede foi estabelecida e os testes principais foram concluídos.\r\n"
                );
            }
            else
            {
                AtualizarStatus(
                    "Foram identificados problemas na conexão de rede.",
                    Color.FromArgb(220, 80, 70)
                );

                EscreverResultado(
                    "Um ou mais testes de conectividade apresentaram falhas.\r\n"
                );
            }
        }

        private string FormatarResultadoTeste(TesteRede teste)
        {
            if (teste.Sucesso)
            {
                return $"OK ({teste.Mensagem})";
            }

            return $"FALHA ({teste.Mensagem})";
        }

        private void MostrarCancelado()
        {
            AtualizarStatus(
                "Diagnóstico cancelado.",
                Color.FromArgb(220, 180, 60)
            );

            EscreverResultado(
                "\r\n----------------------------------------\r\n" +
                "DIAGNÓSTICO CANCELADO\r\n" +
                "----------------------------------------\r\n"
            );
        }

        private void MostrarErro(Exception ex)
        {
            AtualizarStatus(
                "Erro durante o diagnóstico.",
                Color.FromArgb(220, 80, 70)
            );

            EscreverResultado(
                "\r\n----------------------------------------\r\n" +
                "ERRO\r\n" +
                "----------------------------------------\r\n" +
                $"{ex.Message}\r\n"
            );
        }

        private void AlterarEstado(bool executando)
        {
            btnDiagnosticar.Enabled = !executando;
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
                    "O diagnóstico de rede ainda está em andamento.\n\n" +
                    "Aguarde a conclusão antes de fechar esta janela.",
                    "Diagnóstico em andamento",
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