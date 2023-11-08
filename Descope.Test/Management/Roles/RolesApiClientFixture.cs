/* <copyright file="RolesApiClientFixture" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/6/2023 20:55:11</date>
 */

using Descope.Management.Roles;

namespace Descope.Test.Management.Roles
{
    public class RolesApiClientFixture
    {
        private readonly RolesApiClient _rolesApiClient;

        public RolesApiClientFixture(ClientServerFixture fixture)
        {
            _rolesApiClient = new RolesApiClient(fixture.HttpClient);
        }

        internal RolesApiClient RolesApiClient => _rolesApiClient;
    }
}
