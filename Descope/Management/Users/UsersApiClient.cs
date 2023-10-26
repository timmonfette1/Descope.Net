/* <copyright file="UsersApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 20:19:31</date>
 */

using Descope.Configuration;
using Descope.Extensions;
using Descope.HttpClient;
using Descope.Models;
using Descope.Utilities;
using RestSharp;

namespace Descope.Management.Users
{
    internal class UsersApiClient : IUsersApiClient
    {
        private readonly IDescopeManagementHttpClient _httpClient;

        internal UsersApiClient(IDescopeManagementHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DescopeUser> Get(string id)
        {
            var request = Requests.GetRequest(Endpoints.Management.LoadUser);
            request.AddQueryParameter("userId", id);

            var restResponse = await _httpClient.Client.ExecuteGetAsync(request);
            return _httpClient.Client.Serializers.DeserializeResponse<DescopeUser>(restResponse);
        }
    }
}
