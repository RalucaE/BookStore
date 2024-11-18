using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities
{
    public class Book
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public int author_id { get; set; }
        [Required]
        public int category_id { get; set; }
        [Required]
        public int page_number { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public int availability { get; set; }
        [Required]
        public DateTime release_date { get; set; }
        public int? review_id { get; set; }
        public string cover { get; set; }
        [Required]
        public virtual ICollection<Favorite_Book> Favorite_Books { get; set; } = new List<Favorite_Book>();

        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
