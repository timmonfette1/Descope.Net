using Descope.Models;

namespace Descope.Test.Models.Management
{
    public class DescopeRoleTests
    {
        [Fact]
        public void ShouldCreateObject_RoleListResponse()
        {
            var role = new DescopeRoleListResponse
            {
                Roles =
                [
                    new()
                    {
                        Name = "Name",
                        Description = "Description",
                        PermissionNames =
                        [
                            "Perm"
                        ]
                    },
                    new()
                    {
                        Name = "Name 2",
                        Description = "Description 2",
                        PermissionNames =
                        [
                            "Perm2"
                        ]
                    }
                ]
            };

            Assert.Equal(2, role.Roles.Count());
            Assert.Equal("Name", role.Roles.ElementAt(0).Name);
            Assert.Equal("Description", role.Roles.ElementAt(0).Description);
            Assert.Single(role.Roles.ElementAt(0).PermissionNames);
            Assert.Equal("Perm", role.Roles.ElementAt(0).PermissionNames[0]);
            Assert.Equal("Name 2", role.Roles.ElementAt(1).Name);
            Assert.Equal("Description 2", role.Roles.ElementAt(1).Description);
            Assert.Single(role.Roles.ElementAt(1).PermissionNames);
            Assert.Equal("Perm2", role.Roles.ElementAt(1).PermissionNames[0]);
        }

        [Fact]
        public void ShouldCreateObject_RoleUpdateRequest()
        {
            var role = new DescopeRoleUpdateRequest
            {
                Name = "TEST",
                NewName = "TESTU",
                Description = "Testing",
                PermissionNames =
                [
                    "New Perm"
                ]
            };

            Assert.Equal("TEST", role.Name);
            Assert.Equal("TESTU", role.NewName);
            Assert.Equal("Testing", role.Description);
            Assert.Single(role.PermissionNames);

            var perm = role.PermissionNames.Single();

            Assert.Equal("New Perm", perm);
        }

        [Fact]
        public void ShouldCreateObject_RoleDeleteRequest()
        {
            var role = new DescopeRoleDeleteRequest
            {
                Name = "TEST"
            };

            Assert.Equal("TEST", role.Name);
        }
    }
}
