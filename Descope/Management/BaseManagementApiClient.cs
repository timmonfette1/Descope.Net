/* <copyright file="BaseManagementApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/7/2023 21:46:54</date>
 */

using Descope.Extensions;
using Descope.HttpClient;
using Descope.Utilities;
using RestSharp;

namespace Descope.Management
{
    internal class BaseManagementApiClient
    {
        private readonly IDescopeManagementHttpClient _httpClient;

        protected BaseManagementApiClient(IDescopeManagementHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<T> GetAll<T>(string endpoint) where T :class, new()
        {
            var request = Requests.GetRequest(endpoint);
            var restResponse = await _httpClient.Client.ExecuteGetAsync(request);
            return _httpClient.Client.Serializers.DeserializeResponse<T>(restResponse);
        }
    }
}
