namespace Eunis.Exceptions {
    public class NotFoundException : EunisException {
        public override int ExceptionCode { get; }
        public NotFoundException(string message, int statusCode) :
            base(message) {
            ExceptionCode = statusCode;
        }
    }
}
