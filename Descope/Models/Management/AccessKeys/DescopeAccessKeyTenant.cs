namespace Descope.Models
{
    public class DescopeAccessKeyTenant
    {
        public string TenantId { get; set; }
        public IEnumerable<string> RoleNames { get; set; }
    }
}
