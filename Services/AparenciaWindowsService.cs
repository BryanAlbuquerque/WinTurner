using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinTuner.Services
{
    public static class AparenciaWindowsService
    {
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const int DWMWA_CAPTION_COLOR = 35;
        private const int DWMWA_TEXT_COLOR = 36;

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(
            IntPtr hwnd,
            int dwAttribute,
            ref int pvAttribute,
            int cbAttribute
        );

        public static void AplicarBarraEscura(Form form)
        {
            if (form == null)
                return;

            form.HandleCreated += (_, _) =>
            {
                Aplicar(form);
            };

            if (form.IsHandleCreated)
                Aplicar(form);
        }

        private static void Aplicar(Form form)
        {
            try
            {
                // Ativa o modo escuro da barra
                int darkMode = 1;

                DwmSetWindowAttribute(
                    form.Handle,
                    DWMWA_USE_IMMERSIVE_DARK_MODE,
                    ref darkMode,
                    sizeof(int)
                );

                // Cor da barra superior
                int captionColor = ColorTranslator.ToWin32(
                    Color.FromArgb(5, 5, 5)
                );

                DwmSetWindowAttribute(
                    form.Handle,
                    DWMWA_CAPTION_COLOR,
                    ref captionColor,
                    sizeof(int)
                );

                // Cor dos textos da barra
                int textColor = ColorTranslator.ToWin32(
                    Color.FromArgb(242, 242, 242)
                );

                DwmSetWindowAttribute(
                    form.Handle,
                    DWMWA_TEXT_COLOR,
                    ref textColor,
                    sizeof(int)
                );
            }
            catch
            {
                // Alguns ambientes/versões do Windows podem não suportar
                // todos os atributos do DWM.
            }
        }
    }
}