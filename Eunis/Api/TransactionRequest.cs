using System.ComponentModel.DataAnnotations;

namespace Eunis.Api {
    public class TransactionRequest : RequestBase {
        
        [Required(ErrorMessage = "Amount is required.")]
        public string Amount { get; set; }

        [Required(ErrorMessage = "Sender Name is required.")]
        public string SenderName { get; set; }

        [Required(ErrorMessage = "MsisDn is required.")]
        public string MsisDn { get; set; }

        [Required(ErrorMessage = "Narration is required.")]
        public string Narration { get; set; }

        [Required(ErrorMessage = "Network is required.")]
        public string Network { get; set; }

        [Required(ErrorMessage = "Destination is required.")]
        public string Destination { get; set; }

    }
}
