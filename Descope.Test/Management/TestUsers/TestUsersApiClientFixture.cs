using Descope.Management.Users;

namespace Descope.Test.Management.TestUsers
{
    public class TestUsersApiClientFixture(ClientServerFixture fixture)
    {
        private readonly TestUsersApiClient _testUsersApiClient = new(fixture.HttpClient);

        internal TestUsersApiClient TestUsersApiClient => _testUsersApiClient;
    }
}
