using System;
using System.Windows.Forms;
using IBGames.DataAccess;

namespace IBGames.View
{
    public partial class AdminForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private string _username = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        public AdminForm(string username)
        {
            InitializeComponent();
            _username = username;
        }

        /// <summary>
        /// Handles the Load event of the AdminForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void AdminForm_Load(object sender, EventArgs e)
        {
            UsersDataAccess dataAccess = new UsersDataAccess();
            AllResultsGrid.DataSource = dataAccess.GetUsers();

            AllResultsGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }
    }
}
