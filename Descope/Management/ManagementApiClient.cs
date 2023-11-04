/* <copyright file="ManagementApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 20:15:31</date>
 */

using Descope.Management.Permissions;
using Descope.Management.Tenants;
using Descope.Management.Users;

namespace Descope.Management
{
    internal class ManagementApiClient : IManagementApiClient
    {
        private readonly IPermissionsApiClient _permissionsApiClient;
        private readonly ITenantsApiClient _tenantsApiClient;
        private readonly IUsersApiClient _usersApiClient;

        public ManagementApiClient(
            IPermissionsApiClient permissionsApiClient,
            ITenantsApiClient tenants,
            IUsersApiClient usersApiClient)
        {
            _permissionsApiClient = permissionsApiClient;
            _tenantsApiClient = tenants;
            _usersApiClient = usersApiClient;
        }

        public IPermissionsApiClient Permissions => _permissionsApiClient;
        public ITenantsApiClient Tenants => _tenantsApiClient;
        public IUsersApiClient Users => _usersApiClient;
    }
}
