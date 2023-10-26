/* <copyright file="DescopeTenant" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/24/2023 20:52:24</date>
 */

namespace Descope.Models
{
    public class DescopeTenant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string[] SelfProvisioningDomains { get; set; }
        public object CustomAttributes { get; set; }
    }
}
