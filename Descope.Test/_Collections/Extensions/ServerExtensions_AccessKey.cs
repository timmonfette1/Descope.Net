using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions_AccessKey
    {
        public static WireMockServer ExchangeAccessKey(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/auth/accesskey/exchange")
                        .UsingPost()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            KeyId = "KID",
                            SessionJwt = "abc-123-xyz"
                        })
                );

            return server;
        }
    }
}
