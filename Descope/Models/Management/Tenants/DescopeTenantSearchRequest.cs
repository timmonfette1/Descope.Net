/* <copyright file="DescopeTenantSearchRequest" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/26/2023 15:57:13</date>
 */

namespace Descope.Models
{
    public class DescopeTenantSearchRequest
    {
        public string[] TenantIds { get; set; }
        public string[] TenantNames { get; set; }
        public string[] TenantSelfProvisioningDomains { get; set; }
        public object CustomAttributes { get; set; }
    }
}
