using Descope.Models;

namespace Descope.Test.Management.Tenants
{
    [Collection("ClientServer")]
    public class TenantsApiClientTests(TenantsApiClientFixture fixture) : IClassFixture<TenantsApiClientFixture>
    {
        private readonly TenantsApiClientFixture _fixture = fixture;

        [Fact]
        public async Task ShouldGetAllTenants()
        {
            var tenants = await _fixture.TenantsApiClient.GetAll();

            Assert.NotNull(tenants);
            Assert.Single(tenants);

            var tenant = tenants.Single();

            Assert.Equal("TEST", tenant.Id);
            Assert.Equal("Test Client", tenant.Name);
        }

        [Fact]
        public async Task ShouldGetTenantById()
        {
            var tenant = await _fixture.TenantsApiClient.Get("TEST");

            Assert.NotNull(tenant);
            Assert.Equal("TEST", tenant.Id);
            Assert.Equal("Test Client", tenant.Name);
        }

        [Fact]
        public async Task ShouldNotGetTenantById()
        {
            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.TenantsApiClient.Get("TESTBAD"));

            Assert.NotNull(exception);
            Assert.Equal("E111104", exception.ErrorCode);
            Assert.Equal("Failed to load tenants", exception.ErrorDescription);
            Assert.Equal("Could not load tenant by id", exception.ErrorMessage);
        }

        [Fact]
        public async Task ShouldSearchTenantsById()
        {
            var tenants = await _fixture.TenantsApiClient.Search(new DescopeTenantSearchRequest
            {
                TenantIds = ["TEST"]
            });

            Assert.NotNull(tenants);
            Assert.Single(tenants);

            var tenant = tenants.Single();

            Assert.Equal("TEST", tenant.Id);
            Assert.Equal("Test Client", tenant.Name);
        }

        [Fact]
        public async Task ShouldSearchTenantsByName()
        {
            var tenants = await _fixture.TenantsApiClient.Search(new DescopeTenantSearchRequest
            {
                TenantNames = ["Test Client"]
            });

            Assert.NotNull(tenants);
            Assert.Single(tenants);

            var tenant = tenants.Single();

            Assert.Equal("TEST", tenant.Id);
            Assert.Equal("Test Client", tenant.Name);
        }

        [Fact]
        public async Task ShouldNotGetAnyTenantsBySearch()
        {
            var tenants = await _fixture.TenantsApiClient.Search(new DescopeTenantSearchRequest
            {
                TenantIds = ["TESTBAD"]
            });

            Assert.NotNull(tenants);
            Assert.Empty(tenants);
        }

        [Fact]
        public async Task ShouldCreateTenant()
        {
            var tenant = await _fixture.TenantsApiClient.Create(new DescopeTenant
            {
                Id = "TEST",
                Name = "Test Client"
            });

            Assert.NotNull(tenant);
            Assert.Equal("TEST", tenant.Id);
            Assert.Equal("Test Client", tenant.Name);
        }

        [Fact]
        public async Task ShouldNotCreateClient()
        {
            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.TenantsApiClient.Create(new DescopeTenant
            {
                Id = "EXIST",
                Name = "Existing Client"
            }));

            Assert.NotNull(exception);
            Assert.Equal("E073307", exception.ErrorCode);
            Assert.Equal("Failed to save tenant, tenant ID or Name already exist", exception.ErrorDescription);
            Assert.Equal("Failed creating tenant because tenant name is duplicate", exception.ErrorMessage);
        }

        [Fact]
        public async Task ShouldUpdateTenant()
        {
            var tenant = await _fixture.TenantsApiClient.Update(new DescopeTenant
            {
                Id = "TEST",
                Name = "Updated Client"
            });

            Assert.NotNull(tenant);
            Assert.Equal("TEST", tenant.Id);
            Assert.Equal("Updated Client", tenant.Name);
        }

        [Fact]
        public async Task ShouldNotUpdateTenant()
        {
            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.TenantsApiClient.Update(new DescopeTenant
            {
                Id = "TESTBAD",
                Name = "Updated Client"
            }));

            Assert.NotNull(exception);
            Assert.Equal("E111102", exception.ErrorCode);
            Assert.Equal("Failed to update tenant", exception.ErrorDescription);
            Assert.Equal("Could not update tenant", exception.ErrorMessage);
        }

        [Fact]
        public async Task ShouldDeleteTenant()
        {
            var delete = await Record.ExceptionAsync(async () => await _fixture.TenantsApiClient.Delete("TEST"));

            Assert.Null(delete);
        }
    }
}
