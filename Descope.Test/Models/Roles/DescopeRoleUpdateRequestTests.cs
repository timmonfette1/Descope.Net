/* <copyright file="DescopeRoleUpdateRequestTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 23:02:53</date>
 */

using Descope.Models;

namespace Descope.Test.Models.Roles
{
    public class DescopeRoleUpdateRequestTests
    {
        [Fact]
        public void ShouldCreateObject()
        {
            var role = new DescopeRoleUpdateRequest
            {
                Name = "TEST",
                NewName = "TESTU",
                Description = "Testing",
                PermissionNames = new string[1]
                {
                    "New Perm"
                }
            };

            Assert.Equal("TEST", role.Name);
            Assert.Equal("TESTU", role.NewName);
            Assert.Equal("Testing", role.Description);
            Assert.Single(role.PermissionNames);

            var perm = role.PermissionNames.Single();

            Assert.Equal("New Perm", perm);
        }
    }
}
