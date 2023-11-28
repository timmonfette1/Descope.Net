using Descope.Management;
using Descope.Management.AccessKeys;
using Descope.Management.Audit;
using Descope.Management.Flows;
using Descope.Management.Permissions;
using Descope.Management.Roles;
using Descope.Management.Tenants;
using Descope.Management.Themes;
using NSubstitute;

namespace Descope.Test.Management
{
    public class ManagementApiClientTests
    {
        [Fact]
        public void ShouldGetSubClients()
        {
            var accessKeyMock = Substitute.For<IAccessKeysApiClient>();
            var auditMock = Substitute.For<IAuditApiClient>();
            var flowMock = Substitute.For<IFlowsApiClient>();
            var permissionMock = Substitute.For<IPermissionsApiClient>();
            var roleMock = Substitute.For<IRolesApiClient>();
            var tenantMock = Substitute.For<ITenantsApiClient>();
            var themeMock = Substitute.For<IThemesApiClient>();
            var client = new ManagementApiClient(accessKeyMock, auditMock, flowMock, permissionMock, roleMock, tenantMock, themeMock);

            Assert.IsAssignableFrom<IAccessKeysApiClient>(client.AccessKeys);
            Assert.IsAssignableFrom<IAuditApiClient>(client.Audit);
            Assert.IsAssignableFrom<IFlowsApiClient>(client.Flows);
            Assert.IsAssignableFrom<IPermissionsApiClient>(client.Permissions);
            Assert.IsAssignableFrom<IRolesApiClient>(client.Roles);
            Assert.IsAssignableFrom<ITenantsApiClient>(client.Tenants);
            Assert.IsAssignableFrom<IThemesApiClient>(client.Themes);
        }
    }
}
