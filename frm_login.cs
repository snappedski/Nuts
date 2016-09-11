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
            if (in_user.Text == "") { v = inputCheck.noInfo(v, "Username"); }
            if (in_pass.Text == "") { v = inputCheck.noInfo(v, "Password"); }

            if (v == true)
            { // Continue below if all valid //////////////
                //CONNECT WITH ACCOUNT
                //LOAD APPLICATION MAIN WINDOW
            }
        }

        private void lbl_Pass_Click(object sender, EventArgs e)
        {

        }
    }
}
