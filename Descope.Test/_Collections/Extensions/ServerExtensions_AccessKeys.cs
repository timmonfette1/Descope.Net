using Descope.Models;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions_AccessKeys
    {
        private static readonly DescopeAccessKey _accessKeyMock = new()
        {
            Id = "TEST",
            Name = "Testing",
            RoleNames = new string[1] { "Role1" },
            KeyTenants = new DescopeAccessKeyTenant[2]
                {
                    new()
                    {
                        TenantId = "Tenant1",
                        RoleNames = new string[1] { "TenantRole1" }
                    },
                    new()
                    {
                        TenantId = "Tenant2",
                        RoleNames = new string[1] { "TenantRole2" }
                    }
                },
            Status = "Active",
            CreatedTime = 12345,
            ExpireTime = 99999,
            CreatedBy = "Mr. Tester"
        };

        private static readonly object _accessKeyCantFindMock = new
        {
            ErrorCode = "E111502",
            ErrorDescription = "Access key not found",
            ErrorMessage = "Can't find access key",
            Message = "Can't find access key"
        };

        private static readonly object _accessKeyCantUpdateMock = new
        {
            ErrorCode = "E111502",
            ErrorDescription = "Access key not found",
            ErrorMessage = "Unable to update access key because it's not found",
            Message = "Unable to update access key because it's not found"
        };

        public static WireMockServer GetAccessKey(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/accesskey")
                        .WithParam("id", true, "TEST")
                        .UsingGet()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new DescopeAccessKeyResponse
                        {
                            Key = _accessKeyMock
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/accesskey")
                        .WithParam("id", true, "TESTBAD")
                        .UsingGet()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(_accessKeyCantFindMock)
                );

            return server;
        }

        public static WireMockServer SearchAccessKeys(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/accesskey/search")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeAccessKeySearchRequest
                        {
                            TenantIds = new string[1] { "TEST" }
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new DescopeAccessKeyListResponse { Keys = new DescopeAccessKey[1] { _accessKeyMock } })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/accesskey/search")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeAccessKeySearchRequest
                        {
                            TenantIds = new string[1] { "TESTBAD" }
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new DescopeAccessKeyListResponse { Keys = Array.Empty<DescopeAccessKey>() })
                );

            return server;
        }

        public static WireMockServer UpdateAccessKey(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/accesskey/update")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeAccessKeyUpdateRequest
                        {
                            Id = "TEST",
                            Name = "Updated Testing"
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new DescopeAccessKeyResponse
                        {
                            Key = new()
                            {
                                Id = "TEST",
                                Name = "Updated Testing",
                                RoleNames = new string[1] { "Role1" },
                                KeyTenants = new DescopeAccessKeyTenant[2]
                                {
                                    new()
                                    {
                                        TenantId = "Tenant1",
                                        RoleNames = new string[1] { "TenantRole1" }
                                    },
                                    new()
                                    {
                                        TenantId = "Tenant2",
                                        RoleNames = new string[1] { "TenantRole2" }
                                    }
                                },
                                Status = "Active",
                                CreatedTime = 12345,
                                ExpireTime = 99999,
                                CreatedBy = "Mr. Tester"
                            }
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/accesskey/update")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeAccessKeyUpdateRequest
                        {
                            Id = "TESTBAD",
                            Name = "Updated Testing"
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(_accessKeyCantFindMock)
                );

            return server;
        }

        public static WireMockServer ActivateAccessKey(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/accesskey/activate")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeAccessKeyStatusChangeRequest
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

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/accesskey/activate")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeAccessKeyStatusChangeRequest
                        {
                            Id = "TESTBAD"
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(_accessKeyCantUpdateMock)
                );

            return server;
        }

        public static WireMockServer DeactivateAccessKey(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/accesskey/deactivate")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeAccessKeyStatusChangeRequest
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

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/accesskey/deactivate")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeAccessKeyStatusChangeRequest
                        {
                            Id = "TESTBAD"
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(_accessKeyCantUpdateMock)
                );

            return server;
        }

        public static WireMockServer DeleteAccessKey(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/accesskey/delete")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeAccessKeyStatusChangeRequest
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
