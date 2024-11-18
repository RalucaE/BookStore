using BookStore.Entities;
using BookStore.Repository.UserRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using static BookStore.Api.Controllers.UsersController;
using System.Linq.Expressions;
using BookStore.Utils;
using Dapper;

namespace BookStore.Services.UserService
{
    public class UserService:IUserService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly PasswordHasher<User> _passwordHasher;
        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
            _passwordHasher = new PasswordHasher<User>();
        }
        public async Task<List<User>> GetUsers()
        {        
            return await _usersRepository.GetMany();
        }
        public async Task<Boolean> Register(RegisterRequest registerRequest)
        {
            try
            {
                return await _usersRepository.Register(registerRequest);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            try
            {
                return await _usersRepository.Login(loginRequest);
            }
            catch (Exception ex)
            {
                var LoginResponse = new LoginResponse();
                return LoginResponse;
            }
        }
        public async Task<Boolean> EditUser(User user, int id)
        {
            try
            {
                await _usersRepository.Update(user, id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<Boolean> DeleteUser(int id)
        {          
            try
            {
                
                return await _usersRepository.Delete(id); ;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string HashPassword(User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public bool VerifyPassword(User user, string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}