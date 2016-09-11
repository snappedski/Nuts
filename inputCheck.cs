using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nuts
{
    class inputCheck{

        public static Boolean noInfo(Boolean v, string fieldName){ //If no information is provided
            if (v == true) { hj_tools.msgBox("The " + fieldName + " field does not contain any information.", "Invalid Information", "ERROR", true);
                v = false;
            }
            return v;
        }
    }
}
