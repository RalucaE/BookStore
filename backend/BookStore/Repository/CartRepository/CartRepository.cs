using BookStore.Data;
using BookStore.Entities;
using Dapper;
using System.Data;
using System.Net;

namespace BookStore.Repository.CartRepository
{
    public class CartRepository:ICartRepository
    {
        private readonly ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooks()
        {
            string query = "select * from Loan";
            using (var connection = _context.CreateConnection())
            {
                var book = await connection.QueryAsync<Book>(query);
                return book.ToList();
            }
        }
        public async Task<Boolean> AddBookToCart(int bookId, int userId)
        {
            Boolean response = false;
            string query = "INSERT INTO Loan(user_id, book_id, loan_date, due_date) VALUES (@user_id, @book_id, @loan_date, @due_date)";
            var parameters = new DynamicParameters();
            parameters.Add("user_id", userId, DbType.Int32);
            parameters.Add("book_id", bookId, DbType.Int32);
            parameters.Add("loan_date", DateTime.UtcNow, DbType.DateTime);
            parameters.Add("due_date", DateTime.UtcNow, DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                response = true;
            }
            return response;
        }
        public async Task<Boolean> DeleteBook(int id)
        {
            Boolean response = false;
            string query = "delete from Cart where id=@id";
            using (var connection = _context.CreateConnection())
            {
                var book = await connection.ExecuteAsync(query, new { id });
                response = true;
            }
            return response;
        }
    }
}
