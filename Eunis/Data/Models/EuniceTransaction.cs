namespace Eunis.Data.Models {

    public class EuniceTransaction : DomainEntity {
        public string RequestType { get; set; }
        public long CredentialsId { get; set; }
        public string ClientId { get; set; }
        public string RequestId { get; set; }
        public string Particulars { get; set; }
        public string BeneficiaryAccount { get; set; }
        public string BeneficiaryName { get; set; }
        public string MobileNumber { get; set; }
        public decimal Amount { get; set; }
        public string Network { get; set; }
        public string Destination { get; set; }
        public string StatusCode { get; set; }
        public string VendorMessage { get; set; }
        public string VendorReference { get; set; }

        public virtual Credentials Client { get; set; }
    }
}
