using System.ComponentModel.DataAnnotations;

namespace FinTrackPro.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string AccountName { get; set; }

        public decimal Balance { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
