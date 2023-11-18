using Descope.Configuration;
using NSubstitute;
using RestSharp.Authenticators.OAuth2;

namespace Descope.Test.Mocks
{
    public class IDescopeConfigurationMock
    {
        private readonly IDescopeConfiguration _descopeConfigurationMock;

        public IDescopeConfigurationMock() : this("http://localhost:9999")
        {

        }

        public IDescopeConfigurationMock(string baseUrl)
        {
            _descopeConfigurationMock = Substitute.For<IDescopeConfiguration>();
            _descopeConfigurationMock.BaseUrl.Returns(baseUrl);
            _descopeConfigurationMock
                .AuthApiAuthenticator
                .Returns(new OAuth2AuthorizationRequestHeaderAuthenticator("mockProjectId"));
            _descopeConfigurationMock
                .ManagementApiAuthenticator
                .Returns(new OAuth2AuthorizationRequestHeaderAuthenticator("mockProjectId:mockManagementKey"));
        }

        internal IDescopeConfiguration DescopeConfiguration => _descopeConfigurationMock;
    }
}
