using Descope.Configuration;
using Descope.HttpClient;
using Descope.Models;

namespace Descope.Auth.AccessKey
{
    internal class AccessKeyApiClient(IDescopeAuthHttpClient httpClient) : IAccessKeyApiClient
    {
        private readonly IDescopeAuthHttpClient _httpClient = httpClient;

        public async Task<DescopeAccessKeyExchangeResponse> Exchange(string accessKey)
        {
            return await _httpClient.PostWithCustomTokenAsync<object, DescopeAccessKeyExchangeResponse>(Endpoints.Auth.ExchangeAccessKey, accessKey, new { });
        }
    }
}
