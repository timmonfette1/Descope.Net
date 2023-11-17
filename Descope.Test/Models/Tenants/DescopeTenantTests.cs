using Descope.Models;

namespace Descope.Test.Models.Tenants
{
    public class DescopeTenantTests
    {
        [Fact]
        public void ShouldCreateObject()
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
    }
}
