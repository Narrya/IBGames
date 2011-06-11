using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IBGames.View
{
    public partial class OperatorForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private string _username = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        public OperatorForm(string username)
        {
            InitializeComponent();
            _username = username;                 
        }
    }
}
