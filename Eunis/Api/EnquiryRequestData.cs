using System.ComponentModel.DataAnnotations;

namespace Eunis.Api {
    public class EnquiryRequestData {

        [Required(ErrorMessage = "Action is required.")]
        public string Action { get; set; }

        [Required(ErrorMessage = "Agent Code is required.")]
        public string AgentCode { get; set; }

        [Required(ErrorMessage = "Bank sort code is required.")]
        public string BankCode { get; set; }

        [Required(ErrorMessage = "Agent Code is required.")]
        public string AccountNumber { get; set; }
    }
}
