using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions_Flows
    {
        private static readonly string[] _empty = [];
        private static readonly string[] _flowIds = ["TEST"];
        private static readonly string[] _badFlowIds = ["TESTBAD"];

        private static readonly string[] _translateTargetLangs = ["JP"];
        private static readonly string[] _dependsOn = ["Dependency"];

        private static readonly object[] _options =
        [
            new
            {
                Label = "Label",
                Value = "Value"
            }
        ];

        private static readonly object[] _inputs =
        [
            new
            {
                Type = "TEST",
                Name = "Tester",
                Required = false,
                Visible = true,
                DisplayName = "Testing",
                DisplayType = "Test",
                DependsOn = _dependsOn,
                NameValueMap = (object)null,
                ContextAware = true,
                Options = _options
            }
        ];

        private static readonly object[] _interactions =
        [
            new
            {
                Id = "TEST",
                Type = "Tester",
                Label = "Testing",
                Icon = "Smile",
                SubType = "Tester Jr."
            }
        ];

        private static readonly object _flowMetadataMock = new
        {
            Id = "TEST",
            Version = 1,
            Name = "Test",
            Description = "Testing",
            Dsl = new
            {
                Inner = "Inner"
            },
            ModifiedTime = 12345,
            ETag = "Tagged",
            Disabled = false,
            Translate = true,
            TranslateConnectorId = "TID",
            TranslateSourceLang = "ENG",
            TranslateTargetLangs = _translateTargetLangs,
            Fingerprint = true,
        };

        private static readonly object[] _screensMock =
        [
            new
            {
                Id = "TEST",
                Version = 1,
                FlowId = "FTEST",
                Inputs = _inputs,
                Interactions = _interactions,
                HtmlTemplate = new
                {
                    Inner = "Inner"
                },
                ComponentsVersion = "1.0.0",
            }
        ];

        private static readonly object[] _flows = [_flowMetadataMock];

        public static WireMockServer ListFlows(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/flow/list")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            Ids = _flowIds
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Flows = _flows,
                            Total = 1
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/flow/list")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            Ids = _empty
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Flows = _flows,
                            Total = 1
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/flow/list")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            Ids = _badFlowIds
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(new
                        {
                            ErrorCode = "E103009",
                            ErrorDescription = "Failed Finding any flows"
                        })
                );

            return server;
        }

        public static WireMockServer ExportFlow(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/flow/export")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            FlowId = "TEST"
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Flow = _flowMetadataMock,
                            Screens = _screensMock
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/flow/export")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            FlowId = "TESTBAD"
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(new
                        {
                            ErrorCode = "E103003",
                            ErrorDescription = "Failed getting flow",
                            ErrorMessage = "Failed loading flow by ID",
                            Message = "Failed loading flow by ID"
                        })
                );

            return server;
        }

        public static WireMockServer ImportFlow(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/flow/import")
                        .UsingPost()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Flow = new
                            {
                                Id = "TEST",
                                Version = 2,
                                Name = "Test",
                                Description = "Testing",
                                Dsl = new
                                {
                                    Inner = "Inner"
                                },
                                ModifiedTime = 12345,
                                ETag = "Tagged",
                                Disabled = false,
                                Translate = true,
                                TranslateConnectorId = "TID",
                                TranslateSourceLang = "ENG",
                                TranslateTargetLangs = _translateTargetLangs,
                                Fingerprint = true,
                            },
                            Screens = _screensMock
                        })
                );

            return server;
        }
    }
}
