using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nuts
{
    class inputCheck{
        public static void msgBox(string msg, string title){
            if (msg != null){
                Console.WriteLine("- ERROR: " + msg.ToString());
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static Boolean noInfo(Boolean v, string fieldName){ //If no information is provided
            if (v == true) { msgBox("The " + fieldName + " field does not contain any information.", "Invalid Information");
                v = false;
            }
            return v;
        }
    }
}
