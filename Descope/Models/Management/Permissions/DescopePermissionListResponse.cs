/* <copyright file="DescopePermissionListResponse" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 20:12:00</date>
 */

namespace Descope.Models
{
    public class DescopePermissionListResponse
    {
        public IEnumerable<DescopePermission> Permissions { get; set; }
    }
}
