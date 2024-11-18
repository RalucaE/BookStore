using BookStore.Entities;
using BookStore.Models;
using System.Linq.Expressions;

namespace BookStore.Repository.UserRepository
{
    public interface IUsersRepository
    {

        Task<List<User>> GetMany();
        Task<List<User>> Get();
        Task<bool> Create(User user, int id);
        Task<bool> Update(User user, int id);
        Task<bool> Delete(int id);



        Task<Boolean> Register(RegisterRequest registerRequest);
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}
