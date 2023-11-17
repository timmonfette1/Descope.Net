using Descope.Models;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions_Permissions
    {
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
                        .WithBodyAsJson(new DescopePermissionListResponse
                        {
                            Permissions = new DescopePermission[1]
                            {
                                new DescopePermission
                                {
                                    Name = "TEST",
                                    Description = "Testing"
                                }
                            }
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
                        .WithBody(new JsonMatcher(new DescopePermission
                        {
                            Name = "TEST",
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
                        .WithPath("/v1/mgmt/permission/create")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopePermission
                        {
                            Name = "EXIST",
                            Description = "Existing"
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
                        .WithBody(new JsonMatcher(new DescopePermissionUpdateRequest
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
                        .WithBody(new JsonMatcher(new DescopePermissionUpdateRequest
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
                        .WithBody(new JsonMatcher(new DescopePermissionUpdateRequest
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

        public static WireMockServer DeletePermissions(this  WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/permission/delete")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopePermissionDeleteRequest
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
