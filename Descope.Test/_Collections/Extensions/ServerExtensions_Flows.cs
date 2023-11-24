using Descope.Models;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions_Flows
    {
        private static readonly DescopeFlowMetadata _flowMetadataMock = new()
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
            TranslateTargetLangs = new string[1] { "JP" },
            Fingerprint = true,
        };

        private static readonly DescopeScreen[] _screensMock = new DescopeScreen[1]
        {
            new()
            {
               Id = "TEST",
               Version = 1,
               FlowId = "FTEST",
               Inputs = new DescopeScreenInput[1]
               {
                   new()
                    {
                        Type = "TEST",
                        Name = "Tester",
                        Required = false,
                        Visible = true,
                        DisplayName = "Testing",
                        DisplayType = "Test",
                        DependsOn = new string[1] { "Dependency" },
                        NameValueMap = null,
                        ContextAware = true,
                        Options = new DescopeScreenInputOption[1]
                        {
                            new()
                            {
                                Label = "Label",
                                Value = "Value"
                            }
                        }
                    }
               },
               Interactions = new DescopeScreenInteraction[1]
               {
                   new()
                    {
                        Id = "TEST",
                        Type = "Tester",
                        Label = "Testing",
                        Icon = "Smile",
                        SubType = "Tester Jr."
                    }
               },
               HtmlTemplate = new
               {
                   Inner = "Inner"
               },
               ComponentsVersion = "1.0.0",
            }
        };

        private static readonly DescopeFlow _flowMock = new()
        {
            Flow = _flowMetadataMock,
            Screens = _screensMock
        };

        public static WireMockServer ListFlows(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/flow/list")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeFlowSearchRequest
                        {
                            Ids = new string[1] { "TEST" }
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new DescopeFlowListResponse
                        {
                            Flows = new DescopeFlowMetadata[1]
                            {
                                _flowMetadataMock
                            },
                            Total = 1
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/flow/list")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeFlowSearchRequest
                        {
                            Ids = Array.Empty<string>()
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new DescopeFlowListResponse
                        {
                            Flows = new DescopeFlowMetadata[1]
                            {
                                _flowMetadataMock
                            },
                            Total = 1
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/flow/list")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeFlowSearchRequest
                        {
                            Ids = new string[1] { "TESTBAD" }
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
                        .WithBody(new JsonMatcher(new DescopeFlowExportRequest
                        {
                            FlowId = "TEST"
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(_flowMock)
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/flow/export")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeFlowExportRequest
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
                        .WithBodyAsJson(new DescopeFlow
                        {
                            Flow = new DescopeFlowMetadata
                            {
                                Id = _flowMetadataMock.Id,
                                Version = _flowMetadataMock.Version + 1,
                                Name = _flowMetadataMock.Name,
                                Description = _flowMetadataMock.Description,
                                Dsl = _flowMetadataMock.Dsl,
                                ModifiedTime = _flowMetadataMock.ModifiedTime,
                                ETag = _flowMetadataMock.ETag,
                                Disabled = _flowMetadataMock.Disabled,
                                Translate = _flowMetadataMock.Translate,
                                TranslateConnectorId = _flowMetadataMock.TranslateConnectorId,
                                TranslateSourceLang = _flowMetadataMock.TranslateSourceLang,
                                TranslateTargetLangs = _flowMetadataMock.TranslateTargetLangs,
                                Fingerprint = _flowMetadataMock.Fingerprint,
                            },
                            Screens = _screensMock
                        })
                );

            return server;
        }
    }
}
