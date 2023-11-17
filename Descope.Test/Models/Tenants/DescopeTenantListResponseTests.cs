using Descope.Models;

namespace Descope.Test.Models.Tenants
{
    public class DescopeTenantListResponseTests
    {
        [Fact]
        public void ShouldCreateObject()
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
    }
}
