﻿using Descope.HttpClient;
using Descope.Test.Mocks;
using WireMock.Server;

namespace Descope.Test
{
    public class ClientServerFixture : IDisposable
    {
        private readonly WireMockServer _server;
        private readonly IDescopeManagementHttpClient _httpClient;

        private readonly string _serverUrl;

        public ClientServerFixture()
        {
            _server = WireMockServer.Start();

            _server
                .ConfigureDummy()
                .ConfigureAccessKeys()
                .ConifgurePermissions()
                .ConifgureRoles()
                .ConifgureTenants()
                .ConfigureThemes();

            _serverUrl = _server.Url;
            var config = new IDescopeConfigurationMock(_serverUrl);
            _httpClient = new DescopeManagementHttpClient(config.DescopeConfiguration);
        }

        internal IDescopeManagementHttpClient HttpClient => _httpClient;

        internal string ServerUrl => _serverUrl;

        public void Dispose()
        {
            _server?.Stop();
            _server?.Dispose();
            _httpClient?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
