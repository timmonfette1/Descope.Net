using Descope.Models;

namespace Descope.Test.Models.Roles
{
    public class DescopeRoleDeleteRequestTests
    {
        [Fact]
        public void ShouldCreateObject()
        {
            var role = new DescopeRoleDeleteRequest
            {
                Name = "TEST"
            };

            Assert.Equal("TEST", role.Name);
        }
    }
}
