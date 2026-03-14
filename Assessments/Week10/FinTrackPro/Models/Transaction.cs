using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinTrackPro.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}
