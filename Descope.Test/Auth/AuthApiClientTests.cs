using Descope.Auth;
using Descope.Auth.AccessKey;
using NSubstitute;

namespace Descope.Test.Auth
{
    public class AuthApiClientTests
    {
        [Fact]
        public void ShouldGetSubClients()
        {
            var accessKeyMock = Substitute.For<IAccessKeyApiClient>();
            var client = new AuthApiClient(accessKeyMock);

            Assert.IsAssignableFrom<IAccessKeyApiClient>(client.AccessKey);
        }
    }
}
