/* <copyright file="IManagementApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 19:25:50</date>
 */

using Descope.Management.Permissions;
using Descope.Management.Roles;
using Descope.Management.Tenants;

namespace Descope.Management
{
    public interface IManagementApiClient
    {
        IPermissionsApiClient Permissions { get; }
        IRolesApiClient Roles { get; }
        ITenantsApiClient Tenants { get; }
    }
}
