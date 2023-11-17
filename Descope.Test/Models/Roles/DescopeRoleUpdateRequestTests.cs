using Descope.Models;

namespace Descope.Test.Models.Roles
{
    public class DescopeRoleUpdateRequestTests
    {
        [Fact]
        public void ShouldCreateObject()
        {
            var role = new DescopeRoleUpdateRequest
            {
                Name = "TEST",
                NewName = "TESTU",
                Description = "Testing",
                PermissionNames = new string[1]
                {
                    "New Perm"
                }
            };

            Assert.Equal("TEST", role.Name);
            Assert.Equal("TESTU", role.NewName);
            Assert.Equal("Testing", role.Description);
            Assert.Single(role.PermissionNames);

            var perm = role.PermissionNames.Single();

            Assert.Equal("New Perm", perm);
        }
    }
}
