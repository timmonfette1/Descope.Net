using Descope.Models;

namespace Descope.Test.Models.Permissions
{
    public class DescopePermissionDeleteRequestTests
    {
        [Fact]
        public void ShouldCreateObject()
        {
            var permission = new DescopePermissionDeleteRequest
            {
                Name = "Name"
            };

            Assert.Equal("Name", permission.Name);
        }
    }
}
