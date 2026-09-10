using System.Diagnostics;
using WinTuner.Forms;
using WinTurner.Models;
using WinTurner.Services;

namespace WinTuner
{
    public partial class FormPrincipal : Form
    {
        private readonly SistemaService _sistemaService;
        private readonly ProcessosService _processosService;


        public FormPrincipal()
        {
            InitializeComponent();

            _sistemaService = new SistemaService();
            _processosService = new ProcessosService();

            // Processos
            ConfigurarDataGridView();
            dgvProcessos.CellContentClick += dgvProcessos_CellContentClick;
            dgvProcessos.CellMouseEnter += dgvProcessos_CellMouseEnter;

            timerSistema.Interval = 1000;
            timerSistema.Tick += timerSistema_Tick;
            timerSistema.Start();

        }

        #region Botões SideBar
        private void btnDiagnostico_Click(object sender, EventArgs e)
        {
            FormDiagnostico formDiagnostico = new FormDiagnostico();
            formDiagnostico.Show();
            this.Hide();
        }

        private void btnLimpeza_Click(object sender, EventArgs e)
        {
            FormLimpeza formLimpeza = new FormLimpeza();
            formLimpeza.Show();
            this.Hide();
        }

        private void btnOtimizacao_Click(object sender, EventArgs e)
        {
            FormOtimizacao formOtimizacao = new FormOtimizacao();
            formOtimizacao.Show();
            this.Hide();
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            FormHistorico formHistorico = new FormHistorico();
            formHistorico.Show();
            this.Hide();
        }

        #endregion


        #region CARDS
        private void timerSistema_Tick(object sender, EventArgs e)
        {
            AtualizarInformacoesSistema();
            AtualizarProcessos();
        }
        private void AtualizarInformacoesSistema()
        {
            var dados = _sistemaService.ObterInformacoes();

            lblCPU.Text = $"{dados.CpuUso:0}%";
            lblRAM.Text = $"{dados.RamUso:0}%";
            lblDISCO.Text = $"{dados.DiscoUso:0}%";
            lblGpuNome.Text = dados.GpuNome;
            lblGPU.Text = $"{dados.GpuUso:0}%";
        }

        #endregion
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            AtualizarInformacoesSistema();
            AtualizarProcessos();
        }

        #region PROCESSOS

        private void AtualizarProcessos()
        {
            var processos = _processosService.ObterAplicativos();

            dgvProcessos.DataSource = null;
            dgvProcessos.DataSource = processos;
        }
        private void ConfigurarDataGridView()
        {
            dgvProcessos.AutoGenerateColumns = false;
            dgvProcessos.AllowUserToAddRows = false;
            dgvProcessos.AllowUserToDeleteRows = false;
            dgvProcessos.AllowUserToResizeRows = false;

            dgvProcessos.ReadOnly = true;
            dgvProcessos.MultiSelect = false;
            dgvProcessos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvProcessos.RowHeadersVisible = false;
            dgvProcessos.BorderStyle = BorderStyle.None;

            dgvProcessos.BackgroundColor = Color.FromArgb(24, 24, 24);
            dgvProcessos.GridColor = Color.FromArgb(55, 55, 55);

            dgvProcessos.EnableHeadersVisualStyles = false;

            dgvProcessos.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.FromArgb(220, 40, 40),
                Font = new Font("Segoe UI Semibold", 9F),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                SelectionBackColor = Color.FromArgb(30, 30, 30),
                SelectionForeColor = Color.FromArgb(220, 40, 40)
            };

            dgvProcessos.ColumnHeadersHeight = 38;

            dgvProcessos.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(24, 24, 24),
                ForeColor = Color.FromArgb(220, 220, 220),
                Font = new Font("Segoe UI", 9F),
                SelectionBackColor = Color.FromArgb(65, 25, 25),
                SelectionForeColor = Color.White,
                Padding = new Padding(8, 0, 8, 0
                )
            };

            dgvProcessos.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(29, 29, 29),
                ForeColor = Color.FromArgb(220, 220, 220),
                SelectionBackColor = Color.FromArgb(65, 25, 25),
                SelectionForeColor = Color.White
            };

            dgvProcessos.RowTemplate.Height = 36;

            dgvProcessos.Columns.Clear();

            dgvProcessos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNome",
                HeaderText = "APLICATIVO",
                DataPropertyName = "Nome",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 25
            });

            dgvProcessos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPID",
                HeaderText = "PID",
                DataPropertyName = "Id",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvProcessos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colJanela",
                HeaderText = "JANELA",
                DataPropertyName = "Janela",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 40
            });

            dgvProcessos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMemoria",
                HeaderText = "MEMÓRIA",
                DataPropertyName = "MemoriaMB",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N1"
                }
            });

            var colunaEncerrar = new DataGridViewButtonColumn
            {
                Name = "colEncerrar",
                HeaderText = "",
                Text = "ENCERRAR",
                UseColumnTextForButtonValue = true,
                Width = 105,

                FlatStyle = FlatStyle.Flat
            };

            colunaEncerrar.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(130, 20, 20),
                ForeColor = Color.White,
                SelectionBackColor = Color.FromArgb(190, 30, 30),
                SelectionForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI Semibold", 8F)
            };

            dgvProcessos.Columns.Add(colunaEncerrar);
        }

        private void dgvProcessos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvProcessos.Columns[e.ColumnIndex].Name != "colEncerrar")
                return;

            var processo = dgvProcessos.Rows[e.RowIndex].DataBoundItem as ProcessoInfo;

            if (processo == null)
                return;

            EncerrarProcesso(processo.Id);

        }

        private void dgvProcessos_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                e.ColumnIndex >= 0 &&
                dgvProcessos.Columns[e.ColumnIndex].Name == "colEncerrar")
            {
                dgvProcessos.Cursor = Cursors.Hand;
            }
            else
            {
                dgvProcessos.Cursor = Cursors.Default;
            }
        }
        private void EncerrarProcesso(int processoId)
        {
            try
            {
                using Process processo = Process.GetProcessById(processoId);

                if (processo.Id == Environment.ProcessId)
                {
                    MessageBox.Show(
                        "O WinTurner não pode encerrar o próprio processo.",
                        "Operação bloqueada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                string nome = processo.ProcessName;

                DialogResult resultado = MessageBox.Show(
                    $"Deseja realmente encerrar o processo '{nome}'?\n\nPID: {processo.Id}",
                    "Encerrar processo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resultado != DialogResult.Yes)
                    return;

                processo.CloseMainWindow();

                if (!processo.WaitForExit(2000))
                {
                    processo.Kill();
                    processo.WaitForExit(2000);
                }

                AtualizarProcessos();
            }
            catch (ArgumentException)
            {
                MessageBox.Show(
                    "O processo não está mais em execução.",
                    "Processo não encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                AtualizarProcessos();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(
                    "O WinTurner não possui permissão para encerrar este processo.",
                    "Acesso negado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(
                    "Não foi possível encerrar o processo.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                AtualizarProcessos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao encerrar o processo:\n\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        #endregion

    }
}
