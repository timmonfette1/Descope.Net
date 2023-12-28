namespace Descope.Models
{
    internal class DescopeUserUpdateRequest
    {
        public string LoginId { get; set; }
        public string DisplayName { get; set; }
        public string GivenName { get; set; }
        public string MiddleName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool VerifiedEmail { get; set; }
        public bool VerifiedPhone { get; set; }
        public IEnumerable<string> RoleNames { get; set; }
        public IEnumerable<DescopeUserTenant> UserTenants { get; set; }
        public string Picture { get; set; }
        public object CustomAttributes { get; set; }
        public IEnumerable<string> SsoAppIds { get; set; }
    }
}
