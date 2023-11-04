/* <copyright file="PermissionsApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 20:12:59</date>
 */

using Descope.Configuration;
using Descope.Extensions;
using Descope.HttpClient;
using Descope.Models;
using Descope.Utilities;
using RestSharp;

namespace Descope.Management.Permissions
{
    internal class PermissionsApiClient : IPermissionsApiClient
    {
        private readonly IDescopeManagementHttpClient _httpClient;

        public PermissionsApiClient(IDescopeManagementHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DescopePermissionListResponse> GetAll()
        {
            var request = Requests.GetRequest(Endpoints.Management.LoadAllPermissions);
            var restResponse = await _httpClient.Client.ExecuteGetAsync(request);
            return _httpClient.Client.Serializers.DeserializeResponse<DescopePermissionListResponse>(restResponse);
        }

        public async Task<DescopePermission> Create(DescopePermission permission)
        {
            var request = Requests.JsonPostRequest(Endpoints.Management.CreatePermission, permission);
            var restResponse = await _httpClient.Client.ExecutePostAsync(request);
            _httpClient.Client.Serializers.ParseResponse(restResponse);
            return permission;
        }

        public async Task<DescopePermission> Update(DescopePermissionUpdateRequest permission)
        {
            var request = Requests.JsonPostRequest(Endpoints.Management.UpdatePermission, permission);
            var restResponse = await _httpClient.Client.ExecutePostAsync(request);
            _httpClient.Client.Serializers.ParseResponse(restResponse);
            return new DescopePermission
            {
                Name = permission.NewName,
                Description = permission.Description
            };
        }

        public async Task Delete(DescopePermissionDeleteRequest permission)
        {
            var request = Requests.JsonPostRequest(Endpoints.Management.DeletePermission, permission);
            var restResponse = await _httpClient.Client.ExecutePostAsync(request);
            _httpClient.Client.Serializers.ParseResponse(restResponse);
        }
    }
}
