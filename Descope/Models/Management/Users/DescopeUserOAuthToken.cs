using Descope.Types;

namespace Descope.Models
{
    public class DescopeUserOAuthToken
    {
        public string Provider { get; set; }
        public string ProviderUserId { get; set; }
        public string AccessToken { get; set; }
        public SecondsSinceEpoch Expiration { get; set; }
        public IEnumerable<string> Scopes { get; set; }
    }
}
