
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinTuner.Services;
using WinTuner.Services.Otimizacao;

namespace WinTuner.Forms
{
    public partial class ProgramasInicializacao : Form
    {
        #region CAMPOS

        private readonly ProgramasInicializacaoService _service;
        private List<ProgramaInicializacao> _programas = new();

        #endregion

        #region CONSTRUTOR

        public ProgramasInicializacao()
        {
            InitializeComponent();

            _service = new ProgramasInicializacaoService();

            ConfigurarGrade();
            ConfigurarEventos();

            AparenciaWindowsService.AplicarBarraEscura(this);
        }

        #endregion

        #region GRADE

        private void ConfigurarGrade()
        {
            dgvProgramas.Columns.Clear();

            dgvProgramas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNome",
                HeaderText = "Nome",
                DataPropertyName = "Nome",
                FillWeight = 140,
                MinimumWidth = 180
            });

            dgvProgramas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFornecedor",
                HeaderText = "Fornecedor",
                DataPropertyName = "Fornecedor",
                FillWeight = 110,
                MinimumWidth = 150
            });

            dgvProgramas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Status",
                DataPropertyName = "Status",
                FillWeight = 80,
                MinimumWidth = 110
            });

            dgvProgramas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colImpacto",
                HeaderText = "Impacto na inicialização",
                DataPropertyName = "Impacto",
                FillWeight = 105,
                MinimumWidth = 175
            });

            dgvProgramas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                DataPropertyName = "Id",
                Visible = false
            });
        }

        #endregion

        #region EVENTOS

        private void ConfigurarEventos()
        {
            Shown += (_, _) => CarregarProgramas();
            btnAtualizar.Click += (_, _) => CarregarProgramas();
            btnAtivar.Click += btnAtivar_Click;
            btnDesativar.Click += btnDesativar_Click;

            dgvProgramas.SelectionChanged += (_, _) => AtualizarBotoes();
            dgvProgramas.CellFormatting += dgvProgramas_CellFormatting;
        }

        #endregion

        #region CARREGAR

        private void CarregarProgramas()
        {
            try
            {
                _programas = _service.ObterProgramas();

                dgvProgramas.DataSource = null;
                dgvProgramas.DataSource = _programas.Select(p => new LinhaPrograma
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Fornecedor = p.Fornecedor,
                    Status = p.Status,
                    Impacto = p.Impacto
                }).ToList();

                lblResumo.Text =
                    $"{_programas.Count} programas encontrados  |  " +
                    $"{_programas.Count(p => p.Ativado)} habilitados  |  " +
                    $"{_programas.Count(p => !p.Ativado)} desabilitados";

                lblStatus.Text =
                    "Os dados exibidos dependem das informações disponíveis no Windows.";

                AtualizarBotoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar os programas:\n\n" + ex.Message,
                    "WinTuner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion

        #region SELEÇÃO E BOTÕES

        private ProgramaInicializacao ObterSelecionado()
        {
            if (dgvProgramas.CurrentRow?.DataBoundItem is not LinhaPrograma linha)
                return null;

            return _programas.FirstOrDefault(p => p.Id == linha.Id);
        }

        private void AtualizarBotoes()
        {
            ProgramaInicializacao programa = ObterSelecionado();

            btnAtivar.Enabled = programa != null && !programa.Ativado;
            btnDesativar.Enabled = programa != null && programa.Ativado;
        }

        #endregion

        #region AÇÕES

        private void btnDesativar_Click(object sender, EventArgs e)
        {
            ExecutarAcao(false);
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            ExecutarAcao(true);
        }

        private void ExecutarAcao(bool ativar)
        {
            ProgramaInicializacao programa = ObterSelecionado();

            if (programa == null)
                return;

            string acao = ativar ? "ativar" : "desativar";

            if (MessageBox.Show(
                $"Deseja {acao} '{programa.Nome}'?",
                "Confirmar operação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                if (ativar)
                    _service.AtivarPrograma(programa);
                else
                    _service.DesativarPrograma(programa);

                CarregarProgramas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "WinTuner",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region CORES DE STATUS

        private void dgvProgramas_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 ||
                dgvProgramas.Columns[e.ColumnIndex].Name != "colStatus")
                return;

            string status = Convert.ToString(e.Value);

            e.CellStyle.ForeColor = status == "Habilitado"
                ? Color.FromArgb(20, 110, 50)
                : Color.FromArgb(100, 100, 100);
        }

        #endregion

        #region MODELO DA GRADE

        private sealed class LinhaPrograma
        {
            public string Id { get; set; }
            public string Nome { get; set; }
            public string Fornecedor { get; set; }
            public string Status { get; set; }
            public string Impacto { get; set; }
        }

        #endregion
    }
}