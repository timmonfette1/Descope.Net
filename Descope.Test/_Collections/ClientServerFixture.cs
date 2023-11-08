/* <copyright file="ClientServerFixture" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/7/2023 21:08:17</date>
 */

using Descope.HttpClient;
using Descope.Test.Mocks;
using WireMock.Server;

namespace Descope.Test
{
    public class ClientServerFixture : IDisposable
    {
        private readonly WireMockServer _server;
        private readonly IDescopeManagementHttpClient _httpClient;

        public ClientServerFixture()
        {
            _server = WireMockServer.Start();

            _server
                .ConifgurePermissions()
                .ConifgureRoles()
                .ConifgureTenants();

            var config = new IDescopeConfigurationMock(_server.Url);
            _httpClient = new DescopeManagementHttpClient(config.DescopeConfiguration);
        }

        internal IDescopeManagementHttpClient HttpClient => _httpClient;

        public void Dispose()
        {
            _server?.Stop();
            _server?.Dispose();
            _httpClient?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
