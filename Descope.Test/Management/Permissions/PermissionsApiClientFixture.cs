using Descope.Management.Permissions;

namespace Descope.Test.Management.Permissions
{
    public class PermissionsApiClientFixture(ClientServerFixture fixture)
    {
        private readonly PermissionsApiClient _permissionsApiClient = new(fixture.ManagementHttpClient);

        internal PermissionsApiClient PermissionsApiClient => _permissionsApiClient;
    }
}
