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
    public interface IManagementApiClient
    {
        IAccessKeysApiClient AccessKeys { get; }
        IAuditApiClient Audit { get; }
        IFlowsApiClient Flows { get; }
        IPermissionsApiClient Permissions { get; }
        IRolesApiClient Roles { get; }
        ITenantsApiClient Tenants { get; }
        IThemesApiClient Themes { get; }
        IUsersApiClient Users { get; }
    }
}
