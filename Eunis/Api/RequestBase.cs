using System.ComponentModel.DataAnnotations;

namespace Eunis.Api {
    public class RequestBase {
        [Required(ErrorMessage = "RequestId is required.")]
        public string RequestId { get; set; }

        [Required(ErrorMessage = "ClientId is required.")]
        public string ClientId { get; set; }

        [Required(ErrorMessage = "Agent Code is required.")]
        public string AgentCode { get; set; }

        [Required(ErrorMessage = "Bank sort code is required.")]
        public string BankCode { get; set; }

        [Required(ErrorMessage = "Agent Code is required.")]
        public string AccountNumber { get; set; }

    }
}
