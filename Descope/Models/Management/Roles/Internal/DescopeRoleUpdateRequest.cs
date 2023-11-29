namespace Descope.Models
{
    internal class DescopeRoleUpdateRequest
    {
        public string Name { get; set; }
        public string NewName { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> PermissionNames { get; set; }
    }
}
