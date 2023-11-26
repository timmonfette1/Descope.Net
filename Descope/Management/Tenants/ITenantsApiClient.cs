using Descope.Models;

namespace Descope.Management.Tenants
{
    public interface ITenantsApiClient
    {
        Task<IEnumerable<DescopeTenant>> GetAll();
        Task<DescopeTenant> Get(string id);
        Task<IEnumerable<DescopeTenant>> Search(DescopeTenantSearchRequest search);
        Task<DescopeTenant> Create(DescopeTenant tenant);
        Task<DescopeTenant> Update(DescopeTenant tenant);
        Task Delete(string id);
    }
}
