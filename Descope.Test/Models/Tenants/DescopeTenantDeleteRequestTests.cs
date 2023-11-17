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
