/* <copyright file="DescopeManagementHttpClientTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/28/2023 22:22:37</date>
 */

using RestSharp;

namespace Descope.Test.HttpClient.Management
{
    public class DescopeManagementHttpClientTests : IClassFixture<DescopeManagementHttpClientFixture>
    {
        private readonly DescopeManagementHttpClientFixture _fixture;

        public DescopeManagementHttpClientTests(DescopeManagementHttpClientFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ShouldCreateRestClient()
        {
            var client = _fixture.DescopeManagementClient.Client;

            Assert.Equal("http://localhost:9999/", client.Options.BaseUrl.AbsoluteUri);
            Assert.Single(client.Serializers.Serializers.Values.Where(x => x.DataFormat == DataFormat.Json));
        }
    }
}
