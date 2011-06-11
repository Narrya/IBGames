using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IBGames.Business;
using IBGames.View;

namespace IBGames
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string password = tbPassword.Text;
            string username = tbUsername.Text;

            if (!string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(username))
            {
                UserAuthentication access = new UserAuthentication();

                if (!access.Authenticate(username, password))
                {
                    MessageBox.Show("Invalid username or password", "Login Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (access.IsStudent(username))
                    {
                        GameChooseDialog chooser = new GameChooseDialog(username);
                        chooser.ShowDialog(this);
                    }
                    else if (access.IsAdmin(username))
                    {
                        AdminForm administrationModule = new AdminForm(username);
                        administrationModule.ShowDialog(this);
                    }
                    else
                    {
                        OperatorForm operatorModule = new OperatorForm(username);
                        operatorModule.ShowDialog(this);
                    }
                }
            }
            else
            {
                MessageBox.Show("Username or password shouldn't be empty", "Login Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Logowanie podłączone pod ENTER.
            if (e.KeyChar == 13)
            {
                btnLogin_Click(btnLogin, e);
            }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm form = new RegistrationForm();

            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                // Rejestracja zakończona.
                MessageBox.Show("Registration accomplished", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
        }
    }
}