using Descope.Auth;
using Descope.Management;

namespace Descope
{
    public interface IDescopeApiClient
    {
        IAuthApiClient Auth { get; }
        IManagementApiClient Management { get; }
    }
}
