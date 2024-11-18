using BookStore.Entities;
using BookStore.Services.CategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("/GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategories();
            if (categories != null)
            {
                return Ok(categories);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("/AddCategory")]
        public async Task<IActionResult> AddCategory(Category newCategory)
        {
            var category = await _categoryService.AddCategory(newCategory);
            return Ok(category);
        }
        [HttpDelete("/DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.DeleteCategory(id);
            return Ok(category);
        }
    }
}