namespace Eunis.Exceptions {
    public static class ErrorCode {
        public const int AccountNotFound = 1001;
        public const int InsufficientBalance = 1002;
        public const int InvalidAmount = 1003;
        public const int InvalidCurrency = 1004;
        public const int CurrencyMismatch = 1005;
        public const int SystemError = 500;
        public const int ClientError = 400;
        public const int UnauthorizedError = 401;
    }
}
