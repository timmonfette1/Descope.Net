using Descope.Models;

namespace Descope.Test.Models.Management
{
    public class DescopePermissionTests
    {
        [Fact]
        public void ShouldCreateObject_PermissionUpdateRequest()
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

        [Fact]
        public void ShouldCreateObject_PermissionListResponse()
        {
            var permission = new DescopePermissionListResponse
            {
                Permissions =
                [
                    new()
                    {
                        Name = "Name",
                        Description = "Description"
                    },
                    new()
                    {
                        Name = "Name 2",
                        Description = "Description 2"
                    }
                ]
            };

            Assert.Equal(2, permission.Permissions.Count());
            Assert.Equal("Name", permission.Permissions.ElementAt(0).Name);
            Assert.Equal("Description", permission.Permissions.ElementAt(0).Description);
            Assert.Equal("Name 2", permission.Permissions.ElementAt(1).Name);
            Assert.Equal("Description 2", permission.Permissions.ElementAt(1).Description);
        }

        [Fact]
        public void ShouldCreateObject_PermissionDeleteRequest()
        {
            var permission = new DescopePermissionDeleteRequest
            {
                Name = "Name"
            };

            Assert.Equal("Name", permission.Name);
        }
    }
}
