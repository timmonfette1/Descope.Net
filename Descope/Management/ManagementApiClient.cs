using Descope.Management.AccessKeys;
using Descope.Management.Audit;
using Descope.Management.Flows;
using Descope.Management.Permissions;
using Descope.Management.Roles;
using Descope.Management.Tenants;
using Descope.Management.Themes;
using Descope.Management.Users;

namespace Descope.Management
{
    internal class ManagementApiClient(
        IAccessKeysApiClient accessKeysApiClient,
        IAuditApiClient auditApiClient,
        IFlowsApiClient flowsApiClient,
        IPermissionsApiClient permissionsApiClient,
        IRolesApiClient rolesApiClient,
        ITenantsApiClient tenants,
        IThemesApiClient themes,
        IUsersApiClient users) : IManagementApiClient
    {
        private readonly IAccessKeysApiClient _accessKeysApiClient = accessKeysApiClient;
        private readonly IAuditApiClient _auditApiClient = auditApiClient;
        private readonly IFlowsApiClient _flowsApiClient = flowsApiClient;
        private readonly IPermissionsApiClient _permissionsApiClient = permissionsApiClient;
        private readonly IRolesApiClient _rolesApiClient = rolesApiClient;
        private readonly ITenantsApiClient _tenantsApiClient = tenants;
        private readonly IThemesApiClient _themesApiClient = themes;
        private readonly IUsersApiClient _usersApiClient = users;

        public IAccessKeysApiClient AccessKeys => _accessKeysApiClient;
        public IAuditApiClient Audit => _auditApiClient;
        public IFlowsApiClient Flows => _flowsApiClient;
        public IPermissionsApiClient Permissions => _permissionsApiClient;
        public IRolesApiClient Roles => _rolesApiClient;
        public ITenantsApiClient Tenants => _tenantsApiClient;
        public IThemesApiClient Themes => _themesApiClient;
        public IUsersApiClient Users => _usersApiClient;
    }
}
