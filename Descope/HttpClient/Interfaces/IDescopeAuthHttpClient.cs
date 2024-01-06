namespace Descope.HttpClient
{
    internal interface IDescopeAuthHttpClient : IDisposable
    {
        Task<TResponse> PostWithCustomTokenAsync<TBody, TResponse>(string resource, string customTokenValue, TBody body) where TBody : class, new() where TResponse : class, new();
    }
}
