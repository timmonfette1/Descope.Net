/* <copyright file="BaseManagementApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/7/2023 21:46:54</date>
 */

using Descope.Extensions;
using Descope.HttpClient;
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

        protected async Task<TResponse> GetAsync<TResponse>(string resource, object parameters = null) where TResponse : class, new()
        {
            var request = new RestRequest(resource, Method.Get);
            if (parameters != null)
            {
                foreach (var parameter in parameters.GetType().GetProperties())
                {
                    var name = parameter.Name;
                    var value = parameter.GetValue(parameters, null).ToString();
                    if (resource.Contains($"{{{parameter.Name}}}"))
                    {
                        request.AddUrlSegment(name, value);
                    }
                    else
                    {
                        request.AddQueryParameter(name, value);
                    }
                }
            }

            var response = await _httpClient.Client.ExecuteGetAsync(request);
            return _httpClient.Client.Serializers.DeserializeResponse<TResponse>(response);
        }

        protected async Task PostAsync<TBody>(string endpoint, TBody body) where TBody : class, new()
        {
            var request = CreatePostRequest(endpoint, body);
            var response = await _httpClient.Client.ExecutePostAsync(request);
            _httpClient.Client.Serializers.ParseResponse(response);
        }

        protected async Task<TResponse> PostAsync<TResponse, TBody>(string endpoint, TBody body) where TResponse : class, new() where TBody : class, new()
        {
            var request = CreatePostRequest(endpoint, body);
            var response = await _httpClient.Client.ExecutePostAsync(request);
            return _httpClient.Client.Serializers.DeserializeResponse<TResponse>(response);
        }

        #region Private Methods

        private static RestRequest CreatePostRequest<TBody>(string resource, TBody body) where TBody : class, new()
        {
            var request = new RestRequest(resource, Method.Post);
            request.AddJsonBody(body);

            return request;
        }

        #endregion Private Methods
    }
}
