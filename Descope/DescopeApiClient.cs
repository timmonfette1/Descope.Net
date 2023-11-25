using Descope.Management;

namespace Descope
{
    internal class DescopeApiClient(IManagementApiClient managementApiClient) : IDescopeApiClient
    {
        private readonly IManagementApiClient _managementApiClient = managementApiClient;

        public IManagementApiClient Management => _managementApiClient;
    }
}
