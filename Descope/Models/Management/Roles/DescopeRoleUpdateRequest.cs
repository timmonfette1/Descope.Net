namespace Descope.Models
{
    public class DescopeRoleUpdateRequest
    {
        public string Name { get; set; }
        public string NewName { get; set; }
        public string Description { get; set; }
        public string[] PermissionNames { get; set; }
    }
}
