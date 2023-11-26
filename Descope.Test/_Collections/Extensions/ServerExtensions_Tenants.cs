using Descope.Models;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions_Tenants
    {
        private static readonly DescopeTenant _tenantMock = new()
        {
            Id = "TEST",
            Name = "Test Client",
        };

        private static readonly DescopeTenantListResponse _tenantListMock = new()
        {
            Tenants =
            [
                _tenantMock
            ]
        };

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
                        .WithBodyAsJson(_tenantListMock)
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
                        .WithBody(new JsonMatcher(new DescopeTenantSearchRequest
                        {
                            TenantIds = ["TEST"]
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(_tenantListMock)
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/tenant/search")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeTenantSearchRequest
                        {
                            TenantNames = ["Test Client"]
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(_tenantListMock)
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/tenant/search")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeTenantSearchRequest
                        {
                            TenantIds = ["TESTBAD"]
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new DescopeTenantListResponse { Tenants = Array.Empty<DescopeTenant>() })
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
                        .WithBody(new JsonMatcher(new DescopeTenant
                        {
                            Id = "TEST",
                            Name = "Test Client"
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
                        .WithBody(new JsonMatcher(new DescopeTenant
                        {
                            Id = "EXIST",
                            Name = "Existing Client"
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
                        .WithBody(new JsonMatcher(new DescopeTenant
                        {
                            Id = "TEST",
                            Name = "Updated Client"
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
                        .WithBody(new JsonMatcher(new DescopeTenant
                        {
                            Id = "TESTBAD",
                            Name = "Updated Client"
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
                        .WithBody(new JsonMatcher(new DescopeIdModel
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
