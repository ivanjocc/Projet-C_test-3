public class Biblioteque
{
    private List<Personne> authorizedPersons;
    private List<Livre> availableBooks;
    private Dictionary<Livre, Personne> borrowedBooks;

    public Biblioteque()
    {
        authorizedPersons = new List<Personne>();
        availableBooks = new List<Livre>();
        borrowedBooks = new Dictionary<Livre, Personne>();
    }

    public void AddPerson(Personne person)
    {
        authorizedPersons.Add(person);
    }

    public void RemovePerson(string name)
    {
        Personne person = authorizedPersons.FirstOrDefault(p => p.Name == name);
        if (person != null)
        {
            authorizedPersons.Remove(person);
        }
    }

    public List<Personne> GetAuthorizedPersons()
    {
        return authorizedPersons;
    }

    public void AddBook(Livre book)
    {
        availableBooks.Add(book);
    }

    public void RemoveBook(string name)
    {
        Livre book = availableBooks.FirstOrDefault(b => b.Name == name);
        if (book != null)
        {
            availableBooks.Remove(book);
        }
    }

    public List<Livre> GetBooks()
    {
        return availableBooks;
    }

    public void BorrowBook(string bookName, string personName)
    {
        Livre book = availableBooks.FirstOrDefault(b => b.Name == bookName);
        Personne person = authorizedPersons.FirstOrDefault(p => p.Name == personName);

        if (book != null && person != null)
        {
            availableBooks.Remove(book);
            borrowedBooks.Add(book, person);
        }
    }

    public void ReturnBook(string bookName)
    {
        Livre book = borrowedBooks.Keys.FirstOrDefault(b => b.Name == bookName);

        if (book != null)
        {
            borrowedBooks.Remove(book);
            availableBooks.Add(book);
        }
    }

    public List<Livre> GetBorrowedBooks()
    {
        return borrowedBooks.Keys.ToList();
    }

    public List<Livre> GetAvailableBooks()
    {
        List<Livre> availableBooks = new List<Livre>();

        foreach (KeyValuePair<Livre, Personne> pair in borrowedBooks)
        {
            if (pair.Value == null)
            {
                availableBooks.Add(pair.Key);
            }
        }

        return availableBooks;
    }
}
