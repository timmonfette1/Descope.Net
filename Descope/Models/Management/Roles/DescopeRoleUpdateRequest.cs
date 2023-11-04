/* <copyright file="DescopeRoleUpdateRequest" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 22:57:14</date>
 */

namespace Descope.Models
{
    public class DescopeRoleUpdateRequest
    {
        public string Name { get; set; }
        public string NewName { get; set; }
        public string Description { get; set; }
        public string[] PermissionNames { get; set; }
    }
}
