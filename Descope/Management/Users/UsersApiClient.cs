/* <copyright file="UsersApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 20:19:31</date>
 */

using Descope.Configuration;
using Descope.HttpClient;
using Descope.Models;
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

        public async Task<IEnumerable<DescopeUser>> Get()
        {
            return await _httpClient.Client.GetJsonAsync<IEnumerable<DescopeUser>>(Endpoints.LoadUser);
        }
    }
}
