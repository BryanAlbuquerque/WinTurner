
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace WinTuner.Services.Otimizacao
{
    public class ProgramaInicializacao
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Nome { get; set; } = "";
        public string Fornecedor { get; set; } = "Desconhecido";
        public string Comando { get; set; } = "";
        public string Origem { get; set; } = "";
        public string Tipo { get; set; } = "";
        public string Status { get; set; } = "Desconhecido";
        public string Impacto { get; set; } = "Desconhecido";
        public bool Ativado { get; set; }
        public bool RequerAdministrador { get; set; }

        public string Hive { get; set; } = "";
        public string CaminhoRegistro { get; set; } = "";
        public string NomeValorRegistro { get; set; } = "";
        public string TipoValorRegistro { get; set; } = "";
        public string DadosRegistro { get; set; } = "";

        public string CaminhoArquivo { get; set; } = "";
        public string CaminhoBackup { get; set; } = "";
        public string CaminhoOriginal { get; set; } = "";
    }

    public class ProgramasInicializacaoService
    {
        #region CONSTANTES

        private const string RunPath =
            @"Software\Microsoft\Windows\CurrentVersion\Run";

        private const string RunOncePath =
            @"Software\Microsoft\Windows\CurrentVersion\RunOnce";

        #endregion

        #region OBTER PROGRAMAS

        public List<ProgramaInicializacao> ObterProgramas()
        {
            var programas = new List<ProgramaInicializacao>();

            LerRegistro(programas, Registry.CurrentUser, "HKCU");
            LerRegistro(programas, Registry.LocalMachine, "HKLM");

            LerPasta(programas,
                Environment.GetFolderPath(
                    Environment.SpecialFolder.Startup),
                "Inicialização do usuário");

            LerPasta(programas,
                Environment.GetFolderPath(
                    Environment.SpecialFolder.CommonStartup),
                "Inicialização de todos os usuários");

            return programas
                .GroupBy(p => p.Id, StringComparer.OrdinalIgnoreCase)
                .Select(g => g.First())
                .OrderBy(p => p.Nome)
                .ToList();
        }

        private void LerRegistro(
            List<ProgramaInicializacao> lista,
            RegistryKey raiz,
            string hive)
        {
            LerChave(lista, raiz, hive, RunPath);
            LerChave(lista, raiz, hive, RunOncePath);
        }

        private void LerChave(
            List<ProgramaInicializacao> lista,
            RegistryKey raiz,
            string hive,
            string caminho)
        {
            try
            {
                using RegistryKey chave = raiz.OpenSubKey(caminho);

                if (chave == null)
                    return;

                foreach (string nome in chave.GetValueNames())
                {
                    try
                    {
                        object dado = chave.GetValue(
                            nome, null,
                            RegistryValueOptions.DoNotExpandEnvironmentNames);

                        if (dado == null)
                            continue;

                        string comando = Convert.ToString(dado) ?? "";

                        var programa = new ProgramaInicializacao
                        {
                            Id = $"{hive}|{caminho}|{nome}",
                            Nome = nome,
                            Comando = comando,
                            Origem = hive,
                            Tipo = caminho.EndsWith("RunOnce",
                                StringComparison.OrdinalIgnoreCase)
                                ? "Registro (RunOnce)"
                                : "Registro (Run)",
                            Hive = hive,
                            CaminhoRegistro = caminho,
                            NomeValorRegistro = nome,
                            TipoValorRegistro =
                                chave.GetValueKind(nome).ToString(),
                            DadosRegistro = comando,
                            RequerAdministrador = hive == "HKLM",
                            Ativado = true,
                            Status = "Habilitado"
                        };

                        PreencherInformacoes(programa);
                        lista.Add(programa);
                    }
                    catch
                    {
                        // Ignora apenas a entrada que não pôde ser lida.
                    }
                }
            }
            catch
            {
                // A chave pode não existir ou não estar acessível.
            }
        }

        private void LerPasta(
            List<ProgramaInicializacao> lista,
            string pasta,
            string origem)
        {
            if (string.IsNullOrWhiteSpace(pasta) ||
                !Directory.Exists(pasta))
                return;

            try
            {
                foreach (string arquivo in Directory.GetFiles(pasta))
                {
                    string nome = Path.GetFileNameWithoutExtension(arquivo);

                    var programa = new ProgramaInicializacao
                    {
                        Id = "FILE|" + arquivo,
                        Nome = nome,
                        Comando = arquivo,
                        Origem = origem,
                        Tipo = "Pasta de inicialização",
                        CaminhoArquivo = arquivo,
                        CaminhoOriginal = arquivo,
                        RequerAdministrador =
                            origem == "Inicialização de todos os usuários",
                        Ativado = true,
                        Status = "Habilitado"
                    };

                    PreencherInformacoes(programa);
                    lista.Add(programa);
                }
            }
            catch
            {
                // A pasta pode não estar acessível.
            }
        }

        #endregion

        #region FORNECEDOR E INFORMAÇÕES

        private void PreencherInformacoes(ProgramaInicializacao programa)
        {
            string executavel = ExtrairExecutavel(programa.Comando);

            if (string.IsNullOrWhiteSpace(executavel))
                return;

            executavel = Environment.ExpandEnvironmentVariables(executavel);

            if (!File.Exists(executavel))
                return;

            try
            {
                FileVersionInfo info = FileVersionInfo.GetVersionInfo(executavel);

                if (!string.IsNullOrWhiteSpace(info.ProductName))
                    programa.Nome = info.ProductName;

                if (!string.IsNullOrWhiteSpace(info.CompanyName))
                    programa.Fornecedor = info.CompanyName;

                // Não inventa um impacto sem uma medição confiável.
                programa.Impacto = "Desconhecido";
            }
            catch
            {
                programa.Fornecedor = "Desconhecido";
            }
        }

        private string ExtrairExecutavel(string comando)
        {
            if (string.IsNullOrWhiteSpace(comando))
                return "";

            comando = Environment.ExpandEnvironmentVariables(comando.Trim());

            if (comando.StartsWith("\""))
            {
                int fim = comando.IndexOf('"', 1);

                if (fim > 1)
                    return comando.Substring(1, fim - 1);
            }

            int exe = comando.IndexOf(".exe",
                StringComparison.OrdinalIgnoreCase);

            if (exe >= 0)
                return comando.Substring(0, exe + 4).Trim('"');

            return comando.Trim('"');
        }

        #endregion

        #region ATIVAR E DESATIVAR

        public void DesativarPrograma(ProgramaInicializacao programa)
        {
            if (programa == null)
                throw new ArgumentNullException(nameof(programa));

            if (programa.Tipo == "Pasta de inicialização")
            {
                throw new NotSupportedException(
                    "A desativação por movimentação para backup precisa ser " +
                    "integrada ao mecanismo de backup do seu serviço anterior.");
            }

            RegistryKey raiz = ObterRaiz(programa.Hive);

            using RegistryKey chave =
                raiz.OpenSubKey(programa.CaminhoRegistro, true);

            if (chave == null)
                throw new InvalidOperationException(
                    "Não foi possível abrir a chave de inicialização para alteração. " +
                    "Talvez seja necessário executar como administrador.");

            chave.DeleteValue(programa.NomeValorRegistro, false);
        }

        public void AtivarPrograma(ProgramaInicializacao programa)
        {
            if (programa == null)
                throw new ArgumentNullException(nameof(programa));

            if (programa.Tipo == "Pasta de inicialização")
            {
                throw new NotSupportedException(
                    "Para restaurar arquivos desativados, é necessário utilizar " +
                    "o mecanismo de backup do serviço anterior.");
            }

            throw new NotSupportedException(
                "A reativação exige restaurar os dados originais que foram " +
                "salvos no backup antes da desativação. Não é seguro recriar " +
                "uma entrada sem esses dados.");
        }

        private RegistryKey ObterRaiz(string hive)
        {
            return hive switch
            {
                "HKCU" => Registry.CurrentUser,
                "HKLM" => Registry.LocalMachine,
                _ => throw new InvalidOperationException(
                    "Origem de Registro desconhecida.")
            };
        }

        #endregion
    }
}