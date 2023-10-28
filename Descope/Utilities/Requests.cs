/* <copyright file="Requests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/24/2023 21:45:55</date>
 */

using RestSharp;

namespace Descope.Utilities
{
    internal static class Requests
    {
        internal static RestRequest GetRequest(string resource)
        {
            var request = new RestRequest(resource, Method.Get);
            return request;
        }

        internal static RestRequest JsonPostRequest<T>(string resource, T body) where T : class, new()
        {
            var request = new RestRequest(resource, Method.Post);
            request.AddJsonBody<T>(body);

            return request;
        }
    }
}
