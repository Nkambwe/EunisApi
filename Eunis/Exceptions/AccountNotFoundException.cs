namespace Eunis.Exceptions {
    public class AccountNotFoundException : EunisException {
        public override int ExceptionCode => ErrorCode.AccountNotFound;
        public AccountNotFoundException(string message) :
            base(message) {
        }
    }
}
