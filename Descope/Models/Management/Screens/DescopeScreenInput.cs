namespace Descope.Models
{
    public class DescopeScreenInput
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public bool Required { get; set; }
        public bool Visible { get; set; }
        public string DisplayName { get; set; }
        public string DisplayType { get; set; }
        public IEnumerable<string> DependsOn { get; set; }
        public object NameValueMap { get; set; }
        public bool ContextAware { get; set; }
        public IEnumerable<DescopeScreenInputOption> Options { get; set; }
    }
}
