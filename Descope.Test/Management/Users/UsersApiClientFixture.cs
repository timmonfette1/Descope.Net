using Descope.Management.Users;

namespace Descope.Test.Management.Users
{
    public class UsersApiClientFixture(ClientServerFixture fixture)
    {
        private readonly UsersApiClient _usersApiClient = new(fixture.ManagementHttpClient);

        internal UsersApiClient UsersApiClient => _usersApiClient;
    }
}
