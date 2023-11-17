namespace Descope.Models
{
    public class DescopeException : Exception
    {
        public DescopeException() { }
        public DescopeException(string message) : base(message) { }
        public DescopeException(string message, Exception innerException) : base(message, innerException) { }

        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorMessage { get; set; }
    }
}
