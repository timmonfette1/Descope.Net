namespace Descope.Models
{
    public class DescopeAccessKey
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> RoleNames { get; set; }
        public IEnumerable<DescopeAccessKeyTenant> KeyTenants { get; set; }
        public string Status { get; set; }
        public long CreatedTime { get; set; }
        public long ExpireTime { get; set; }
        public string CreatedBy { get; set; }
    }
}
