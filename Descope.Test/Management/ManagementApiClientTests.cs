/* <copyright file="ManagementApiClientTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/28/2023 21:39:48</date>
 */

using Descope.Management;
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
            var userMock = Substitute.For<IUsersApiClient>();
            var tenantMock = Substitute.For<ITenantsApiClient>();
            var client = new ManagementApiClient(userMock, tenantMock);

            Assert.IsAssignableFrom<IUsersApiClient>(client.Users);
            Assert.IsAssignableFrom<ITenantsApiClient>(client.Tenants);
        }
    }
}
