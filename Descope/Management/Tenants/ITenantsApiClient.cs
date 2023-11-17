using Descope.Models;

namespace Descope.Management.Tenants
{
    public interface ITenantsApiClient
    {
        Task<DescopeTenantListResponse> GetAll();
        Task<DescopeTenant> Get(string id);
        Task<DescopeTenantListResponse> Search(DescopeTenantSearchRequest search);
        Task<DescopeTenant> Create(DescopeTenant tenant);
        Task<DescopeTenant> Update(DescopeTenant tenant);
        Task Delete(DescopeTenantDeleteRequest tenant);
    }
}
