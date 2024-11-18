using BookStore.Entities;

namespace BookStore.Repository.AuthorRepository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAuthors();
        Task<Boolean> AddAuthor(Author author);
        Task<Boolean> DeleteAuthor(int id);
    }
}
