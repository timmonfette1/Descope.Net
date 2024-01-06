using Descope.Models;

namespace Descope.Auth.AccessKey
{
    public interface IAccessKeyApiClient
    {
        Task<DescopeAccessKeyExchangeResponse> Exchange(string accessKey);
    }
}
