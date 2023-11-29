namespace Descope.Models
{
    public class DescopeScreen
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public string FlowId { get; set; }
        public IEnumerable<DescopeScreenInput> Inputs { get; set; }
        public IEnumerable<DescopeScreenInteraction> Interactions { get; set; }
        public object HtmlTemplate { get; set; }
        public string ComponentsVersion { get; set; }
    }
}
