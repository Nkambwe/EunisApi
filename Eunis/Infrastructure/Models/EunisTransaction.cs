namespace Eunis.Infrastructure.Models {
    public class EunisTransaction {
        public long Id { get; set; }
        public string RequestType { get; set; }
        public long UserId { get; set; }
        public DateTime PostedOn { get; set; }
        public string RequestId { get; set; }
        public string ClientId { get; set; }
        public string Narrative { get; set; }
        public string BeneficiaryAccount { get; set; }
        public string BeneficiaryName { get; set; }
        public string MobileNumber { get; set; }
        public decimal Amount { get; set; }
        public string Network { get; set; }
        public string Destination { get; set; }
        public string StatusCode { get; set; }
        public string Description { get; set; }
        public string VendorReference { get; set; }
    }
}
