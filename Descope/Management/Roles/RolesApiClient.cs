using Descope.Configuration;
using Descope.HttpClient;
using Descope.Models;

namespace Descope.Management.Roles
{
    internal class RolesApiClient(IDescopeManagementHttpClient httpClient) : IRolesApiClient
    {
        private readonly IDescopeManagementHttpClient _httpClient = httpClient;

        public async Task<DescopeRoleListResponse> GetAll()
        {
            return await _httpClient.GetAsync<DescopeRoleListResponse>(Endpoints.Management.LoadAllRoles);
        }

        public async Task<DescopeRole> Create(DescopeRole role)
        {
            await _httpClient.PostAsync(Endpoints.Management.CreateRole, role);
            return role;
        }

        public async Task<DescopeRole> Update(DescopeRole role, string newName)
        {
            var request = new DescopeRoleUpdateRequest
            {
                Name = role.Name,
                NewName = newName,
                Description = role.Description,
                PermissionNames = role.PermissionNames,
            };

            await _httpClient.PostAsync(Endpoints.Management.UpdateRole, request);
            return new DescopeRole
            {
                Name = newName,
                Description = role.Description,
                PermissionNames = role.PermissionNames
            };
        }

        public async Task Delete(string name)
        {
            var request = new DescopeRoleDeleteRequest
            {
                Name = name
            };
            await _httpClient.PostAsync(Endpoints.Management.DeleteRole, request);
        }
    }
}
