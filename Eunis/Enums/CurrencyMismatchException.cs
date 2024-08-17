using Eunis.Exceptions;

namespace Eunis.Enums {
    public class CurrencyMismatchException : EunisException {

        public override int ExceptionCode => ErrorCode.CurrencyMismatch;

        public CurrencyMismatchException(Currency currency, Currency setCurrency)
            : base($"Currency missmatch. Currency '{currency}' cannot be exchanged for '{setCurrency}'.") { }

        
    }
}
