/* <copyright file="DescopePermissionUpdateRequest" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 20:06:23</date>
 */

namespace Descope.Models
{
    public class DescopePermissionUpdateRequest
    {
        public string Name { get; set; }
        public string NewName { get; set; }
        public string Description { get; set; }
    }
}
