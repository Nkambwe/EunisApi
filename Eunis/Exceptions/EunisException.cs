namespace Eunis.Exceptions {
    public abstract class EunisException : Exception {

        public abstract int ExceptionCode { get; }

        public EunisException(string message)
            : base(message) { }

        
    }
}
