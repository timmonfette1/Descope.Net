namespace Descope.Test.Auth.AccessKey
{
    [Collection("ClientServer")]
    public class AccessKeyApiClientTests(AccessKeyApiClientFixture fixture) : IClassFixture<AccessKeyApiClientFixture>
    {
        private readonly AccessKeyApiClientFixture _fixture = fixture;

        [Fact]
        public async Task ShouldExchangeAccessKey()
        {
            var exchange = await _fixture.AccessKeyApiClient.Exchange("access-key");

            Assert.NotNull(exchange);
            Assert.Equal("KID", exchange.KeyId);
            Assert.Equal("abc-123-xyz", exchange.SessionJwt);
        }
    }
}
