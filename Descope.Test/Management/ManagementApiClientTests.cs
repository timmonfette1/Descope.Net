using Descope.Management;
using Descope.Management.AccessKeys;
using Descope.Management.Audit;
using Descope.Management.Flows;
using Descope.Management.Permissions;
using Descope.Management.Roles;
using Descope.Management.Tenants;
using Descope.Management.Themes;
using Descope.Management.Users;
using NSubstitute;

namespace Descope.Test.Management
{
    public class ManagementApiClientTests
    {
        [Fact]
        public void ShouldGetSubClients()
        {
            var accessKeysMock = Substitute.For<IAccessKeysApiClient>();
            var auditMock = Substitute.For<IAuditApiClient>();
            var flowMock = Substitute.For<IFlowsApiClient>();
            var permissionMock = Substitute.For<IPermissionsApiClient>();
            var roleMock = Substitute.For<IRolesApiClient>();
            var tenantMock = Substitute.For<ITenantsApiClient>();
            var themeMock = Substitute.For<IThemesApiClient>();
            var testUserMock = Substitute.For<ITestUsersApiClient>();
            var userMock = Substitute.For<IUsersApiClient>();
            var client = new ManagementApiClient(accessKeysMock, auditMock, flowMock, permissionMock, roleMock, tenantMock, themeMock, testUserMock, userMock);

            Assert.IsAssignableFrom<IAccessKeysApiClient>(client.AccessKeys);
            Assert.IsAssignableFrom<IAuditApiClient>(client.Audit);
            Assert.IsAssignableFrom<IFlowsApiClient>(client.Flows);
            Assert.IsAssignableFrom<IPermissionsApiClient>(client.Permissions);
            Assert.IsAssignableFrom<IRolesApiClient>(client.Roles);
            Assert.IsAssignableFrom<ITenantsApiClient>(client.Tenants);
            Assert.IsAssignableFrom<IThemesApiClient>(client.Themes);
            Assert.IsAssignableFrom<ITestUsersApiClient>(client.TestUsers);
            Assert.IsAssignableFrom<IUsersApiClient>(client.Users);
        }
    }
}
