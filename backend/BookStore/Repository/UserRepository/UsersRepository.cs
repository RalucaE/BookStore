using BookStore.Data;
using Dapper;
using System.Data;
using BookStore.Entities;
using BookStore.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using BookStore.Utils;
using System.Text;


namespace BookStore.Repository.UserRepository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public UsersRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<List<User>> GetMany()
        {
            var sqlQuery = new StringBuilder("SELECT * FROM Users");
            var parameters = new DynamicParameters();  
            using var connection = _context.CreateConnection();
            var user = await connection.QueryAsync<User>(sqlQuery.ToString(), parameters);
            return user.ToList();
        }

        public async Task<Boolean> Register(Models.RegisterRequest registerRequest)
        {
            Boolean response = false;
            string query = "select * from Users where email = @email ";
            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryFirstOrDefaultAsync<User[]>(query, new { registerRequest.email});
                if (users != null && users.Length > 0)
                    return false;
            }

            string insertUserQuery = "insert into Users(full_name,username,email,password)" +
                            "output INSERTED.id " +
                            "values (@full_name,@username,@email,@password)";
            var parameters = new DynamicParameters();
            parameters.Add("full_name", registerRequest.full_name, DbType.String);
            parameters.Add("username", registerRequest.username, DbType.String);
            parameters.Add("email", registerRequest.email, DbType.String);
            parameters.Add("password", registerRequest.password, DbType.String);

            string insertRoleQuery = "insert into User_Role(user_id) values (@user_id)";

            using (var connection = _context.CreateConnection())
            {
                int userId = await connection.ExecuteScalarAsync<int>(insertUserQuery, parameters);
                var param = new DynamicParameters();
                param.Add("user_id", userId, DbType.Int32);               
                await connection.ExecuteAsync(insertRoleQuery, param);
                response = true;
            }
            return response;
        }
        public async Task<LoginResponse> Login(Models.LoginRequest loginRequest)
        {
            LoginResponse response = new LoginResponse();
            string selectUserQuery = "SELECT * FROM Users WHERE email = @email AND password = @password";
            
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>(selectUserQuery, new { loginRequest.email, loginRequest.password });
                if (user != null)
                {
                    var userId = user.Id;                   
                    string selectRoleIdQuery = "SELECT role_id FROM User_Role where user_id=@userId";
                    var roleId = await connection.ExecuteScalarAsync<int>(selectRoleIdQuery, new { userId });
                    Console.WriteLine("roleId" + roleId);
                    string selectRoleNameQuery = "SELECT role_name FROM Roles where id=@roleId";
                    string? role = await connection.ExecuteScalarAsync<string>(selectRoleNameQuery, new { roleId });                                   
                    if (role != null)
                    {
                        response.token = JwtUtils.GenerateJwtToken(_configuration, user, role);
                        response.role = role;
                        response.user = user;
                        Console.WriteLine(response.user.FullName);
                    }
                }
            }
            return response;
        }
       
        public async Task<Boolean> Update(User user, int id)
        {
            Boolean response = false;
            string query = "update Users set full_name=@full_name,username=@username,email=@email,password=@password,account_status=@account_status where id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", user.Id, DbType.Int32);
            parameters.Add("full_name", user.FullName, DbType.String);
            parameters.Add("username", user.Username, DbType.String);
            parameters.Add("email", user.Email, DbType.String);
            parameters.Add("password", user.Password, DbType.String);
            parameters.Add("account_status", user.AccountStatus, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                response = true;
            }
            return response;
        }
        public async Task<Boolean> Delete(int id)
        {
            Boolean response = false;
            string query = "delete from Users where id=@id";
            string query_roles = "delete from User_Role where user_id=@id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query_roles, new { id });
                await connection.ExecuteAsync(query, new { id });
                response = true;
            }
            return response;
        }

        public Task<List<User>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(User user, int id)
        {
            throw new NotImplementedException();
        }
    }
}