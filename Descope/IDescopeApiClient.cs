using Descope.Management;

namespace Descope
{
    public interface IDescopeApiClient
    {
        IManagementApiClient Management { get; }
    }
}
