using Descope.HttpClient;
using Descope.Test.Mocks;

namespace Descope.Test.HttpClient.Auth
{
    public class DescopeAuthHttpClientFixture : IDisposable
    {
        private readonly DescopeAuthHttpClient _client;

        public DescopeAuthHttpClientFixture()
        {
            var config = new IDescopeConfigurationMock();
            _client = new DescopeAuthHttpClient(config.DescopeConfiguration);
        }

        internal DescopeAuthHttpClient DescopeAuthClient => _client;

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
