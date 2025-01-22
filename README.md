This project is a RESTful Web API for managing a simple Library Management System. The API supports basic CRUD operations for books stored in memory, adhering to RESTful principles.
Steps to Run the API
Prerequisites:

.NET 6 SDK or later installed on your system.
A code editor like Visual Studio or Visual Studio Code.
Clone the Repository:
git clone <repository-url>
cd LibraryManagementSystemAPI
Restore Dependencies: Run the following command in the project directory:

dotnet restore
Run the Application: Start the API with:

dotnet run
Access the API: Once the application is running, navigate to:

Swagger UI: http://localhost:<port>/swagger
Replace <port> with the port shown in the terminal when running the API (e.g., http://localhost:5065/swagger).

Endpoints and Sample Requests
1. Add a New Book
Endpoint: POST /api/books
Request Body (JSON):
{
    "title": "The Great Gatsby",
    "author": "F. Scott Fitzgerald",
    "isbn": "9780743273565",
    "available": true
}
Response:
201 Created: Book added successfully.
409 Conflict: ISBN already exists.

2. Update a Book
Endpoint: PUT /api/books/{isbn}
URL Parameter:
{isbn}: ISBN of the book to update.
Request Body (JSON):
{
    "title": "The Great Gatsby (Updated)",
    "author": "F. Scott Fitzgerald",
    "isbn": "9780743273565",
    "available": false
}
Response:
200 OK: Book updated successfully.
404 Not Found: Book not found.
   
3. Delete a Book
Endpoint: DELETE /api/books/{isbn}
URL Parameter:
{isbn}: ISBN of the book to delete.
Response:
200 OK: Book deleted successfully.
404 Not Found: Book not found.
   
4. Retrieve All Books
Endpoint: GET /api/books
Response:
200 OK: Returns a list of all books.
Response Body:
[
    {
        "title": "The Great Gatsby",
        "author": "F. Scott Fitzgerald",
        "isbn": "9780743273565",
        "available": true
    }
]

5. Search for Books by Title
Endpoint: GET /api/books/{title}
URL Parameter:
{title}: Title or partial title of the book(s) to search for.
Response:
200 OK: Returns a list of books matching the title.
404 Not Found: No books found.
Error Handling
400 Bad Request: Invalid input or missing fields in the request body.
404 Not Found: Book not found for the specified ISBN or title.
409 Conflict: Attempt to add a book with a duplicate ISBN.
