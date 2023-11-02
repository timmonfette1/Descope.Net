/* <copyright file="DescopeTenantDeleteRequestTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/26/2023 22:14:48</date>
 */

using Descope.Models;

namespace Descope.Test.Models.Tenants
{
    public class DescopeTenantDeleteRequestTests
    {
        [Fact]
        public void ShouldCreateObject()
        {
            var request = new DescopeTenantDeleteRequest
            {
                Id = "My Id"
            };

            Assert.Equal("My Id", request.Id);
        }
    }
}
