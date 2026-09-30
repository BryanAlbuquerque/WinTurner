using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WinTuner.Services
{
    public class OtimizacaoDebloatService
    {
        private readonly string _diretorioData;
        private readonly string _arquivoHistorico;

        private static readonly HashSet<string> PacotesProtegidos =
            new(StringComparer.OrdinalIgnoreCase)
            {
                "Microsoft.WindowsStore",
                "Microsoft.StorePurchaseApp",
                "Microsoft.Windows.SecHealthUI",
                "Microsoft.SecHealthUI",
                "Microsoft.Windows.StartMenuExperienceHost",
                "Microsoft.Windows.Search",
                "MicrosoftWindows.Client.CBS",
                "MicrosoftWindows.Client.Core",
                "MicrosoftWindows.Client.AIX",
                "Microsoft.Windows.ShellExperienceHost",
                "Microsoft.AAD.BrokerPlugin",
                "Microsoft.AccountsControl",
                "Microsoft.LockApp",
                "Microsoft.Windows.CloudExperienceHost",
                "Microsoft.Windows.ContentDeliveryManager",
                "Microsoft.DesktopAppInstaller",
                "Microsoft.WindowsAppRuntime"
            };

        private static readonly string[] TermosProtegidos =
        {
            "SecHealthUI",
            "SecurityHealth",
            "StartMenuExperienceHost",
            "ShellExperienceHost",
            "AAD.BrokerPlugin",
            "AccountsControl",
            "LockApp",
            "CloudExperienceHost",
            "ContentDeliveryManager",
            "DesktopAppInstaller",
            "VCLibs",
            "UI.Xaml",
            "NET.Native",
            "WindowsAppRuntime"
        };

        private static readonly Dictionary<string, string> NomesAmigaveis =
            new(StringComparer.OrdinalIgnoreCase)
            {
                ["Microsoft.XboxApp"] = "Xbox",
                ["Microsoft.GamingApp"] = "Xbox / Gaming",
                ["Microsoft.XboxGamingOverlay"] = "Xbox Game Bar",
                ["Microsoft.XboxIdentityProvider"] = "Xbox Identity Provider",
                ["Microsoft.XboxSpeechToTextOverlay"] = "Xbox Speech To Text",
                ["Microsoft.Xbox.TCUI"] = "Xbox TCUI",

                ["MicrosoftTeams"] = "Microsoft Teams",
                ["MSTeams"] = "Microsoft Teams",

                ["Clipchamp.Clipchamp"] = "Microsoft Clipchamp",
                ["Microsoft.Clipchamp"] = "Microsoft Clipchamp",

                ["Microsoft.WindowsWidgets"] = "Windows Widgets",
                ["MicrosoftWindows.Client.WebExperience"] =
                    "Windows Web Experience Pack",

                ["Microsoft.SolitaireCollection"] =
                    "Microsoft Solitaire Collection",

                ["Microsoft.WindowsAlarms"] = "Relógio",
                ["Microsoft.WindowsCalculator"] = "Calculadora",
                ["Microsoft.WindowsCamera"] = "Câmera",
                ["Microsoft.WindowsMaps"] = "Mapas",
                ["Microsoft.WindowsNotepad"] = "Bloco de Notas",
                ["Microsoft.Windows.Photos"] = "Fotos",
                ["Microsoft.Paint"] = "Paint",
                ["Microsoft.ScreenSketch"] = "Ferramenta de Captura",
                ["Microsoft.3DViewer"] = "Visualizador 3D",
                ["Microsoft.GetHelp"] = "Obter Ajuda",
                ["Microsoft.Getstarted"] = "Introdução",
                ["Microsoft.MicrosoftOfficeHub"] = "Microsoft 365",
                ["Microsoft.Office.OneNote"] = "OneNote",
                ["Microsoft.OneDriveSync"] = "OneDrive",
                ["Microsoft.People"] = "Pessoas",
                ["Microsoft.SkypeApp"] = "Skype",
                ["Microsoft.WindowsFeedbackHub"] = "Hub de Comentários",
                ["Microsoft.WindowsSoundRecorder"] = "Gravador de Som",
                ["Microsoft.ZuneMusic"] = "Media Player",
                ["Microsoft.ZuneVideo"] = "Filmes e TV",
                ["Microsoft.BingWeather"] = "Clima",
                ["Microsoft.BingNews"] = "Notícias",
                ["Microsoft.BingSearch"] = "Pesquisa do Windows"
            };

        public OtimizacaoDebloatService()
        {
            _diretorioData =
                Path.Combine(
                    AppContext.BaseDirectory,
                    "Data");

            _arquivoHistorico =
                Path.Combine(
                    _diretorioData,
                    "debloat_history.json");

            Directory.CreateDirectory(
                _diretorioData);
        }

        public async Task<List<DebloatItem>> AnalisarAsync()
        {
            var instalados =
                await ObterPacotesInstaladosAsync();

            var provisionados =
                await ObterPacotesProvisionadosAsync();

            var historico =
                await ObterHistoricoAsync();

            var resultado =
                new List<DebloatItem>();

            foreach (var app in instalados)
            {
                app.Provisionado =
                    provisionados.Contains(
                        app.PackageName);

                app.Protegido =
                    EhProtegido(
                        app.PackageName,
                        app.PackageFullName);

                app.MotivoProtecao =
                    ObterMotivoProtecao(
                        app.PackageName,
                        app.PackageFullName);

                app.Categoria =
                    ClassificarCategoria(app);

                resultado.Add(app);
            }

            foreach (var registro in historico)
            {
                if (resultado.Any(x =>
                    string.Equals(
                        x.PackageName,
                        registro.PackageName,
                        StringComparison.OrdinalIgnoreCase)))
                {
                    continue;
                }

                resultado.Add(
                    new DebloatItem
                    {
                        Nome =
                            string.IsNullOrWhiteSpace(
                                registro.Nome)
                                ? ObterNomeAmigavel(
                                    registro.PackageName)
                                : registro.Nome,

                        Fabricante =
                            string.IsNullOrWhiteSpace(
                                registro.Fabricante)
                                ? "Microsoft"
                                : registro.Fabricante,

                        Versao =
                            string.IsNullOrWhiteSpace(
                                registro.Versao)
                                ? "Não instalada"
                                : registro.Versao,

                        PackageName =
                            registro.PackageName,

                        PackageFullName =
                            registro.PackageFullName,

                        InstallLocation =
                            string.Empty,

                        Arquitetura =
                            "Não instalada",

                        Categoria =
                            ClassificarCategoriaPorNome(
                                registro.PackageName),

                        Instalado = false,

                        Provisionado =
                            registro.Provisionado,

                        Protegido = false,

                        MotivoProtecao =
                            string.Empty
                    });
            }

            return resultado
                .OrderBy(x => x.Categoria)
                .ThenBy(x => x.Nome)
                .ToList();
        }

        private async Task<List<DebloatItem>>
            ObterPacotesInstaladosAsync()
        {
            const string script = @"
$ErrorActionPreference = 'SilentlyContinue'

$packages = Get-AppxPackage -AllUsers |
    Where-Object {
        $_.Name -and
        $_.PackageFullName
    } |
    Select-Object `
        Name,
        PackageFullName,
        PackageFamilyName,
        Publisher,
        PublisherId,
        PublisherDisplayName,
        Version,
        Architecture,
        InstallLocation,
        IsFramework,
        IsResourcePackage,
        IsBundle,
        Status

$packages | ConvertTo-Json -Depth 5 -Compress
";

            var json =
                await ExecutarPowerShellAsync(script);

            if (string.IsNullOrWhiteSpace(json))
                return new List<DebloatItem>();

            try
            {
                using var document =
                    JsonDocument.Parse(json);

                var lista =
                    new List<DebloatItem>();

                if (document.RootElement.ValueKind ==
                    JsonValueKind.Array)
                {
                    foreach (
                        var elemento
                        in document.RootElement.EnumerateArray())
                    {
                        var item =
                            ConverterPacote(elemento);

                        if (item != null)
                            lista.Add(item);
                    }
                }
                else if (
                    document.RootElement.ValueKind ==
                    JsonValueKind.Object)
                {
                    var item =
                        ConverterPacote(
                            document.RootElement);

                    if (item != null)
                        lista.Add(item);
                }

                return lista;
            }
            catch
            {
                return new List<DebloatItem>();
            }
        }

        private DebloatItem? ConverterPacote(
            JsonElement elemento)
        {
            var nomePacote =
                ObterString(
                    elemento,
                    "Name");

            var packageFullName =
                ObterString(
                    elemento,
                    "PackageFullName");

            if (string.IsNullOrWhiteSpace(nomePacote) ||
                string.IsNullOrWhiteSpace(packageFullName))
            {
                return null;
            }

            var publisher =
                ObterString(
                    elemento,
                    "PublisherDisplayName");

            if (string.IsNullOrWhiteSpace(publisher))
            {
                publisher =
                    ObterString(
                        elemento,
                        "Publisher");
            }

            var versao =
                ObterString(
                    elemento,
                    "Version");

            var arquitetura =
                ObterString(
                    elemento,
                    "Architecture");

            var installLocation =
                ObterString(
                    elemento,
                    "InstallLocation");

            return new DebloatItem
            {
                Nome =
                    ObterNomeAmigavel(
                        nomePacote),

                Fabricante =
                    NormalizarTexto(
                        publisher,
                        ObterFabricantePorNome(
                            nomePacote)),

                Versao =
                    NormalizarTexto(
                        versao,
                        "Não identificada"),

                PackageName =
                    nomePacote,

                PackageFullName =
                    packageFullName,

                InstallLocation =
                    installLocation,

                Arquitetura =
                    NormalizarTexto(
                        arquitetura,
                        "Não identificada"),

                Instalado = true,

                Provisionado = false,

                Protegido = false,

                MotivoProtecao =
                    string.Empty
            };
        }

        private async Task<HashSet<string>>
            ObterPacotesProvisionadosAsync()
        {
            const string script = @"
$ErrorActionPreference = 'SilentlyContinue'

Get-AppxProvisionedPackage -Online |
    Where-Object {
        $_.DisplayName
    } |
    Select-Object DisplayName |
    ConvertTo-Json -Depth 3 -Compress
";

            var json =
                await ExecutarPowerShellAsync(script);

            var resultado =
                new HashSet<string>(
                    StringComparer.OrdinalIgnoreCase);

            if (string.IsNullOrWhiteSpace(json))
                return resultado;

            try
            {
                using var document =
                    JsonDocument.Parse(json);

                if (document.RootElement.ValueKind ==
                    JsonValueKind.Array)
                {
                    foreach (
                        var elemento
                        in document.RootElement.EnumerateArray())
                    {
                        var nome =
                            ObterString(
                                elemento,
                                "DisplayName");

                        if (!string.IsNullOrWhiteSpace(nome))
                            resultado.Add(nome);
                    }
                }
                else if (
                    document.RootElement.ValueKind ==
                    JsonValueKind.Object)
                {
                    var nome =
                        ObterString(
                            document.RootElement,
                            "DisplayName");

                    if (!string.IsNullOrWhiteSpace(nome))
                        resultado.Add(nome);
                }
            }
            catch
            {
            }

            return resultado;
        }

        public async Task<ResultadoDebloat>
            RemoverAsync(
                DebloatItem item)
        {
            if (item == null)
            {
                return new ResultadoDebloat
                {
                    Sucesso = false,
                    Mensagem =
                        "Aplicativo inválido."
                };
            }

            if (!item.Instalado)
            {
                return new ResultadoDebloat
                {
                    Sucesso = false,
                    Mensagem =
                        "O aplicativo não está instalado."
                };
            }

            if (item.Protegido)
            {
                return new ResultadoDebloat
                {
                    Sucesso = false,
                    Mensagem =
                        $"O aplicativo '{item.Nome}' está protegido: " +
                        item.MotivoProtecao
                };
            }

            if (string.IsNullOrWhiteSpace(
                    item.PackageFullName))
            {
                return new ResultadoDebloat
                {
                    Sucesso = false,
                    Mensagem =
                        "PackageFullName não encontrado."
                };
            }

            var script = $@"
$ErrorActionPreference = 'Stop'

$package = Get-AppxPackage -AllUsers |
    Where-Object {{
        $_.PackageFullName -eq '{EscaparPowerShell(item.PackageFullName)}'
    }}

if ($null -eq $package) {{
    throw 'Pacote não encontrado.'
}}

Remove-AppxPackage `
    -Package $package.PackageFullName `
    -AllUsers

Write-Output 'OK'
";

            var resultado =
                await ExecutarPowerShellElevadoAsync(
                    script);

            if (!resultado.Sucesso)
            {
                return new ResultadoDebloat
                {
                    Sucesso = false,
                    Mensagem =
                        resultado.Mensagem,

                    Saida =
                        resultado.Saida
                };
            }

            await RegistrarHistoricoAsync(item);

            return new ResultadoDebloat
            {
                Sucesso = true,
                Mensagem =
                    $"'{item.Nome}' removido com sucesso.",

                Saida =
                    resultado.Saida
            };
        }

        public async Task<ResultadoDebloat>
            RestaurarAsync(
                DebloatItem item)
        {
            if (item == null)
            {
                return new ResultadoDebloat
                {
                    Sucesso = false,
                    Mensagem =
                        "Aplicativo inválido."
                };
            }

            if (item.Instalado)
            {
                return new ResultadoDebloat
                {
                    Sucesso = false,
                    Mensagem =
                        $"'{item.Nome}' já está instalado."
                };
            }

            var wingetId =
                ObterWingetId(
                    item.PackageName);

            if (!string.IsNullOrWhiteSpace(
                    wingetId))
            {
                var resultadoWinget =
                    await RestaurarViaWingetAsync(
                        wingetId);

                if (resultadoWinget.Sucesso)
                {
                    await RemoverDoHistoricoAsync(
                        item.PackageName);

                    return resultadoWinget;
                }
            }

            return new ResultadoDebloat
            {
                Sucesso = false,
                Mensagem =
                    $"Não foi possível determinar uma fonte segura " +
                    $"para restaurar '{item.Nome}'."
            };
        }

        private async Task<ResultadoDebloat>
            RestaurarViaWingetAsync(
                string id)
        {
            try
            {
                var psi =
                    new ProcessStartInfo
                    {
                        FileName = "winget",

                        Arguments =
                            $"install --id \"{id}\" " +
                            "--exact " +
                            "--source msstore " +
                            "--accept-source-agreements " +
                            "--accept-package-agreements",

                        UseShellExecute = false,

                        CreateNoWindow = true,

                        RedirectStandardOutput = true,

                        RedirectStandardError = true,

                        StandardOutputEncoding =
                            Encoding.UTF8,

                        StandardErrorEncoding =
                            Encoding.UTF8
                    };

                using var processo =
                    new Process
                    {
                        StartInfo = psi
                    };

                processo.Start();

                var saida =
                    await processo
                        .StandardOutput
                        .ReadToEndAsync();

                var erro =
                    await processo
                        .StandardError
                        .ReadToEndAsync();

                await processo.WaitForExitAsync();

                if (processo.ExitCode == 0)
                {
                    return new ResultadoDebloat
                    {
                        Sucesso = true,
                        Mensagem =
                            "Aplicativo restaurado com sucesso.",

                        Saida =
                            saida
                    };
                }

                return new ResultadoDebloat
                {
                    Sucesso = false,
                    Mensagem =
                        "O winget não conseguiu restaurar o aplicativo.",

                    Saida =
                        $"{saida}\n{erro}"
                };
            }
            catch (Exception ex)
            {
                return new ResultadoDebloat
                {
                    Sucesso = false,
                    Mensagem =
                        $"Erro ao restaurar: {ex.Message}"
                };
            }
        }

        private string? ObterWingetId(
            string packageName)
        {
            var ids =
                new Dictionary<string, string>(
                    StringComparer.OrdinalIgnoreCase)
                {
                    ["Microsoft.XboxApp"] =
                        "9MWPM2CQNLHN",

                    ["Microsoft.GamingApp"] =
                        "9NZKPSTSNW4P",

                    ["Microsoft.XboxGamingOverlay"] =
                        "9NZKPSTSNW4P",

                    ["Clipchamp.Clipchamp"] =
                        "9P1J8S7CCWWT",

                    ["MicrosoftTeams"] =
                        "9WZDNCRFJ364",

                    ["MSTeams"] =
                        "XP8BT8DW290MPQ",

                    ["Microsoft.WindowsCalculator"] =
                        "9WZDNCRFHVN5",

                    ["Microsoft.WindowsNotepad"] =
                        "9MSMLRH6LZF3",

                    ["Microsoft.Windows.Photos"] =
                        "9WZDNCRFJBH4",

                    ["Microsoft.Paint"] =
                        "9PCFS5B6T72H",

                    ["Microsoft.SolitaireCollection"] =
                        "9WZDNCRFHWD2"
                };

            return ids.TryGetValue(
                packageName,
                out var id)
                ? id
                : null;
        }

        private bool EhProtegido(
            string packageName,
            string packageFullName)
        {
            if (string.IsNullOrWhiteSpace(packageName))
                return true;

            if (PacotesProtegidos.Contains(
                    packageName))
            {
                return true;
            }

            foreach (var termo in TermosProtegidos)
            {
                if (packageName.Contains(
                        termo,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (packageFullName.Contains(
                        termo,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            if (packageName.Contains(
                    "VCLibs",
                    StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (packageName.Contains(
                    "UI.Xaml",
                    StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (packageName.Contains(
                    "NET.Native",
                    StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (packageName.Contains(
                    "WindowsAppRuntime",
                    StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        private string ObterMotivoProtecao(
            string packageName,
            string packageFullName)
        {
            if (PacotesProtegidos.Contains(
                    packageName))
            {
                return "Componente importante do Windows.";
            }

            foreach (var termo in TermosProtegidos)
            {
                if (packageName.Contains(
                        termo,
                        StringComparison.OrdinalIgnoreCase) ||
                    packageFullName.Contains(
                        termo,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return "Componente essencial do Windows.";
                }
            }

            if (packageName.Contains(
                    "VCLibs",
                    StringComparison.OrdinalIgnoreCase) ||
                packageName.Contains(
                    "UI.Xaml",
                    StringComparison.OrdinalIgnoreCase) ||
                packageName.Contains(
                    "NET.Native",
                    StringComparison.OrdinalIgnoreCase))
            {
                return "Biblioteca de runtime utilizada por outros aplicativos.";
            }

            if (packageName.Contains(
                    "WindowsAppRuntime",
                    StringComparison.OrdinalIgnoreCase))
            {
                return "Runtime utilizado por aplicativos modernos do Windows.";
            }

            return "Componente protegido.";
        }

        private string ClassificarCategoria(
            DebloatItem item)
        {
            return ClassificarCategoriaPorNome(
                item.PackageName);
        }

        private string ClassificarCategoriaPorNome(
            string packageName)
        {
            if (string.IsNullOrWhiteSpace(packageName))
                return "Outros";

            var nome =
                packageName.ToLowerInvariant();

            if (nome.Contains("xbox") ||
                nome.Contains("gaming") ||
                nome.Contains("solitaire"))
            {
                return "Jogos";
            }

            if (nome.Contains("teams") ||
                nome.Contains("skype") ||
                nome.Contains("people"))
            {
                return "Comunicação";
            }

            if (nome.Contains("clipchamp") ||
                nome.Contains("zunemusic") ||
                nome.Contains("zunevideo") ||
                nome.Contains("photos") ||
                nome.Contains("paint") ||
                nome.Contains("camera") ||
                nome.Contains("soundrecorder"))
            {
                return "Multimídia";
            }

            if (nome.Contains("widgets") ||
                nome.Contains("webexperience") ||
                nome.Contains("windows"))
            {
                return "Windows";
            }

            if (nome.Contains("office") ||
                nome.Contains("onenote") ||
                nome.Contains("calculator") ||
                nome.Contains("notepad"))
            {
                return "Utilitários";
            }

            if (nome.StartsWith(
                    "microsoft.",
                    StringComparison.OrdinalIgnoreCase) ||
                nome.StartsWith(
                    "microsoft",
                    StringComparison.OrdinalIgnoreCase))
            {
                return "Microsoft";
            }

            return "Outros";
        }

        private string ObterNomeAmigavel(
            string packageName)
        {
            if (string.IsNullOrWhiteSpace(packageName))
                return "Aplicativo";

            if (NomesAmigaveis.TryGetValue(
                    packageName,
                    out var nome))
            {
                return nome;
            }

            var nomeBase =
                packageName;

            var indiceSufixo =
                nomeBase.IndexOf(
                    "_",
                    StringComparison.Ordinal);

            if (indiceSufixo > 0)
            {
                nomeBase =
                    nomeBase[..indiceSufixo];
            }

            if (nomeBase.StartsWith(
                    "Microsoft.",
                    StringComparison.OrdinalIgnoreCase))
            {
                nomeBase =
                    nomeBase[
                        "Microsoft.".Length..];
            }

            if (nomeBase.StartsWith(
                    "Windows.",
                    StringComparison.OrdinalIgnoreCase))
            {
                nomeBase =
                    nomeBase[
                        "Windows.".Length..];
            }

            nomeBase =
                nomeBase
                    .Replace(".", " ")
                    .Replace("_", " ");

            return string.IsNullOrWhiteSpace(
                    nomeBase)
                ? packageName
                : nomeBase;
        }

        private string ObterFabricantePorNome(
            string packageName)
        {
            if (packageName.StartsWith(
                    "Microsoft",
                    StringComparison.OrdinalIgnoreCase))
            {
                return "Microsoft";
            }

            return "Desenvolvedor não informado";
        }

        private string NormalizarTexto(
            string? valor,
            string fallback)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return fallback;

            return valor.Trim();
        }

        private string ObterString(
            JsonElement elemento,
            string propriedade)
        {
            if (!elemento.TryGetProperty(
                    propriedade,
                    out var valor))
            {
                return string.Empty;
            }

            if (valor.ValueKind ==
                JsonValueKind.Null)
            {
                return string.Empty;
            }

            return valor.ToString().Trim();
        }

        private async Task<string> ExecutarPowerShellAsync(string script)
        {
            return await Task.Run(() =>
            {
                using Process processo = new Process();

                processo.StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments =
                        "-NoProfile -NonInteractive -ExecutionPolicy Bypass -Command " +
                        $"\"{EscaparScriptPowerShell(script)}\"",

                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    StandardOutputEncoding = Encoding.UTF8,
                    StandardErrorEncoding = Encoding.UTF8
                };

                processo.Start();

                string saida =
                    processo.StandardOutput.ReadToEnd();

                string erro =
                    processo.StandardError.ReadToEnd();

                processo.WaitForExit();

                if (!string.IsNullOrWhiteSpace(erro) &&
                    string.IsNullOrWhiteSpace(saida))
                {
                    throw new InvalidOperationException(
                        erro.Trim());
                }

                return saida.Trim();
            });
        }

        private string EscaparScriptPowerShell(string script)
        {
            return script
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"");
        }

        private async Task<ResultadoDebloat>ExecutarPowerShellElevadoAsync( string script)
        {
            string arquivoTemporario =
                Path.Combine(
                    Path.GetTempPath(),
                    $"wintuner_debloat_{Guid.NewGuid():N}.ps1");

            try
            {
                await File.WriteAllTextAsync(
                    arquivoTemporario,
                    script,
                    new UTF8Encoding(false));

                var psi =
                    new ProcessStartInfo
                    {
                        FileName =
                            "powershell.exe",

                        Arguments =
                            $"-NoProfile " +
                            $"-ExecutionPolicy Bypass " +
                            $"-File \"{arquivoTemporario}\"",

                        UseShellExecute = true,

                        Verb = "runas",

                        WindowStyle =
                            ProcessWindowStyle.Hidden
                    };

                using var processo =
                    Process.Start(psi);

                if (processo == null)
                {
                    return new ResultadoDebloat
                    {
                        Sucesso = false,
                        Mensagem =
                            "Não foi possível iniciar o PowerShell."
                    };
                }

                await processo.WaitForExitAsync();

                if (processo.ExitCode == 0)
                {
                    return new ResultadoDebloat
                    {
                        Sucesso = true,
                        Mensagem =
                            "Operação concluída."
                    };
                }

                return new ResultadoDebloat
                {
                    Sucesso = false,
                    Mensagem =
                        $"O PowerShell retornou o código " +
                        $"{processo.ExitCode}."
                };
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                if (ex.NativeErrorCode == 1223)
                {
                    return new ResultadoDebloat
                    {
                        Sucesso = false,
                        Mensagem =
                            "A operação foi cancelada pelo usuário."
                    };
                }

                return new ResultadoDebloat
                {
                    Sucesso = false,
                    Mensagem =
                        ex.Message
                };
            }
            catch (Exception ex)
            {
                return new ResultadoDebloat
                {
                    Sucesso = false,
                    Mensagem =
                        ex.Message
                };
            }
            finally
            {
                try
                {
                    if (File.Exists(
                            arquivoTemporario))
                    {
                        File.Delete(
                            arquivoTemporario);
                    }
                }
                catch
                {
                }
            }
        }

        private async Task<List<DebloatHistorico>>ObterHistoricoAsync()
        {
            if (!File.Exists(
                    _arquivoHistorico))
            {
                return new List<DebloatHistorico>();
            }

            try
            {
                var json =
                    await File.ReadAllTextAsync(
                        _arquivoHistorico);

                return JsonSerializer.Deserialize<
                    List<DebloatHistorico>>(
                        json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive =
                                true
                        })
                    ?? new List<DebloatHistorico>();
            }
            catch
            {
                return new List<DebloatHistorico>();
            }
        }

        private async Task RegistrarHistoricoAsync(DebloatItem item)
        {
            var historico =
                await ObterHistoricoAsync();

            historico.RemoveAll(x =>
                string.Equals(
                    x.PackageName,
                    item.PackageName,
                    StringComparison.OrdinalIgnoreCase));

            historico.Add(
                new DebloatHistorico
                {
                    PackageName =
                        item.PackageName,

                    PackageFullName =
                        item.PackageFullName,

                    Nome =
                        item.Nome,

                    Fabricante =
                        item.Fabricante,

                    Versao =
                        item.Versao,

                    DataRemocao =
                        DateTime.Now,

                    Provisionado =
                        item.Provisionado
                });

            var json =
                JsonSerializer.Serialize(
                    historico,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

            await File.WriteAllTextAsync(
                _arquivoHistorico,
                json);
        }

        private async Task RemoverDoHistoricoAsync(
            string packageName)
        {
            var historico =
                await ObterHistoricoAsync();

            historico.RemoveAll(x =>
                string.Equals(
                    x.PackageName,
                    packageName,
                    StringComparison.OrdinalIgnoreCase));

            var json =
                JsonSerializer.Serialize(
                    historico,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

            await File.WriteAllTextAsync(
                _arquivoHistorico,
                json);
        }

        private string EscaparPowerShell(
            string valor)
        {
            return valor.Replace(
                "'",
                "''");
        }

        public class DebloatItem
        {
            public string Nome { get; set; } =
                "Aplicativo";

            public string Fabricante { get; set; } =
                "Desenvolvedor não informado";

            public string Versao { get; set; } =
                "Não identificada";

            public string PackageName { get; set; } =
                string.Empty;

            public string PackageFullName { get; set; } =
                string.Empty;

            public string InstallLocation { get; set; } =
                string.Empty;

            public string Arquitetura { get; set; } =
                "Não identificada";

            public string Categoria { get; set; } =
                "Outros";

            public bool Instalado { get; set; }

            public bool Provisionado { get; set; }

            public bool Protegido { get; set; }

            public string MotivoProtecao { get; set; } =
                string.Empty;

            [JsonIgnore]
            public bool Removivel =>
                Instalado && !Protegido;

            [JsonIgnore]
            public string Estado
            {
                get
                {
                    if (!Instalado)
                        return "REMOVIDO";

                    if (Protegido)
                        return "PROTEGIDO";

                    return "REMOVÍVEL";
                }
            }
        }

        public class DebloatHistorico
        {
            public string PackageName { get; set; } =
                string.Empty;

            public string PackageFullName { get; set; } =
                string.Empty;

            public string Nome { get; set; } =
                string.Empty;

            public string Fabricante { get; set; } =
                string.Empty;

            public string Versao { get; set; } =
                string.Empty;

            public DateTime DataRemocao { get; set; }

            public bool Provisionado { get; set; }
        }

        public class ResultadoDebloat
        {
            public bool Sucesso { get; set; }

            public string Mensagem { get; set; } =
                string.Empty;

            public string Saida { get; set; } =
                string.Empty;
        }
    }
}