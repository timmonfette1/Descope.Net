/* <copyright file="PermissionsApiClientFixture" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 20:33:30</date>
 */

using Descope.HttpClient;
using Descope.Management.Permissions;
using Descope.Models;
using Descope.Test.Mocks;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test.Management
{
    public class PermissionsApiClientFixture : IDisposable
    {
        private readonly WireMockServer _server;
        private readonly IDescopeManagementHttpClient _httpClient;
        private readonly PermissionsApiClient _permissionsApiClient;

        public PermissionsApiClientFixture()
        {
            _server = WireMockServer.Start();

            #region Get All Permissions Mocks

            _server
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

            #endregion Get All Permissions Mocks

            #region Create Permission Mocks

            _server
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
                        .WithBodyAsJson(new { Id = "TEST" })
                );

            _server
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

            #endregion Create Permission Mocks

            #region Update Permission Mocks

            _server
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

            _server
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

            _server
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

            #endregion Update Permission Mocks

            #region Delete Permission Mocks

            _server
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

            #endregion Delete Permission Mocks

            var config = new IDescopeConfigurationMock(_server.Url);
            _httpClient = new DescopeManagementHttpClient(config.DescopeConfiguration);
            _permissionsApiClient = new PermissionsApiClient(_httpClient);
        }

        internal PermissionsApiClient PermissionsApiClient => _permissionsApiClient;

        public void Dispose()
        {
            _server?.Stop();
            _server?.Dispose();
            _httpClient?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
