namespace Descope.Test.HttpClient.Auth
{
    [Collection("ClientServer")]
    public class DescopeAuthHttpClientTests(DescopeAuthHttpClientFixture fixture) : IClassFixture<DescopeAuthHttpClientFixture>
    {
        class Dummy
        {
            public string Message { get; set; }
        }

        private readonly DescopeAuthHttpClientFixture _fixture = fixture;

        [Fact]
        public async Task ShouldPostWithCustomToken()
        {
            var response = await _fixture.DescopeAuthClient.PostWithCustomTokenAsync<object, Dummy>("/dummy/post", "custom", new { Name = "TEST" });

            Assert.NotNull(response);
            Assert.Equal("Hello TEST!", response.Message);
        }
    }
}
