namespace Eunis.Exceptions {
    public class SecurityException : EunisException {
        public override int ExceptionCode => ErrorCode.UnauthorizedError;
        public SecurityException(string message) 
            : base(message) {
        }
    }
}
