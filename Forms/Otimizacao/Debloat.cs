using WinTuner.Services;

namespace WinTuner.Forms.Otimizacao
{
    public partial class Debloat : Form
    {
        private readonly OtimizacaoDebloatService _service;

        private List<OtimizacaoDebloatService.DebloatItem> _itens =
            new List<OtimizacaoDebloatService.DebloatItem>();

        private readonly Dictionary<string, CheckBox> _checkBoxes =
            new Dictionary<string, CheckBox>(StringComparer.OrdinalIgnoreCase);

        private bool _processando;
        private bool _carregando;

        public Debloat()
        {
            InitializeComponent();

            _service =
                new OtimizacaoDebloatService();

            Shown +=
                Debloat_Shown;

            txtPesquisa.TextChanged +=
                FiltrosAlterados;

            cmbCategoria.SelectedIndexChanged +=
                FiltrosAlterados;

            chkSomenteRemoviveis.CheckedChanged +=
                FiltrosAlterados;
        }

        private async void Debloat_Shown(
            object? sender,
            EventArgs e)
        {
            await AnalisarAsync();
        }

        private async void btnAnalisar_Click(
            object? sender,
            EventArgs e)
        {
            await AnalisarAsync();
        }

        private async Task AnalisarAsync()
        {
            if (_processando)
                return;

            try
            {
                _processando = true;

                AlterarInterface(true);

                progressBar.Visible = true;

                lblStatus.Text =
                    "Analisando aplicativos instalados no Windows...";

                _itens =
                    await _service.AnalisarAsync();

                PopularCategorias();

                RenderizarCards();

                AtualizarResumo();

                lblStatus.Text =
                    $"Análise concluída. {_itens.Count} aplicativos encontrados.";
            }
            catch (Exception ex)
            {
                lblStatus.Text =
                    $"Erro durante a análise: {ex.Message}";

                MessageBox.Show(
                    $"Não foi possível analisar os aplicativos do Windows.\n\n{ex.Message}",
                    "Debloat",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Visible = false;

                AlterarInterface(false);

                _processando = false;
            }
        }

        private void PopularCategorias()
        {
            _carregando = true;

            try
            {
                string categoriaAtual =
                    cmbCategoria.SelectedItem?.ToString()
                    ?? "TODAS";

                cmbCategoria.Items.Clear();

                cmbCategoria.Items.Add("TODAS");

                foreach (string categoria in _itens
                    .Select(x => x.Categoria)
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .OrderBy(x => x))
                {
                    cmbCategoria.Items.Add(categoria);
                }

                int indice =
                    cmbCategoria.Items.IndexOf(
                        categoriaAtual);

                cmbCategoria.SelectedIndex =
                    indice >= 0
                        ? indice
                        : 0;
            }
            finally
            {
                _carregando = false;
            }
        }

        private void FiltrosAlterados(
            object? sender,
            EventArgs e)
        {
            if (_carregando)
                return;

            RenderizarCards();

            AtualizarResumo();
        }

        private void RenderizarCards()
        {
            if (flowCards == null)
                return;

            flowCards.SuspendLayout();

            try
            {
                flowCards.Controls.Clear();

                IEnumerable<OtimizacaoDebloatService.DebloatItem>
                    filtrados =
                    AplicarFiltros();

                foreach (
                    OtimizacaoDebloatService.DebloatItem item
                    in filtrados)
                {
                    flowCards.Controls.Add(
                        CriarCard(item));
                }
            }
            finally
            {
                flowCards.ResumeLayout(true);
            }
        }

        private IEnumerable<OtimizacaoDebloatService.DebloatItem>
            AplicarFiltros()
        {
            IEnumerable<OtimizacaoDebloatService.DebloatItem>
                resultado =
                _itens;

            string pesquisa =
                txtPesquisa.Text.Trim();

            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                resultado =
                    resultado.Where(x =>
                        x.Nome.Contains(
                            pesquisa,
                            StringComparison.OrdinalIgnoreCase) ||

                        x.Fabricante.Contains(
                            pesquisa,
                            StringComparison.OrdinalIgnoreCase) ||

                        x.PackageName.Contains(
                            pesquisa,
                            StringComparison.OrdinalIgnoreCase) ||

                        x.PackageFullName.Contains(
                            pesquisa,
                            StringComparison.OrdinalIgnoreCase));
            }

            string categoria =
                cmbCategoria.SelectedItem?.ToString()
                ?? "TODAS";

            if (!string.Equals(
                    categoria,
                    "TODAS",
                    StringComparison.OrdinalIgnoreCase))
            {
                resultado =
                    resultado.Where(x =>
                        string.Equals(
                            x.Categoria,
                            categoria,
                            StringComparison.OrdinalIgnoreCase));
            }

            if (chkSomenteRemoviveis.Checked)
            {
                resultado =
                    resultado.Where(x =>
                        x.Removivel);
            }

            return resultado
                .OrderBy(x => x.Protegido)
                .ThenBy(x => x.Categoria)
                .ThenBy(x => x.Nome);
        }

        private Panel CriarCard(
            OtimizacaoDebloatService.DebloatItem item)
        {
            Panel card =
                new Panel
                {
                    Width = 315,
                    Height = 174,
                    BackColor =
                        Color.FromArgb(23, 23, 23),
                    BorderStyle =
                        BorderStyle.FixedSingle,
                    Margin =
                        new Padding(8),
                    Padding =
                        new Padding(0)
                };

            CheckBox checkBox =
                new CheckBox
                {
                    AutoSize = false,
                    Location =
                        new Point(15, 15),
                    Size =
                        new Size(22, 22),
                    Cursor =
                        item.Removivel
                            ? Cursors.Hand
                            : Cursors.Default,
                    Enabled =
                        item.Removivel,
                    Checked =
                        ObterSelecao(item)
                };

            checkBox.CheckedChanged +=
                (sender, args) =>
                {
                    AtualizarResumo();
                };

            Label lblNome =
                new Label
                {
                    AutoSize = false,
                    Location =
                        new Point(45, 11),
                    Size =
                        new Size(245, 31),
                    Font =
                        new Font(
                            "Segoe UI Semibold",
                            10.5F,
                            FontStyle.Bold),
                    ForeColor =
                        Color.FromArgb(242, 242, 242),
                    Text =
                        item.Nome,
                    TextAlign =
                        ContentAlignment.MiddleLeft,
                    AutoEllipsis =
                        true
                };

            Label lblFabricante =
                new Label
                {
                    AutoSize = false,
                    Location =
                        new Point(16, 48),
                    Size =
                        new Size(280, 19),
                    Font =
                        new Font(
                            "Segoe UI",
                            8F),
                    ForeColor =
                        Color.FromArgb(135, 135, 135),
                    Text =
                        item.Fabricante,
                    TextAlign =
                        ContentAlignment.MiddleLeft,
                    AutoEllipsis =
                        true
                };

            Label lblVersao =
                new Label
                {
                    AutoSize = false,
                    Location =
                        new Point(16, 68),
                    Size =
                        new Size(280, 19),
                    Font =
                        new Font(
                            "Segoe UI",
                            8F),
                    ForeColor =
                        Color.FromArgb(115, 115, 115),
                    Text =
                        $"Versão: {item.Versao}",
                    TextAlign =
                        ContentAlignment.MiddleLeft,
                    AutoEllipsis =
                        true
                };

            Label lblPacote =
                new Label
                {
                    AutoSize = false,
                    Location =
                        new Point(16, 88),
                    Size =
                        new Size(280, 19),
                    Font =
                        new Font(
                            "Segoe UI",
                            8F),
                    ForeColor =
                        Color.FromArgb(115, 115, 115),
                    Text =
                        $"Pacote: {item.PackageName}",
                    TextAlign =
                        ContentAlignment.MiddleLeft,
                    AutoEllipsis =
                        true
                };

            Label lblCategoria =
                new Label
                {
                    AutoSize = false,
                    Location =
                        new Point(16, 125),
                    Size =
                        new Size(120, 25),
                    Font =
                        new Font(
                            "Segoe UI Semibold",
                            7.5F,
                            FontStyle.Bold),
                    ForeColor =
                        Color.FromArgb(130, 130, 130),
                    Text =
                        item.Categoria.ToUpperInvariant(),
                    TextAlign =
                        ContentAlignment.MiddleLeft
                };

            Label lblEstado =
                new Label
                {
                    AutoSize = false,
                    Location =
                        new Point(165, 122),
                    Size =
                        new Size(125, 29),
                    Font =
                        new Font(
                            "Segoe UI Semibold",
                            7.5F,
                            FontStyle.Bold),
                    TextAlign =
                        ContentAlignment.MiddleRight
                };

            if (item.Protegido)
            {
                lblEstado.Text =
                    "PROTEGIDO";

                lblEstado.ForeColor =
                    Color.FromArgb(120, 120, 120);

                card.Cursor =
                    Cursors.Default;

                ToolTip tooltip =
                    new ToolTip();

                tooltip.SetToolTip(
                    card,
                    item.MotivoProtecao);
            }
            else
            {
                lblEstado.Text =
                    item.Instalado
                        ? "REMOVÍVEL"
                        : "REMOVIDO";

                lblEstado.ForeColor =
                    item.Instalado
                        ? Color.FromArgb(208, 0, 0)
                        : Color.FromArgb(105, 175, 105);
            }

            card.Controls.Add(
                lblEstado);

            card.Controls.Add(
                lblCategoria);

            card.Controls.Add(
                lblPacote);

            card.Controls.Add(
                lblVersao);

            card.Controls.Add(
                lblFabricante);

            card.Controls.Add(
                lblNome);

            card.Controls.Add(
                checkBox);

            _checkBoxes[
                ObterChave(item)] =
                checkBox;

            return card;
        }

        private string ObterChave(
            OtimizacaoDebloatService.DebloatItem item)
        {
            return item.PackageFullName;
        }

        private bool ObterSelecao(
            OtimizacaoDebloatService.DebloatItem item)
        {
            return _checkBoxes.TryGetValue(
                ObterChave(item),
                out CheckBox? checkBox) &&
                checkBox.Checked;
        }

        private List<OtimizacaoDebloatService.DebloatItem>
            ObterSelecionados()
        {
            List<OtimizacaoDebloatService.DebloatItem>
                selecionados =
                new List<OtimizacaoDebloatService.DebloatItem>();

            foreach (
                OtimizacaoDebloatService.DebloatItem item
                in _itens)
            {
                if (!item.Removivel)
                    continue;

                if (_checkBoxes.TryGetValue(
                        ObterChave(item),
                        out CheckBox? checkBox) &&
                    checkBox.Checked)
                {
                    selecionados.Add(item);
                }
            }

            return selecionados;
        }

        private void btnSelecionarRemoviveis_Click(
            object? sender,
            EventArgs e)
        {
            foreach (
                OtimizacaoDebloatService.DebloatItem item
                in AplicarFiltros())
            {
                if (!item.Removivel)
                    continue;

                string chave =
                    ObterChave(item);

                if (_checkBoxes.TryGetValue(
                        chave,
                        out CheckBox? checkBox))
                {
                    checkBox.Checked = true;
                }
            }

            AtualizarResumo();

            lblStatus.Text =
                "Aplicativos removíveis visíveis foram selecionados.";
        }

        private void btnLimparSelecao_Click(
            object? sender,
            EventArgs e)
        {
            foreach (CheckBox checkBox in _checkBoxes.Values)
            {
                if (checkBox.Enabled)
                    checkBox.Checked = false;
            }

            AtualizarResumo();

            lblStatus.Text =
                "Seleção limpa.";
        }

        private async void btnRemover_Click(
            object? sender,
            EventArgs e)
        {
            if (_processando)
                return;

            List<OtimizacaoDebloatService.DebloatItem>
                selecionados =
                ObterSelecionados();

            if (selecionados.Count == 0)
            {
                MessageBox.Show(
                    "Nenhum aplicativo removível foi selecionado.",
                    "Debloat",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DialogResult confirmacao =
                MessageBox.Show(
                    CriarMensagemConfirmacaoRemocao(
                        selecionados),
                    "Confirmar remoção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (confirmacao != DialogResult.Yes)
                return;

            try
            {
                _processando = true;

                AlterarInterface(true);

                progressBar.Visible = true;

                int sucesso = 0;
                int falhas = 0;

                foreach (
                    OtimizacaoDebloatService.DebloatItem item
                    in selecionados)
                {
                    lblStatus.Text =
                        $"Removendo {item.Nome}...";

                    Application.DoEvents();

                    OtimizacaoDebloatService.ResultadoDebloat
                        resultado =
                        await _service.RemoverAsync(item);

                    if (resultado.Sucesso)
                        sucesso++;
                    else
                        falhas++;
                }

                _itens =
                    await _service.AnalisarAsync();

                PopularCategorias();

                RenderizarCards();

                AtualizarResumo();

                lblStatus.Text =
                    $"Debloat concluído: {sucesso} removido(s), {falhas} falha(s).";
            }
            catch (Exception ex)
            {
                lblStatus.Text =
                    $"Erro durante o Debloat: {ex.Message}";

                MessageBox.Show(
                    ex.Message,
                    "Debloat",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Visible = false;

                AlterarInterface(false);

                _processando = false;
            }
        }

        private async void btnRestaurar_Click(
            object? sender,
            EventArgs e)
        {
            if (_processando)
                return;

            List<OtimizacaoDebloatService.DebloatItem>
                selecionados =
                ObterSelecionados();

            if (selecionados.Count == 0)
            {
                MessageBox.Show(
                    "Selecione os aplicativos removidos que deseja restaurar.",
                    "Restaurar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            List<OtimizacaoDebloatService.DebloatItem>
                removidos =
                selecionados
                    .Where(x => !x.Instalado)
                    .ToList();

            if (removidos.Count == 0)
            {
                MessageBox.Show(
                    "Os itens selecionados não estão marcados como removidos.",
                    "Restaurar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DialogResult confirmacao =
                MessageBox.Show(
                    CriarMensagemConfirmacaoRestauracao(
                        removidos),
                    "Confirmar restauração",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirmacao != DialogResult.Yes)
                return;

            try
            {
                _processando = true;

                AlterarInterface(true);

                progressBar.Visible = true;

                int sucesso = 0;
                int falhas = 0;

                foreach (
                    OtimizacaoDebloatService.DebloatItem item
                    in removidos)
                {
                    lblStatus.Text =
                        $"Restaurando {item.Nome}...";

                    Application.DoEvents();

                    OtimizacaoDebloatService.ResultadoDebloat
                        resultado =
                        await _service.RestaurarAsync(item);

                    if (resultado.Sucesso)
                        sucesso++;
                    else
                        falhas++;
                }

                _itens =
                    await _service.AnalisarAsync();

                PopularCategorias();

                RenderizarCards();

                AtualizarResumo();

                lblStatus.Text =
                    $"Restauração concluída: {sucesso} restaurado(s), {falhas} falha(s).";
            }
            catch (Exception ex)
            {
                lblStatus.Text =
                    $"Erro durante a restauração: {ex.Message}";

                MessageBox.Show(
                    ex.Message,
                    "Restaurar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Visible = false;

                AlterarInterface(false);

                _processando = false;
            }
        }

        private string CriarMensagemConfirmacaoRemocao(
            List<OtimizacaoDebloatService.DebloatItem>
                itens)
        {
            IEnumerable<string> nomes =
                itens
                    .Take(8)
                    .Select(x => $"• {x.Nome}");

            string lista =
                string.Join(
                    Environment.NewLine,
                    nomes);

            if (itens.Count > 8)
            {
                lista +=
                    $"{Environment.NewLine}• ... e mais {itens.Count - 8}";
            }

            return
                $"Você selecionou {itens.Count} aplicativo(s) para remoção." +
                Environment.NewLine +
                Environment.NewLine +
                lista +
                Environment.NewLine +
                Environment.NewLine +
                "O WinTuner tentará remover o pacote para todos os usuários " +
                "e, quando possível, também o pacote provisionado." +
                Environment.NewLine +
                Environment.NewLine +
                "Deseja continuar?";
        }

        private string CriarMensagemConfirmacaoRestauracao(
            List<OtimizacaoDebloatService.DebloatItem>
                itens)
        {
            IEnumerable<string> nomes =
                itens
                    .Take(8)
                    .Select(x => $"• {x.Nome}");

            string lista =
                string.Join(
                    Environment.NewLine,
                    nomes);

            if (itens.Count > 8)
            {
                lista +=
                    $"{Environment.NewLine}• ... e mais {itens.Count - 8}";
            }

            return
                $"Você selecionou {itens.Count} aplicativo(s) para restauração." +
                Environment.NewLine +
                Environment.NewLine +
                lista +
                Environment.NewLine +
                Environment.NewLine +
                "O WinTuner utilizará o histórico da ferramenta e o WinGet " +
                "quando houver um identificador conhecido." +
                Environment.NewLine +
                Environment.NewLine +
                "Deseja continuar?";
        }

        private void AtualizarResumo()
        {
            int encontrados =
                _itens.Count;

            int removiveis =
                _itens.Count(x => x.Removivel);

            int protegidos =
                _itens.Count(x => x.Protegido);

            int instalados =
                _itens.Count(x => x.Instalado);

            int selecionados =
                ObterSelecionados().Count;

            lblTotal.Text =
                encontrados.ToString();

            lblInstalados.Text =
                instalados.ToString();

            lblRemoviveis.Text =
                removiveis.ToString();

            lblProtegidos.Text =
                protegidos.ToString();

            lblSelecionados.Text =
                selecionados.ToString();
        }

        private void AlterarInterface(
            bool processando)
        {
            btnAnalisar.Enabled =
                !processando;

            btnSelecionarRemoviveis.Enabled =
                !processando;

            btnLimparSelecao.Enabled =
                !processando;

            btnRemover.Enabled =
                !processando;

            btnRestaurar.Enabled =
                !processando;

            txtPesquisa.Enabled =
                !processando;

            cmbCategoria.Enabled =
                !processando;

            chkSomenteRemoviveis.Enabled =
                !processando;
        }

        private void Debloat_FormClosing(
            object? sender,
            FormClosingEventArgs e)
        {
            if (!_processando)
                return;

            DialogResult resultado =
                MessageBox.Show(
                    "Existe uma operação do Debloat em andamento.\n\n" +
                    "Deseja realmente fechar o WinTuner?",
                    "Operação em andamento",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (resultado != DialogResult.Yes)
                e.Cancel = true;
        }
    }
}
