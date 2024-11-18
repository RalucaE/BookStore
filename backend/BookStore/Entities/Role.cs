using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookStore.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}