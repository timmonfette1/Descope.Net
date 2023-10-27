/* <copyright file="DescopeConfigurationTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/26/2023 21:23:06</date>
 */

using Descope.Configuration;
using RestSharp.Authenticators.OAuth2;

namespace Descope.Test.Configuration
{
    public class DescopeConfigurationTests
    {
        private readonly DescopeConfiguration _config;

        public DescopeConfigurationTests()
        {
            _config = new DescopeConfiguration("myProjectId", "myManagementKey");
        }

        [Fact]
        public void ShouldGetBaseUrl()
        {
            var baseUrl = _config.BaseUrl;

            Assert.Equal("https://api.descope.com", baseUrl);
        }

        [Fact]
        public void ShouldGetAuthAuthenticator()
        {
            var authenticator = _config.AuthApiAuthenticator;

            Assert.IsType<OAuth2AuthorizationRequestHeaderAuthenticator>(authenticator);
        }

        [Fact]
        public void ShouldGetManagementAuthenticator()
        {
            var authenticator = _config.ManagementApiAuthenticator;

            Assert.IsType<OAuth2AuthorizationRequestHeaderAuthenticator>(authenticator);
        }
    }
}
