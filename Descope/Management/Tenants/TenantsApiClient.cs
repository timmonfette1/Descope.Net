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

        public async Task<DescopeTenant> Create(DescopeTenant tenant)
        {
            var request = Requests.JsonPostRequest(Endpoints.Management.CreateTenant, tenant);            
            var restResponse = await _httpClient.Client.ExecutePostAsync(request);
            var response = _httpClient.Client.Serializers.DeserializeResponse<DescopeTenant>(restResponse);
            tenant.Id = response.Id;

            return tenant;
        }

        public async Task<DescopeTenant> Update(DescopeTenant tenant)
        {
            var request = Requests.JsonPostRequest(Endpoints.Management.UpdateTenant, tenant);
            var restResponse = await _httpClient.Client.ExecutePostAsync(request);
            _httpClient.Client.Serializers.ParseResponse(restResponse);
            return tenant;
        }
    }
}
