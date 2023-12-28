namespace Descope.Models
{
    public class DescopeUserCreateRequest : DescopeUsersCreateRequest
    {
        public bool Invite { get; set; }
        public string InviteUrl { get; set; }
        public bool SendMail { get; set; }
        public bool SendSms { get; set; }
    }
}
