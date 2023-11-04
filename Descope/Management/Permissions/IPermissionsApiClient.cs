/* <copyright file="IPermissionsApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 20:12:50</date>
 */

using Descope.Models;

namespace Descope.Management.Permissions
{
    public interface IPermissionsApiClient
    {
        Task<DescopePermissionListResponse> GetAll();
        Task<DescopePermission> Create(DescopePermission permission);
        Task<DescopePermission> Update(DescopePermissionUpdateRequest permission);
        Task Delete(DescopePermissionDeleteRequest permission);
    }
}
