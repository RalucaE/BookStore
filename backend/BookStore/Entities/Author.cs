using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities
{
    public class Author
    {
        [Key]       
        public int id { get; set; }
        [Required]
        public string author_name { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
