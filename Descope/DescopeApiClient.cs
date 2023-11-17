using Descope.Management;

namespace Descope
{
    internal class DescopeApiClient : IDescopeApiClient
    {
        private readonly IManagementApiClient _managementApiClient;

        public DescopeApiClient(IManagementApiClient managementApiClient)
        {
            _managementApiClient = managementApiClient;
        }

        public IManagementApiClient Management => _managementApiClient;
    }
}
