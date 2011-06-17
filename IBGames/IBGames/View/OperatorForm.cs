using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IBGames.DataAccess;

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

        /// <summary>
        /// Handles the Load event of the OperatorForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OperatorForm_Load(object sender, EventArgs e)
        {
            Rebind();
        }

        /// <summary>
        /// Rebinds all grids.
        /// </summary>
        protected void Rebind()
        {
            UsersDataAccess dataAccess = new UsersDataAccess();

            AllStudents.DataSource = dataAccess.GetAllDisconectedStudents(_username);
            AllStudents.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

            AssociatedStudents.DataSource = dataAccess.GetMyUsers(_username);
            AssociatedStudents.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

        /// <summary>
        /// Handles the Click event of the btnAssociateStudents control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAssociateStudents_Click(object sender, EventArgs e)
        {
            UsersDataAccess dataAccess = new UsersDataAccess();

            List<int> students = new List<int>();
            foreach (DataGridViewRow student in AllStudents.SelectedRows)
            {
                dataAccess.AssociateStudent((int)student.Cells["ID"].Value, _username);
            }

            // Refresh data sets.
            Rebind();
        }
    }
}
