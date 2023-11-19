namespace Descope.Models
{
    public class DescopeAccessKeyCreateRequest
    {
        public string Name { get; set; }
        public long ExpireTime { get; set; }
        public string[] RoleNames { get; set; }
        public DescopeAccessKeyTenant[] KeyTenants { get; set; }
    }
}
