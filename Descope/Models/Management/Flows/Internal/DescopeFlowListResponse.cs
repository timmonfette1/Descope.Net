namespace Descope.Models
{
    internal class DescopeFlowListResponse
    {
        public IEnumerable<DescopeFlowMetadata> Flows { get; set; }
        public int Total { get; set; }
    }
}
