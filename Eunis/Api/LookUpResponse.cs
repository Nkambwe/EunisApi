namespace Eunis.Api {
    public class LookUpResponse {
        public int StatusCode { get; set; }
        public string Wallet { get; set; }
        public string Currency { get; set; }
        public bool IsDebitable { get; set; }
        public bool IsCreditable { get; set; }
        public string Naration { get; set; }

        public LookUpResponse() { }
        public LookUpResponse(int statusCode, string wallet, string currency,
            string naration, bool isCreditable = false, bool isDebitable = true) {
            StatusCode = statusCode;
            Wallet = wallet;
            Currency = currency;
            Naration = naration;
            IsCreditable = isCreditable;
            IsDebitable = isDebitable;
        }
    }
}
