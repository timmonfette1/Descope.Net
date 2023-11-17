using Descope.Configuration;
using Descope.HttpClient;
using Descope.Models;

namespace Descope.Management.Tenants
{
    internal class TenantsApiClient : ITenantsApiClient
    {
        private readonly IDescopeManagementHttpClient _httpClient;

        public TenantsApiClient(IDescopeManagementHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DescopeTenantListResponse> GetAll()
        {
            return await _httpClient.GetAsync<DescopeTenantListResponse>(Endpoints.Management.LoadAllTenants);
        }

        public async Task<DescopeTenant> Get(string id)
        {
            return await _httpClient.GetAsync<DescopeTenant>(Endpoints.Management.LoadTenant, new { id });
        }

        public async Task<DescopeTenantListResponse> Search(DescopeTenantSearchRequest search)
        {
            return await _httpClient.PostAsync<DescopeTenantSearchRequest, DescopeTenantListResponse>(Endpoints.Management.SearchTenants, search);
        }

        public async Task<DescopeTenant> Create(DescopeTenant tenant)
        {
            var response = await _httpClient.PostAsync<DescopeTenant, DescopeTenant>(Endpoints.Management.CreateTenant, tenant);
            tenant.Id = response.Id;
            return tenant;
        }

        public async Task<DescopeTenant> Update(DescopeTenant tenant)
        {
            await _httpClient.PostAsync(Endpoints.Management.UpdateTenant, tenant);
            return tenant;
        }

        public async Task Delete(DescopeTenantDeleteRequest tenant)
        {
            await _httpClient.PostAsync(Endpoints.Management.DeleteTenant, tenant);
        }
    }
}
