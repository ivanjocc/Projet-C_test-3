using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Travail
{
    public partial class AddPersonForm : Form
    {
        private Biblioteque library;
        private AuthForm authForm;

        public AddPersonForm(Biblioteque library, AuthForm authForm)
        {
            InitializeComponent();
            this.library = library;
            this.authForm = authForm;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form with DialogResult.Cancel
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string personName = txtFirstName.Text;

            if (!string.IsNullOrEmpty(personName))
            {
                Personne person = new Personne(personName);
                library.AddPerson(person);

                if (authForm != null)
                {
                    authForm.RefreshDataGridView();
                }

                MessageBox.Show("Person added successfully!");
                ClearFields();
            }
            else
            {
                MessageBox.Show("Please enter a valid person name.");
            }
        }

        private void ClearFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            dtpDateOfBirth.Value = DateTime.Now;
        }
    }
}
