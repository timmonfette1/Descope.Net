/* <copyright file="DescopePermission" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 20:05:08</date>
 */

namespace Descope.Models
{
    public class DescopePermission
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool SystemDefault { get; private set; }
    }
}
