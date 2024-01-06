using Descope.Auth;
using Descope.Management;
using NSubstitute;

namespace Descope.Test
{
    public class DescopeApiClientTests
    {
        [Fact]
        public void ShouldGetSubClients()
        {
            var authMock = Substitute.For<IAuthApiClient>();
            var mgmtMock = Substitute.For<IManagementApiClient>();
            var client = new DescopeApiClient(authMock, mgmtMock);

            Assert.IsAssignableFrom<IAuthApiClient>(client.Auth);
            Assert.IsAssignableFrom<IManagementApiClient>(client.Management);
        }
    }
}
