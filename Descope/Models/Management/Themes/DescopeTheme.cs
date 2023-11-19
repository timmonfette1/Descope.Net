namespace Descope.Models
{
    public class DescopeTheme
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public object CssTemplate { get; set; }
        public string ComponentsVersion { get; set; }
    }
}
