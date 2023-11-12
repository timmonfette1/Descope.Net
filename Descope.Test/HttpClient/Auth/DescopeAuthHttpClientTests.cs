/* <copyright file="DescopeAuthHttpClientTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/28/2023 21:42:13</date>
 */

using RestSharp;

namespace Descope.Test.HttpClient.Auth
{
    public class DescopeAuthHttpClientTests : IClassFixture<DescopeAuthHttpClientFixture>
    {
        private readonly DescopeAuthHttpClientFixture _fixture;

        public DescopeAuthHttpClientTests(DescopeAuthHttpClientFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ShouldCreateRestClient()
        {
            var client = _fixture.DescopeAuthClient.Client;

            Assert.Equal("http://localhost:9999/", client.Options.BaseUrl.AbsoluteUri);
            Assert.Single(client.Serializers.Serializers.Values.Where(x => x.DataFormat == DataFormat.Json));
        }
    }
}
