
using BookStore.Entities;

namespace BookStore.Models
{
    public class LoginResponse
    {
        public string token { get; set; }
        public string role { get; set; }
        public User user { get; set; }
    }
}
