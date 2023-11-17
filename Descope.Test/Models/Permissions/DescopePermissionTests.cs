using Descope.Models;

namespace Descope.Test.Models.Permissions
{
    public class DescopePermissionTests
    {
        [Fact]
        public void ShouldCreateObject()
        {
            var permission = new DescopePermission
            {
                Name = "Name",
                Description = "Description"
            };

            Assert.Equal("Name", permission.Name);
            Assert.Equal("Description", permission.Description);
            Assert.False(permission.SystemDefault);
        }
    }
}
