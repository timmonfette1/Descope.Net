using Descope.Configuration;
using Descope.HttpClient;
using Descope.Models;

namespace Descope.Management.AccessKeys
{
    internal class AccessKeysApiClient(IDescopeManagementHttpClient httpClient) : IAccessKeysApiClient
    {
        private readonly IDescopeManagementHttpClient _httpClient = httpClient;

        public async Task<DescopeAccessKey> Get(string id)
        {
            var response = await _httpClient.GetAsync<DescopeAccessKeyResponse>(Endpoints.Management.LoadAccessKey, new { id });
            return response.Key;
        }

        public async Task<DescopeAccessKeyListResponse> Search(params string[] tenantIds)
        {
            var request = new DescopeAccessKeySearchRequest
            {
                TenantIds = tenantIds
            };

            return await _httpClient.PostAsync<DescopeAccessKeySearchRequest, DescopeAccessKeyListResponse>(Endpoints.Management.SearchAccessKeys, request);
        }

        public async Task<DescopeAccessKeyCreateResponse> Create(DescopeAccessKeyCreateRequest accessKey)
        {
            return await _httpClient.PostAsync<DescopeAccessKeyCreateRequest, DescopeAccessKeyCreateResponse>(Endpoints.Management.CreateAccessKey, accessKey);
        }

        public async Task<DescopeAccessKey> Update(string id, string name)
        {
            var request = new DescopeAccessKeyUpdateRequest
            {
                Id = id,
                Name = name
            };

            var response = await _httpClient.PostAsync<DescopeAccessKeyUpdateRequest, DescopeAccessKeyResponse>(Endpoints.Management.UpdateAccessKey, request);
            return response.Key;
        }

        public async Task Activate(string id)
        {
            var request = new DescopeAccessKeyStatusChangeRequest
            {
                Id = id
            };

            await _httpClient.PostAsync(Endpoints.Management.ActivateAccessKey, request);
        }

        public async Task Deactivate(string id)
        {
            var request = new DescopeAccessKeyStatusChangeRequest
            {
                Id = id
            };

            await _httpClient.PostAsync(Endpoints.Management.DeactivateAccessKey, request);
        }

        public async Task Delete(string id)
        {
            var request = new DescopeAccessKeyStatusChangeRequest
            {
                Id = id
            };

            await _httpClient.PostAsync(Endpoints.Management.DeleteAccessKey, request);
        }
    }
}
