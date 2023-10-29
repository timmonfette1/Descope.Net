/* <copyright file="DescopeAuthHttpClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 20:14:30</date>
 */

using System.Text.Json;
using Descope.Configuration;
using RestSharp;
using RestSharp.Serializers.Json;

namespace Descope.HttpClient
{
    internal class DescopeAuthHttpClient : IDescopeAuthHttpClient
    {
        private readonly RestClient _client;

        public DescopeAuthHttpClient(IDescopeConfiguration config)
        {
            var options = new RestClientOptions(config.BaseUrl)
            {
                Authenticator = config.AuthApiAuthenticator
            };

            _client = new RestClient(options, configureSerialization: x => x.UseSystemTextJson(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            }));
        }

        public RestClient Client => _client;

        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
