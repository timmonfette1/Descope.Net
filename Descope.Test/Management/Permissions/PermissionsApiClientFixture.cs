using Descope.Management.Permissions;

namespace Descope.Test.Management.Permissions
{
    public class PermissionsApiClientFixture
    {
        private readonly PermissionsApiClient _permissionsApiClient;

        public PermissionsApiClientFixture(ClientServerFixture fixture)
        {
            _permissionsApiClient = new PermissionsApiClient(fixture.HttpClient);
        }

        internal PermissionsApiClient PermissionsApiClient => _permissionsApiClient;
    }
}
