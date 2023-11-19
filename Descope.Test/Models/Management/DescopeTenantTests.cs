using Descope.Models;

namespace Descope.Test.Models.Management
{
    public class DescopeTenantTests
    {
        [Fact]
        public void ShouldCreateObject_Tenant()
        {
            var tenant = new DescopeTenant
            {
                Id = "Id",
                Name = "Name",
                SelfProvisioningDomains = new string[1] { "My Domain" },
                CustomAttributes = new
                {
                    Attr1 = "Value"
                }
            };

            Assert.Equal("Id", tenant.Id);
            Assert.Equal("Name", tenant.Name);
            Assert.Single(tenant.SelfProvisioningDomains);
            Assert.Equal("My Domain", tenant.SelfProvisioningDomains[0]);
            Assert.NotNull(tenant.CustomAttributes);
        }

        [Fact]
        public void ShouldCreateObject_TenantSearchRequest()
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

        [Fact]
        public void ShouldCreateObject_TenantListResponse()
        {
            var list = new DescopeTenantListResponse
            {
                Tenants = new DescopeTenant[2]
                {
                    new DescopeTenant
                    {
                        Id = "1",
                        Name = "One"
                    },
                    new DescopeTenant
                    {
                        Id = "2",
                        Name = "Two"
                    }
                }
            };

            Assert.Equal(2, list.Tenants.Count());
            Assert.Equal("1", list.Tenants.ElementAt(0).Id);
            Assert.Equal("One", list.Tenants.ElementAt(0).Name);
            Assert.Equal("2", list.Tenants.ElementAt(1).Id);
            Assert.Equal("Two", list.Tenants.ElementAt(1).Name);
        }

        [Fact]
        public void ShouldCreateObject_TenantDeleteRequest()
        {
            var request = new DescopeTenantDeleteRequest
            {
                Id = "My Id"
            };

            Assert.Equal("My Id", request.Id);
        }
    }
}
