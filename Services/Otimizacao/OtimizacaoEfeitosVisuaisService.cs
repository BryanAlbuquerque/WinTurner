using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Text;
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

        private const string VisualEffectsKey =
            @"Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects";

        private const string DwmKey =
            @"Software\Microsoft\Windows\DWM";

        private const uint SPIF_UPDATEINIFILE = 0x0001;
        private const uint SPIF_SENDCHANGE = 0x0002;

        private const uint SPI_SETCOMBOBOXANIMATION = 0x1005;
        private const uint SPI_SETLISTBOXSMOOTHSCROLLING = 0x1007;
        private const uint SPI_SETMENUANIMATION = 0x1003;
        private const uint SPI_SETTOOLTIPANIMATION = 0x1017;
        private const uint SPI_SETTOOLTIPFADE = 0x1019;
        private const uint SPI_SETCURSORSHADOW = 0x101B;
        private const uint SPI_SETUIEFFECTS = 0x103F;
        private const uint SPI_SETCLIENTAREAANIMATION = 0x1043;

        private const uint SPI_SETFONTSMOOTHING = 0x004B;
        private const uint SPI_SETFONTSMOOTHINGTYPE = 0x200B;

        private const int FE_FONTSMOOTHINGSTANDARD = 0x0001;
        private const int FE_FONTSMOOTHINGCLEARTYPE = 0x0002;

        private const uint HWND_BROADCAST = 0xFFFF;
        private const uint WM_SETTINGCHANGE = 0x001A;
        private const uint WM_THEMECHANGED = 0x031A;
        private const uint SMTO_ABORTIFHUNG = 0x0002;

        private const uint SHCNE_ASSOCCHANGED = 0x08000000;
        private const uint SHCNF_IDLIST = 0x0000;

        /*
         * Máscara de fallback caso UserPreferencesMask
         * não exista no registro.
         *
         * Ela NÃO é utilizada para substituir a máscara
         * existente quando o Windows já possui uma.
         */
        private static readonly byte[] MascaraFallback =
        {
            0x90,
            0x12,
            0x01,
            0x80,
            0x10,
            0x00,
            0x00,
            0x00
        };

        [DllImport(
            "user32.dll",
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        private static extern bool SystemParametersInfo(
            uint uiAction,
            uint uiParam,
            IntPtr pvParam,
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

            /*
             * 0 = Windows decide
             * 1 = Melhor aparência
             * 2 = Melhor desempenho
             * 3 = Personalizado
             */
            public int ModoVisualFX { get; set; } = 3;
        }

        public class ResultadoEfeitos
        {
            public bool Sucesso { get; set; }

            public string Mensagem { get; set; } = string.Empty;
        }

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

                    /*
                     * Dá tempo para o Windows processar
                     * as notificações e atualizar o registro.
                     */
                    System.Threading.Thread.Sleep(200);

                    ConfiguracaoEfeitos confirmacao =
                        LerConfiguracao();

                    if (ConfiguracaoIgual(
                        configuracao,
                        confirmacao))
                    {
                        return new ResultadoEfeitos
                        {
                            Sucesso = true,
                            Mensagem =
                                "Efeitos visuais aplicados e confirmados com sucesso."
                        };
                    }

                    return new ResultadoEfeitos
                    {
                        Sucesso = false,
                        Mensagem =
                            "O Windows aplicou as configurações, mas algumas opções não retornaram o estado solicitado durante a confirmação.\n\n" +
                            ObterDiferencas(
                                configuracao,
                                confirmacao)
                    };
                }
                catch (Exception ex)
                {
                    return new ResultadoEfeitos
                    {
                        Sucesso = false,
                        Mensagem =
                            $"Erro ao aplicar efeitos visuais:\n\n{ex.Message}"
                    };
                }
            });
        }

        public async Task<ResultadoEfeitos> AplicarPresetAsync(
            string preset)
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
                    return await AplicarConfiguracaoAsync(
                        CriarMelhorDesempenho());

                case "Equilibrado":
                    return await AplicarConfiguracaoAsync(
                        CriarEquilibrado());

                case "Melhor aparência":
                    return await AplicarConfiguracaoAsync(
                        CriarMelhorAparencia());

                case "Padrão do Windows":
                    return await RestaurarPadraoWindowsAsync();

                default:
                    return new ResultadoEfeitos
                    {
                        Sucesso = false,
                        Mensagem =
                            $"Preset desconhecido: {preset}"
                    };
            }
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
                SuavizacaoFontes = true,
                SombrasRotulosDesktop = false,
                Preset = "Melhor desempenho",
                ModoVisualFX = 3
            };
        }

        private ConfiguracaoEfeitos CriarEquilibrado()
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
                HabilitarPeek = true,
                MostrarConteudoJanelaArrastar = true,
                MostrarMiniaturas = true,
                RetanguloSelecaoTranslucido = false,
                SombrasJanelas = true,
                SombrasPonteiro = false,
                RolarListasSuavemente = false,
                SalvarMiniaturasBarraTarefas = true,
                SuavizacaoFontes = true,
                SombrasRotulosDesktop = true,
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

        private async Task<ResultadoEfeitos>
            RestaurarPadraoWindowsAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    /*
                     * 0 = deixar o Windows decidir
                     * quais efeitos devem ser utilizados.
                     */
                    GravarDword(
                        VisualEffectsKey,
                        "VisualFXSetting",
                        0);

                    NotificarWindows();

                    System.Threading.Thread.Sleep(200);

                    return new ResultadoEfeitos
                    {
                        Sucesso = true,
                        Mensagem =
                            "O controle dos efeitos visuais foi devolvido ao Windows."
                    };
                }
                catch (Exception ex)
                {
                    return new ResultadoEfeitos
                    {
                        Sucesso = false,
                        Mensagem =
                            $"Erro ao restaurar o padrão do Windows:\n\n{ex.Message}"
                    };
                }
            });
        }

        private ConfiguracaoEfeitos LerConfiguracao()
        {
            byte[] mask =
                LerUserPreferencesMask();

            int modo =
                LerDword(
                    VisualEffectsKey,
                    "VisualFXSetting",
                    3);

            var configuracao =
                new ConfiguracaoEfeitos
                {
                    AbrirCaixasCombinacao =
                        (mask[0] & 0x04) != 0,

                    AnimacoesBarraTarefas =
                        LerDword(
                            ExplorerAdvancedKey,
                            "TaskbarAnimations",
                            1) != 0,

                    AnimarControlesElementos =
                        (mask[4] & 0x02) != 0,

                    AnimarJanelasMinMax =
                        LerString(
                            WindowMetricsKey,
                            "MinAnimate",
                            "1") == "1",

                    EsmaecerItensMenu =
                        (mask[1] & 0x04) != 0,

                    EsmaecerToolTips =
                        (mask[1] & 0x08) != 0,

                    EsmaecerMenus =
                        (mask[0] & 0x02) != 0,

                    HabilitarPeek =
                        LerDword(
                            DwmKey,
                            "EnableAeroPeek",
                            1) != 0,

                    MostrarConteudoJanelaArrastar =
                        LerString(
                            DesktopKey,
                            "DragFullWindows",
                            "1") == "1",

                    MostrarMiniaturas =
                        LerDword(
                            ExplorerAdvancedKey,
                            "IconsOnly",
                            0) == 0,

                    RetanguloSelecaoTranslucido =
                        LerDword(
                            ExplorerAdvancedKey,
                            "ListviewAlphaSelect",
                            1) != 0,

                    SombrasJanelas =
                        (mask[2] & 0x04) != 0,

                    SombrasPonteiro =
                        (mask[1] & 0x20) != 0,

                    RolarListasSuavemente =
                        (mask[0] & 0x08) != 0,

                    SalvarMiniaturasBarraTarefas =
                        LerDword(
                            DwmKey,
                            "AlwaysHibernateThumbnails",
                            1) != 0,

                    SuavizacaoFontes =
                        LerString(
                            DesktopKey,
                            "FontSmoothing",
                            "2") == "2",

                    SombrasRotulosDesktop =
                        LerDword(
                            ExplorerAdvancedKey,
                            "ListviewShadow",
                            1) != 0,

                    ModoVisualFX = modo
                };

            configuracao.Preset =
                DetectarPreset(configuracao);

            return configuracao;
        }

        private string DetectarPreset(
            ConfiguracaoEfeitos config)
        {
            if (config.ModoVisualFX == 0)
                return "Padrão do Windows";

            if (ConfiguracaoIgual(
                config,
                CriarMelhorDesempenho()))
            {
                return "Melhor desempenho";
            }

            if (ConfiguracaoIgual(
                config,
                CriarEquilibrado()))
            {
                return "Equilibrado";
            }

            if (ConfiguracaoIgual(
                config,
                CriarMelhorAparencia()))
            {
                return "Melhor aparência";
            }

            return "Personalizado";
        }

        private static bool ConfiguracaoIgual(
            ConfiguracaoEfeitos atual,
            ConfiguracaoEfeitos esperado)
        {
            return
                atual.AbrirCaixasCombinacao ==
                esperado.AbrirCaixasCombinacao &&

                atual.AnimacoesBarraTarefas ==
                esperado.AnimacoesBarraTarefas &&

                atual.AnimarControlesElementos ==
                esperado.AnimarControlesElementos &&

                atual.AnimarJanelasMinMax ==
                esperado.AnimarJanelasMinMax &&

                atual.EsmaecerItensMenu ==
                esperado.EsmaecerItensMenu &&

                atual.EsmaecerToolTips ==
                esperado.EsmaecerToolTips &&

                atual.EsmaecerMenus ==
                esperado.EsmaecerMenus &&

                atual.HabilitarPeek ==
                esperado.HabilitarPeek &&

                atual.MostrarConteudoJanelaArrastar ==
                esperado.MostrarConteudoJanelaArrastar &&

                atual.MostrarMiniaturas ==
                esperado.MostrarMiniaturas &&

                atual.RetanguloSelecaoTranslucido ==
                esperado.RetanguloSelecaoTranslucido &&

                atual.SombrasJanelas ==
                esperado.SombrasJanelas &&

                atual.SombrasPonteiro ==
                esperado.SombrasPonteiro &&

                atual.RolarListasSuavemente ==
                esperado.RolarListasSuavemente &&

                atual.SalvarMiniaturasBarraTarefas ==
                esperado.SalvarMiniaturasBarraTarefas &&

                atual.SuavizacaoFontes ==
                esperado.SuavizacaoFontes &&

                atual.SombrasRotulosDesktop ==
                esperado.SombrasRotulosDesktop;
        }

        private void AplicarConfiguracao(
            ConfiguracaoEfeitos config)
        {
            /*
             * Como o WinTuner controla individualmente
             * os efeitos, o modo final é personalizado.
             */
            GravarDword(
                VisualEffectsKey,
                "VisualFXSetting",
                3);

            /*
             * Configurações independentes.
             */
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
                config.MostrarConteudoJanelaArrastar
                    ? "1"
                    : "0");

            GravarDword(
                ExplorerAdvancedKey,
                "IconsOnly",
                config.MostrarMiniaturas ? 0 : 1);

            GravarDword(
                ExplorerAdvancedKey,
                "ListviewAlphaSelect",
                config.RetanguloSelecaoTranslucido
                    ? 1
                    : 0);

            GravarDword(
                DwmKey,
                "AlwaysHibernateThumbnails",
                config.SalvarMiniaturasBarraTarefas
                    ? 1
                    : 0);

            GravarDword(
                ExplorerAdvancedKey,
                "ListviewShadow",
                config.SombrasRotulosDesktop
                    ? 1
                    : 0);

            /*
             * Suavização das fontes.
             */
            GravarString(
                DesktopKey,
                "FontSmoothing",
                config.SuavizacaoFontes
                    ? "2"
                    : "0");

            /*
             * Parâmetros do User32.
             */
            AplicarSystemParameters(config);

            /*
             * UserPreferencesMask é aplicado depois
             * dos parâmetros individuais.
             */
            byte[] mask =
                CriarMascara(config);

            GravarUserPreferencesMask(mask);

            /*
             * Reforça a suavização depois da máscara.
             */
            AplicarSuavizacaoFonte(
                config.SuavizacaoFontes);

            /*
             * Notificação geral.
             */
            NotificarWindows();
        }

        private byte[] CriarMascara(
            ConfiguracaoEfeitos config)
        {
            /*
             * Importante:
             *
             * Começamos com a máscara atual.
             * Assim preservamos bits que não pertencem
             * aos controles do WinTuner.
             */
            byte[] mask =
                LerUserPreferencesMask();

            /*
             * Byte 0.
             */
            mask[0] =
                AlterarBit(
                    mask[0],
                    0x04,
                    config.AbrirCaixasCombinacao);

            mask[0] =
                AlterarBit(
                    mask[0],
                    0x08,
                    config.RolarListasSuavemente);

            mask[0] =
                AlterarBit(
                    mask[0],
                    0x02,
                    config.EsmaecerMenus);

            /*
             * Byte 1.
             */
            mask[1] =
                AlterarBit(
                    mask[1],
                    0x04,
                    config.EsmaecerItensMenu);

            mask[1] =
                AlterarBit(
                    mask[1],
                    0x08,
                    config.EsmaecerToolTips);

            mask[1] =
                AlterarBit(
                    mask[1],
                    0x20,
                    config.SombrasPonteiro);

            /*
             * Byte 2.
             */
            mask[2] =
                AlterarBit(
                    mask[2],
                    0x04,
                    config.SombrasJanelas);

            /*
             * Byte 4.
             */
            mask[4] =
                AlterarBit(
                    mask[4],
                    0x02,
                    config.AnimarControlesElementos);

            return mask;
        }

        private void AplicarSystemParameters(
    ConfiguracaoEfeitos config)
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
        }

        private void AplicarSuavizacaoFonte(bool habilitada)
        {
            /*
             * SPI_SETFONTSMOOTHING:
             *
             * O Windows espera TRUE/FALSE diretamente em uiParam.
             * pvParam deve ser NULL.
             */
            bool resultado =
                SystemParametersInfo(
                    SPI_SETFONTSMOOTHING,
                    habilitada ? 1u : 0u,
                    IntPtr.Zero,
                    SPIF_UPDATEINIFILE |
                    SPIF_SENDCHANGE);

            if (!resultado)
            {
                int erro =
                    Marshal.GetLastWin32Error();

                throw new InvalidOperationException(
                    $"Não foi possível configurar a suavização das fontes. " +
                    $"Código Win32: {erro}.");
            }

            /*
             * SPI_SETFONTSMOOTHINGTYPE:
             *
             * O Windows espera o valor do tipo diretamente
             * em pvParam:
             *
             * 1 = suavização padrão
             * 2 = ClearType
             *
             */
            uint tipo =
                habilitada
                    ? (uint)FE_FONTSMOOTHINGCLEARTYPE
                    : (uint)FE_FONTSMOOTHINGSTANDARD;

            resultado =
                SystemParametersInfo(
                    SPI_SETFONTSMOOTHINGTYPE,
                    0,
                    new IntPtr(tipo),
                    SPIF_UPDATEINIFILE |
                    SPIF_SENDCHANGE);

            if (!resultado)
            {
                int erro =
                    Marshal.GetLastWin32Error();

                throw new InvalidOperationException(
                    $"Não foi possível configurar o tipo de suavização das fontes. " +
                    $"Código Win32: {erro}.");
            }
        }

        private void DefinirBoolSystemParameter(
            uint action,
            bool valor)
        {
            IntPtr buffer =
                Marshal.AllocHGlobal(sizeof(int));

            try
            {
                Marshal.WriteInt32(
                    buffer,
                    valor ? 1 : 0);

                bool sucesso =
                    SystemParametersInfo(
                        action,
                        0,
                        buffer,
                        SPIF_UPDATEINIFILE |
                        SPIF_SENDCHANGE);

                if (!sucesso)
                {
                    int erro =
                        Marshal.GetLastWin32Error();

                    throw new InvalidOperationException(
                        $"Não foi possível atualizar um parâmetro visual do Windows. Código Win32: {erro}.");
                }
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }


        private byte[] LerUserPreferencesMask()
        {
            using RegistryKey? key =
                Registry.CurrentUser.OpenSubKey(
                    DesktopKey);

            if (key?.GetValue(
                    "UserPreferencesMask") is byte[] bytes &&
                bytes.Length >= 8)
            {
                byte[] resultado =
                    new byte[8];

                Array.Copy(
                    bytes,
                    resultado,
                    8);

                return resultado;
            }

            return (byte[])MascaraFallback.Clone();
        }

        private void GravarUserPreferencesMask(
            byte[] mask)
        {
            if (mask == null ||
                mask.Length < 8)
            {
                throw new ArgumentException(
                    "A UserPreferencesMask precisa possuir pelo menos 8 bytes.");
            }

            using RegistryKey key =
                Registry.CurrentUser.CreateSubKey(
                    DesktopKey);

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
                return (byte)(
                    valor |
                    mascara);
            }

            return (byte)(
                valor &
                ~mascara);
        }

        private static int LerDword(
            string caminho,
            string nome,
            int padrao)
        {
            using RegistryKey? key =
                Registry.CurrentUser.OpenSubKey(
                    caminho);

            object? valor =
                key?.GetValue(nome);

            if (valor is int inteiro)
                return inteiro;

            if (valor is long longo)
                return (int)longo;

            if (valor is string texto &&
                int.TryParse(
                    texto,
                    out int convertido))
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
                Registry.CurrentUser.OpenSubKey(
                    caminho);

            object? valor =
                key?.GetValue(nome);

            return valor?.ToString() ?? padrao;
        }

        private static void GravarDword(
            string caminho,
            string nome,
            int valor)
        {
            using RegistryKey key =
                Registry.CurrentUser.CreateSubKey(
                    caminho);

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
                Registry.CurrentUser.CreateSubKey(
                    caminho);

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

        private static string ObterDiferencas(
            ConfiguracaoEfeitos esperado,
            ConfiguracaoEfeitos atual)
        {
            var diferencas =
                new StringBuilder();

            Comparar(
                diferencas,
                "Abrir caixas de combinação",
                esperado.AbrirCaixasCombinacao,
                atual.AbrirCaixasCombinacao);

            Comparar(
                diferencas,
                "Animações da barra de tarefas",
                esperado.AnimacoesBarraTarefas,
                atual.AnimacoesBarraTarefas);

            Comparar(
                diferencas,
                "Animar controles e elementos",
                esperado.AnimarControlesElementos,
                atual.AnimarControlesElementos);

            Comparar(
                diferencas,
                "Animar janelas",
                esperado.AnimarJanelasMinMax,
                atual.AnimarJanelasMinMax);

            Comparar(
                diferencas,
                "Esmaecer itens de menu",
                esperado.EsmaecerItensMenu,
                atual.EsmaecerItensMenu);

            Comparar(
                diferencas,
                "Esmaecer ToolTips",
                esperado.EsmaecerToolTips,
                atual.EsmaecerToolTips);

            Comparar(
                diferencas,
                "Esmaecer menus",
                esperado.EsmaecerMenus,
                atual.EsmaecerMenus);

            Comparar(
                diferencas,
                "Peek",
                esperado.HabilitarPeek,
                atual.HabilitarPeek);

            Comparar(
                diferencas,
                "Conteúdo ao arrastar",
                esperado.MostrarConteudoJanelaArrastar,
                atual.MostrarConteudoJanelaArrastar);

            Comparar(
                diferencas,
                "Miniaturas",
                esperado.MostrarMiniaturas,
                atual.MostrarMiniaturas);

            Comparar(
                diferencas,
                "Retângulo de seleção",
                esperado.RetanguloSelecaoTranslucido,
                atual.RetanguloSelecaoTranslucido);

            Comparar(
                diferencas,
                "Sombras das janelas",
                esperado.SombrasJanelas,
                atual.SombrasJanelas);

            Comparar(
                diferencas,
                "Sombras do ponteiro",
                esperado.SombrasPonteiro,
                atual.SombrasPonteiro);

            Comparar(
                diferencas,
                "Rolagem suave",
                esperado.RolarListasSuavemente,
                atual.RolarListasSuavemente);

            Comparar(
                diferencas,
                "Salvar miniaturas",
                esperado.SalvarMiniaturasBarraTarefas,
                atual.SalvarMiniaturasBarraTarefas);

            Comparar(
                diferencas,
                "Suavização das fontes",
                esperado.SuavizacaoFontes,
                atual.SuavizacaoFontes);

            Comparar(
                diferencas,
                "Sombras dos rótulos",
                esperado.SombrasRotulosDesktop,
                atual.SombrasRotulosDesktop);

            if (diferencas.Length == 0)
            {
                diferencas.Append(
                    "A configuração VisualFXSetting foi alterada pelo Windows durante a confirmação.");
            }

            return diferencas.ToString();
        }

        private static void Comparar(
            StringBuilder builder,
            string nome,
            bool esperado,
            bool atual)
        {
            if (esperado == atual)
                return;

            builder.AppendLine(
                $"• {nome}: esperado {(esperado ? "ativado" : "desativado")}, " +
                $"retornado {(atual ? "ativado" : "desativado")}.");
        }
    }
}