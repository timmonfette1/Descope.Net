using Descope.Management.AccessKeys;
using Descope.Management.Flows;
using Descope.Management.Permissions;
using Descope.Management.Roles;
using Descope.Management.Tenants;
using Descope.Management.Themes;

namespace Descope.Management
{
    internal class ManagementApiClient(
        IAccessKeysApiClient accKeysApiClient,
        IFlowsApiClient flowsApiClient,
        IPermissionsApiClient permissionsApiClient,
        IRolesApiClient rolesApiClient,
        ITenantsApiClient tenants,
        IThemesApiClient themes) : IManagementApiClient
    {
        private readonly IAccessKeysApiClient _accKeysApiClient = accKeysApiClient;
        private readonly IFlowsApiClient _flowsApiClient = flowsApiClient;
        private readonly IPermissionsApiClient _permissionsApiClient = permissionsApiClient;
        private readonly IRolesApiClient _rolesApiClient = rolesApiClient;
        private readonly ITenantsApiClient _tenantsApiClient = tenants;
        private readonly IThemesApiClient _themesApiClient = themes;

        public IAccessKeysApiClient AccessKeys => _accKeysApiClient;
        public IFlowsApiClient Flows => _flowsApiClient;
        public IPermissionsApiClient Permissions => _permissionsApiClient;
        public IRolesApiClient Roles => _rolesApiClient;
        public ITenantsApiClient Tenants => _tenantsApiClient;
        public IThemesApiClient Themes => _themesApiClient;
    }
}
