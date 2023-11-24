namespace Descope.Models
{
    public class DescopeScreen
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public string FlowId { get; set; }
        public DescopeScreenInput[] Inputs { get; set; }
        public DescopeScreenInteraction[] Interactions { get; set; }
        public object HtmlTemplate { get; set; }
        public string ComponentsVersion { get; set; }
    }
}
