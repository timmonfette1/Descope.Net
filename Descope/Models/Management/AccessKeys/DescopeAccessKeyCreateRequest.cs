using Descope.Types;

namespace Descope.Models
{
    public class DescopeAccessKeyCreateRequest
    {
        public string Name { get; set; }
        public SecondsSinceEpoch ExpireTime { get; set; }
        public IEnumerable<string> RoleNames { get; set; }
        public IEnumerable<DescopeAccessKeyTenant> KeyTenants { get; set; }
    }
}
