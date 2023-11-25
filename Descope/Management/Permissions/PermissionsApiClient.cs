using Descope.Configuration;
using Descope.HttpClient;
using Descope.Models;

namespace Descope.Management.Permissions
{
    internal class PermissionsApiClient(IDescopeManagementHttpClient httpClient) : IPermissionsApiClient
    {
        private readonly IDescopeManagementHttpClient _httpClient = httpClient;

        public async Task<DescopePermissionListResponse> GetAll()
        {
            return await _httpClient.GetAsync<DescopePermissionListResponse>(Endpoints.Management.LoadAllPermissions);
        }

        public async Task<DescopePermission> Create(DescopePermission permission)
        {
            await _httpClient.PostAsync(Endpoints.Management.CreatePermission, permission);
            return permission;
        }

        public async Task<DescopePermission> Update(DescopePermission permission, string newName)
        {
            var request = new DescopePermissionUpdateRequest
            {
                Name = permission.Name,
                NewName = newName,
                Description = permission.Description,
            };

            await _httpClient.PostAsync(Endpoints.Management.UpdatePermission, request);
            return new DescopePermission
            {
                Name = newName,
                Description = permission.Description
            };
        }

        public async Task Delete(string name)
        {
            var request = new DescopePermissionDeleteRequest
            {
                Name = name
            };

            await _httpClient.PostAsync(Endpoints.Management.DeletePermission, request);
        }
    }
}
