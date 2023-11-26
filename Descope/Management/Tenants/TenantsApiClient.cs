using Descope.Configuration;
using Descope.HttpClient;
using Descope.Models;

namespace Descope.Management.Tenants
{
    internal class TenantsApiClient(IDescopeManagementHttpClient httpClient) : ITenantsApiClient
    {
        private readonly IDescopeManagementHttpClient _httpClient = httpClient;

        public async Task<IEnumerable<DescopeTenant>> GetAll()
        {
            var response = await _httpClient.GetAsync<DescopeTenantListResponse>(Endpoints.Management.LoadAllTenants);
            return response.Tenants;
        }

        public async Task<DescopeTenant> Get(string id)
        {
            return await _httpClient.GetAsync<DescopeTenant>(Endpoints.Management.LoadTenant, new { id });
        }

        public async Task<IEnumerable<DescopeTenant>> Search(DescopeTenantSearchRequest search)
        {
            var response = await _httpClient.PostAsync<DescopeTenantSearchRequest, DescopeTenantListResponse>(Endpoints.Management.SearchTenants, search);
            return response.Tenants;
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

        public async Task Delete(string id)
        {
            var request = new DescopeIdModel
            {
                Id = id
            };

            await _httpClient.PostAsync(Endpoints.Management.DeleteTenant, request);
        }
    }
}
