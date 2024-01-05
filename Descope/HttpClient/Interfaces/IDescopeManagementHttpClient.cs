namespace Descope.HttpClient
{
    internal interface IDescopeManagementHttpClient : IDisposable
    {
        Task<TResponse> GetAsync<TResponse>(string resource, object parameters = null) where TResponse : class, new();
        Task DeleteAsync(string resource);
        Task PostAsync<TBody>(string resource, TBody body) where TBody : class, new();
        Task<TResponse> PostAsync<TBody, TResponse>(string resource, TBody body) where TBody : class, new() where TResponse : class, new();
    }
}
