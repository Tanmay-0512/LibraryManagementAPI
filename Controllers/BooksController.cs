using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BookService _bookService;

    // Ensure that the BookService is injected via the constructor
    public BooksController(BookService bookService)
    {
        _bookService = bookService;
    }

    // Your actions (AddBook, UpdateBook, etc.)
    [HttpPost]
    public IActionResult AddBook([FromBody] Book newBook)
    {
        // Logic for adding a book
        if (_bookService.AddBook(newBook))
        {
            return CreatedAtAction(nameof(GetBookByTitle), new { title = newBook.Title }, newBook);
        }
        return Conflict("A book with this ISBN already exists.");
    }

    // PUT /api/books/{isbn}: Update the details of a book by ISBN
    [HttpPut("{isbn}")]
    public IActionResult UpdateBook(string isbn, [FromBody] Book updatedBook)
    {
        bool isUpdated = _bookService.UpdateBook(isbn, updatedBook);
        if (!isUpdated)
        {
            return NotFound("Book not found.");
        }

        return NoContent(); // 204 No Content
    }

    // DELETE /api/books/{isbn}: Remove a book from the library using ISBN
    [HttpDelete("{isbn}")]
    public IActionResult DeleteBook(string isbn)
    {
        bool isDeleted = _bookService.DeleteBook(isbn);
        if (!isDeleted)
        {
            return NotFound("Book not found.");
        }

        return NoContent(); // 204 No Content
    }

    // GET /api/books: Retrieve all books in the library
    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var books = _bookService.GetAllBooks();
        return Ok(books);
    }

    // GET /api/books/{title}: Search for books in the library by title
    [HttpGet("{title}")]
    public IActionResult GetBookByTitle(string title)
    {
        var books = _bookService.GetBooksByTitle(title);
        if (!books.Any())
        {
            return NotFound("No books found with the specified title.");
        }

        return Ok(books);
    }
}
