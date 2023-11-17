namespace Descope.Models
{
    public class DescopePermission
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool SystemDefault { get; private set; }
    }
}
