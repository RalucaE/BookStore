using BookStore.Entities;

namespace BookStore.Services.CartService
{
    public interface ICartService
    {
        Task<List<Book>> GetBooks();
        Task<Boolean> AddBookToCart(int bookId, int userId);
        Task<Boolean> DeleteBook(int id);
    }
}
