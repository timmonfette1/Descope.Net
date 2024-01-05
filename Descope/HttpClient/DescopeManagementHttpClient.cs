using Descope.Configuration;
using Descope.Extensions;
using RestSharp;
using RestSharp.Serializers.Json;

namespace Descope.HttpClient
{
    internal class DescopeManagementHttpClient : IDescopeManagementHttpClient
    {
        private readonly RestClient _client;

        public DescopeManagementHttpClient(IDescopeConfiguration config)
        {
            var options = new RestClientOptions(config.BaseUrl)
            {
                Authenticator = config.ManagementApiAuthenticator
            };

            _client = new RestClient(options, configureSerialization: x => x.UseSystemTextJson(HttpConfigurations.JsonSerializerOptions));
        }

        public async Task<TResponse> GetAsync<TResponse>(string resource, object parameters = null) where TResponse : class, new()
        {
            var request = new RestRequest(resource, Method.Get);
            if (parameters != null)
            {
                foreach (var parameter in parameters.GetType().GetProperties())
                {
                    var name = parameter.Name;
                    var value = parameter.GetValue(parameters, null).ToString();
                    if (resource.Contains($"{{{parameter.Name}}}"))
                    {
                        request.AddUrlSegment(name, value);
                    }
                    else
                    {
                        request.AddQueryParameter(name, value);
                    }
                }
            }

            var response = await _client.ExecuteGetAsync(request);
            return _client.Serializers.DeserializeResponse<TResponse>(response);
        }

        public async Task DeleteAsync(string resource)
        {
            var request = new RestRequest(resource, Method.Delete);
            var response = await _client.DeleteAsync(request);
            _client.Serializers.ParseResponse(response);
        }

        public async Task PostAsync<TBody>(string resource, TBody body) where TBody : class, new()
        {
            var request = CreatePostRequest(resource, body);
            var response = await _client.ExecutePostAsync(request);
            _client.Serializers.ParseResponse(response);
        }

        public async Task<TResponse> PostAsync<TBody, TResponse>(string resource, TBody body) where TResponse : class, new() where TBody : class, new()
        {
            var request = CreatePostRequest(resource, body);
            var response = await _client.ExecutePostAsync(request);
            return _client.Serializers.DeserializeResponse<TResponse>(response);
        }

        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }

        #region Private Methods

        private static RestRequest CreatePostRequest<TBody>(string resource, TBody body) where TBody : class, new()
        {
            var request = new RestRequest(resource, Method.Post);
            request.AddJsonBody(body);

            return request;
        }

        #endregion Private Methods
    }
}
