using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nuts
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void frm_login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /////////////////// Validation ///////////////////////////////
            Boolean v = true;
            string user = in_user.Text; string pass = in_pass.Text;
            if (user == "") { v = inputCheck.noInfo(v, "Username"); }
            if (pass == "") { v = inputCheck.noInfo(v, "Password"); }

            if (v == true)
            { // Continue below if all valid //////////////
                string hash = hj_tools.ext_hash_sha1(user,pass);
                string[] conditions = {"username", "password"};
                string[] values = { user,hash};
                string[] r = db.db_select("hj_users", db_setup.columns_hj_users, conditions, values);
                if (r.Length > 0){
                    //LOAD MAIN APPLICATION WINDOW
                } else {
                    hj_tools.msgBox("Failed Login. Please check your credentials and try again.", "Failed Login!", "EXCLAMATION", true);
                }
            }
        }

        private void lbl_Pass_Click(object sender, EventArgs e)
        {

        }
    }
}
