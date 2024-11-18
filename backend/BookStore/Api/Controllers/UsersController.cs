using BookStore.Entities;
using BookStore.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("/GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            

            var users = await _userService.GetUsers();
            if (users != null && users.Any())
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }
        }

        [AllowAnonymous]
        [HttpPost("/Register")]
        public async Task<IActionResult> Register(BookStore.Models.RegisterRequest registerRequest)
        {
            var succes = await _userService.Register(registerRequest);
            if (!succes)
                return BadRequest("Something went wrong");
            else
                return Ok("user registered");
        }
        [HttpPost("/Login")]
        public async Task<IActionResult> Login(BookStore.Models.LoginRequest loginRequest)
        {
            var loginResponse = await _userService.Login(loginRequest);
            if (loginResponse.token == null)
            {
                return BadRequest(loginResponse);
            }
            return Ok(loginResponse);
        }
        [Authorize(Roles ="Admin")]
        [HttpPut("/EditUser/{id}")]
        public async Task<IActionResult> EditUser(User new_user, int id)
        {
            var user = await _userService.EditUser(new_user, id);
            return Ok(user);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("/DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _userService.DeleteUser(id);
            return Ok(response);
        }

    }
}