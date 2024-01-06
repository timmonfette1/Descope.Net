using Descope.Auth.AccessKey;

namespace Descope.Auth
{
    internal class AuthApiClient(IAccessKeyApiClient accessKeyApiClient) : IAuthApiClient
    {
        private readonly IAccessKeyApiClient _accessKeyApiClient = accessKeyApiClient;

        public IAccessKeyApiClient AccessKey => _accessKeyApiClient;
    }
}
