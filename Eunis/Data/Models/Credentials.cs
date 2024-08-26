namespace Eunis.Data.Models
{
    public class Credentials : DomainEntity
    {
        public string ClientId { get; set; }
        public string ClientCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SecretKey { get; set; }
        public string Actions { get; set; }

        public ICollection<EunisTransaction> Transactions { get; set; }
    }
}
