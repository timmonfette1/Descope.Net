namespace Descope.Models
{
    public class DescopeFlow
    {
        public DescopeFlowMetadata Flow { get; set; }
        public IEnumerable<DescopeScreen> Screens { get; set; }
    }
}
