using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IBGames.Business;

namespace IBGames
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegistrationOK_Click(object sender, EventArgs e)
        {
            // Zabezpieczenie przed pustym hasłem.
            if (string.IsNullOrWhiteSpace(tbPassword.Text) && string.IsNullOrWhiteSpace(tbPasswordAgain.Text))
            {
                MessageBox.Show("Password shouldn't be empty", "Registration Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Walidacja.
            if (tbPassword.Text == tbPasswordAgain.Text)
            {
                // Tworzenie nowego użytkownika.
                UserFactory usersFactory = new UserFactory();

                if (usersFactory.RegisterUser(tbLogin.Text, tbPassword.Text, cbIsStudent.Checked))
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("User with specified username exists in database - please try different username", "Registration Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Passwords didn't match", "Registration Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
