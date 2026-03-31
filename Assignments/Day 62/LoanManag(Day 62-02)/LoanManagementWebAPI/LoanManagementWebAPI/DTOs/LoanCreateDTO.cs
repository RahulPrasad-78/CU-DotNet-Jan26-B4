using System.ComponentModel.DataAnnotations;

namespace LoanManagementWebAPI.DTOs
{
    public class LoanCreateDTO
    {

        [Required]
        public string BorrowerName { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int LoanTermMonths { get; set; }
    }
}
