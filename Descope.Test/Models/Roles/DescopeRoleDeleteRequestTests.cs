/* <copyright file="DescopeRoleDeleteRequestTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 23:02:07</date>
 */

using Descope.Models;

namespace Descope.Test.Models.Roles
{
    public class DescopeRoleDeleteRequestTests
    {
        [Fact]
        public void ShouldCreateObject()
        {
            var role = new DescopeRoleDeleteRequest
            {
                Name = "TEST"
            };

            Assert.Equal("TEST", role.Name);
        }
    }
}
