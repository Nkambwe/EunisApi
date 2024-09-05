using Eunis.Enums;

namespace Eunis.Data.Models {
    public class BankAccount : DomainEntity {
        public long BankId { get; set; }
        public long ClientId { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public bool IsDormant { get; set; }
        public bool IsFrozen { get; set; }
        public string FreezReason { get; set; }
        public AccountType Type { get; set; }
        public bool CanWithdraw { get; set; }
        public bool AllowOverdraft { get; set; }
        public bool CanDeposit { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ClosedOn { get; set; }
        public DateTime? LastTransactedOn { get; set; }
        public decimal Balance { get; set; }

        public virtual Bank Bank { get; set; }
        public virtual Client Client { get; set; }
    }
}
