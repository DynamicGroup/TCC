using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DynamicAgente
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{db00dc5b-77d2-4cad-aa20-faefaa542a35}");
        [STAThread]
        static void Main()
        {
            if (!mutex.WaitOne(5000, true))
            {
                MessageBox.Show("A aplicação já está em execução", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Principal());
        }
    }
}
