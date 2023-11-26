using Descope.Models;

namespace Descope.Management.Permissions
{
    public interface IPermissionsApiClient
    {
        Task<IEnumerable<DescopePermission>> GetAll();
        Task<DescopePermission> Create(DescopePermission permission);
        Task<DescopePermission> Update(DescopePermission permission, string newName);
        Task Delete(string name);
    }
}
