using Descope.HttpClient;
using Descope.Test.Mocks;

namespace Descope.Test.HttpClient.Management
{
    public class DescopeManagementHttpClientFixture : IDisposable
    {
        private readonly DescopeManagementHttpClient _client;

        public DescopeManagementHttpClientFixture(ClientServerFixture fixture)
        {
            var config = new IDescopeConfigurationMock(fixture.ServerUrl);
            _client = new DescopeManagementHttpClient(config.DescopeConfiguration);
        }

        internal DescopeManagementHttpClient DescopeManagementClient => _client;

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
