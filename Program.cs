using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nuts
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!File.Exists(@"C:\Program Files\HandyJobs\Nuts\nuts.config")){
                Application.Run(new frm_dbSetup());
            } else { Application.Run(new frm_login()); }
        }
    }
}
