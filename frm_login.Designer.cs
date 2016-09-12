namespace Nuts
{
    partial class frm_login
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
            this.in_user = new System.Windows.Forms.TextBox();
            this.in_pass = new System.Windows.Forms.TextBox();
            this.lbl_user = new System.Windows.Forms.Label();
            this.lbl_Pass = new System.Windows.Forms.Label();
            this.lbl_instructions = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.pic_login = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_login)).BeginInit();
            this.SuspendLayout();
            // 
            // in_user
            // 
            this.in_user.Location = new System.Drawing.Point(200, 32);
            this.in_user.Name = "in_user";
            this.in_user.Size = new System.Drawing.Size(100, 20);
            this.in_user.TabIndex = 0;
            this.in_user.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // in_pass
            // 
            this.in_pass.Location = new System.Drawing.Point(200, 58);
            this.in_pass.Name = "in_pass";
            this.in_pass.PasswordChar = '•';
            this.in_pass.Size = new System.Drawing.Size(100, 20);
            this.in_pass.TabIndex = 1;
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(133, 32);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(61, 13);
            this.lbl_user.TabIndex = 2;
            this.lbl_user.Text = "Username: ";
            this.lbl_user.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_Pass
            // 
            this.lbl_Pass.AutoSize = true;
            this.lbl_Pass.Location = new System.Drawing.Point(135, 61);
            this.lbl_Pass.Name = "lbl_Pass";
            this.lbl_Pass.Size = new System.Drawing.Size(59, 13);
            this.lbl_Pass.TabIndex = 3;
            this.lbl_Pass.Text = "Password: ";
            this.lbl_Pass.Click += new System.EventHandler(this.lbl_Pass_Click);
            // 
            // lbl_instructions
            // 
            this.lbl_instructions.AutoSize = true;
            this.lbl_instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_instructions.Location = new System.Drawing.Point(222, 9);
            this.lbl_instructions.Name = "lbl_instructions";
            this.lbl_instructions.Size = new System.Drawing.Size(84, 13);
            this.lbl_instructions.TabIndex = 4;
            this.lbl_instructions.Text = "Please Login.";
            this.lbl_instructions.Click += new System.EventHandler(this.label3_Click);
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(225, 84);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 5;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.button1_Click);
            // 
            // pic_login
            // 
            this.pic_login.Image = global::Nuts.Properties.Resources._1273444902643;
            this.pic_login.Location = new System.Drawing.Point(12, 12);
            this.pic_login.Name = "pic_login";
            this.pic_login.Size = new System.Drawing.Size(100, 92);
            this.pic_login.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_login.TabIndex = 6;
            this.pic_login.TabStop = false;
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 116);
            this.Controls.Add(this.pic_login);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.lbl_instructions);
            this.Controls.Add(this.lbl_Pass);
            this.Controls.Add(this.lbl_user);
            this.Controls.Add(this.in_pass);
            this.Controls.Add(this.in_user);
            this.Name = "frm_login";
            this.Text = "Nuts - Login";
            this.Load += new System.EventHandler(this.frm_login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_login)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox in_user;
        private System.Windows.Forms.TextBox in_pass;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.Label lbl_Pass;
        private System.Windows.Forms.Label lbl_instructions;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.PictureBox pic_login;
    }
}