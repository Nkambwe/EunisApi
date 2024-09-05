namespace Eunis.Data.Models {
    public class Bank : DomainEntity {
        public string SortCode { get; set; } 
        public string BankName { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        
    }
}
