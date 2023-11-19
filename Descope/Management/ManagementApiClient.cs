﻿using Descope.Management.AccessKeys;
using Descope.Management.Permissions;
using Descope.Management.Roles;
using Descope.Management.Tenants;
using Descope.Management.Themes;

namespace Descope.Management
{
    internal class ManagementApiClient : IManagementApiClient
    {
        private readonly IAccessKeysApiClient _accKeysApiClient;
        private readonly IPermissionsApiClient _permissionsApiClient;
        private readonly IRolesApiClient _rolesApiClient;
        private readonly ITenantsApiClient _tenantsApiClient;
        private readonly IThemesApiClient _themesApiClient;

        public ManagementApiClient(
            IAccessKeysApiClient accKeysApiClient,
            IPermissionsApiClient permissionsApiClient,
            IRolesApiClient rolesApiClient,
            ITenantsApiClient tenants,
            IThemesApiClient themes)
        {
            _accKeysApiClient = accKeysApiClient;
            _permissionsApiClient = permissionsApiClient;
            _rolesApiClient = rolesApiClient;
            _tenantsApiClient = tenants;
            _themesApiClient = themes;
        }

        public IAccessKeysApiClient AccessKeys => _accKeysApiClient;
        public IPermissionsApiClient Permissions => _permissionsApiClient;
        public IRolesApiClient Roles => _rolesApiClient;
        public ITenantsApiClient Tenants => _tenantsApiClient;
        public IThemesApiClient Themes => _themesApiClient;
    }
}
