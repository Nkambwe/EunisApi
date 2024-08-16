using System.ComponentModel.DataAnnotations;

namespace Eunis.Api {

    public class EunisRequest {
        [Required(ErrorMessage = "ClientId is required.")]
        public string ClientId { get; set; }

        [Required(ErrorMessage = "Action is required.")]
        public string Action { get; set; }

        [Required(ErrorMessage = "Data is required.")]
        public RequestData RequestData { get; set; }
    }

}
