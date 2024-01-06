using Descope.Management.Roles;

namespace Descope.Test.Management.Roles
{
    public class RolesApiClientFixture(ClientServerFixture fixture)
    {
        private readonly RolesApiClient _rolesApiClient = new(fixture.ManagementHttpClient);

        internal RolesApiClient RolesApiClient => _rolesApiClient;
    }
}
