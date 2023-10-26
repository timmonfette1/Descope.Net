/* <copyright file="DescopeTenantListResponse" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/26/2023 15:59:57</date>
 */

namespace Descope.Models
{
    public class DescopeTenantListResponse
    {
        public IEnumerable<DescopeTenant> Tenants { get; set; }
    }
}
