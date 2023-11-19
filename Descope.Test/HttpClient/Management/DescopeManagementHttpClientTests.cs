using Descope.Models;

namespace Descope.Test.HttpClient.Management
{
    [Collection("ClientServer")]
    public class DescopeManagementHttpClientTests : IClassFixture<DescopeManagementHttpClientFixture>
    {
        class Dummy
        {
            public string Message { get; set; }
        }

        private readonly DescopeManagementHttpClientFixture _fixture;

        public DescopeManagementHttpClientTests(DescopeManagementHttpClientFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldGetAsync()
        {
            var response = await _fixture.DescopeManagementClient.GetAsync<Dummy>("/dummy/get");

            Assert.NotNull(response);
            Assert.Equal("Hello World!", response.Message);
        }

        [Fact]
        public async Task ShouldGetAsync_QueryParams()
        {
            var response = await _fixture.DescopeManagementClient.GetAsync<Dummy>("/dummy/get", new { name = "TEST" });

            Assert.NotNull(response);
            Assert.Equal("Hello TEST!", response.Message);
        }

        [Fact]
        public async Task ShouldGetAsync_PathParams()
        {
            var response = await _fixture.DescopeManagementClient.GetAsync<Dummy>("/dummy/get/{name}", new { name = "TESTURL" });

            Assert.NotNull(response);
            Assert.Equal("Hello TESTURL!", response.Message);
        }

        [Fact]
        public async Task ShouldNotGetAsync()
        {
            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.DescopeManagementClient.GetAsync<Dummy>("/dummy/get/error"));

            Assert.NotNull(exception);
            Assert.Equal("E123456", exception.ErrorCode);
            Assert.Equal("Failed to GET data", exception.ErrorDescription);
            Assert.Equal("Failed to GET data", exception.ErrorMessage);
        }

        [Fact]
        public async Task ShouldPostAsync()
        {
            var response = await _fixture.DescopeManagementClient.PostAsync<object, Dummy>("/dummy/post", new { Name = "TEST" });

            Assert.NotNull(response);
            Assert.Equal("Hello TEST!", response.Message);
        }

        [Fact]
        public async Task ShouldPostAsync_EmptyResponse()
        {
            var exception = await Record.ExceptionAsync(async () => await _fixture.DescopeManagementClient.PostAsync<object>("/dummy/post", new { Name = "EMPTY" }));

            Assert.Null(exception);
        }

        [Fact]
        public async Task ShouldNotPostAsync()
        {
            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.DescopeManagementClient.PostAsync<object>("/dummy/post", new { Name = "ERROR" }));

            Assert.NotNull(exception);
            Assert.Equal("E123456", exception.ErrorCode);
            Assert.Equal("Failed to POST data", exception.ErrorDescription);
            Assert.Equal("Failed to POST data", exception.ErrorMessage);
        }
    }
}
