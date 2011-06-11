namespace IBGames
{
    partial class RegistrationForm
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
            this.btnRegistrationOK = new System.Windows.Forms.Button();
            this.lblL1 = new System.Windows.Forms.Label();
            this.lnkCancel = new System.Windows.Forms.LinkLabel();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.cbIsStudent = new System.Windows.Forms.CheckBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblIsStudent = new System.Windows.Forms.Label();
            this.tbPasswordAgain = new System.Windows.Forms.TextBox();
            this.lblPasswordAgain = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegistrationOK
            // 
            this.btnRegistrationOK.Location = new System.Drawing.Point(143, 256);
            this.btnRegistrationOK.Name = "btnRegistrationOK";
            this.btnRegistrationOK.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrationOK.TabIndex = 0;
            this.btnRegistrationOK.Text = "OK";
            this.btnRegistrationOK.UseVisualStyleBackColor = true;
            this.btnRegistrationOK.Click += new System.EventHandler(this.btnRegistrationOK_Click);
            // 
            // lblL1
            // 
            this.lblL1.Location = new System.Drawing.Point(224, 261);
            this.lblL1.Name = "lblL1";
            this.lblL1.Size = new System.Drawing.Size(21, 13);
            this.lblL1.TabIndex = 1;
            this.lblL1.Text = "or";
            // 
            // lnkCancel
            // 
            this.lnkCancel.AutoSize = true;
            this.lnkCancel.Location = new System.Drawing.Point(240, 261);
            this.lnkCancel.Name = "lnkCancel";
            this.lnkCancel.Size = new System.Drawing.Size(40, 13);
            this.lnkCancel.TabIndex = 2;
            this.lnkCancel.TabStop = true;
            this.lnkCancel.Text = "Cancel";
            this.lnkCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCancel_LinkClicked);
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(109, 146);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(163, 20);
            this.tbLogin.TabIndex = 3;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(109, 172);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(163, 20);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // cbIsStudent
            // 
            this.cbIsStudent.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbIsStudent.Checked = true;
            this.cbIsStudent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsStudent.Location = new System.Drawing.Point(256, 224);
            this.cbIsStudent.Name = "cbIsStudent";
            this.cbIsStudent.Size = new System.Drawing.Size(16, 24);
            this.cbIsStudent.TabIndex = 5;
            this.cbIsStudent.UseVisualStyleBackColor = true;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(12, 146);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(36, 13);
            this.lblLogin.TabIndex = 6;
            this.lblLogin.Text = "Login:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 175);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password:";
            // 
            // lblIsStudent
            // 
            this.lblIsStudent.AutoSize = true;
            this.lblIsStudent.Location = new System.Drawing.Point(12, 229);
            this.lblIsStudent.Name = "lblIsStudent";
            this.lblIsStudent.Size = new System.Drawing.Size(96, 13);
            this.lblIsStudent.TabIndex = 8;
            this.lblIsStudent.Text = "Are you a student?";
            // 
            // tbPasswordAgain
            // 
            this.tbPasswordAgain.Location = new System.Drawing.Point(109, 198);
            this.tbPasswordAgain.Name = "tbPasswordAgain";
            this.tbPasswordAgain.Size = new System.Drawing.Size(163, 20);
            this.tbPasswordAgain.TabIndex = 9;
            this.tbPasswordAgain.UseSystemPasswordChar = true;
            // 
            // lblPasswordAgain
            // 
            this.lblPasswordAgain.AutoSize = true;
            this.lblPasswordAgain.Location = new System.Drawing.Point(12, 201);
            this.lblPasswordAgain.Name = "lblPasswordAgain";
            this.lblPasswordAgain.Size = new System.Drawing.Size(89, 13);
            this.lblPasswordAgain.TabIndex = 10;
            this.lblPasswordAgain.Text = "Password check:";
            // 
            // Logo
            // 
            this.Logo.Image = global::IBGames.Properties.Resources.IBLogo;
            this.Logo.Location = new System.Drawing.Point(119, 12);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(132, 128);
            this.Logo.TabIndex = 11;
            this.Logo.TabStop = false;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.lnkCancel;
            this.ClientSize = new System.Drawing.Size(284, 292);
            this.ControlBox = false;
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.lblPasswordAgain);
            this.Controls.Add(this.tbPasswordAgain);
            this.Controls.Add(this.lblIsStudent);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.cbIsStudent);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.lnkCancel);
            this.Controls.Add(this.lblL1);
            this.Controls.Add(this.btnRegistrationOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrationForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration for IBGames";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegistrationOK;
        private System.Windows.Forms.Label lblL1;
        private System.Windows.Forms.LinkLabel lnkCancel;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.CheckBox cbIsStudent;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblIsStudent;
        private System.Windows.Forms.TextBox tbPasswordAgain;
        private System.Windows.Forms.Label lblPasswordAgain;
        private System.Windows.Forms.PictureBox Logo;
    }
}