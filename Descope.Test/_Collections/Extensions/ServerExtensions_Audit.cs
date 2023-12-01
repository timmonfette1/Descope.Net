using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions_Audit
    {
        private static readonly string[] _userIds = ["TEST"];
        private static readonly string[] _userIdsBad = ["TESTBAD"];

        private static readonly string[] _tenants = ["TEST"];
        private static readonly string[] _externalIds = ["ExTEST"];

        private static readonly object[] _audits =
        [
            new
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
                ExternalIds = _externalIds,
                Tenants = _tenants,
                Data = new
                {
                    Inner = "Inner"
                },
                Type = "Info",
            }
        ];

        private static readonly object[] _empty = [];

        public static WireMockServer SearchAudit(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/audit/search")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            From = 12345,
                            To = 99999,
                            UserIds = _userIds,
                            Actions = (object)null,
                            Devices = (object)null,
                            ExcludedActions = (object)null,
                            ExternalIds = (object)null,
                            Geos = (object)null,
                            Methods = (object)null,
                            NoTenants = false,
                            RemoteAddresses = (object)null,
                            Tenants = (object)null,
                            Text = (object)null,
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Audits = _audits
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/audit/search")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            From = 12345,
                            To = 99999,
                            UserIds = _userIdsBad,
                            Actions = (object)null,
                            Devices = (object)null,
                            ExcludedActions = (object)null,
                            ExternalIds = (object)null,
                            Geos = (object)null,
                            Methods = (object)null,
                            NoTenants = false,
                            RemoteAddresses = (object)null,
                            Tenants = (object)null,
                            Text = (object)null,
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Audits = _empty
                        })
                );

            return server;
        }
    }
}
