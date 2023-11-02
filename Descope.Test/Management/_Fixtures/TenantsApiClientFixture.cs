/* <copyright file="TenantsApiClientFixture" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/31/2023 20:53:26</date>
 */

using Descope.HttpClient;
using Descope.Management.Tenants;
using Descope.Models;
using Descope.Test.Mocks;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test.Management
{
    public class TenantsApiClientFixture : IDisposable
    {
        private readonly WireMockServer _server;
        private readonly IDescopeManagementHttpClient _httpClient;
        private readonly TenantsApiClient _tenantsApiClient;

        private readonly DescopeTenant _tenantMock;
        private readonly DescopeTenantListResponse _tenantListMock;

        public TenantsApiClientFixture()
        {
            _tenantMock = new()
            {
                Id = "TEST",
                Name = "Test Client",
            };

            _tenantListMock = new()
            {
                Tenants = new DescopeTenant[1]
                {
                    _tenantMock
                }
            };

            _server = WireMockServer.Start();

            #region Get All Tenants Mock

            _server
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

            #endregion Get All Tenants Mock

            #region Get Single Tenant Mock

            _server
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

            _server
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

            #endregion Get Single Tenant Mock

            #region Search Tenants Mock

            _server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/tenant/search")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeTenantSearchRequest
                        {
                            TenantIds = new string[1] { "TEST" }
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(_tenantListMock)
                );

            _server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/tenant/search")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeTenantSearchRequest
                        {
                            TenantNames = new string[1] { "Test Client" }
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(_tenantListMock)
                );

            _server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/tenant/search")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeTenantSearchRequest
                        {
                            TenantIds = new string[1] { "TESTBAD" }
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new DescopeTenantListResponse { Tenants = Array.Empty<DescopeTenant>() })
                );

            #endregion Search Tenants Mock

            #region Create Tenant Mock

            _server
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

            _server
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

            #endregion Create Tenant Mock

            #region Update Tenant Mock

            _server
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

            _server
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

            #endregion Update Tenant Mock

            #region Delete Tenant Mock

            _server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/tenant/delete")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new DescopeTenantDeleteRequest
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

            #endregion Delete Tenant Mock

            var config = new IDescopeConfigurationMock(_server.Url);
            _httpClient = new DescopeManagementHttpClient(config.DescopeConfiguration);
            _tenantsApiClient = new TenantsApiClient(_httpClient);
        }

        internal TenantsApiClient TenantsApiClient => _tenantsApiClient;

        public void Dispose()
        {
            _server?.Stop();
            _server?.Dispose();
            _httpClient?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
