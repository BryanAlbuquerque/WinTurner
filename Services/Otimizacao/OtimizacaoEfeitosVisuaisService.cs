using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace WinTuner.Services
{
    public class OtimizacaoEfeitosVisuaisService
    {
        private const string DesktopKey =
            @"Control Panel\Desktop";

        private const string WindowMetricsKey =
            @"Control Panel\Desktop\WindowMetrics";

        private const string ExplorerAdvancedKey =
            @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";

        private const string DwmKey =
            @"Software\Microsoft\Windows\DWM";

        private const uint SPIF_UPDATEINIFILE = 0x0001;
        private const uint SPIF_SENDCHANGE = 0x0002;

        private const uint SPI_SETCLIENTAREAANIMATION = 0x1043;
        private const uint SPI_SETFONTSMOOTHING = 0x004B;
        private const uint SPI_SETCOMBOBOXANIMATION = 0x1005;
        private const uint SPI_SETLISTBOXSMOOTHSCROLLING = 0x1007;
        private const uint SPI_SETMENUANIMATION = 0x1003;
        private const uint SPI_SETSELECTIONFADE = 0x1015;
        private const uint SPI_SETTOOLTIPANIMATION = 0x1017;
        private const uint SPI_SETTOOLTIPFADE = 0x1019;
        private const uint SPI_SETCURSORSHADOW = 0x101B;
        private const uint SPI_SETUIEFFECTS = 0x103F;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern bool SystemParametersInfo(
            uint uiAction,
            uint uiParam,
            IntPtr pvParam,
            uint fWinIni);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
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

        private const uint HWND_BROADCAST = 0xFFFF;
        private const uint WM_SETTINGCHANGE = 0x001A;
        private const uint WM_THEMECHANGED = 0x031A;
        private const uint SMTO_ABORTIFHUNG = 0x0002;

        private const uint SHCNE_ASSOCCHANGED = 0x08000000;
        private const uint SHCNF_IDLIST = 0x0000;

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
        }

        public class ResultadoEfeitos
        {
            public bool Sucesso { get; set; }
            public string Mensagem { get; set; } = string.Empty;
        }

        public async Task<ConfiguracaoEfeitos> ObterConfiguracaoAsync()
        {
            return await Task.Run(LerConfiguracao);
        }

        public async Task<ResultadoEfeitos> AplicarConfiguracaoAsync(
            ConfiguracaoEfeitos configuracao)
        {
            return await Task.Run(() =>
            {
                try
                {
                    AplicarConfiguracao(configuracao);

                    var confirmacao = LerConfiguracao();

                    bool sucesso =
                        confirmacao.AbrirCaixasCombinacao == configuracao.AbrirCaixasCombinacao &&
                        confirmacao.AnimacoesBarraTarefas == configuracao.AnimacoesBarraTarefas &&
                        confirmacao.AnimarControlesElementos == configuracao.AnimarControlesElementos &&
                        confirmacao.AnimarJanelasMinMax == configuracao.AnimarJanelasMinMax &&
                        confirmacao.EsmaecerItensMenu == configuracao.EsmaecerItensMenu &&
                        confirmacao.EsmaecerToolTips == configuracao.EsmaecerToolTips &&
                        confirmacao.EsmaecerMenus == configuracao.EsmaecerMenus &&
                        confirmacao.HabilitarPeek == configuracao.HabilitarPeek &&
                        confirmacao.MostrarConteudoJanelaArrastar == configuracao.MostrarConteudoJanelaArrastar &&
                        confirmacao.MostrarMiniaturas == configuracao.MostrarMiniaturas &&
                        confirmacao.RetanguloSelecaoTranslucido == configuracao.RetanguloSelecaoTranslucido &&
                        confirmacao.SombrasJanelas == configuracao.SombrasJanelas &&
                        confirmacao.SombrasPonteiro == configuracao.SombrasPonteiro &&
                        confirmacao.RolarListasSuavemente == configuracao.RolarListasSuavemente &&
                        confirmacao.SalvarMiniaturasBarraTarefas == configuracao.SalvarMiniaturasBarraTarefas &&
                        confirmacao.SuavizacaoFontes == configuracao.SuavizacaoFontes &&
                        confirmacao.SombrasRotulosDesktop == configuracao.SombrasRotulosDesktop;

                    return new ResultadoEfeitos
                    {
                        Sucesso = sucesso,
                        Mensagem = sucesso
                            ? "Efeitos visuais aplicados e verificados com sucesso."
                            : "As configurações foram gravadas, mas a leitura de confirmação encontrou diferenças."
                    };
                }
                catch (Exception ex)
                {
                    return new ResultadoEfeitos
                    {
                        Sucesso = false,
                        Mensagem = $"Erro ao aplicar efeitos visuais: {ex.Message}"
                    };
                }
            });
        }

        public async Task<ResultadoEfeitos> AplicarPresetAsync(string preset)
        {
            var configuracao = new ConfiguracaoEfeitos();

            switch (preset)
            {
                case "Melhor desempenho":
                    configuracao = CriarMelhorDesempenho();
                    break;

                case "Melhor aparência":
                    configuracao = CriarMelhorAparencia();
                    break;

                case "Equilibrado":
                    configuracao = CriarEquilibrado();
                    break;

                case "Padrão do Windows":
                    configuracao = CriarPadraoWindows();
                    break;

                default:
                    return new ResultadoEfeitos
                    {
                        Sucesso = false,
                        Mensagem = "Preset desconhecido."
                    };
            }

            configuracao.Preset = preset;

            return await AplicarConfiguracaoAsync(configuracao);
        }

        public async Task<ResultadoEfeitos> RestaurarPadraoAsync()
        {
            return await AplicarPresetAsync("Padrão do Windows");
        }

        private ConfiguracaoEfeitos CriarMelhorDesempenho()
        {
            return new ConfiguracaoEfeitos
            {
                AbrirCaixasCombinacao = false,
                AnimacoesBarraTarefas = false,
                AnimarControlesElementos = false,
                AnimarJanelasMinMax = false,
                EsmaecerItensMenu = false,
                EsmaecerToolTips = false,
                EsmaecerMenus = false,
                HabilitarPeek = false,
                MostrarConteudoJanelaArrastar = false,
                MostrarMiniaturas = false,
                RetanguloSelecaoTranslucido = false,
                SombrasJanelas = false,
                SombrasPonteiro = false,
                RolarListasSuavemente = false,
                SalvarMiniaturasBarraTarefas = false,
                SuavizacaoFontes = false,
                SombrasRotulosDesktop = false,
                Preset = "Melhor desempenho"
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
                Preset = "Melhor aparência"
            };
        }

        private ConfiguracaoEfeitos CriarEquilibrado()
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
                SombrasPonteiro = false,
                RolarListasSuavemente = true,
                SalvarMiniaturasBarraTarefas = true,
                SuavizacaoFontes = true,
                SombrasRotulosDesktop = true,
                Preset = "Equilibrado"
            };
        }

        private ConfiguracaoEfeitos CriarPadraoWindows()
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
                Preset = "Padrão do Windows"
            };
        }

        private ConfiguracaoEfeitos LerConfiguracao()
        {
            byte[] mask = LerUserPreferencesMask();

            return new ConfiguracaoEfeitos
            {
                AbrirCaixasCombinacao = (mask[0] & 0x04) != 0,

                AnimacoesBarraTarefas =
                    LerDword(ExplorerAdvancedKey, "TaskbarAnimations", 1) != 0,

                AnimarControlesElementos =
                    (mask[4] & 0x02) != 0,

                AnimarJanelasMinMax =
                    LerString(WindowMetricsKey, "MinAnimate", "1") == "1",

                EsmaecerItensMenu =
                    (mask[1] & 0x04) != 0,

                EsmaecerToolTips =
                    (mask[1] & 0x08) != 0,

                EsmaecerMenus =
                    (mask[0] & 0x02) != 0,

                HabilitarPeek =
                    LerDword(DwmKey, "EnableAeroPeek", 1) != 0,

                MostrarConteudoJanelaArrastar =
                    LerString(DesktopKey, "DragFullWindows", "1") == "1",

                MostrarMiniaturas =
                    LerDword(ExplorerAdvancedKey, "IconsOnly", 0) == 0,

                RetanguloSelecaoTranslucido =
                    LerDword(ExplorerAdvancedKey, "ListviewAlphaSelect", 1) != 0,

                SombrasJanelas =
                    (mask[2] & 0x04) != 0,

                SombrasPonteiro =
                    (mask[1] & 0x20) != 0,

                RolarListasSuavemente =
                    (mask[0] & 0x08) != 0,

                SalvarMiniaturasBarraTarefas =
                    LerDword(DwmKey, "AlwaysHibernateThumbnails", 1) != 0,

                SuavizacaoFontes =
                    LerString(DesktopKey, "FontSmoothing", "2") == "2",

                SombrasRotulosDesktop =
                    LerDword(ExplorerAdvancedKey, "ListviewShadow", 1) != 0,

                Preset = "Personalizado"
            };
        }

        private void AplicarConfiguracao(ConfiguracaoEfeitos config)
        {
            byte[] mask = LerUserPreferencesMask();

            mask[0] = AlterarBit(mask[0], 0x04, config.AbrirCaixasCombinacao);
            mask[0] = AlterarBit(mask[0], 0x08, config.RolarListasSuavemente);
            mask[0] = AlterarBit(mask[0], 0x02, config.EsmaecerMenus);

            mask[1] = AlterarBit(mask[1], 0x04, config.EsmaecerItensMenu);
            mask[1] = AlterarBit(mask[1], 0x08, config.EsmaecerToolTips);
            mask[1] = AlterarBit(mask[1], 0x20, config.SombrasPonteiro);

            mask[2] = AlterarBit(mask[2], 0x04, config.SombrasJanelas);

            mask[4] = AlterarBit(mask[4], 0x02, config.AnimarControlesElementos);

            GravarUserPreferencesMask(mask);

            GravarDword(
                ExplorerAdvancedKey,
                "TaskbarAnimations",
                config.AnimacoesBarraTarefas ? 1 : 0);

            GravarString(
                WindowMetricsKey,
                "MinAnimate",
                config.AnimarJanelasMinMax ? "1" : "0");

            GravarDword(
                DwmKey,
                "EnableAeroPeek",
                config.HabilitarPeek ? 1 : 0);

            GravarString(
                DesktopKey,
                "DragFullWindows",
                config.MostrarConteudoJanelaArrastar ? "1" : "0");

            GravarDword(
                ExplorerAdvancedKey,
                "IconsOnly",
                config.MostrarMiniaturas ? 0 : 1);

            GravarDword(
                ExplorerAdvancedKey,
                "ListviewAlphaSelect",
                config.RetanguloSelecaoTranslucido ? 1 : 0);

            GravarDword(
                DwmKey,
                "AlwaysHibernateThumbnails",
                config.SalvarMiniaturasBarraTarefas ? 1 : 0);

            GravarString(
                DesktopKey,
                "FontSmoothing",
                config.SuavizacaoFontes ? "2" : "0");

            GravarDword(
                ExplorerAdvancedKey,
                "ListviewShadow",
                config.SombrasRotulosDesktop ? 1 : 0);

            // 3 = Custom / Personalizado
            GravarDword(
                ExplorerAdvancedKey,
                "VisualFXSetting",
                3);

            AplicarSystemParameters(config);

            NotificarWindows();
        }

        private void AplicarSystemParameters(ConfiguracaoEfeitos config)
        {
            DefinirBoolSystemParameter(
                SPI_SETCOMBOBOXANIMATION,
                config.AbrirCaixasCombinacao);

            DefinirBoolSystemParameter(
                SPI_SETLISTBOXSMOOTHSCROLLING,
                config.RolarListasSuavemente);

            DefinirBoolSystemParameter(
                SPI_SETMENUANIMATION,
                config.EsmaecerMenus);

            DefinirBoolSystemParameter(
                SPI_SETSELECTIONFADE,
                config.RetanguloSelecaoTranslucido);

            DefinirBoolSystemParameter(
                SPI_SETTOOLTIPANIMATION,
                config.EsmaecerToolTips);

            DefinirBoolSystemParameter(
                SPI_SETTOOLTIPFADE,
                config.EsmaecerToolTips);

            DefinirBoolSystemParameter(
                SPI_SETCURSORSHADOW,
                config.SombrasPonteiro);

            DefinirBoolSystemParameter(
                SPI_SETCLIENTAREAANIMATION,
                config.AnimarControlesElementos);

            DefinirBoolSystemParameter(
                SPI_SETUIEFFECTS,
                config.AnimarControlesElementos ||
                config.AbrirCaixasCombinacao ||
                config.EsmaecerMenus ||
                config.EsmaecerToolTips ||
                config.EsmaecerItensMenu);

            DefinirBoolSystemParameter(
                SPI_SETFONTSMOOTHING,
                config.SuavizacaoFontes);
        }

        private void DefinirBoolSystemParameter(
            uint action,
            bool valor)
        {
            IntPtr buffer = Marshal.AllocHGlobal(sizeof(int));

            try
            {
                Marshal.WriteInt32(
                    buffer,
                    valor ? 1 : 0);

                SystemParametersInfo(
                    action,
                    0,
                    buffer,
                    SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        private byte[] LerUserPreferencesMask()
        {
            using RegistryKey? key =
                Registry.CurrentUser.OpenSubKey(DesktopKey);

            if (key?.GetValue("UserPreferencesMask") is byte[] bytes &&
                bytes.Length >= 8)
            {
                return (byte[])bytes.Clone();
            }

            return new byte[]
            {
                0x9E,
                0x3E,
                0x07,
                0x80,
                0x12,
                0x00,
                0x00,
                0x00
            };
        }

        private void GravarUserPreferencesMask(byte[] mask)
        {
            using RegistryKey key =
                Registry.CurrentUser.CreateSubKey(DesktopKey);

            key.SetValue(
                "UserPreferencesMask",
                mask,
                RegistryValueKind.Binary);
        }

        private static byte AlterarBit(
            byte valor,
            byte mascara,
            bool habilitado)
        {
            if (habilitado)
            {
                return (byte)(valor | mascara);
            }

            return (byte)(valor & ~mascara);
        }

        private static int LerDword(
            string caminho,
            string nome,
            int padrao)
        {
            using RegistryKey? key =
                Registry.CurrentUser.OpenSubKey(caminho);

            object? valor = key?.GetValue(nome);

            if (valor is int inteiro)
                return inteiro;

            if (valor is long longo)
                return (int)longo;

            if (valor is string texto &&
                int.TryParse(texto, out int convertido))
            {
                return convertido;
            }

            return padrao;
        }

        private static string LerString(
            string caminho,
            string nome,
            string padrao)
        {
            using RegistryKey? key =
                Registry.CurrentUser.OpenSubKey(caminho);

            object? valor = key?.GetValue(nome);

            return valor?.ToString() ?? padrao;
        }

        private static void GravarDword(
            string caminho,
            string nome,
            int valor)
        {
            using RegistryKey key =
                Registry.CurrentUser.CreateSubKey(caminho);

            key.SetValue(
                nome,
                valor,
                RegistryValueKind.DWord);
        }

        private static void GravarString(
            string caminho,
            string nome,
            string valor)
        {
            using RegistryKey key =
                Registry.CurrentUser.CreateSubKey(caminho);

            key.SetValue(
                nome,
                valor,
                RegistryValueKind.String);
        }

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
    }
}