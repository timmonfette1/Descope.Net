/* <copyright file="RestSerializersExtensions" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/24/2023 21:27:07</date>
 */

using Descope.Models;
using RestSharp;
using RestSharp.Serializers;

namespace Descope.Extensions
{
    internal static class RestSerializersExtensions
    {
        internal static void ParseResponse(this RestSerializers serializers, RestResponse response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var exception = serializers.DeserializeContent<DescopeException>(response);
                throw exception;
            }
        }

        internal static T DeserializeResponse<T>(this RestSerializers serializers, RestResponse response) where T : class, new()
        {
            if (response.IsSuccessStatusCode)
            {
                return serializers.DeserializeContent<T>(response);
            }
            else
            {
                var exception = serializers.DeserializeContent<DescopeException>(response);
                throw exception;
            }
        }
    }
}
