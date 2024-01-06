using Descope.Models;

namespace Descope.Test.Models.Auth
{
    public class DescopeAccessKeyTests
    {
        [Fact]
        public void ShouldCreateObject()
        {
            var exchange = new DescopeAccessKeyExchangeResponse
            {
                KeyId = "KID",
                SessionJwt = "abc-123-xyz"
            };

            Assert.NotNull(exchange);
            Assert.Equal("KID", exchange.KeyId);
            Assert.Equal("abc-123-xyz", exchange.SessionJwt);
        }
    }
}
