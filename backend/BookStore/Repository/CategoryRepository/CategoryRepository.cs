using BookStore.Data;
using BookStore.Entities;
using Dapper;
using System.Data;

namespace BookStore.Repository.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetCategories()
        {
            string query = "select * from Category";
            using (var connection = _context.CreateConnection())
            {
                var category = await connection.QueryAsync<Category>(query);
                return category.ToList();
            }
        }
        public async Task<Boolean> AddCategory(Category category)
        {
            Boolean response = false;
            string query = "insert into Category(category_name) values (@category_name)";
            var parameters = new DynamicParameters();          
            parameters.Add("category_name", category.category_name, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                response = true;
            }
            return response;
        }
        public async Task<Boolean> DeleteCategory(int id)
        {
            Boolean response = false;
            string query = "delete from Category where id=@id";
            using (var connection = _context.CreateConnection())
            {
                var category = await connection.ExecuteAsync(query, new { id });
                response = true;
            }
            return response;
        }
    }
}