namespace Descope.Models
{
    public class DescopeUserBatchCreateRequest
    {
        public IEnumerable<DescopeUsersCreateRequest> Users { get; set; }
        public bool Invite { get; set; }
        public string InviteUrl { get; set; }
        public bool SendMail { get; set; }
        public bool SendSms { get; set; }
    }
}
