using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions_Tenants
    {
        private static readonly object[] _empty = [];
        private static readonly string[] _tenantIds = ["TEST"];
        private static readonly string[] _badTenantIds = ["TESTBAD"];
        private static readonly string[] _tenantNames = ["Test Client"];

        private static readonly object _tenantMock = new
        {
            Id = "TEST",
            Name = "Test Client",
        };

        private static readonly object[] _tenantsMock =
        [
            _tenantMock
        ];

        public static WireMockServer GetAllTenants(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/tenant/all")
                        .UsingGet()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Tenants = _tenantsMock
                        })
                );

            return server;
        }

        public static WireMockServer GetTenants(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/tenant")
                        .WithParam("id", true, "TEST")
                        .UsingGet()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(_tenantMock)
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/tenant")
                        .WithParam("id", true, "TESTBAD")
                        .UsingGet()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(new
                        {
                            ErrorCode = "E111104",
                            ErrorDescription = "Failed to load tenants",
                            ErrorMessage = "Could not load tenant by id",
                            Message = "Could not load tenant by id"
                        })
                );

            return server;
        }

        public static WireMockServer SearchTenants(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/tenant/search")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            TenantIds = _tenantIds,
                            TenantNames = (object)null,
                            TenantSelfProvisioningDomains = (object)null,
                            CustomAttributes = (object)null,
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Tenants = _tenantsMock
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/tenant/search")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            TenantIds = (object)null,
                            TenantNames = _tenantNames,
                            TenantSelfProvisioningDomains = (object)null,
                            CustomAttributes = (object)null,
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Tenants = _tenantsMock
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/tenant/search")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            TenantIds = _badTenantIds,
                            TenantNames = (object)null,
                            TenantSelfProvisioningDomains = (object)null,
                            CustomAttributes = (object)null,
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Tenants = _empty
                        })
                );

            return server;
        }

        public static WireMockServer CreateTenants(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/tenant/create")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            Id = "TEST",
                            Name = "Test Client",
                            SelfProvisioningDomains = (object)null,
                            CustomAttributes = (object)null,
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new { Id = "TEST" })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/tenant/create")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            Id = "EXIST",
                            Name = "Existing Client",
                            SelfProvisioningDomains = (object)null,
                            CustomAttributes = (object)null,
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(new
                        {
                            ErrorCode = "E073307",
                            ErrorDescription = "Failed to save tenant, tenant ID or Name already exist",
                            ErrorMessage = "Failed creating tenant because tenant name is duplicate",
                            Message = "Failed creating tenant because tenant name is duplicate"
                        })
                );

            return server;
        }

        public static WireMockServer UpdateTenants(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/tenant/update")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            Id = "TEST",
                            Name = "Updated Client",
                            SelfProvisioningDomains = (object)null,
                            CustomAttributes = (object)null,
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
                        .WithPath("/v1/mgmt/tenant/update")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            Id = "TESTBAD",
                            Name = "Updated Client",
                            SelfProvisioningDomains = (object)null,
                            CustomAttributes = (object)null,
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(new
                        {
                            ErrorCode = "E111102",
                            ErrorDescription = "Failed to update tenant",
                            ErrorMessage = "Could not update tenant",
                            Message = "Could not update tenant"
                        })
                );

            return server;
        }

        public static WireMockServer DeleteTenants(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/tenant/delete")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            Id = "TEST"
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new { })
                );

            return server;
        }
    }
}
