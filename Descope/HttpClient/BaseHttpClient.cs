using RestSharp;

namespace Descope.HttpClient
{
    internal class BaseHttpClient
    {
        protected static RestRequest CreatePostRequest<TBody>(string resource, TBody body) where TBody : class, new()
        {
            var request = new RestRequest(resource, Method.Post);
            request.AddJsonBody(body);

            return request;
        }
    }
}
