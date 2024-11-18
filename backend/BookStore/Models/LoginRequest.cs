using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class LoginRequest
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
