using BookStore.Entities;
using BookStore.Services.AuthorSerice;
using Microsoft.AspNetCore.Mvc;



namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorsService;
        public AuthorsController(IAuthorService authorsService)
        {
            _authorsService = authorsService;
        }
        [HttpGet("/GetAuthors")]
        public async Task<IActionResult> GetAuthors()
        {

            var authors = await _authorsService.GetAuthors();

            if (authors != null)
            {

                return Ok(authors);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("/AddAuthor")]
        public async Task<IActionResult> AddAuthor(Author newAuthor)
        {
            var author = await _authorsService.AddAuthor(newAuthor);
            return Ok(author);
        }
        [HttpDelete("/DeleteAuthor/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _authorsService.DeleteAuthor(id);
            return Ok(author);
        }
    }
}