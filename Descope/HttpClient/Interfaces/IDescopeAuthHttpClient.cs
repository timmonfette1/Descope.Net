using RestSharp;

namespace Descope.HttpClient
{
    internal interface IDescopeAuthHttpClient : IDisposable
    {
        RestClient Client { get; }

    }
}
