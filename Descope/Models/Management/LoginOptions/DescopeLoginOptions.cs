namespace Descope.Models
{
    public class DescopeLoginOptions
    {
        public bool Stepup { get; set; }
        public object CustomClaims { get; set; }
        public bool Mfa { get; set; }
        public string SsoAppId { get; set; }
    }
}
