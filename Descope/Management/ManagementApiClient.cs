/* <copyright file="ManagementApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 20:15:31</date>
 */

using Descope.Management.Users;

namespace Descope.Management
{
    internal class ManagementApiClient : IManagementApiClient
    {
        private readonly IUsersApiClient _usersApiClient;

        internal ManagementApiClient(IUsersApiClient usersApiClient)
        {
            _usersApiClient = usersApiClient;
        }

        public IUsersApiClient Users => _usersApiClient;
    }
}
