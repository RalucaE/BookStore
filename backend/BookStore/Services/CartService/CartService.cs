using BookStore.Entities;
using BookStore.Repository.BookRepository;
using BookStore.Repository.CartRepository;

namespace BookStore.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public Task<List<Book>> GetBooks() => _cartRepository.GetBooks();
        public async Task<Boolean> AddBookToCart(int bookId, int userId)
        {
            try
            {
                return await _cartRepository.AddBookToCart(bookId, userId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<Boolean> DeleteBook(int id)
        {
            return await _cartRepository.DeleteBook(id);
        }
    }
}
