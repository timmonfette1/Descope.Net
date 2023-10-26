/* <copyright file="ITenantsApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/24/2023 20:51:29</date>
 */

using Descope.Models;

namespace Descope.Management.Tenants
{
    public interface ITenantsApiClient
    {
        Task<DescopeTenant> Create(DescopeTenant tenant);
        Task<DescopeTenant> Update(DescopeTenant tenant);
    }
}
