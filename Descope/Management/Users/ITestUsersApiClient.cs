using Descope.Models;

namespace Descope.Management.Users
{
    public interface ITestUsersApiClient
    {
        Task<DescopeTestUserOtp> GenerateOtp(string loginId, string deliveryMethod, DescopeLoginOptions loginOptions);
        Task<DescopeTestUserMagicLink> GenerateMagicLink(string loginId, string deliveryMethod, string redirectUrl, DescopeLoginOptions loginOptions);
        Task<DescopeTestUserEnchantedLink> GenerateEnchantedLink(string loginId, string redirectUrl, DescopeLoginOptions loginOptions);
        Task DeleteAll();
    }
}
