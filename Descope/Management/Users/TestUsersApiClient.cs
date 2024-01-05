using Descope.Configuration;
using Descope.HttpClient;
using Descope.Models;

namespace Descope.Management.Users
{
    internal class TestUsersApiClient(IDescopeManagementHttpClient httpClient) : ITestUsersApiClient
    {
        private readonly IDescopeManagementHttpClient _httpClient = httpClient;

        public async Task<DescopeTestUserOtp> GenerateOtp(string loginId, string deliveryMethod, DescopeLoginOptions loginOptions)
        {
            var request = new
            {
                loginId,
                deliveryMethod,
                loginOptions
            };

            return await _httpClient.PostAsync<object, DescopeTestUserOtp>(Endpoints.Management.GenerateTestUserOtp, request);
        }

        public async Task<DescopeTestUserMagicLink> GenerateMagicLink(string loginId, string deliveryMethod, string redirectUrl, DescopeLoginOptions loginOptions)
        {
            var request = new
            {
                loginId,
                deliveryMethod,
                redirectUrl,
                loginOptions
            };

            return await _httpClient.PostAsync<object, DescopeTestUserMagicLink>(Endpoints.Management.GenerateTestUserMagicLink, request);
        }

        public async Task<DescopeTestUserEnchantedLink> GenerateEnchantedLink(string loginId, string redirectUrl, DescopeLoginOptions loginOptions)
        {
            var request = new
            {
                loginId,
                redirectUrl,
                loginOptions
            };

            return await _httpClient.PostAsync<object, DescopeTestUserEnchantedLink>(Endpoints.Management.GenerateTestUserEnchantedLink, request);
        }

        public async Task DeleteAll()
        {
            await _httpClient.DeleteAsync(Endpoints.Management.DeleteTestUsers);
        }
    }
}
