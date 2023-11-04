/* <copyright file="DescopePermissionTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 20:22:09</date>
 */

using Descope.Models;

namespace Descope.Test.Models.Permissions
{
    public class DescopePermissionTests
    {
        [Fact]
        public void ShouldCreateObject()
        {
            var permission = new DescopePermission
            {
                Name = "Name",
                Description = "Description"
            };

            Assert.Equal("Name", permission.Name);
            Assert.Equal("Description", permission.Description);
            Assert.False(permission.SystemDefault);
        }
    }
}
