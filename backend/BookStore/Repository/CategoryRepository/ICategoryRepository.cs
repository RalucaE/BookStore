using BookStore.Entities;

namespace BookStore.Repository.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();
        Task<Boolean> AddCategory(Category category);
        Task<Boolean> DeleteCategory(int id);
    }
}