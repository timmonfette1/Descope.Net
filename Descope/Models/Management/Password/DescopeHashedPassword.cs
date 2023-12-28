namespace Descope.Models
{
    public class DescopeHashedPassword
    {
        public string Algorithm { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
        public int Iterations { get; set; }
    }
}
