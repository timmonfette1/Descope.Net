using Descope.Auth.AccessKey;

namespace Descope
{
    public interface IAuthApiClient
    {
        IAccessKeyApiClient AccessKey { get; }
    }
}
