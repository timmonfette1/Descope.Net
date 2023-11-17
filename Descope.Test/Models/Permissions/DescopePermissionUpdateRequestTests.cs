using Descope.Models;

namespace Descope.Test.Models.Permissions
{
    public class DescopePermissionUpdateRequestTests
    {
        [Fact]
        public void ShouldCreateObject()
        {
            var permission = new DescopePermissionUpdateRequest
            {
                Name = "Name",
                NewName = "NewName",
                Description = "Description"
            };

            Assert.Equal("Name", permission.Name);
            Assert.Equal("NewName", permission.NewName);
            Assert.Equal("Description", permission.Description);
        }
    }
}
