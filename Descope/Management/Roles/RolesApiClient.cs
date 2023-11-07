/* <copyright file="RolesApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 23:11:25</date>
 */

using Descope.Configuration;
using Descope.Extensions;
using Descope.HttpClient;
using Descope.Models;
using Descope.Utilities;
using RestSharp;

namespace Descope.Management.Roles
{
    internal class RolesApiClient : IRolesApiClient
    {
        private readonly IDescopeManagementHttpClient _httpClient;

        public RolesApiClient(IDescopeManagementHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DescopeRoleListResponse> GetAll()
        {
            var request = Requests.GetRequest(Endpoints.Management.LoadAllRoles);
            var restResponse = await _httpClient.Client.ExecuteGetAsync(request);
            return _httpClient.Client.Serializers.DeserializeResponse<DescopeRoleListResponse>(restResponse);
        }

        public async Task<DescopeRole> Create(DescopeRole role)
        {
            var request = Requests.JsonPostRequest(Endpoints.Management.CreateRole, role);
            var restResponse = await _httpClient.Client.ExecutePostAsync(request);
            _httpClient.Client.Serializers.ParseResponse(restResponse);
            return role;
        }

        public async Task<DescopeRole> Update(DescopeRoleUpdateRequest role)
        {
            var request = Requests.JsonPostRequest(Endpoints.Management.UpdateRole, role);
            var restResponse = await _httpClient.Client.ExecutePostAsync(request);
            _httpClient.Client.Serializers.ParseResponse(restResponse);
            return new DescopeRole
            {
                Name = role.NewName,
                Description = role.Description,
                PermissionNames = role.PermissionNames
            };
        }

        public async Task Delete(DescopeRoleDeleteRequest role)
        {
            var request = Requests.JsonPostRequest(Endpoints.Management.DeleteRole, role);
            var restResponse = await _httpClient.Client.ExecutePostAsync(request);
            _httpClient.Client.Serializers.ParseResponse(restResponse);
        }
    }
}
