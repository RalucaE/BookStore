using Microsoft.AspNetCore.Mvc;
using BookStore.Entities;
using BookStore.Models;
using static BookStore.Api.Controllers.UsersController;

namespace BookStore.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<Boolean> Register(RegisterRequest registerRequest);
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<Boolean> EditUser(User user, int id);
        Task<Boolean> DeleteUser(int id);
    }
}
