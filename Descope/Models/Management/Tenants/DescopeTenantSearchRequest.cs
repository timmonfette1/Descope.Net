namespace Descope.Models
{
    public class DescopeTenantSearchRequest
    {
        public IEnumerable<string> TenantIds { get; set; }
        public IEnumerable<string> TenantNames { get; set; }
        public IEnumerable<string> TenantSelfProvisioningDomains { get; set; }
        public object CustomAttributes { get; set; }
    }
}
