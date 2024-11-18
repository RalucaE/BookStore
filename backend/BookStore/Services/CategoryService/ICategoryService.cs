using BookStore.Entities;
namespace BookStore.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
        Task<Boolean> AddCategory(Category category);
        Task<Boolean> DeleteCategory(int id);
    }
}