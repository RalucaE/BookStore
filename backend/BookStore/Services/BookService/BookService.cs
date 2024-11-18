using BookStore.Entities;
using BookStore.Repository.BookRepository;

namespace BookStore.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly  IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public  Task<List<Book>> GetBooks() => _bookRepository.GetBooks();
        public async Task<Boolean> AddBook(Book book)
        {
            try
            {
                return await _bookRepository.AddBook(book);            
            }
            catch (Exception ex)
            {
                return false;              
            }            
        }
        public async Task<Boolean> EditBook(Book book, int id)
        {
            try
            {
                await _bookRepository.EditBook(book,id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<Boolean> DeleteBook(int id)
        {
           return await _bookRepository.DeleteBook(id);
        }

        public async Task<List<Book>> SearchBooks(string keyword)
        {      
            try
            {
                return await _bookRepository.SearchBooks(keyword);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
    }
}