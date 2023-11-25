using Descope.Management.AccessKeys;

namespace Descope.Test.Management.AccessKeys
{
    public class AccessKeysApiClientFixture(ClientServerFixture fixture)
    {
        private readonly AccessKeysApiClient _accessKeysApiClient = new(fixture.HttpClient);

        internal AccessKeysApiClient AccessKeysApiClient => _accessKeysApiClient;
    }
}
