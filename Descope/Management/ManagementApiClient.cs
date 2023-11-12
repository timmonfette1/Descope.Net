/* <copyright file="ManagementApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 20:15:31</date>
 */

using Descope.Management.Permissions;
using Descope.Management.Roles;
using Descope.Management.Tenants;

namespace Descope.Management
{
    internal class ManagementApiClient : IManagementApiClient
    {
        private readonly IPermissionsApiClient _permissionsApiClient;
        private readonly IRolesApiClient _rolesApiClient;
        private readonly ITenantsApiClient _tenantsApiClient;

        public ManagementApiClient(
            IPermissionsApiClient permissionsApiClient,
            IRolesApiClient rolesApiClient,
            ITenantsApiClient tenants)
        {
            _permissionsApiClient = permissionsApiClient;
            _rolesApiClient = rolesApiClient;
            _tenantsApiClient = tenants;
        }

        public IPermissionsApiClient Permissions => _permissionsApiClient;
        public IRolesApiClient Roles => _rolesApiClient;
        public ITenantsApiClient Tenants => _tenantsApiClient;
    }
}
