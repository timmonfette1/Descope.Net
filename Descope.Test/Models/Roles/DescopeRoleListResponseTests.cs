/* <copyright file="DescopeRoleListResponseTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>11/3/2023 23:05:19</date>
 */

using Descope.Models;

namespace Descope.Test.Models.Roles
{
    public class DescopeRoleListResponseTests
    {
        [Fact]
        public void ShouldCreateObject()
        {
            var role = new DescopeRoleListResponse
            {
                Roles = new DescopeRole[2]
                {
                    new DescopeRole
                    {
                        Name = "Name",
                        Description = "Description",
                        PermissionNames = new string[1]
                        {
                            "Perm"
                        }
                    },
                    new DescopeRole
                    {
                        Name = "Name 2",
                        Description = "Description 2",
                        PermissionNames = new string[1]
                        {
                            "Perm2"
                        }
                    }
                }
            };

            Assert.Equal(2, role.Roles.Count());
            Assert.Equal("Name", role.Roles.ElementAt(0).Name);
            Assert.Equal("Description", role.Roles.ElementAt(0).Description);
            Assert.Single(role.Roles.ElementAt(0).PermissionNames);
            Assert.Equal("Perm", role.Roles.ElementAt(0).PermissionNames[0]);
            Assert.Equal("Name 2", role.Roles.ElementAt(1).Name);
            Assert.Equal("Description 2", role.Roles.ElementAt(1).Description);
            Assert.Single(role.Roles.ElementAt(1).PermissionNames);
            Assert.Equal("Perm2", role.Roles.ElementAt(1).PermissionNames[0]);
        }
    }
}
