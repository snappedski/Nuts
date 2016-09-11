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
    public partial class frm_dbSetup : Form
    {
        public frm_dbSetup()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_user_Click(object sender, EventArgs e)
        {

        }

        private void lbl_db_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e){
            /////////////////// Validation ///////////////////////////////
            Boolean v = true;
            if (in_host.Text == "") { v = inputCheck.noInfo(v, "Hostname"); }
            if (in_db.Text == "") { v = inputCheck.noInfo(v, "Database"); }
            if (in_user.Text == "") { v = inputCheck.noInfo(v, "Username"); }
            if (in_pass.Text == "") { v = inputCheck.noInfo(v, "Password"); }

            if (v == true) { // Continue below if all valid //////////////
                string r = db_setup.db_initialize();
                if (r == null) { inputCheck.msgBox(r, "Cannot Initialize");
                } else { //db setup successful
                    frm_login form = new frm_login();
                    //form.Text = "test";
                    form.Show();
                    Application.Run();
                }
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void pic_dbSetup_Click(object sender, EventArgs e)
        {

        }
    }
}
