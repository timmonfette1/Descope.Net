/* <copyright file="ManagementApiClientTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/28/2023 21:39:48</date>
 */

using Descope.Management;
using Descope.Management.Permissions;
using Descope.Management.Roles;
using Descope.Management.Tenants;
using Descope.Management.Users;
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
            var userMock = Substitute.For<IUsersApiClient>();
            var client = new ManagementApiClient(permissionMock, roleMock, tenantMock, userMock);

            Assert.IsAssignableFrom<IPermissionsApiClient>(client.Permissions);
            Assert.IsAssignableFrom<IRolesApiClient>(client.Roles);
            Assert.IsAssignableFrom<ITenantsApiClient>(client.Tenants);
            Assert.IsAssignableFrom<IUsersApiClient>(client.Users);
        }
    }
}
