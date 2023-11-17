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
