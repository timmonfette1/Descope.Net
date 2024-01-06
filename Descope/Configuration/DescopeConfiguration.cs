using RestSharp.Authenticators.OAuth2;

namespace Descope.Configuration
{
    internal class DescopeConfiguration : IDescopeConfiguration
    {
        private readonly string _projectId;

        private const string BEARER = "Bearer";

        private readonly OAuth2AuthorizationRequestHeaderAuthenticator _mgmtAuthenticator;
        private readonly OAuth2AuthorizationRequestHeaderAuthenticator _authAuthenticator;

        public DescopeConfiguration(string projectId, string managementKey)
        {
            _projectId = projectId;

            var mgmtToken = $"{projectId}:{managementKey}";

            _mgmtAuthenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(mgmtToken, BEARER);
            _authAuthenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(projectId, BEARER);
        }

        public string BaseUrl => "https://api.descope.com";
        public OAuth2AuthorizationRequestHeaderAuthenticator AuthApiAuthenticator => _authAuthenticator;
        public OAuth2AuthorizationRequestHeaderAuthenticator ManagementApiAuthenticator => _mgmtAuthenticator;

        public OAuth2AuthorizationRequestHeaderAuthenticator ConfigureCustomAuthenticator(string custom)
        {
            return new OAuth2AuthorizationRequestHeaderAuthenticator($"{_projectId}:{custom}");
        }
    }
}
