using Descope.Models;

namespace Descope.Management.Users
{
    public interface IUsersApiClient
    {
        Task<DescopeUser> GetByUserId(string userId);
        Task<DescopeUser> GetByLoginId(string loginId);
        Task<DescopeUserOAuthToken> GetProviderToken(string loginId, string provider);
        Task<IEnumerable<DescopeUser>> Search(DescopeUserSearchRequest search);
        Task<DescopeUser> Create(DescopeUserCreateRequest user);
        Task<DescopeUserBatchCreateResponse> BatchCreate(DescopeUserBatchCreateRequest users);
        Task<DescopeUser> Update(string loginId, DescopeUser user);
        Task<DescopeUser> UpdateStatus(string loginId, string status);
        Task<DescopeUser> UpdateEmail(string loginId, string email, bool verified);
        Task<DescopeUser> UpdateLoginId(string loginId, string newLoginId);
        Task<DescopeUser> UpdatePhone(string loginId, string phone, bool verified);
        Task<DescopeUser> UpdateName(string loginId, string givenName, string middleName, string familyName, string displayName = null);
        Task<DescopeUser> UpdatePicture(string loginId, string picture);
        Task<DescopeUser> UpdateCustomAttribute(string loginId, string key, object value);
        Task<DescopeUser> AddTenant(string loginId, string tenantId);
        Task<DescopeUser> RemoveTenant(string loginId, string tenantId);
        Task<DescopeUser> AddRoles(string loginId, string tenantId, IEnumerable<string> roleNames);
        Task<DescopeUser> RemoveRoles(string loginId, string tenantId, IEnumerable<string> roleNames);
        Task SetPassword(string loginId, string password);
        Task ExpirePassword(string loginId);
        Task<DescopeUser> LogoutByUserId(string userId);
        Task<DescopeUser> LogoutByLoginId(string loginId);
        Task Delete(string loginId);
    }
}
