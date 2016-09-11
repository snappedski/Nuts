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
            if (!File.Exists(nuts_session.config_path)){ //If config file does not exists
                Application.Run(new frm_dbSetup()); //Load Database Setup
            } else { Application.Run(new frm_login()); } //Else Load Login
        }
    }
}
