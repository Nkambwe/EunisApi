namespace Eunis.Api {
    public class Validator {

        public static string ValidateRequestHeader(RequestHeader header, string requestId) {
            string msg = "Invalid Request.";
            if (header == null) {
                return $"{msg} Request Id '{requestId}' has no header";
            }

            if (header.XUserId == null) {
                return $"{msg} Request Id '{requestId}' header is missing Client ID";
            }

            if (header.Password == null) {
                return $"{msg} Request Id '{requestId}' header is missing Password";
            }

            if (header.XSecret == null) {
                return $"{msg} Request Id '{requestId}' header is missing Scret Key";
            }

            if (header.XSignature == null) {
                return $"{msg} Request Id '{requestId}' header is missing Signature";
            }

            return null;
        }
    }
}
