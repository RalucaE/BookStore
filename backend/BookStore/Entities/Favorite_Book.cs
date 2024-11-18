using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities
{
    public class Favorite_Book
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public int book_id { get; set; }
        [Required]
        public int user_id { get; set; }
    }
}