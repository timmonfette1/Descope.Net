using Descope.Configuration;
using Descope.Extensions;
using RestSharp;
using RestSharp.Serializers.Json;

namespace Descope.HttpClient
{
    internal class DescopeAuthHttpClient : BaseHttpClient, IDescopeAuthHttpClient
    {
        private readonly RestClient _client;

        private readonly IDescopeConfiguration _config;

        public DescopeAuthHttpClient(IDescopeConfiguration config)
        {
            _config = config;

            var options = new RestClientOptions(config.BaseUrl)
            {
                Authenticator = config.AuthApiAuthenticator
            };

            _client = new RestClient(options, configureSerialization: x => x.UseSystemTextJson(HttpConfigurations.JsonSerializerOptions));
        }

        public async Task<TResponse> PostWithCustomTokenAsync<TBody, TResponse>(string resource, string customTokenValue, TBody body) where TBody : class, new() where TResponse : class, new()
        {
            var request = CreatePostRequest(resource, body);
            var options = new RestClientOptions(_config.BaseUrl)
            {
                Authenticator = _config.ConfigureCustomAuthenticator(customTokenValue)
            };

            using var customClient = new RestClient(options, configureSerialization: x => x.UseSystemTextJson(HttpConfigurations.JsonSerializerOptions));
            var response = await customClient.ExecutePostAsync(request);
            return customClient.Serializers.DeserializeResponse<TResponse>(response);
        }

        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
