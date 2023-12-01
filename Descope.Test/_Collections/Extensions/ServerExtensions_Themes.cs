using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions_Themes
    {
        public static WireMockServer ExportTheme(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/theme/export")
                        .UsingPost()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Theme = new
                            {
                                Id = "TEST",
                                Version = 1,
                                CssTemplate = new
                                {
                                    Dark = new
                                    {
                                        Font = "Fun Font",
                                        Color = "Black"
                                    },
                                    Light = new
                                    {
                                        Font = "Less Fun Font",
                                        Color = "White"
                                    }
                                },
                                ComponentsVersion = "1.0.0"
                            }
                        })
                );

            return server;
        }

        public static WireMockServer ImportTheme(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/theme/import")
                        .UsingPost()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Theme = new
                            {
                                Id = "TEST",
                                Version = 2,
                                CssTemplate = new
                                {
                                    Dark = new
                                    {
                                        Font = "Fun Font",
                                        Color = "Black"
                                    },
                                    Light = new
                                    {
                                        Font = "Less Fun Font",
                                        Color = "White"
                                    }
                                },
                                ComponentsVersion = "1.0.0"
                            }
                        })
                );

            return server;
        }
    }
}
