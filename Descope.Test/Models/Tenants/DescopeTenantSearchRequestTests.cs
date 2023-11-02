/* <copyright file="DescopeTenantSearchRequestTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/26/2023 22:15:54</date>
 */

using Descope.Models;

namespace Descope.Test.Models.Tenants
{
    public class DescopeTenantSearchRequestTests
    {
        [Fact]
        public void ShouldCreateObject()
        {
            var search = new DescopeTenantSearchRequest
            {
                TenantIds = new string[1] { "1" },
                TenantNames = new string[2] { "One", "Two" },
                TenantSelfProvisioningDomains = new string[1] { "My Domain" },
                CustomAttributes = new
                {
                    Attr1 = "Value"
                },
            };

            Assert.Single(search.TenantIds);
            Assert.Equal("1", search.TenantIds[0]);
            Assert.Equal(2, search.TenantNames.Length);
            Assert.Equal("One", search.TenantNames[0]);
            Assert.Equal("Two", search.TenantNames[1]);
            Assert.Single(search.TenantSelfProvisioningDomains);
            Assert.Equal("My Domain", search.TenantSelfProvisioningDomains[0]);
            Assert.NotNull(search.CustomAttributes);
        }
    }
}
