using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities
{
    public class Review
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]

        public int user_id { get; set; }
        [Required]

        public int rating { get; set; }
        [Required]

        public string review_date { get; set; }
        [Required]

        public string comment { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
