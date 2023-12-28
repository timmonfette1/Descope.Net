namespace Descope.Models
{
    public class DescopeUserBatchCreateResponse
    {
        public IEnumerable<DescopeUser> CreatedUsers { get; set; }
        public IEnumerable<DescopeFailedUser> FailedUsers { get; set; }
    }
}
