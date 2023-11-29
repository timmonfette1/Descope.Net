namespace Descope.Models
{
    public class DescopeAudit
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string UserId { get; set; }
        public string Action { get; set; }
        public long Occurred { get; set; }
        public string Device { get; set; }
        public string Method { get; set; }
        public string Geo { get; set; }
        public string RemoteAddress { get; set; }
        public IEnumerable<string> ExternalIds { get; set; }
        public IEnumerable<string> Tenants { get; set; }
        public object Data { get; set; }
        public string Type { get; set; }
    }
}
