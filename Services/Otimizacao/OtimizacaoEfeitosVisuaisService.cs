using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinTuner.Services
{
    public class OtimizacaoEfeitosVisuaisService
    {
        #region Constantes

        private const string DesktopKey = @"Control Panel\Desktop";
        private const string WindowMetricsKey = @"Control Panel\Desktop\WindowMetrics";
        private const string ExplorerAdvancedKey = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        private const string VisualEffectsKey = @"Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects";
        private const string DwmKey = @"Software\Microsoft\Windows\DWM";

        private const uint SPIF_UPDATEINIFILE = 0x0001;
        private const uint SPIF_SENDCHANGE = 0x0002;
        private const uint SPIF_FLAGS = SPIF_UPDATEINIFILE | SPIF_SENDCHANGE;

        // Animação de janelas (minimizar/maximizar)
        private const uint SPI_GETANIMATION = 0x0048;
        private const uint SPI_SETANIMATION = 0x0049;

        // Arrastar janela mostrando conteúdo
        private const uint SPI_GETDRAGFULLWINDOWS = 0x0026;
        private const uint SPI_SETDRAGFULLWINDOWS = 0x0025;

        // Suavização de fontes
        private const uint SPI_GETFONTSMOOTHING = 0x004A;
        private const uint SPI_SETFONTSMOOTHING = 0x004B;
        private const uint SPI_SETFONTSMOOTHINGTYPE = 0x200B;
        private const int FE_FONTSMOOTHINGCLEARTYPE = 0x0002;

        // Menus, listas, tooltips, ponteiro
        private const uint SPI_GETMENUANIMATION = 0x1002;
        private const uint SPI_SETMENUANIMATION = 0x1003;
        private const uint SPI_GETCOMBOBOXANIMATION = 0x1004;
        private const uint SPI_SETCOMBOBOXANIMATION = 0x1005;
        private const uint SPI_GETLISTBOXSMOOTHSCROLLING = 0x1006;
        private const uint SPI_SETLISTBOXSMOOTHSCROLLING = 0x1007;
        private const uint SPI_GETSELECTIONFADE = 0x1014;
        private const uint SPI_SETSELECTIONFADE = 0x1015;
        private const uint SPI_GETTOOLTIPANIMATION = 0x1016;
        private const uint SPI_SETTOOLTIPANIMATION = 0x1017;
        private const uint SPI_SETTOOLTIPFADE = 0x1019;
        private const uint SPI_GETCURSORSHADOW = 0x101A;
        private const uint SPI_SETCURSORSHADOW = 0x101B;
        private const uint SPI_GETDROPSHADOW = 0x1024;
        private const uint SPI_SETDROPSHADOW = 0x1025;
        private const uint SPI_SETUIEFFECTS = 0x103F;
        private const uint SPI_GETCLIENTAREAANIMATION = 0x1042;
        private const uint SPI_SETCLIENTAREAANIMATION = 0x1043;

        private const uint HWND_BROADCAST = 0xFFFF;
        private const uint WM_SETTINGCHANGE = 0x001A;
        private const uint WM_THEMECHANGED = 0x031A;
        private const uint SMTO_ABORTIFHUNG = 0x0002;

        private const uint SHCNE_ASSOCCHANGED = 0x08000000;
        private const uint SHCNF_IDLIST = 0x0000;

        #endregion

        #region API do Windows

        [StructLayout(LayoutKind.Sequential)]
        private struct ANIMATIONINFO
        {
            public uint cbSize;
            public int iMinAnimate;
        }

        // pvParam como ponteiro (leitura e valores por referência)
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
        private static extern bool SpiPtr(
            uint uiAction,
            uint uiParam,
            IntPtr pvParam,
            uint fWinIni);

        // pvParam como ANIMATIONINFO
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
        private static extern bool SpiAnim(
            uint uiAction,
            uint uiParam,
            ref ANIMATIONINFO pvParam,
            uint fWinIni);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessageTimeout(
            IntPtr hWnd,
            uint Msg,
            IntPtr wParam,
            IntPtr lParam,
            uint fuFlags,
            uint uTimeout,
            out IntPtr lpdwResult);

        [DllImport("shell32.dll")]
        private static extern void SHChangeNotify(
            uint wEventId,
            uint uFlags,
            IntPtr dwItem1,
            IntPtr dwItem2);

        #endregion

        #region Modelos

        public class ConfiguracaoEfeitos
        {
            public bool AbrirCaixasCombinacao { get; set; }
            public bool AnimacoesBarraTarefas { get; set; }
            public bool AnimarControlesElementos { get; set; }
            public bool AnimarJanelasMinMax { get; set; }
            public bool EsmaecerItensMenu { get; set; }
            public bool EsmaecerToolTips { get; set; }
            public bool EsmaecerMenus { get; set; }
            public bool HabilitarPeek { get; set; }
            public bool MostrarConteudoJanelaArrastar { get; set; }
            public bool MostrarMiniaturas { get; set; }
            public bool RetanguloSelecaoTranslucido { get; set; }
            public bool SombrasJanelas { get; set; }
            public bool SombrasPonteiro { get; set; }
            public bool RolarListasSuavemente { get; set; }
            public bool SalvarMiniaturasBarraTarefas { get; set; }
            public bool SuavizacaoFontes { get; set; }
            public bool SombrasRotulosDesktop { get; set; }

            public string Preset { get; set; } = "Personalizado";

            // 0 = Windows decide | 3 = Personalizado (usado pelos presets do WinTuner)
            public int ModoVisualFX { get; set; } = 3;
        }

        public class ResultadoEfeitos
        {
            public bool Sucesso { get; set; }
            public string Mensagem { get; set; } = string.Empty;
        }

        #endregion

        #region Métodos públicos

        public Task<ConfiguracaoEfeitos> ObterConfiguracaoAsync()
        {
            return Task.Run(LerConfiguracao);
        }

        public Task<ResultadoEfeitos> AplicarConfiguracaoAsync(
            ConfiguracaoEfeitos configuracao)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (configuracao == null)
                    {
                        return new ResultadoEfeitos
                        {
                            Sucesso = false,
                            Mensagem = "A configuração recebida é inválida."
                        };
                    }

                    AplicarConfiguracao(configuracao);

                    // Aguarda o Windows processar as alterações
                    Thread.Sleep(300);

                    ConfiguracaoEfeitos confirmacao = LerConfiguracao();

                    if (ConfiguracaoIgual(configuracao, confirmacao))
                    {
                        return new ResultadoEfeitos
                        {
                            Sucesso = true,
                            Mensagem = "Efeitos visuais aplicados e confirmados com sucesso."
                        };
                    }

                    return new ResultadoEfeitos
                    {
                        Sucesso = false,
                        Mensagem =
                            "O Windows aplicou a configuração, mas algumas opções retornaram diferentes durante a confirmação.\n\n" +
                            ObterDiferencas(configuracao, confirmacao)
                    };
                }
                catch (Exception ex)
                {
                    return new ResultadoEfeitos
                    {
                        Sucesso = false,
                        Mensagem = $"Erro ao aplicar efeitos visuais:\n\n{ex.Message}"
                    };
                }
            });
        }

        public async Task<ResultadoEfeitos> AplicarPresetAsync(string preset)
        {
            if (string.IsNullOrWhiteSpace(preset))
            {
                return new ResultadoEfeitos
                {
                    Sucesso = false,
                    Mensagem = "Preset inválido."
                };
            }

            switch (preset)
            {
                case "Melhor desempenho":
                    return await AplicarConfiguracaoAsync(CriarMelhorDesempenho());

                case "Equilibrado":
                    return await AplicarConfiguracaoAsync(CriarEquilibrado());

                case "Melhor aparência":
                    return await AplicarConfiguracaoAsync(CriarMelhorAparencia());

                case "Padrão do Windows":
                    return await RestaurarPadraoWindowsAsync();

                default:
                    return new ResultadoEfeitos
                    {
                        Sucesso = false,
                        Mensagem = $"Preset desconhecido: {preset}"
                    };
            }
        }

        #endregion

        #region Presets

        private ConfiguracaoEfeitos CriarMelhorDesempenho()
        {
            // Tudo desligado, exceto a suavização das fontes
            return new ConfiguracaoEfeitos
            {
                SuavizacaoFontes = true,
                Preset = "Melhor desempenho",
                ModoVisualFX = 3
            };
        }

        private ConfiguracaoEfeitos CriarEquilibrado()
        {
            return new ConfiguracaoEfeitos
            {
                AbrirCaixasCombinacao = true,
                AnimarControlesElementos = true,
                AnimarJanelasMinMax = true,
                EsmaecerMenus = true,
                MostrarMiniaturas = true,
                SombrasPonteiro = true,
                RolarListasSuavemente = true,
                SuavizacaoFontes = true,

                // Os demais ficam desativados
                Preset = "Equilibrado",
                ModoVisualFX = 3
            };
        }

        private ConfiguracaoEfeitos CriarMelhorAparencia()
        {
            return new ConfiguracaoEfeitos
            {
                AbrirCaixasCombinacao = true,
                AnimacoesBarraTarefas = true,
                AnimarControlesElementos = true,
                AnimarJanelasMinMax = true,
                EsmaecerItensMenu = true,
                EsmaecerToolTips = true,
                EsmaecerMenus = true,
                HabilitarPeek = true,
                MostrarConteudoJanelaArrastar = true,
                MostrarMiniaturas = true,
                RetanguloSelecaoTranslucido = true,
                SombrasJanelas = true,
                SombrasPonteiro = true,
                RolarListasSuavemente = true,
                SalvarMiniaturasBarraTarefas = true,
                SuavizacaoFontes = true,
                SombrasRotulosDesktop = true,
                Preset = "Melhor aparência",
                ModoVisualFX = 3
            };
        }

        private Task<ResultadoEfeitos> RestaurarPadraoWindowsAsync()
        {
            return Task.Run(() =>
            {
                try
                {
                    // VisualFXSetting = 0: o Windows volta a controlar os efeitos
                    GravarDword(VisualEffectsKey, "VisualFXSetting", 0);

                    NotificarWindows();
                    Thread.Sleep(300);

                    return new ResultadoEfeitos
                    {
                        Sucesso = true,
                        Mensagem = "O controle dos efeitos visuais foi devolvido ao Windows."
                    };
                }
                catch (Exception ex)
                {
                    return new ResultadoEfeitos
                    {
                        Sucesso = false,
                        Mensagem = $"Erro ao restaurar o padrão do Windows:\n\n{ex.Message}"
                    };
                }
            });
        }

        #endregion

        #region Leitura

        private ConfiguracaoEfeitos LerConfiguracao()
        {
            // Os efeitos controlados por SPI são lidos do estado real do Windows,
            // exatamente como o sysdm.cpl faz.
            var configuracao = new ConfiguracaoEfeitos
            {
                AbrirCaixasCombinacao = LerBoolSpi(SPI_GETCOMBOBOXANIMATION),
                AnimacoesBarraTarefas = LerDword(ExplorerAdvancedKey, "TaskbarAnimations", 1) != 0,
                AnimarControlesElementos = LerBoolSpi(SPI_GETCLIENTAREAANIMATION),
                AnimarJanelasMinMax = LerAnimacaoJanelas(),
                EsmaecerItensMenu = LerBoolSpi(SPI_GETSELECTIONFADE),
                EsmaecerToolTips = LerBoolSpi(SPI_GETTOOLTIPANIMATION),
                EsmaecerMenus = LerBoolSpi(SPI_GETMENUANIMATION),
                HabilitarPeek = LerDword(DwmKey, "EnableAeroPeek", 1) != 0,
                MostrarConteudoJanelaArrastar = LerBoolSpi(SPI_GETDRAGFULLWINDOWS),
                MostrarMiniaturas = LerDword(ExplorerAdvancedKey, "IconsOnly", 0) == 0,
                RetanguloSelecaoTranslucido = LerDword(ExplorerAdvancedKey, "ListviewAlphaSelect", 1) != 0,
                SombrasJanelas = LerBoolSpi(SPI_GETDROPSHADOW),
                SombrasPonteiro = LerBoolSpi(SPI_GETCURSORSHADOW),
                RolarListasSuavemente = LerBoolSpi(SPI_GETLISTBOXSMOOTHSCROLLING),
                SalvarMiniaturasBarraTarefas = LerDword(DwmKey, "AlwaysHibernateThumbnails", 1) != 0,
                SuavizacaoFontes = LerBoolSpi(SPI_GETFONTSMOOTHING),
                SombrasRotulosDesktop = LerDword(ExplorerAdvancedKey, "ListviewShadow", 1) != 0,
                ModoVisualFX = LerDword(VisualEffectsKey, "VisualFXSetting", 3)
            };

            configuracao.Preset = DetectarPreset(configuracao);

            return configuracao;
        }

        private string DetectarPreset(ConfiguracaoEfeitos config)
        {
            if (config.ModoVisualFX == 0)
                return "Padrão do Windows";

            if (ConfiguracaoIgual(config, CriarMelhorDesempenho()))
                return "Melhor desempenho";

            if (ConfiguracaoIgual(config, CriarEquilibrado()))
                return "Equilibrado";

            if (ConfiguracaoIgual(config, CriarMelhorAparencia()))
                return "Melhor aparência";

            return "Personalizado";
        }

        #endregion

        #region Comparação

        private static List<(string Nome, bool Valor)> ListarEfeitos(
            ConfiguracaoEfeitos c)
        {
            return new List<(string, bool)>
            {
                ("Abrir caixas de combinação", c.AbrirCaixasCombinacao),
                ("Animações da barra de tarefas", c.AnimacoesBarraTarefas),
                ("Animar controles e elementos", c.AnimarControlesElementos),
                ("Animar janelas", c.AnimarJanelasMinMax),
                ("Esmaecer itens de menu", c.EsmaecerItensMenu),
                ("Esmaecer ToolTips", c.EsmaecerToolTips),
                ("Esmaecer menus", c.EsmaecerMenus),
                ("Peek", c.HabilitarPeek),
                ("Conteúdo da janela ao arrastar", c.MostrarConteudoJanelaArrastar),
                ("Miniaturas", c.MostrarMiniaturas),
                ("Retângulo de seleção translúcido", c.RetanguloSelecaoTranslucido),
                ("Sombras das janelas", c.SombrasJanelas),
                ("Sombras do ponteiro", c.SombrasPonteiro),
                ("Rolagem suave", c.RolarListasSuavemente),
                ("Salvar miniaturas", c.SalvarMiniaturasBarraTarefas),
                ("Suavização das fontes", c.SuavizacaoFontes),
                ("Sombras dos rótulos", c.SombrasRotulosDesktop)
            };
        }

        private static bool ConfiguracaoIgual(
            ConfiguracaoEfeitos atual,
            ConfiguracaoEfeitos esperado)
        {
            var a = ListarEfeitos(atual);
            var e = ListarEfeitos(esperado);

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].Valor != e[i].Valor)
                    return false;
            }

            return true;
        }

        private static string ObterDiferencas(
            ConfiguracaoEfeitos esperado,
            ConfiguracaoEfeitos atual)
        {
            var diferencas = new StringBuilder();
            var e = ListarEfeitos(esperado);
            var a = ListarEfeitos(atual);

            for (int i = 0; i < e.Count; i++)
            {
                if (e[i].Valor == a[i].Valor)
                    continue;

                diferencas.AppendLine(
                    $"• {e[i].Nome}: esperado {(e[i].Valor ? "ATIVADO" : "DESATIVADO")}, " +
                    $"Windows retornou {(a[i].Valor ? "ATIVADO" : "DESATIVADO")}.");
            }

            return diferencas.Length > 0
                ? diferencas.ToString()
                : "Nenhuma diferença específica foi identificada.";
        }

        #endregion

        #region Aplicação

        private void AplicarConfiguracao(ConfiguracaoEfeitos config)
        {
            // Sempre personalizado
            GravarDword(VisualEffectsKey, "VisualFXSetting", 3);

            // Configurações baseadas em registro
            GravarDword(ExplorerAdvancedKey, "TaskbarAnimations", config.AnimacoesBarraTarefas ? 1 : 0);
            GravarDword(DwmKey, "EnableAeroPeek", config.HabilitarPeek ? 1 : 0);
            GravarDword(ExplorerAdvancedKey, "IconsOnly", config.MostrarMiniaturas ? 0 : 1);
            GravarDword(ExplorerAdvancedKey, "ListviewAlphaSelect", config.RetanguloSelecaoTranslucido ? 1 : 0);
            GravarDword(DwmKey, "AlwaysHibernateThumbnails", config.SalvarMiniaturasBarraTarefas ? 1 : 0);
            GravarDword(ExplorerAdvancedKey, "ListviewShadow", config.SombrasRotulosDesktop ? 1 : 0);

            // Master "UI effects" primeiro; os individuais vêm depois
            // para não serem sobrescritos por ele.
            bool efeitosInterface =
                config.AbrirCaixasCombinacao ||
                config.RolarListasSuavemente ||
                config.EsmaecerMenus ||
                config.EsmaecerItensMenu ||
                config.EsmaecerToolTips ||
                config.SombrasPonteiro;

            DefinirBoolSpi(SPI_SETUIEFFECTS, efeitosInterface);

            // Efeitos individuais (todos via SystemParametersInfo)
            DefinirBoolSpi(SPI_SETCOMBOBOXANIMATION, config.AbrirCaixasCombinacao);
            DefinirBoolSpi(SPI_SETLISTBOXSMOOTHSCROLLING, config.RolarListasSuavemente);
            DefinirBoolSpi(SPI_SETMENUANIMATION, config.EsmaecerMenus);
            DefinirBoolSpi(SPI_SETSELECTIONFADE, config.EsmaecerItensMenu);
            DefinirBoolSpi(SPI_SETTOOLTIPANIMATION, config.EsmaecerToolTips);
            DefinirBoolSpi(SPI_SETTOOLTIPFADE, config.EsmaecerToolTips);
            DefinirBoolSpi(SPI_SETCURSORSHADOW, config.SombrasPonteiro);
            DefinirBoolSpi(SPI_SETDROPSHADOW, config.SombrasJanelas);
            DefinirBoolSpi(SPI_SETCLIENTAREAANIMATION, config.AnimarControlesElementos);

            DefinirAnimacaoJanelas(config.AnimarJanelasMinMax);
            DefinirArrastarJanelaCompleta(config.MostrarConteudoJanelaArrastar);

            // Fontes por último
            DefinirSuavizacaoFontes(config.SuavizacaoFontes);

            NotificarWindows();
        }

        #endregion

        #region SystemParametersInfo

        private static bool LerBoolSpi(uint action)
        {
            IntPtr buffer = Marshal.AllocHGlobal(sizeof(int));

            try
            {
                Marshal.WriteInt32(buffer, 0);

                if (!SpiPtr(action, 0, buffer, 0))
                    return false;

                return Marshal.ReadInt32(buffer) != 0;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        // Para os SPI_SET* em que pvParam recebe o valor (TRUE/FALSE) e não um ponteiro
        private static void DefinirBoolSpi(uint action, bool valor)
        {
            bool ok = SpiPtr(
                action,
                0,
                new IntPtr(valor ? 1 : 0),
                SPIF_FLAGS);

            if (!ok)
                LancarErroWin32(action);
        }

        private static bool LerAnimacaoJanelas()
        {
            var info = new ANIMATIONINFO
            {
                cbSize = (uint)Marshal.SizeOf<ANIMATIONINFO>()
            };

            if (!SpiAnim(SPI_GETANIMATION, info.cbSize, ref info, 0))
                return false;

            return info.iMinAnimate != 0;
        }

        private static void DefinirAnimacaoJanelas(bool habilitado)
        {
            var info = new ANIMATIONINFO
            {
                cbSize = (uint)Marshal.SizeOf<ANIMATIONINFO>(),
                iMinAnimate = habilitado ? 1 : 0
            };

            if (!SpiAnim(SPI_SETANIMATION, info.cbSize, ref info, SPIF_FLAGS))
                LancarErroWin32(SPI_SETANIMATION);

            GravarString(WindowMetricsKey, "MinAnimate", habilitado ? "1" : "0");
        }

        private static void DefinirArrastarJanelaCompleta(bool habilitado)
        {
            // Aqui o valor vai em uiParam
            bool ok = SpiPtr(
                SPI_SETDRAGFULLWINDOWS,
                habilitado ? 1u : 0u,
                IntPtr.Zero,
                SPIF_FLAGS);

            if (!ok)
                LancarErroWin32(SPI_SETDRAGFULLWINDOWS);

            GravarString(DesktopKey, "DragFullWindows", habilitado ? "1" : "0");
        }

        private static void DefinirSuavizacaoFontes(bool habilitado)
        {
            bool ok = SpiPtr(
                SPI_SETFONTSMOOTHING,
                habilitado ? 1u : 0u,
                IntPtr.Zero,
                SPIF_FLAGS);

            if (!ok)
                LancarErroWin32(SPI_SETFONTSMOOTHING);

            if (habilitado)
            {
                // ClearType
                SpiPtr(
                    SPI_SETFONTSMOOTHINGTYPE,
                    0,
                    new IntPtr(FE_FONTSMOOTHINGCLEARTYPE),
                    SPIF_FLAGS);
            }

            GravarString(DesktopKey, "FontSmoothing", habilitado ? "2" : "0");

            if (habilitado)
                GravarDword(DesktopKey, "FontSmoothingType", FE_FONTSMOOTHINGCLEARTYPE);
        }

        private static void LancarErroWin32(uint action)
        {
            int erro = Marshal.GetLastWin32Error();

            throw new InvalidOperationException(
                $"Não foi possível atualizar o parâmetro visual 0x{action:X4}. " +
                $"Código Win32: {erro}.");
        }

        #endregion

        #region Registro

        private static int LerDword(string caminho, string nome, int padrao)
        {
            using RegistryKey? key = Registry.CurrentUser.OpenSubKey(caminho);

            object? valor = key?.GetValue(nome);

            if (valor is int inteiro)
                return inteiro;

            if (valor is long longo)
                return (int)longo;

            if (valor is string texto && int.TryParse(texto, out int convertido))
                return convertido;

            return padrao;
        }

        private static void GravarDword(string caminho, string nome, int valor)
        {
            using RegistryKey key = Registry.CurrentUser.CreateSubKey(caminho);

            key.SetValue(nome, valor, RegistryValueKind.DWord);
        }

        private static void GravarString(string caminho, string nome, string valor)
        {
            using RegistryKey key = Registry.CurrentUser.CreateSubKey(caminho);

            key.SetValue(nome, valor, RegistryValueKind.String);
        }

        #endregion

        #region Notificação

        private static void NotificarWindows()
        {
            IntPtr resultado;

            SendMessageTimeout(
                new IntPtr(HWND_BROADCAST),
                WM_SETTINGCHANGE,
                IntPtr.Zero,
                IntPtr.Zero,
                SMTO_ABORTIFHUNG,
                1000,
                out resultado);

            SendMessageTimeout(
                new IntPtr(HWND_BROADCAST),
                WM_THEMECHANGED,
                IntPtr.Zero,
                IntPtr.Zero,
                SMTO_ABORTIFHUNG,
                1000,
                out resultado);

            SHChangeNotify(
                SHCNE_ASSOCCHANGED,
                SHCNF_IDLIST,
                IntPtr.Zero,
                IntPtr.Zero);
        }

        #endregion
    }
}