using Descope.Models;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions_Roles
    {
        public static WireMockServer GetAllRoles(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/role/all")
                        .UsingGet()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new DescopeRoleListResponse
                        {
                            Roles = new DescopeRole[1]
                            {
                                new DescopeRole
                                {
                                    Name = "TEST",
                                    Description = "Testing",
                                    PermissionNames = new string[1]
                                    {
                                        "TestPerm"
                                    }
                                }
                            }
                        })
                );

            return server;
        }

        public static WireMockServer CreateRoles(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/role/create")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeRole
                        {
                            Name = "TEST",
                            Description = "Testing",
                            PermissionNames = new string[1]
                            {
                                "TestPerm"
                            }
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
                        .WithPath("/v1/mgmt/role/create")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeRole
                        {
                            Name = "EXIST",
                            Description = "Existing",
                            PermissionNames = new string[1]
                            {
                                "TestPerm"
                            }
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(new
                        {
                            ErrorCode = "E024209",
                            ErrorDescription = "Failed to save role, role ID or Name already exist",
                            ErrorMessage = "Failed to create record, role entity already exists",
                            Message = "Failed to create record, role entity already exists"
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/role/create")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeRole
                        {
                            Name = "TEST",
                            Description = "Testing",
                            PermissionNames = new string[1]
                            {
                                "FakePerm"
                            }
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

        public static WireMockServer UpdateRoles(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/role/update")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeRoleUpdateRequest
                        {
                            Name = "TEST",
                            NewName = "UTEST",
                            Description = "Testing Updated",
                            PermissionNames = new string[1]
                            {
                                "TestPerm"
                            }
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
                        .WithPath("/v1/mgmt/role/update")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeRoleUpdateRequest
                        {
                            Name = "TESTBAD",
                            NewName = "UTEST",
                            Description = "Testing Updated",
                            PermissionNames = new string[1]
                            {
                                "TestPerm"
                            }
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(new
                        {
                            ErrorCode = "E111403",
                            ErrorDescription = "Role not found",
                            ErrorMessage = "Role does not exist",
                            Message = "Role does not exist"
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/role/update")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeRoleUpdateRequest
                        {
                            Name = "TEST",
                            NewName = "EXIST",
                            Description = "Testing Updated",
                            PermissionNames = new string[1]
                            {
                                "TestPerm"
                            }
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(500)
                        .WithBodyAsJson(new
                        {
                            ErrorCode = "E024209",
                            ErrorDescription = "Failed to save role, role ID or Name already exist",
                            ErrorMessage = "Failed to create record, role entity already exists",
                            Message = "Failed to create record, role entity already exists"
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/role/update")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeRoleUpdateRequest
                        {
                            Name = "TEST",
                            NewName = "UTEST",
                            Description = "Testing Updated",
                            PermissionNames = new string[1]
                            {
                                "FakePerm"
                            }
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

        public static WireMockServer DeleteRoles(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/role/delete")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeRoleDeleteRequest
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
