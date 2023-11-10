/* <copyright file="TenantsApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/24/2023 20:54:35</date>
 */

using Descope.Configuration;
using Descope.HttpClient;
using Descope.Models;

namespace Descope.Management.Tenants
{
    internal class TenantsApiClient : BaseManagementApiClient, ITenantsApiClient
    {
        private readonly IDescopeManagementHttpClient _httpClient;

        public TenantsApiClient(IDescopeManagementHttpClient httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DescopeTenantListResponse> GetAll()
        {
            return await GetAsync<DescopeTenantListResponse>(Endpoints.Management.LoadAllTenants);
        }

        public async Task<DescopeTenant> Get(string id)
        {
            return await GetAsync<DescopeTenant>(Endpoints.Management.LoadTenant, new { id });
        }

        public async Task<DescopeTenantListResponse> Search(DescopeTenantSearchRequest search)
        {
            return await PostAsync<DescopeTenantListResponse, DescopeTenantSearchRequest>(Endpoints.Management.SearchTenants, search);
        }

        public async Task<DescopeTenant> Create(DescopeTenant tenant)
        {
            var response = await PostAsync<DescopeTenant, DescopeTenant>(Endpoints.Management.CreateTenant, tenant);
            tenant.Id = response.Id;
            return tenant;
        }

        public async Task<DescopeTenant> Update(DescopeTenant tenant)
        {
            await PostAsync(Endpoints.Management.UpdateTenant, tenant);
            return tenant;
        }

        public async Task Delete(DescopeTenantDeleteRequest tenant)
        {
            await PostAsync(Endpoints.Management.DeleteTenant, tenant);
        }
    }
}
