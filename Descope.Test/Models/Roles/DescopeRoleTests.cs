using Descope.Models;

namespace Descope.Test.Models.Roles
{
    public class DescopeRoleTests
    {
        [Fact]
        public void ShouldCreateObject()
        {
            var role = new DescopeRole
            {
                Name = "TEST",
                Description = "Testing",
                PermissionNames = new string[1]
                {
                    "Permission"
                }
            };

            Assert.Equal("TEST", role.Name);
            Assert.Equal("Testing", role.Description);
            Assert.Single(role.PermissionNames);

            var perm = role.PermissionNames.Single();

            Assert.Equal("Permission", perm);
        }
    }
}
