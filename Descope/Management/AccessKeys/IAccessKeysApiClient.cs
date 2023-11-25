using Descope.Models;

namespace Descope.Management.AccessKeys
{
    public interface IAccessKeysApiClient
    {
        Task<DescopeAccessKey> Get(string id);
        Task<IEnumerable<DescopeAccessKey>> Search(params string[] tenantIds);
        Task<DescopeAccessKeyCreateResponse> Create(DescopeAccessKeyCreateRequest accessKey);
        Task<DescopeAccessKey> Update(string id, string name);
        Task Activate(string id);
        Task Deactivate(string id);
        Task Delete(string id);
    }
}
