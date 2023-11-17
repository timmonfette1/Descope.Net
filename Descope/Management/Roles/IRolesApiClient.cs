using Descope.Models;

namespace Descope.Management.Roles
{
    public interface IRolesApiClient
    {
        Task<DescopeRoleListResponse> GetAll();
        Task<DescopeRole> Create(DescopeRole role);
        Task<DescopeRole> Update(DescopeRoleUpdateRequest role);
        Task Delete(DescopeRoleDeleteRequest role);
    }
}
