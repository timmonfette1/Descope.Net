﻿/* <copyright file="DescopeConfiguration" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 20:06:45</date>
 */

using RestSharp.Authenticators.OAuth2;

namespace Descope.Configuration
{
    internal class DescopeConfiguration : IDescopeConfiguration
    {
        private const string BEARER = "Bearer";

        private readonly OAuth2AuthorizationRequestHeaderAuthenticator _mgmtAuthenticator;
        private readonly OAuth2AuthorizationRequestHeaderAuthenticator _authAuthenticator;

        internal DescopeConfiguration(string projectId, string managementKey)
        {
            var mgmtToken = $"{projectId}:{managementKey}";

            _mgmtAuthenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(mgmtToken, BEARER);
            _authAuthenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(projectId, BEARER);
        }

        public string BaseUrl => "https://api.descope.com";
        public OAuth2AuthorizationRequestHeaderAuthenticator AuthApiAuthenticator => _authAuthenticator;
        public OAuth2AuthorizationRequestHeaderAuthenticator ManagementApiAuthenticator => _mgmtAuthenticator;
    }
}
