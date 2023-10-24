/* <copyright file="DescopeManagementHttpClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 19:58:12</date>
 */

using System.Text.Json;
using Descope.Configuration;
using RestSharp;
using RestSharp.Serializers.Json;

namespace Descope.HttpClient
{
    internal class DescopeManagementHttpClient : IDescopeManagementHttpClient
    {
        private readonly RestClient _client;

        internal DescopeManagementHttpClient(IDescopeConfiguration config)
        {
            var options = new RestClientOptions(config.BaseUrl)
            {
                Authenticator = config.ManagementApiAuthenticator
            };

            _client = new RestClient(options, configureSerialization: x => x.UseSystemTextJson(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            }));
        }

        public RestClient Client => _client;
    }
}
