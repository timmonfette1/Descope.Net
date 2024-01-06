using Descope.Auth.AccessKey;

namespace Descope.Test.Auth.AccessKey
{
    public class AccessKeyApiClientFixture(ClientServerFixture fixture)
    {
        private readonly AccessKeyApiClient _accessKeyApiClient = new(fixture.AuthHttpClient);

        internal AccessKeyApiClient AccessKeyApiClient => _accessKeyApiClient;
    }
}
