/* <copyright file="DescopeApiClientTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/27/2023 22:18:01</date>
 */

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
