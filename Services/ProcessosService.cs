using System.Diagnostics;
using WinTurner.Models;

namespace WinTurner.Services
{
    public class ProcessosService
    {
        public List<ProcessoInfo> ObterAplicativos()
        {
            var processos = new List<ProcessoInfo>();

            foreach (Process processo in Process.GetProcesses())
            {
                try
                {
                    // Ignora processos sem janela principal.
                    if (processo.MainWindowHandle == IntPtr.Zero)
                        continue;

                    // Ignora processos que não possuem título de janela.
                    if (string.IsNullOrWhiteSpace(processo.MainWindowTitle))
                        continue;

                    double memoriaMB = processo.WorkingSet64 / 1024.0 / 1024.0;

                    processos.Add(new ProcessoInfo
                    {
                        Nome = processo.ProcessName,
                        Id = processo.Id,
                        Janela = processo.MainWindowTitle,
                        MemoriaMB = Math.Round(memoriaMB, 1)
                    });
                }
                catch
                {

                }
                finally
                {
                    processo.Dispose();
                }
            }

            return processos
                .OrderByDescending(x => x.MemoriaMB)
                .ToList();
        }
    }
}