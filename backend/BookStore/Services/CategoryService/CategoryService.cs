using BookStore.Entities;
using BookStore.Repository.CategoryRepository;

namespace BookStore.Services.CategoryService
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<List<Category>> GetCategories() => _categoryRepository.GetCategories();
        public async Task<Boolean> AddCategory(Category category)
        {
            try
            {               
                 return await _categoryRepository.AddCategory(category);               
            }
            catch(Exception ex)
            {
                return false;
            }   
        }
        public async Task<Boolean> DeleteCategory(int id)
        {
            return await _categoryRepository.DeleteCategory(id);
        }
    }
}
