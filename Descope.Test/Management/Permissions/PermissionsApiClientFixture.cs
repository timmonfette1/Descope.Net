/* <copyright file="PermissionsApiClientFixture" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 20:33:30</date>
 */

using Descope.Management.Permissions;

namespace Descope.Test.Management.Permissions
{
    public class PermissionsApiClientFixture
    {
        private readonly PermissionsApiClient _permissionsApiClient;

        public PermissionsApiClientFixture(ClientServerFixture fixture)
        {
            _permissionsApiClient = new PermissionsApiClient(fixture.HttpClient);
        }

        internal PermissionsApiClient PermissionsApiClient => _permissionsApiClient;
    }
}
