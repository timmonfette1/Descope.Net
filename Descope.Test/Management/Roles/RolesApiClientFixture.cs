using Descope.Management.Roles;

namespace Descope.Test.Management.Roles
{
    public class RolesApiClientFixture
    {
        private readonly RolesApiClient _rolesApiClient;

        public RolesApiClientFixture(ClientServerFixture fixture)
        {
            _rolesApiClient = new RolesApiClient(fixture.HttpClient);
        }

        internal RolesApiClient RolesApiClient => _rolesApiClient;
    }
}
