using Eunis.Enums;

namespace Eunis.Data.Models {
    public class Client : DomainEntity {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public virtual ICollection<BankAccount> Accounts { get; set; }
    }
}
