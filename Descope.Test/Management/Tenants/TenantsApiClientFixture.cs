using Descope.Management.Tenants;

namespace Descope.Test.Management.Tenants
{
    public class TenantsApiClientFixture(ClientServerFixture fixture)
    {
        private readonly TenantsApiClient _tenantsApiClient = new(fixture.ManagementHttpClient);

        internal TenantsApiClient TenantsApiClient => _tenantsApiClient;
    }
}
