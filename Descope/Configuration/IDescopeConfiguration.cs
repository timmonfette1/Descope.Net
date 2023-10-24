/* <copyright file="IDescopeConfiguration" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 20:06:29</date>
 */

using RestSharp.Authenticators.OAuth2;

namespace Descope.Configuration
{
    internal interface IDescopeConfiguration
    {
        string BaseUrl { get; }
        OAuth2AuthorizationRequestHeaderAuthenticator AuthApiAuthenticator { get; }
        OAuth2AuthorizationRequestHeaderAuthenticator ManagementApiAuthenticator { get; }
    }
}
