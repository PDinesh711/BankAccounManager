using System.ComponentModel.DataAnnotations;

namespace BankAccounManager.DTO
{
    public class GetBankAccount
    {
        public int AccountId { get; set; }
       
        public string AccountHolderName { get; set; }
       
        public int AccountNumber { get; set; }
       
        public string AccountType { get; set; }
       
        public string IFSCCode { get; set; }
       
        public string BranchLocation { get; set; }
    }
}
