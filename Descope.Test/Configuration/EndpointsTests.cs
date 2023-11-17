/* <copyright file="EndpointsTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/26/2023 21:34:32</date>
 */

using Descope.Configuration;

namespace Descope.Test.Configuration
{
    public class EndpointsTests
    {
        [Fact]
        public void ShouldGetEndpoints()
        {
            Assert.Equal("mgmt/accesskey", Endpoints.Management.LoadAccessKey);
            Assert.Equal("mgmt/accesskey/search", Endpoints.Management.SearchAccessKeys);
            Assert.Equal("mgmt/accesskey/create", Endpoints.Management.CreateAccessKey);
            Assert.Equal("mgmt/accesskey/update", Endpoints.Management.UpdateAccessKey);
            Assert.Equal("mgmt/accesskey/activate", Endpoints.Management.ActivateAccessKey);
            Assert.Equal("mgmt/accesskey/deactivate", Endpoints.Management.DeactivateAccessKey);
            Assert.Equal("mgmt/accesskey/delete", Endpoints.Management.DeleteAccessKey);
            Assert.Equal("v1/mgmt/permission/all", Endpoints.Management.LoadAllPermissions);
            Assert.Equal("v1/mgmt/permission/create", Endpoints.Management.CreatePermission);
            Assert.Equal("v1/mgmt/permission/update", Endpoints.Management.UpdatePermission);
            Assert.Equal("v1/mgmt/permission/delete", Endpoints.Management.DeletePermission);
            Assert.Equal("v1/mgmt/role/all", Endpoints.Management.LoadAllRoles);
            Assert.Equal("v1/mgmt/role/create", Endpoints.Management.CreateRole);
            Assert.Equal("v1/mgmt/role/update", Endpoints.Management.UpdateRole);
            Assert.Equal("v1/mgmt/role/delete", Endpoints.Management.DeleteRole);
            Assert.Equal("v1/mgmt/tenant", Endpoints.Management.LoadTenant);
            Assert.Equal("v1/mgmt/tenant/all", Endpoints.Management.LoadAllTenants);
            Assert.Equal("v1/mgmt/tenant/search", Endpoints.Management.SearchTenants);
            Assert.Equal("v1/mgmt/tenant/create", Endpoints.Management.CreateTenant);
            Assert.Equal("v1/mgmt/tenant/update", Endpoints.Management.UpdateTenant);
            Assert.Equal("v1/mgmt/tenant/delete", Endpoints.Management.DeleteTenant);
        }
    }
}
