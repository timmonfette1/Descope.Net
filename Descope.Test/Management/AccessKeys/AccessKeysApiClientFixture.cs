using Descope.Management.AccessKeys;

namespace Descope.Test.Management.AccessKeys
{
    public class AccessKeysApiClientFixture
    {
        private readonly AccessKeysApiClient _accessKeysApiClient;

        public AccessKeysApiClientFixture(ClientServerFixture fixture)
        {
            _accessKeysApiClient = new AccessKeysApiClient(fixture.HttpClient);
        }

        internal AccessKeysApiClient AccessKeysApiClient => _accessKeysApiClient;
    }
}
