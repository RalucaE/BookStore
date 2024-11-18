using BookStore.Entities;
namespace BookStore.Services.BookService
{
    public interface IBookService
    {
        Task<List<Book>> GetBooks();
        Task<Boolean> AddBook(Book book);
        Task<Boolean> EditBook(Book book, int id);
        Task<Boolean> DeleteBook(int id);
        Task<List<Book>> SearchBooks(string keyword);
    }
}