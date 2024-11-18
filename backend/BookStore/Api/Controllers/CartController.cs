using BookStore.Entities;
using BookStore.Services.BookService;
using BookStore.Services.CartService;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("/GetCartBooks")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _cartService.GetBooks();
            if (books != null)
            {
                return Ok(books);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("/AddBookToCart")]
        public async Task<IActionResult> AddBookToCart(int bookId, int userId)
        {
            var cartBook = await _cartService.AddBookToCart(bookId, userId);
            return Ok(cartBook);
        }
        [HttpDelete("/DeleteBookFromCart/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _cartService.DeleteBook(id);
            return Ok(book);
        }
    }
}
