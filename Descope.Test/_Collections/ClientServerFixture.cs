using Descope.HttpClient;
using Descope.Test.Mocks;
using WireMock.Server;

namespace Descope.Test
{
    public class ClientServerFixture : IDisposable
    {
        private readonly WireMockServer _server;
        private readonly IDescopeAuthHttpClient _authHttpClient;
        private readonly IDescopeManagementHttpClient _managementHttpClient;

        private readonly string _serverUrl;

        public ClientServerFixture()
        {
            _server = WireMockServer.Start();

            _server
                .ConfigureDummy()
                .ConfigureAccessKey()
                .ConfigureAccessKeys()
                .ConfigureAudit()
                .ConfigureFlows()
                .ConifgurePermissions()
                .ConifgureRoles()
                .ConifgureTenants()
                .ConfigureThemes()
                .ConfigureTestUsers()
                .ConfigureUsers();

            _serverUrl = _server.Url;
            var config = new IDescopeConfigurationMock(_serverUrl);
            _authHttpClient = new DescopeAuthHttpClient(config.DescopeConfiguration);
            _managementHttpClient = new DescopeManagementHttpClient(config.DescopeConfiguration);
        }

        internal IDescopeAuthHttpClient AuthHttpClient => _authHttpClient;
        internal IDescopeManagementHttpClient ManagementHttpClient => _managementHttpClient;

        internal string ServerUrl => _serverUrl;

        public void Dispose()
        {
            _server?.Stop();
            _server?.Dispose();
            _authHttpClient?.Dispose();
            _managementHttpClient?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
