/* <copyright file="DescopeRole" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 22:51:18</date>
 */

namespace Descope.Models
{
    public class DescopeRole
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] PermissionNames { get; set; }
        public long CreatedTime { get; private set; }
    }
}
