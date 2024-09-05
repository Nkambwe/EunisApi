namespace Eunis.Api {
    public class EnquiryResponse {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public EnquiryData Data { get; set; }
    }

    public class EnquiryData {
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
        public bool IsDebitable { get; set; }
        public bool IsCreditable { get; set; }
        public string Naration { get; set; }
    }
}
