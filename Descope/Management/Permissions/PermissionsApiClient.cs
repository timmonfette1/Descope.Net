using Descope.Configuration;
using Descope.HttpClient;
using Descope.Models;

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
            return await _httpClient.GetAsync<DescopePermissionListResponse>(Endpoints.Management.LoadAllPermissions);
        }

        public async Task<DescopePermission> Create(DescopePermission permission)
        {
            await _httpClient.PostAsync(Endpoints.Management.CreatePermission, permission);
            return permission;
        }

        public async Task<DescopePermission> Update(DescopePermissionUpdateRequest permission)
        {
            await _httpClient.PostAsync(Endpoints.Management.UpdatePermission, permission);
            return new DescopePermission
            {
                Name = permission.NewName,
                Description = permission.Description
            };
        }

        public async Task Delete(DescopePermissionDeleteRequest permission)
        {
            await _httpClient.PostAsync(Endpoints.Management.DeletePermission, permission);
        }
    }
}
