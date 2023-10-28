/* <copyright file="DescopeConfigurationTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/26/2023 21:23:06</date>
 */

using RestSharp.Authenticators.OAuth2;

namespace Descope.Test.Configuration
{
    public class DescopeConfigurationTests : IClassFixture<DescopeConfigurationFixture>
    {
        private readonly DescopeConfigurationFixture _fixture;

        public DescopeConfigurationTests(DescopeConfigurationFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ShouldGetBaseUrl()
        {
            var baseUrl = _fixture.Config.BaseUrl;

            Assert.Equal("https://api.descope.com", baseUrl);
        }

        [Fact]
        public void ShouldGetAuthAuthenticator()
        {
            var authenticator = _fixture.Config.AuthApiAuthenticator;

            Assert.IsType<OAuth2AuthorizationRequestHeaderAuthenticator>(authenticator);
        }

        [Fact]
        public void ShouldGetManagementAuthenticator()
        {
            var authenticator = _fixture.Config.ManagementApiAuthenticator;

            Assert.IsType<OAuth2AuthorizationRequestHeaderAuthenticator>(authenticator);
        }
    }
}
