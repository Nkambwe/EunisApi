namespace Eunis.Exceptions {
    public class ClientException : EunisException {
        public override int ExceptionCode => ErrorCode.ClientError;
        public ClientException(string message) :
            base(message) {
        }
    }
}
