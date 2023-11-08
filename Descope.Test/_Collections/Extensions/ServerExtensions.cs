/* <copyright file="ServerExtensions" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/7/2023 21:13:21</date>
 */

using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions
    {
        public static WireMockServer ConifgurePermissions(this WireMockServer server)
        {
            server
                .GetAllPermissions()
                .CreatePermissions()
                .UpdatePermissions()
                .DeletePermissions();

            return server;
        }

        public static WireMockServer ConifgureRoles(this WireMockServer server)
        {
            server
                .GetAllRoles()
                .CreateRoles()
                .UpdateRoles()
                .DeleteRoles();

            return server;
        }

        public static WireMockServer ConifgureTenants(this WireMockServer server)
        {
            server
                .GetAllTenants()
                .GetTenants()
                .SearchTenants()
                .CreateTenants()
                .UpdateTenants()
                .DeleteTenants();

            return server;
        }
    }
}
