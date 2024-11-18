using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities
{
    public class Loan
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]

        public int user_id { get; set; }
        [Required]

        public int book_id { get; set; }
        [Required]

        public string loan_date { get; set; }
        [Required]

        public string due_date { get; set; }
    }
}
