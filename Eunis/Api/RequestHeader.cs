
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Eunis.Api {

    public class RequestHeader {
        [Required(ErrorMessage = "User ID is required.")]
        [FromHeader(Name = "xUserId")]
        public string XUserId { get; set; }

        [Required(ErrorMessage = "Signature is required.")]
        [FromHeader(Name = "xSignature")]
        public string XSignature { get; set; }

        [Required(ErrorMessage = "Secret key is required.")]
        [FromHeader(Name = "xSecret")]
        public string XSecret { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [FromHeader(Name = "password")]
        public string Password { get; set; }
    }

}
