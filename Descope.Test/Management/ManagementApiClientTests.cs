using Descope.Management;
using Descope.Management.AccessKeys;
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
            var accessKeyMock = Substitute.For<IAccessKeysApiClient>();
            var permissionMock = Substitute.For<IPermissionsApiClient>();
            var roleMock = Substitute.For<IRolesApiClient>();
            var tenantMock = Substitute.For<ITenantsApiClient>();
            var client = new ManagementApiClient(accessKeyMock, permissionMock, roleMock, tenantMock);

            Assert.IsAssignableFrom<IAccessKeysApiClient>(client.AccessKeys);
            Assert.IsAssignableFrom<IPermissionsApiClient>(client.Permissions);
            Assert.IsAssignableFrom<IRolesApiClient>(client.Roles);
            Assert.IsAssignableFrom<ITenantsApiClient>(client.Tenants);
        }
    }
}
