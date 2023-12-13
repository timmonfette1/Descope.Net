namespace Descope.Models
{
    public class DescopeUserSearchRequest
    {
        public string LoginId { get; set; }
        public IEnumerable<string> TenantIds { get; set; }
        public IEnumerable<string> RoleNames { get; set; }
        public string Text { get; set; }
        public bool SsoOnly { get; set; }
        public bool WithTestUser { get; set; }
        public bool TestUsersOnly { get; set; }
        public object CustomAttributes { get; set; }
        public IEnumerable<string> Statuses { get; set; }
        public IEnumerable<string> Emails { get; set; }
        public IEnumerable<string> Phones { get; set; }
        public IEnumerable<string> SsoAppIds { get; set; }
        public int Limit { get; set; }
        public int Page { get; set; }
    }
}
