using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions_Roles
    {
        private static readonly string[] _permissions = ["TestPerm"];
        private static readonly string[] _fakePermissions = ["FakePerm"];
        private static readonly object[] _roles =
        [
            new
            {
                Name = "TEST",
                Description = "Testing",
                PermissionNames = _permissions
            }
        ];

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
                        .WithBodyAsJson(new
                        {
                            Roles = _roles
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
                        .WithBody(new JsonMatcher(new
                        {
                            Name = "TEST",
                            Description = "Testing",
                            PermissionNames = _permissions,
                            CreatedTime = (long)0,
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
                        .WithBody(new JsonMatcher(new
                        {
                            Name = "EXIST",
                            Description = "Existing",
                            PermissionNames = _permissions,
                            CreatedTime = (long)0,
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
                        .WithBody(new JsonMatcher(new
                        {
                            Name = "TEST",
                            Description = "Testing",
                            PermissionNames = _fakePermissions,
                            CreatedTime = (long)0,
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
                        .WithBody(new JsonMatcher(new
                        {
                            Name = "TEST",
                            NewName = "UTEST",
                            Description = "Testing Updated",
                            PermissionNames = _permissions
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
                        .WithBody(new JsonMatcher(new
                        {
                            Name = "TESTBAD",
                            NewName = "UTEST",
                            Description = "Testing Updated",
                            PermissionNames = _permissions
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
                        .WithBody(new JsonMatcher(new
                        {
                            Name = "TEST",
                            NewName = "EXIST",
                            Description = "Testing Updated",
                            PermissionNames = _permissions
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
                        .WithBody(new JsonMatcher(new
                        {
                            Name = "TEST",
                            NewName = "UTEST",
                            Description = "Testing Updated",
                            PermissionNames = _fakePermissions
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
