using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class RegisterRequest
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string full_name { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
