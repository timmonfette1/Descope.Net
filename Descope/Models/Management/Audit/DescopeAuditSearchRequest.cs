using Descope.Types;

namespace Descope.Models
{
    public class DescopeAuditSearchRequest
    {
        public MillisecondsSinceEpoch From { get; set; }
        public MillisecondsSinceEpoch To { get; set; }
        public IEnumerable<string> UserIds { get; set; }
        public IEnumerable<string> Actions { get; set; }
        public IEnumerable<string> Devices { get; set; }
        public IEnumerable<string> Methods { get; set; }
        public IEnumerable<string> Geos { get; set; }
        public IEnumerable<string> RemoteAddresses { get; set; }
        public IEnumerable<string> ExternalIds { get; set; }
        public IEnumerable<string> Tenants { get; set; }
        public bool NoTenants { get; set; }
        public string Text { get; set; }
        public IEnumerable<string> ExcludedActions { get; set; }
    }
}
