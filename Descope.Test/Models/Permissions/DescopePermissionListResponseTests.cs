/* <copyright file="DescopePermissionListResponseTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 20:25:13</date>
 */

using Descope.Models;

namespace Descope.Test.Models.Permissions
{
    public class DescopePermissionListResponseTests
    {
        [Fact]
        public void ShouldCreateObject()
        {
            var permission = new DescopePermissionListResponse
            {
                Permissions = new DescopePermission[2]
                {
                    new DescopePermission
                    {
                        Name = "Name",
                        Description = "Description"
                    },
                    new DescopePermission
                    {
                        Name = "Name 2",
                        Description = "Description 2"
                    }
                }
            };

            Assert.Equal(2, permission.Permissions.Count());
            Assert.Equal("Name", permission.Permissions.ElementAt(0).Name);
            Assert.Equal("Description", permission.Permissions.ElementAt(0).Description);
            Assert.Equal("Name 2", permission.Permissions.ElementAt(1).Name);
            Assert.Equal("Description 2", permission.Permissions.ElementAt(1).Description);
        }
    }
}
