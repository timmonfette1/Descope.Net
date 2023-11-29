using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions_AccessKeys
    {
        private static readonly string[] roleNames = ["Role1"];
        private static readonly string[] tenantIds = ["TEST"];
        private static readonly string[] badTenantIds = ["TESTBAD"];
        private static readonly object[] keyTenants =
        [
            new
            {
                TenantId = "Tenant1",
                RoleNames = new string[1] { "TenantRole1" }
            },
            new
            {
                TenantId = "Tenant2",
                RoleNames = new string[1] { "TenantRole2" }
            }
        ];

        private static readonly object _accessKeyObjectMock = new
        {
            Id = "TEST",
            Name = "Testing",
            RoleNames = roleNames,
            KeyTenants = keyTenants,
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
                        .WithBodyAsJson(new
                        {
                            Key = _accessKeyObjectMock
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

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/accesskey")
                        .WithParam("id", true, "X")
                        .UsingGet()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(new
                        {
                            ErrorCode = "E011003",
                            ErrorDescription = "Request is invalid",
                            ErrorMessage = "The id field must be at least 27 characters",
                            Message = "The id field must be at least 27 characters"
                        })
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
                        .WithBody(new JsonMatcher(new
                        {
                            TenantIds = tenantIds
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new { Keys = new object[1] { _accessKeyObjectMock } })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/accesskey/search")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            TenantIds = badTenantIds
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new { Keys = Array.Empty<object>() })
                );

            return server;
        }

        public static WireMockServer CreateAccessKey(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/accesskey/create")
                        .UsingPost()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            ClearText = "Secret",
                            Key = _accessKeyObjectMock
                        })
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
                        .WithBody(new JsonMatcher(new
                        {
                            Id = "TEST",
                            Name = "Updated Testing"
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Key = new
                            {
                                Id = "TEST",
                                Name = "Updated Testing",
                                RoleNames = roleNames,
                                KeyTenants = keyTenants,
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
                        .WithBody(new JsonMatcher(new
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

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/accesskey/activate")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
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

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/accesskey/deactivate")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
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
