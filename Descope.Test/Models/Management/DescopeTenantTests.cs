using Descope.Models;

namespace Descope.Test.Models.Management
{
    public class DescopeTenantTests
    {
        [Fact]
        public void ShouldCreateObject_TenantSearchRequest()
        {
            var search = new DescopeTenantSearchRequest
            {
                TenantIds = ["1"],
                TenantNames = ["One", "Two"],
                TenantSelfProvisioningDomains = ["My Domain"],
                CustomAttributes = new
                {
                    Attr1 = "Value"
                },
            };

            Assert.Single(search.TenantIds);
            Assert.Equal("1", search.TenantIds.ElementAt(0));
            Assert.Equal(2, search.TenantNames.Count());
            Assert.Equal("One", search.TenantNames.ElementAt(0));
            Assert.Equal("Two", search.TenantNames.ElementAt(1));
            Assert.Single(search.TenantSelfProvisioningDomains);
            Assert.Equal("My Domain", search.TenantSelfProvisioningDomains.ElementAt(0));
            Assert.NotNull(search.CustomAttributes);
        }

        [Fact]
        public void ShouldCreateObject_TenantListResponse()
        {
            var list = new DescopeTenantListResponse
            {
                Tenants =
                [
                    new()
                    {
                        Id = "1",
                        Name = "One",
                        SelfProvisioningDomains = ["My One Domain"],
                        CustomAttributes = new
                        {
                            Attr1 = "One Value"
                        }
                    },
                    new()
                    {
                        Id = "2",
                        Name = "Two",
                        SelfProvisioningDomains = ["My Two Domain"],
                        CustomAttributes = new
                        {
                            Attr1 = "Two Value"
                        }
                    }
                ]
            };

            Assert.Equal(2, list.Tenants.Count());
            Assert.Equal("1", list.Tenants.ElementAt(0).Id);
            Assert.Equal("One", list.Tenants.ElementAt(0).Name);
            Assert.Single(list.Tenants.ElementAt(0).SelfProvisioningDomains);
            Assert.Equal("My One Domain", list.Tenants.ElementAt(0).SelfProvisioningDomains.ElementAt(0));
            Assert.NotNull(list.Tenants.ElementAt(0).CustomAttributes);
            Assert.Equal("2", list.Tenants.ElementAt(1).Id);
            Assert.Equal("Two", list.Tenants.ElementAt(1).Name);
            Assert.Single(list.Tenants.ElementAt(1).SelfProvisioningDomains);
            Assert.Equal("My Two Domain", list.Tenants.ElementAt(1).SelfProvisioningDomains.ElementAt(0));
            Assert.NotNull(list.Tenants.ElementAt(1).CustomAttributes);
        }
    }
}
