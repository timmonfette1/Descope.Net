/* <copyright file="ManagementApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 20:15:31</date>
 */

using Descope.Management.Tenants;
using Descope.Management.Users;

namespace Descope.Management
{
    internal class ManagementApiClient : IManagementApiClient
    {
        private readonly IUsersApiClient _usersApiClient;
        private readonly ITenantsApiClient _tenantsApiClient;

        public ManagementApiClient(IUsersApiClient usersApiClient, ITenantsApiClient tenants)
        {
            _usersApiClient = usersApiClient;
            _tenantsApiClient = tenants;
        }

        public IUsersApiClient Users => _usersApiClient;
        public ITenantsApiClient Tenants => _tenantsApiClient;
    }
}
