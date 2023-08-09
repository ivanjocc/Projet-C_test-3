using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travail
{
    public partial class AuthForm : Form
    {
        private Biblioteque library;

        public AuthForm(Biblioteque library)
        {
            InitializeComponent();
            this.library = library;
            RefreshDataGridView();
        }

        public void RefreshDataGridView()
        {
            dgvAuthorizedPeople.DataSource = library.GetAuthorizedPersons();
        }

        private void btnBackToMainForm_Click(object sender, EventArgs e)
        {
            // Create a new instance of MainForm and show it
            MainForm mainForm = new MainForm();
            mainForm.Show();

            // Close the current form (the current form will be closed when the user goes back to the MainForm)
            this.Close();
        }

        private void btnAddAuthorizedPerson_Click(object sender, EventArgs e)
        {
            // Show the AddPersonForm with the MainForm as the owner
            AddPersonForm addPersonForm = new AddPersonForm(library, this);
            addPersonForm.ShowDialog();

            // Refresh the DataGridView after adding a new authorized person
            RefreshDataGridView();
        }

        private void btnDeleteAuthorizedPerson_Click(object sender, EventArgs e)
        {
            if (dgvAuthorizedPeople.SelectedRows.Count > 0)
            {
                string selectedPersonName = dgvAuthorizedPeople.SelectedRows[0].Cells[0].Value?.ToString();
                if (!string.IsNullOrEmpty(selectedPersonName))
                {
                    library.RemovePerson(selectedPersonName);
                    RefreshDataGridView();
                }
                else
                {
                    MessageBox.Show("Please select a valid person to remove.");
                }
            }
            else
            {
                MessageBox.Show("Please select a person to remove.");
            }
        }
    }
}
