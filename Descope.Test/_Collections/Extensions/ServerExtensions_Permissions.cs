using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions_Permissions
    {
        private static readonly object[] _permissions =
        [
            new
            {
                Name = "TEST",
                Description = "Testing"
            }
        ];

        public static WireMockServer GetAllPermissions(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/permission/all")
                        .UsingGet()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Permissions = _permissions
                        })
                );

            return server;
        }

        public static WireMockServer CreatePermissions(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/permission/create")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            Name = "TEST",
                            Description = "Testing",
                            SystemDefault = false,
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
                        .WithPath("/v1/mgmt/permission/create")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            Name = "EXIST",
                            Description = "Existing",
                            SystemDefault = false,
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(new
                        {
                            ErrorCode = "E024104",
                            ErrorDescription = "Failed to save permission, permission ID or Name already exist",
                            ErrorMessage = "Failed to create record, permission entity already exists",
                            Message = "Failed to create record, permission entity already exists"
                        })
                );

            return server;
        }

        public static WireMockServer UpdatePermissions(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/permission/update")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            Name = "TEST",
                            NewName = "TESTU",
                            Description = "Testing"
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
                        .WithPath("/v1/mgmt/permission/update")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            Name = "TEST",
                            NewName = "EXIST",
                            Description = "Testing"
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(new
                        {
                            ErrorCode = "E024104",
                            ErrorDescription = "Failed to save permission, permission ID or Name already exist",
                            ErrorMessage = "Failed to update record, a duplicate permission entity already exists",
                            Message = "Failed to update record, a duplicate permission entity already exists"
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/permission/update")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            Name = "TESTBAD",
                            NewName = "TEST",
                            Description = "Testing"
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(new
                        {
                            ErrorCode = "E111303",
                            ErrorDescription = "Permission not found",
                            ErrorMessage = "Permission does not exist",
                            Message = "Permission does not exist"
                        })
                );

            return server;
        }

        public static WireMockServer DeletePermissions(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/permission/delete")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            Name = "TEST"
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
