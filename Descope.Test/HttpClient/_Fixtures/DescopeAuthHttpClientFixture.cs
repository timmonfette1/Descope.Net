/* <copyright file="DescopeAuthHttpClientFixture" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/28/2023 21:52:46</date>
 */

using Descope.HttpClient;
using Descope.Test.Mocks;

namespace Descope.Test.HttpClient
{
    public class DescopeAuthHttpClientFixture : IDisposable
    {
        private readonly DescopeAuthHttpClient _client;

        public DescopeAuthHttpClientFixture()
        {
            var config = new IDescopeConfigurationMock();
            _client = new DescopeAuthHttpClient(config.DescopeConfiguration);
        }

        internal DescopeAuthHttpClient DescopeAuthClient => _client;

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
