﻿using Descope.Management.AccessKeys;
using Descope.Management.Permissions;
using Descope.Management.Roles;
using Descope.Management.Tenants;

namespace Descope.Management
{
    public interface IManagementApiClient
    {
        IAccessKeysApiClient AccessKeys { get; }
        IPermissionsApiClient Permissions { get; }
        IRolesApiClient Roles { get; }
        ITenantsApiClient Tenants { get; }
    }
}
