using System.Collections.Generic;
using System.Linq;

public class BookService
{
    private readonly List<Book> _books = new List<Book>();

    // Add a new book
    public bool AddBook(Book newBook)
    {
        if (_books.Any(b => b.ISBN == newBook.ISBN))
        {
            return false; // ISBN already exists
        }

        _books.Add(newBook);
        return true;
    }

    // Update an existing book
    public bool UpdateBook(string isbn, Book updatedBook)
    {
        var existingBook = _books.FirstOrDefault(b => b.ISBN == isbn);
        if (existingBook == null)
        {
            return false; // Book not found
        }

        existingBook.Title = updatedBook.Title;
        existingBook.Author = updatedBook.Author;
        existingBook.Available = updatedBook.Available;
        return true;
    }

    // Delete a book by ISBN
    public bool DeleteBook(string isbn)
    {
        var book = _books.FirstOrDefault(b => b.ISBN == isbn);
        if (book == null)
        {
            return false; // Book not found
        }

        _books.Remove(book);
        return true;
    }

    // Get all books
    public List<Book> GetAllBooks()
    {
        return _books;
    }

    // Search for books by title
    public List<Book> GetBooksByTitle(string title)
    {
        return _books.Where(b => b.Title.Contains(title, System.StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
