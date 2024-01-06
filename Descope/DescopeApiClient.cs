using Descope.Auth;
using Descope.Management;

namespace Descope
{
    internal class DescopeApiClient(IAuthApiClient authApiClient, IManagementApiClient managementApiClient) : IDescopeApiClient
    {
        private readonly IAuthApiClient _authApiClient = authApiClient;
        private readonly IManagementApiClient _managementApiClient = managementApiClient;

        public IAuthApiClient Auth => _authApiClient;
        public IManagementApiClient Management => _managementApiClient;
    }
}
