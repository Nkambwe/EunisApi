using System.ComponentModel.DataAnnotations;

namespace Eunis.Api {

    public class RequestBody {
        [Required(ErrorMessage = "ClientId is required.")]
        public string ClientId { get; set; }

        [Required(ErrorMessage = "Action is required.")]
        public string Action { get; set; }

        [Required(ErrorMessage = "Data is required.")]
        public TransactionRequest RequestData { get; set; }
    }

}
