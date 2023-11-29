namespace Descope.Models
{
    public class DescopeAccessKeyCreateRequest
    {
        public string Name { get; set; }
        public long ExpireTime { get; set; }
        public IEnumerable<string> RoleNames { get; set; }
        public IEnumerable<DescopeAccessKeyTenant> KeyTenants { get; set; }
    }
}
