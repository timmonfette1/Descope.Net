using Descope.Configuration;
using RestSharp;
using RestSharp.Serializers.Json;

namespace Descope.HttpClient
{
    internal class DescopeAuthHttpClient : IDescopeAuthHttpClient
    {
        private readonly RestClient _client;

        public DescopeAuthHttpClient(IDescopeConfiguration config)
        {
            var options = new RestClientOptions(config.BaseUrl)
            {
                Authenticator = config.AuthApiAuthenticator
            };

            _client = new RestClient(options, configureSerialization: x => x.UseSystemTextJson(HttpConfigurations.JsonSerializerOptions));
        }

        public RestClient Client => _client;

        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
