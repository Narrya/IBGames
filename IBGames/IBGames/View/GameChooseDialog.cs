using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using projekt;

namespace IBGames.View
{
    /// <summary>
    /// 
    /// </summary>
    public partial class GameChooseDialog : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private string _username = string.Empty;

        public GameChooseDialog(string username)
        {
            InitializeComponent();

            _username = username;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void FirstGame_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

            Game memo = new Game(_username);
            memo.ShowDialog(this);
        }

        private void SecondGame_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

            Tetris tetris = new Tetris();
            tetris.ShowDialog(this);
        }

        private void ThirdGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet.", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}