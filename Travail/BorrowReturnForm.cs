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
    public partial class BorrowReturnForm : Form
    {
        private Biblioteque library;

        public BorrowReturnForm(Biblioteque library)
        {
            InitializeComponent();
            this.library = library;
            RefreshDataGridViews();
        }

        private void btnBackToMainForm_Click(object sender, EventArgs e)
        {
            // Create a new instance of MainForm and show it
            MainForm mainForm = new MainForm();
            mainForm.Show();

            // Close the current form (the current form will be closed when the user goes back to the MainForm)
            this.Close();
        }

        private void btnBorrow_Click_1(object sender, EventArgs e)
        {
            if (dgvAvailableBooks.SelectedRows.Count > 0)
            {
                string selectedBookName = dgvAvailableBooks.SelectedRows[0].Cells[0].Value?.ToString();
                string selectedPersonName = dgvAvailableBooks.SelectedRows[0].Cells[1].Value?.ToString();
                if (!string.IsNullOrEmpty(selectedBookName) && !string.IsNullOrEmpty(selectedPersonName))
                {
                    library.BorrowBook(selectedBookName, selectedPersonName);
                    RefreshDataGridViews();
                }
                else
                {
                    MessageBox.Show("Please select a valid book to borrow.");
                }
            }
            else
            {
                MessageBox.Show("Please select a book to borrow.");
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvBorrowedBooks.SelectedRows.Count > 0)
            {
                string selectedBookName = dgvBorrowedBooks.SelectedRows[0].Cells[0].Value?.ToString();
                if (!string.IsNullOrEmpty(selectedBookName))
                {
                    library.ReturnBook(selectedBookName);
                    RefreshDataGridViews();
                }
                else
                {
                    MessageBox.Show("Please select a valid book to return.");
                }
            }
            else
            {
                MessageBox.Show("Please select a book to return.");
            }
        }

        private void RefreshDataGridViews()
        {
            dgvAvailableBooks.DataSource = null;
            dgvBorrowedBooks.DataSource = null;

            dgvAvailableBooks.DataSource = library.GetAvailableBooks();
            dgvBorrowedBooks.DataSource = library.GetBorrowedBooks();
        }

        private List<BookData> GetAvailableBooksData()
        {
            List<BookData> availableBooksData = new List<BookData>();

            foreach (Livre livre in library.GetAvailableBooks())
            {
                availableBooksData.Add(new BookData(livre.Name, livre.Author));
            }

            return availableBooksData;
        }

        private List<BookData> GetBorrowedBooksData()
        {
            List<BookData> borrowedBooksData = new List<BookData>();

            foreach (KeyValuePair<Livre, Personne> pair in library.GetBorrowedBooks())
            {
                Livre book = pair.Key;
                Personne person = pair.Value;

                if (person != null)
                {
                    borrowedBooksData.Add(new BookData(book.Name, book.Author));
                }
            }

            return borrowedBooksData;
        }

    }

    public class BookData
    {
        public string Name { get; set; }
        public string Author { get; set; }

        public BookData(string name, string author)
        {
            Name = name;
            Author = author;
        }
    }
}
