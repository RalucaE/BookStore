using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities
{
    public class User_Roles
    {
        [Key]
        [Column(Order = 1)]
        public int user_id { get; set; }
        [Key]
        [Column(Order = 2)]
        public int role_id { get; set; }
    }
}