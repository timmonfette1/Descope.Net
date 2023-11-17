using Descope.Management;
using Descope.Management.Permissions;
using Descope.Management.Roles;
using Descope.Management.Tenants;
using NSubstitute;

namespace Descope.Test.Management
{
    public class ManagementApiClientTests
    {
        [Fact]
        public void ShouldGetSubClients()
        {
            var permissionMock = Substitute.For<IPermissionsApiClient>();
            var roleMock = Substitute.For<IRolesApiClient>();
            var tenantMock = Substitute.For<ITenantsApiClient>();
            var client = new ManagementApiClient(permissionMock, roleMock, tenantMock);

            Assert.IsAssignableFrom<IPermissionsApiClient>(client.Permissions);
            Assert.IsAssignableFrom<IRolesApiClient>(client.Roles);
            Assert.IsAssignableFrom<ITenantsApiClient>(client.Tenants);
        }
    }
}
