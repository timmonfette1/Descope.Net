using Descope.Auth.AccessKey;

namespace Descope.Auth
{
    public interface IAuthApiClient
    {
        IAccessKeyApiClient AccessKey { get; }
    }
}
