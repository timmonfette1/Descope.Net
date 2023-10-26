/* <copyright file="TenantsApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/24/2023 20:54:35</date>
 */

using Descope.Configuration;
using Descope.Extensions;
using Descope.HttpClient;
using Descope.Models;
using Descope.Utilities;
using RestSharp;

namespace Descope.Management.Tenants
{
    internal class TenantsApiClient : ITenantsApiClient
    {
        private readonly IDescopeManagementHttpClient _httpClient;

        internal TenantsApiClient(IDescopeManagementHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DescopeTenantListResponse> GetAll()
        {
            var request = Requests.GetRequest(Endpoints.Management.LoadAllTenants);
            var restResponse = await _httpClient.Client.ExecuteGetAsync(request);
            return _httpClient.Client.Serializers.DeserializeResponse<DescopeTenantListResponse>(restResponse);
        }

        public async Task<DescopeTenantResponse> Get(string id)
        {
            var request = Requests.GetRequest(Endpoints.Management.LoadTenant);
            request.AddQueryParameter("id", id);

            var restResponse = await _httpClient.Client.ExecuteGetAsync(request);
            return _httpClient.Client.Serializers.DeserializeResponse<DescopeTenantResponse>(restResponse);
        }

        public async Task<DescopeTenantListResponse> Search(DescopeTenantSearchRequest search)
        {
            var request = Requests.JsonPostRequest(Endpoints.Management.SearchTenants, search);
            var restResponse = await _httpClient.Client.ExecutePostAsync(request);
            return _httpClient.Client.Serializers.DeserializeResponse<DescopeTenantListResponse>(restResponse);
        }

        public async Task<DescopeTenantResponse> Create(DescopeTenant tenant)
        {
            var request = Requests.JsonPostRequest(Endpoints.Management.CreateTenant, tenant);
            var restResponse = await _httpClient.Client.ExecutePostAsync(request);
            var response = _httpClient.Client.Serializers.DeserializeResponse<DescopeTenant>(restResponse);
            tenant.Id = response.Id;

            return new DescopeTenantResponse
            {
                Tenant = tenant
            };
        }

        public async Task<DescopeTenantResponse> Update(DescopeTenant tenant)
        {
            var request = Requests.JsonPostRequest(Endpoints.Management.UpdateTenant, tenant);
            var restResponse = await _httpClient.Client.ExecutePostAsync(request);
            _httpClient.Client.Serializers.ParseResponse(restResponse);

            return new DescopeTenantResponse
            {
                Tenant = tenant
            };
        }

        public async Task Delete(DescopeTenantDeleteRequest tenant)
        {
            var request = Requests.JsonPostRequest(Endpoints.Management.DeleteTenant, tenant);
            var restResponse = await _httpClient.Client.ExecutePostAsync(request);
            _httpClient.Client.Serializers.ParseResponse(restResponse);
        }
    }
}
