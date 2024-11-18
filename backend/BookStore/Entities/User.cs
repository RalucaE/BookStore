using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
        public required Role Role { get; set; }
        public string AccountStatus { get; set; } = string.Empty;
        public ICollection<Favorite_Book> Favorite_Books { get; set; } = new List<Favorite_Book>();

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}