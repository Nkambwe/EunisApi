namespace Eunis.Api {
    public class EuinisResponse {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Info { get; set; }

        public EuinisResponse() { }
        public EuinisResponse(int statusCode, string message, string info = "") {
            StatusCode = statusCode;
            Message = message;
            Info = info;
        }
    }
}
