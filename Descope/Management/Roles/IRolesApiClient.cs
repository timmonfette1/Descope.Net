/* <copyright file="IRolesApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 23:11:01</date>
 */

using Descope.Models;

namespace Descope.Management.Roles
{
    public interface IRolesApiClient
    {
        Task<DescopeRoleListResponse> GetAll();
        Task<DescopeRole> Create(DescopeRole role);
        Task<DescopeRole> Update(DescopeRoleUpdateRequest role);
        Task Delete(DescopeRoleDeleteRequest role);
    }
}
