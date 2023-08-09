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
    public partial class BookForm : Form
    {
        private Biblioteque library;

        public BookForm(Biblioteque library)
        {
            InitializeComponent();
            this.library = library;
            RefreshDataGridView();
        }

        public void RefreshDataGridView()
        {
            dgvBooks.DataSource = library.GetBooks();
        }

        private void btnBackToMainForm_Click(object sender, EventArgs e)
        {
            // Create a new instance of MainForm and show it
            MainForm mainForm = new MainForm();
            mainForm.Show();

            // Close the current form (the current form will be closed when the user goes back to the MainForm)
            this.Close();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            // Show the AddBookForm with the MainForm as the owner
            AddBookForm addBookForm = new AddBookForm(library, this);
            addBookForm.ShowDialog();

            // Refresh the DataGridView after adding a new book
            RefreshDataGridView();
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                string selectedBookName = dgvBooks.SelectedRows[0].Cells[0].Value?.ToString();
                if (!string.IsNullOrEmpty(selectedBookName))
                {
                    library.RemoveBook(selectedBookName);
                    RefreshDataGridView();
                }
                else
                {
                    MessageBox.Show("Please select a valid book to remove.");
                }
            }
            else
            {
                MessageBox.Show("Please select a book to remove.");
            }
        }
    }
}
