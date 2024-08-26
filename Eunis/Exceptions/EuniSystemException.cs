namespace Eunis.Exceptions {
    public class EuniSystemException : EunisException {
        public override int ExceptionCode => ErrorCode.SystemError;
        public EuniSystemException(string message)
            : base(message) {
        }

       
    }
}
