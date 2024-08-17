namespace Eunis.Infrastructure.Data.Models {
    public abstract class DomainEntity {
        public long Id { get; set; }
        public DateTime PostedOn { get; set; }
    }
}
