namespace Descope.Models
{
    public class DescopeTenantSearchRequest
    {
        public string[] TenantIds { get; set; }
        public string[] TenantNames { get; set; }
        public string[] TenantSelfProvisioningDomains { get; set; }
        public object CustomAttributes { get; set; }
    }
}
