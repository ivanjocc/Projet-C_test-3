namespace Travail
{
    public partial class MainForm : Form
    {
        private Biblioteque biblioteque = new Biblioteque();

        private List<Livre> borrowedBooksList = new List<Livre>();

        // Make the library variable static
        //public static Biblioteque library = new Biblioteque();

        // Declare a list to store borrowed books
        private List<Livre> borrowedBooks = new List<Livre>();

        private Biblioteque library;

        public MainForm()
        {
            InitializeComponent();
            library = new Biblioteque();
            // Initialize the BookForm and AuthForm instances
        }

        private void btnManageBooks_Click(object sender, EventArgs e)
        {
            // Show the BookForm with the MainForm as the owner
            BookForm bookForm = new BookForm(library);
            bookForm.ShowDialog();
            this.Close();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            // Create a new instance of BorrowForm and show it
            BorrowReturnForm borrowForm = new BorrowReturnForm(library);
            borrowForm.ShowDialog();
            this.Close();
        }

        private void btnManageAuthorizedPersons_Click(object sender, EventArgs e)
        {
            // Show the AuthForm with the MainForm as the owner
            AuthForm authForm = new AuthForm(library);
            authForm.ShowDialog();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}