namespace Nuts
{
    partial class frm_dbSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.in_host = new System.Windows.Forms.TextBox();
            this.in_db = new System.Windows.Forms.TextBox();
            this.in_user = new System.Windows.Forms.TextBox();
            this.in_pass = new System.Windows.Forms.TextBox();
            this.lbl_host = new System.Windows.Forms.Label();
            this.lbl_db = new System.Windows.Forms.Label();
            this.lbl_user = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // in_host
            // 
            this.in_host.Location = new System.Drawing.Point(79, 71);
            this.in_host.Name = "in_host";
            this.in_host.Size = new System.Drawing.Size(159, 20);
            this.in_host.TabIndex = 0;
            // 
            // in_db
            // 
            this.in_db.Location = new System.Drawing.Point(79, 97);
            this.in_db.Name = "in_db";
            this.in_db.Size = new System.Drawing.Size(159, 20);
            this.in_db.TabIndex = 1;
            // 
            // in_user
            // 
            this.in_user.Location = new System.Drawing.Point(79, 123);
            this.in_user.Name = "in_user";
            this.in_user.Size = new System.Drawing.Size(159, 20);
            this.in_user.TabIndex = 2;
            // 
            // in_pass
            // 
            this.in_pass.Location = new System.Drawing.Point(79, 149);
            this.in_pass.Name = "in_pass";
            this.in_pass.Size = new System.Drawing.Size(159, 20);
            this.in_pass.TabIndex = 3;
            // 
            // lbl_host
            // 
            this.lbl_host.AutoSize = true;
            this.lbl_host.Location = new System.Drawing.Point(12, 71);
            this.lbl_host.Name = "lbl_host";
            this.lbl_host.Size = new System.Drawing.Size(61, 13);
            this.lbl_host.TabIndex = 4;
            this.lbl_host.Text = "Hostname: ";
            this.lbl_host.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_db
            // 
            this.lbl_db.AutoSize = true;
            this.lbl_db.Location = new System.Drawing.Point(14, 97);
            this.lbl_db.Name = "lbl_db";
            this.lbl_db.Size = new System.Drawing.Size(59, 13);
            this.lbl_db.TabIndex = 5;
            this.lbl_db.Text = "Database: ";
            this.lbl_db.Click += new System.EventHandler(this.lbl_db_Click);
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(12, 123);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(61, 13);
            this.lbl_user.TabIndex = 6;
            this.lbl_user.Text = "Username: ";
            this.lbl_user.Click += new System.EventHandler(this.lbl_user_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Initialize Database";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Please provide database credentials.";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // frm_dbSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 219);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_user);
            this.Controls.Add(this.lbl_db);
            this.Controls.Add(this.lbl_host);
            this.Controls.Add(this.in_pass);
            this.Controls.Add(this.in_user);
            this.Controls.Add(this.in_db);
            this.Controls.Add(this.in_host);
            this.Name = "frm_dbSetup";
            this.Text = "Nuts Database Setup";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox in_host;
        private System.Windows.Forms.TextBox in_db;
        private System.Windows.Forms.TextBox in_user;
        private System.Windows.Forms.TextBox in_pass;
        private System.Windows.Forms.Label lbl_host;
        private System.Windows.Forms.Label lbl_db;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

