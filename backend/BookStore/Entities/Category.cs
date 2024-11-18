using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities
{
    public class Category
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string category_name { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
