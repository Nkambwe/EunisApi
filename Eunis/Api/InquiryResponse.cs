namespace Eunis.Api {
    public class InquiryResponse {
        public int RequestId { get; set; }
        public int ClientId { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Vendor { get; set; }

        public InquiryResponse() { }
        public InquiryResponse(int requestId, int clientId, int statusCode, string vendor, string message = "") {
            RequestId = requestId;
            ClientId = clientId;
            StatusCode = statusCode;
            Vendor = vendor;
            Message = message;
        }
    }
}
