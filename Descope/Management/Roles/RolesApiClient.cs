/* <copyright file="RolesApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 23:11:25</date>
 */

using Descope.Configuration;
using Descope.HttpClient;
using Descope.Models;

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
            return await _httpClient.GetAsync<DescopeRoleListResponse>(Endpoints.Management.LoadAllRoles);
        }

        public async Task<DescopeRole> Create(DescopeRole role)
        {
            await _httpClient.PostAsync(Endpoints.Management.CreateRole, role);
            return role;
        }

        public async Task<DescopeRole> Update(DescopeRoleUpdateRequest role)
        {
            await _httpClient.PostAsync(Endpoints.Management.UpdateRole, role);
            return new DescopeRole
            {
                Name = role.NewName,
                Description = role.Description,
                PermissionNames = role.PermissionNames
            };
        }

        public async Task Delete(DescopeRoleDeleteRequest role)
        {
            await _httpClient.PostAsync(Endpoints.Management.DeleteRole, role);
        }
    }
}
