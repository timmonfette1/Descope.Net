using Descope.Configuration;
using Descope.HttpClient;
using Descope.Models;

namespace Descope.Management.AccessKeys
{
    internal class AccessKeysApiClient : IAccessKeysApiClient
    {
        private readonly IDescopeManagementHttpClient _httpClient;

        public AccessKeysApiClient(IDescopeManagementHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DescopeAccessKey> Get(string id)
        {
            var response = await _httpClient.GetAsync<DescopeAccessKeyResponse>(Endpoints.Management.LoadAccessKey, new { id });
            return response.Key;
        }

        public async Task<DescopeAccessKeyListResponse> Search(DescopeAccessKeySearchRequest search)
        {
            return await _httpClient.PostAsync<DescopeAccessKeySearchRequest, DescopeAccessKeyListResponse>(Endpoints.Management.SearchAccessKeys, search);
        }

        public async Task<DescopeAccessKeyCreateResponse> Create(DescopeAccessKeyCreateRequest accessKey)
        {
            return await _httpClient.PostAsync<DescopeAccessKeyCreateRequest, DescopeAccessKeyCreateResponse>(Endpoints.Management.CreateAccessKey, accessKey);
        }

        public async Task<DescopeAccessKey> Update(DescopeAccessKeyUpdateRequest accessKey)
        {
            var response = await _httpClient.PostAsync<DescopeAccessKeyUpdateRequest, DescopeAccessKeyResponse>(Endpoints.Management.UpdateAccessKey, accessKey);
            return response.Key;
        }

        public async Task Activate(DescopeAccessKeyStatusChangeRequest accessKey)
        {
            await _httpClient.PostAsync(Endpoints.Management.ActivateAccessKey, accessKey);
        }

        public async Task Deactivate(DescopeAccessKeyStatusChangeRequest accessKey)
        {
            await _httpClient.PostAsync(Endpoints.Management.DeactivateAccessKey, accessKey);
        }

        public async Task Delete(DescopeAccessKeyStatusChangeRequest accessKey)
        {
            await _httpClient.PostAsync(Endpoints.Management.DeleteAccessKey, accessKey);
        }
    }
}
