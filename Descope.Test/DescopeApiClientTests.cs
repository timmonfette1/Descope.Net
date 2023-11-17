using Descope.Management;
using NSubstitute;

namespace Descope.Test
{
    public class DescopeApiClientTests
    {
        [Fact]
        public void ShouldGetSubClients()
        {
            var mgmtMock = Substitute.For<IManagementApiClient>();
            var client = new DescopeApiClient(mgmtMock);

            Assert.IsAssignableFrom<IManagementApiClient>(client.Management);
        }
    }
}
