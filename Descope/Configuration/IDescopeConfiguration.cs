using RestSharp.Authenticators.OAuth2;

namespace Descope.Configuration
{
    internal interface IDescopeConfiguration
    {
        string BaseUrl { get; }
        OAuth2AuthorizationRequestHeaderAuthenticator AuthApiAuthenticator { get; }
        OAuth2AuthorizationRequestHeaderAuthenticator ManagementApiAuthenticator { get; }
    }
}
