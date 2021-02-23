/*
 * Enterprise Analysis
 * Programa desarrollado por Juan David Rosero Torres para la materia de Redes 1 de la Universidad Distrital Francisco Jose de caldas
 */

using EnterpriseAnalisys.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnterpriseAnalisys
{
    static class Program
    {
        /// <summary>
        ///  Metodo main del programa
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PreForm form = new PreForm();
            form.Show();
            Application.Run();
        }
    }
}
