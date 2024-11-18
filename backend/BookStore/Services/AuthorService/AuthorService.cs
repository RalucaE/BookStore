using BookStore.Entities;
using BookStore.Repository.AuthorRepository;

namespace BookStore.Services.AuthorSerice
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<List<Author>> GetAuthors() => await _authorRepository.GetAuthors();
        public async Task<Boolean> AddAuthor(Author author)
        {
            try
            {
                return await _authorRepository.AddAuthor(author);
            }
            catch (Exception ex)
            {               
                return false;
            }
        }
        public async Task<Boolean> DeleteAuthor(int id)
        {
            return await _authorRepository.DeleteAuthor(id);
        }
    }
}