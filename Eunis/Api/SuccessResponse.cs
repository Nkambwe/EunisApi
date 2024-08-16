namespace Eunis.Api {
    public class SuccessResponse {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Info { get; set; }

        public SuccessResponse() { }
        public SuccessResponse(int statusCode, string message, string info = "") {
            StatusCode = statusCode;
            Message = message;
            Info = info;
        }
    }
}
