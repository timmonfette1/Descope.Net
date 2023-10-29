/* <copyright file="DescopeManagementHttpClientFixture" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/28/2023 21:52:46</date>
 */

using Descope.HttpClient;
using Descope.Test.Mocks;

namespace Descope.Test.HttpClient
{
    public class DescopeManagementHttpClientFixture : IDisposable
    {
        private readonly DescopeManagementHttpClient _client;

        public DescopeManagementHttpClientFixture()
        {
            var config = new IDescopeConfigurationMock();
            _client = new DescopeManagementHttpClient(config.DescopeConfiguration);
        }

        internal DescopeManagementHttpClient DescopeManagementClient => _client;

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
