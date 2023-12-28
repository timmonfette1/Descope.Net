namespace Descope.Models
{
    public class DescopeUserTenant
    {
        public string TenantId { get; set; }
        public string TenantName { get; set; }
        public IEnumerable<string> RoleNames { get; set; }
    }
}
