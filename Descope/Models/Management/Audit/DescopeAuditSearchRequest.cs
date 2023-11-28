namespace Descope.Models
{
    public class DescopeAuditSearchRequest
    {
        public long From { get; set; }
        public long To { get; set; }
        public string[] UserIds { get; set; }
        public string[] Actions { get; set; }
        public string[] Devices { get; set; }
        public string[] Methods { get; set; }
        public string[] Geos { get; set; }
        public string[] RemoteAddresses { get; set; }
        public string[] ExternalIds { get; set; }
        public string[] Tenants { get; set; }
        public bool NoTenants { get; set; }
        public string Text { get; set; }
        public string[] ExcludedActions { get; set; }
    }
}
