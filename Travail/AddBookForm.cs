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
    public partial class AddBookForm : Form
    {
        private Biblioteque library;
        private BookForm bookForm;

        public AddBookForm(Biblioteque library, BookForm bookForm)
        {
            InitializeComponent();
            this.library = library;
            this.bookForm = bookForm;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string bookName = txtBookName.Text;
            string author = txtAuthorName.Text;
            DateTime publicationDate = dtpPublicationDate.Value;

            if (!string.IsNullOrEmpty(bookName) && !string.IsNullOrEmpty(author))
            {
                Livre book = new Livre(bookName, author, publicationDate);
                library.AddBook(book);

                if (bookForm != null)
                {
                    bookForm.RefreshDataGridView();
                }

                MessageBox.Show("Book added successfully!");
                ClearFields();
            }
            else
            {
                MessageBox.Show("Please enter valid book details.");
            }
        }

        private void ClearFields()
        {
            txtBookName.Clear();
            txtAuthorName.Clear();
            dtpPublicationDate.Value = DateTime.Now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form with DialogResult.Cancel
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
