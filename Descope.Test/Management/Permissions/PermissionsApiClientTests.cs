using Descope.Models;

namespace Descope.Test.Management.Permissions
{
    [Collection("ClientServer")]
    public class PermissionsApiClientTests(PermissionsApiClientFixture fixture) : IClassFixture<PermissionsApiClientFixture>
    {
        private readonly PermissionsApiClientFixture _fixture = fixture;

        [Fact]
        public async Task ShouldGetAllPermissions()
        {
            var permissions = await _fixture.PermissionsApiClient.GetAll();

            Assert.NotNull(permissions);
            Assert.Single(permissions.Permissions);

            var permission = permissions.Permissions.Single();

            Assert.Equal("TEST", permission.Name);
            Assert.Equal("Testing", permission.Description);
            Assert.False(permission.SystemDefault);
        }

        [Fact]
        public async Task ShouldCreatePermission()
        {
            var permission = await _fixture.PermissionsApiClient.Create(new DescopePermission
            {
                Name = "TEST",
                Description = "Testing"
            });

            Assert.NotNull(permission);
            Assert.Equal("TEST", permission.Name);
            Assert.Equal("Testing", permission.Description);
        }

        [Fact]
        public async Task ShouldNotCreatePermission()
        {
            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.PermissionsApiClient.Create(new DescopePermission
            {
                Name = "EXIST",
                Description = "Existing"
            }));

            Assert.NotNull(exception);
            Assert.Equal("E024104", exception.ErrorCode);
            Assert.Equal("Failed to save permission, permission ID or Name already exist", exception.ErrorDescription);
            Assert.Equal("Failed to create record, permission entity already exists", exception.ErrorMessage);
        }

        [Fact]
        public async Task ShouldUpdatePermission()
        {
            var permission = new DescopePermission
            {
                Name = "TEST",
                Description = "Testing"
            };
            var updatedPermission = await _fixture.PermissionsApiClient.Update(permission, "TESTU");

            Assert.NotNull(updatedPermission);
            Assert.Equal("TESTU", updatedPermission.Name);
            Assert.Equal("Testing", updatedPermission.Description);
        }

        [Fact]
        public async Task ShouldNotUpdatePermission_Duplicate()
        {
            var permission = new DescopePermission
            {
                Name = "TEST",
                Description = "Testing"
            };

            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.PermissionsApiClient.Update(permission, "EXIST"));

            Assert.NotNull(exception);
            Assert.Equal("E024104", exception.ErrorCode);
            Assert.Equal("Failed to save permission, permission ID or Name already exist", exception.ErrorDescription);
            Assert.Equal("Failed to update record, a duplicate permission entity already exists", exception.ErrorMessage);
        }

        [Fact]
        public async Task ShouldNotUpdatePermission_NotFound()
        {
            var permission = new DescopePermission
            {
                Name = "TESTBAD",
                Description = "Testing"
            };

            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.PermissionsApiClient.Update(permission, "TEST"));

            Assert.NotNull(exception);
            Assert.Equal("E111303", exception.ErrorCode);
            Assert.Equal("Permission not found", exception.ErrorDescription);
            Assert.Equal("Permission does not exist", exception.ErrorMessage);
        }

        [Fact]
        public async Task ShouldDeletePermission()
        {
            var delete = await Record.ExceptionAsync(async () => await _fixture.PermissionsApiClient.Delete("TEST"));

            Assert.Null(delete);
        }
    }
}
