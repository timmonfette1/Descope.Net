using Descope.Models;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions_Audit
    {
        public static WireMockServer SearchAudit(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/audit/search")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeAuditSearchRequest
                        {
                            From = 12345,
                            To = 99999,
                            UserIds = ["TEST"]
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new DescopeAuditListResponse
                        {
                            Audits =
                            [
                                new()
                                {
                                    Id = "AID",
                                    ProjectId = "PTEST",
                                    UserId = "UTEST",
                                    Action = "Action",
                                    Occurred = 34567,
                                    Device = "Desktop",
                                    Method = "Delete",
                                    Geo = "USA",
                                    RemoteAddress = "0.0.0.0",
                                    ExternalIds =
                                    [
                                        "ExTEST"
                                    ],
                                    Tenants =
                                    [
                                        "TEST"
                                    ],
                                    Data = new
                                    {
                                        Inner = "Inner"
                                    },
                                    Type = "Info",
                                }
                            ]
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/audit/search")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeAuditSearchRequest
                        {
                            From = 12345,
                            To = 99999,
                            UserIds = ["TESTBAD"]
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new DescopeAuditListResponse
                        {
                            Audits = []
                        })
                );

            return server;
        }
    }
}
