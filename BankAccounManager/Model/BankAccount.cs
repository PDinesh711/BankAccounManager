using System.ComponentModel.DataAnnotations;

namespace BankAccounManager.Model
{
    public class BankAccount
    {
        [Key]
        public int AccountId { get; set; }
        [Required]
        public string AccountHolderName { get; set; }
        [Required]
        public int AccountNumber { get; set; }
        [Required]
        public string AccountType { get; set; }
        [Required]
        public string IFSCCode { get; set; }
        [Required]
        public string BranchLocation { get; set; }
    }
}
