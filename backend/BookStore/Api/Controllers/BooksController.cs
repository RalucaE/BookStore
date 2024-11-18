using BookStore.Entities;
using BookStore.Services.BookService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _booksService;
        public BooksController(IBookService booksService)
        {
            _booksService = booksService;
        }
        [HttpGet("/GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _booksService.GetBooks();
            if (books != null)
            {
                return Ok(books);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("/AddBook")]
        public async Task<IActionResult> AddBook(Book newBook)
        {
            var book = await _booksService.AddBook(newBook);
            return Ok(book);
        }

        [HttpPut("/EditBook/{id}")]
        public async Task<IActionResult> EditBook(Book new_book, int id)
        {
            var book = await _booksService.EditBook(new_book, id);
            return Ok(book);
        }

        [HttpDelete("/DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _booksService.DeleteBook(id);
            return Ok(book);
        }
        [HttpGet("/SearchBooks/{keyword}")]
        public async Task<IActionResult> SearchBooks(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return BadRequest("Keyword parameter is required for searching.");
            }

            var books = await _booksService.SearchBooks(keyword);

            if (books != null && books.Count > 0)
            {
                return Ok(books);
            }
            else
            {
                return NotFound("No books found matching the search criteria.");
            }
        }
    }
}