using Descope.Management.Tenants;

namespace Descope.Test.Management.Tenants
{
    public class TenantsApiClientFixture
    {
        private readonly TenantsApiClient _tenantsApiClient;

        public TenantsApiClientFixture(ClientServerFixture fixture)
        {
            _tenantsApiClient = new TenantsApiClient(fixture.HttpClient);
        }

        internal TenantsApiClient TenantsApiClient => _tenantsApiClient;
    }
}
