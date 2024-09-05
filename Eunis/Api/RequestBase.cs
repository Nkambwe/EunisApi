using System.ComponentModel.DataAnnotations;

namespace Eunis.Api {
    public class RequestBase {
        [Required(ErrorMessage = "RequestId is required.")]
        public string RequestId { get; set; }

        [Required(ErrorMessage = "ClientId is required.")]
        public string ClientId { get; set; }


    }
}
