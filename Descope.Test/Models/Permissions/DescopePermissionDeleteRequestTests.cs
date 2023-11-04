/* <copyright file="DescopePermissionDeleteRequestTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 20:23:43</date>
 */

using Descope.Models;

namespace Descope.Test.Models.Permissions
{
    public class DescopePermissionDeleteRequestTests
    {
        [Fact]
        public void ShouldCreateObject()
        {
            var permission = new DescopePermissionDeleteRequest
            {
                Name = "Name"
            };

            Assert.Equal("Name", permission.Name);
        }
    }
}
