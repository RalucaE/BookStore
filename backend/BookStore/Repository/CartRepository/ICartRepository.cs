using BookStore.Entities;

namespace BookStore.Repository.CartRepository
{
    public interface ICartRepository
    {
        Task<List<Book>> GetBooks();
        Task<Boolean> AddBookToCart(int bookId, int userId);
        Task<Boolean> DeleteBook(int id);
    }
}
