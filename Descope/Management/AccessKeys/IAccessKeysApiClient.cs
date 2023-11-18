using Descope.Models;

namespace Descope.Management.AccessKeys
{
    public interface IAccessKeysApiClient
    {
        Task<DescopeAccessKey> Get(string id);
        Task<DescopeAccessKeyListResponse> Search(DescopeAccessKeySearchRequest search);
        Task<DescopeAccessKeyCreateResponse> Create(DescopeAccessKeyCreateRequest accessKey);
        Task<DescopeAccessKey> Update(DescopeAccessKeyUpdateRequest accessKey);
        Task Activate(DescopeAccessKeyStatusChangeRequest accessKey);
        Task Deactivate(DescopeAccessKeyStatusChangeRequest accessKey);
        Task Delete(DescopeAccessKeyStatusChangeRequest accessKey);
    }
}
