using Descope.Models;

namespace Descope.Management.Roles
{
    public interface IRolesApiClient
    {
        Task<IEnumerable<DescopeRole>> GetAll();
        Task<DescopeRole> Create(DescopeRole role);
        Task<DescopeRole> Update(DescopeRole role, string newName);
        Task Delete(string name);
    }
}
