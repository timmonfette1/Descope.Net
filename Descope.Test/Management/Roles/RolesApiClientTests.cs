using System.Xml.Linq;
using Descope.Models;

namespace Descope.Test.Management.Roles
{
    [Collection("ClientServer")]
    public class RolesApiClientTests(RolesApiClientFixture fixture) : IClassFixture<RolesApiClientFixture>
    {
        private readonly RolesApiClientFixture _fixture = fixture;

        [Fact]
        public async Task ShouldGetAllRoles()
        {
            var roles = await _fixture.RolesApiClient.GetAll();

            Assert.NotNull(roles);
            Assert.Single(roles.Roles);

            var role = roles.Roles.Single();

            Assert.Equal("TEST", role.Name);
            Assert.Equal("Testing", role.Description);
            Assert.Equal(default, role.CreatedTime);
            Assert.Single(role.PermissionNames);
            Assert.Equal("TestPerm", role.PermissionNames[0]);
        }

        [Fact]
        public async Task ShouldCreateRole()
        {
            var role = await _fixture.RolesApiClient.Create(new DescopeRole
            {
                Name = "TEST",
                Description = "Testing",
                PermissionNames =
                [
                    "TestPerm"
                ]
            });

            Assert.NotNull(role);
            Assert.Equal("TEST", role.Name);
            Assert.Equal("Testing", role.Description);
            Assert.Equal(default, role.CreatedTime);
            Assert.Single(role.PermissionNames);
            Assert.Equal("TestPerm", role.PermissionNames[0]);
        }

        [Fact]
        public async Task ShouldNotCreateRole_Existing()
        {
            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.RolesApiClient.Create(new DescopeRole
            {
                Name = "EXIST",
                Description = "Existing",
                PermissionNames =
                [
                    "TestPerm"
                ]
            }));

            Assert.NotNull(exception);
            Assert.Equal("E024209", exception.ErrorCode);
            Assert.Equal("Failed to save role, role ID or Name already exist", exception.ErrorDescription);
            Assert.Equal("Failed to create record, role entity already exists", exception.ErrorMessage);
        }

        [Fact]
        public async Task ShouldNotCreateRole_NoPermission()
        {
            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.RolesApiClient.Create(new DescopeRole
            {
                Name = "TEST",
                Description = "Testing",
                PermissionNames =
                [
                    "FakePerm"
                ]
            }));

            Assert.NotNull(exception);
            Assert.Equal("E111303", exception.ErrorCode);
            Assert.Equal("Permission not found", exception.ErrorDescription);
            Assert.Equal("Permission does not exist", exception.ErrorMessage);
        }

        [Fact]
        public async Task ShouldUpdateRole()
        {
            var role = new DescopeRole
            {
                Name = "TEST",
                Description = "Testing Updated",
                PermissionNames =
                [
                    "TestPerm"
                ]
            };

            var updatedRole = await _fixture.RolesApiClient.Update(role, "UTEST");

            Assert.NotNull(updatedRole);
            Assert.Equal("UTEST", updatedRole.Name);
            Assert.Equal("Testing Updated", updatedRole.Description);
            Assert.Equal(default, updatedRole.CreatedTime);
            Assert.Single(updatedRole.PermissionNames);
            Assert.Equal("TestPerm", updatedRole.PermissionNames[0]);
        }

        [Fact]
        public async Task ShouldNotUpdateRole_NotFound()
        {
            var role = new DescopeRole
            {
                Name = "TESTBAD",
                Description = "Testing Updated",
                PermissionNames =
                [
                    "TestPerm"
                ]
            };

            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.RolesApiClient.Update(role, "UTEST"));

            Assert.NotNull(exception);
            Assert.Equal("E111403", exception.ErrorCode);
            Assert.Equal("Role not found", exception.ErrorDescription);
            Assert.Equal("Role does not exist", exception.ErrorMessage);
        }

        [Fact]
        public async Task ShouldNotUpdateRole_Existing()
        {
            var role = new DescopeRole
            {
                Name = "TEST",
                Description = "Testing Updated",
                PermissionNames =
                [
                    "TestPerm"
                ]
            };

            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.RolesApiClient.Update(role, "EXIST"));

            Assert.NotNull(exception);
            Assert.Equal("E024209", exception.ErrorCode);
            Assert.Equal("Failed to save role, role ID or Name already exist", exception.ErrorDescription);
            Assert.Equal("Failed to create record, role entity already exists", exception.ErrorMessage);
        }

        [Fact]
        public async Task ShouldNotUpdateRole_NoPermission()
        {
            var role = new DescopeRole
            {
                Name = "TEST",
                Description = "Testing Updated",
                PermissionNames =
                [
                    "FakePerm"
                ]
            };

            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.RolesApiClient.Update(role, "UTEST"));

            Assert.NotNull(exception);
            Assert.Equal("E111303", exception.ErrorCode);
            Assert.Equal("Permission not found", exception.ErrorDescription);
            Assert.Equal("Permission does not exist", exception.ErrorMessage);
        }

        [Fact]
        public async Task ShouldDeleteRole()
        {
            var delete = await Record.ExceptionAsync(async () => await _fixture.RolesApiClient.Delete("TEST"));

            Assert.Null(delete);
        }
    }
}
