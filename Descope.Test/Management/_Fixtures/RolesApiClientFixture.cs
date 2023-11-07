/* <copyright file="RolesApiClientFixture" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/6/2023 20:55:11</date>
 */

using Descope.HttpClient;
using Descope.Management.Roles;
using Descope.Models;
using Descope.Test.Mocks;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test.Management._Fixtures
{
    public class RolesApiClientFixture : IDisposable
    {
        private readonly WireMockServer _server;
        private readonly IDescopeManagementHttpClient _httpClient;
        private readonly RolesApiClient _rolesApiClient;

        public RolesApiClientFixture()
        {
            _server = WireMockServer.Start();

            #region Get All Roles Mocks

            _server
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

            #endregion Get All Roles Mocks

            #region Create Roles Mocks

            _server
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

            _server
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

            _server
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

            #endregion Create Roles Mocks

            #region Update Roles Mocks

            _server
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

            _server
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

            _server
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

            _server
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

            #endregion Update Roles Mocks

            #region Delete Role Mocks

            _server
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

            #endregion Delete Role Mocks

            var config = new IDescopeConfigurationMock(_server.Url);
            _httpClient = new DescopeManagementHttpClient(config.DescopeConfiguration);
            _rolesApiClient = new RolesApiClient(_httpClient);
        }

        internal RolesApiClient RolesApiClient => _rolesApiClient;

        public void Dispose()
        {
            _server?.Stop();
            _server?.Dispose();
            _httpClient?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
