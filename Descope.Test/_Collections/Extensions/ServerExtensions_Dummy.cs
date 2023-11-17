using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions_Dummy
    {
        public static WireMockServer ConfigureDummyGets(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/dummy/get")
                        .UsingGet()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Message = "Hello World!"
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/dummy/get")
                        .WithParam("name", true, "TEST")
                        .UsingGet()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Message = "Hello TEST!"
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/dummy/get/TESTURL")
                        .UsingGet()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Message = "Hello TESTURL!"
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/dummy/get/error")
                        .UsingGet()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(new {
                            ErrorCode = "E123456",
                            ErrorDescription = "Failed to GET data",
                            ErrorMessage = "Failed to GET data",
                            Message = "Failed to GET data"
                        })
                );

            return server;
        }

        public static WireMockServer ConfigureDummyPosts(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/dummy/post")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            Name = "EMPTY",
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new { })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/dummy/post")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            Name = "TEST",
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Message = "Hello TEST!"
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/dummy/post")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            Name = "ERROR",
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(new
                        {
                            ErrorCode = "E123456",
                            ErrorDescription = "Failed to POST data",
                            ErrorMessage = "Failed to POST data",
                            Message = "Failed to POST data"
                        })
                );

            return server;
        }
    }
}
