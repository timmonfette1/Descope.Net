using Descope.Configuration;

namespace Descope.Test.Configuration
{
    public class EndpointsTests
    {
        [Fact]
        public void ShouldGetEndpoints()
        {
            Assert.Equal("v1/mgmt/accesskey", Endpoints.Management.LoadAccessKey);
            Assert.Equal("v1/mgmt/accesskey/search", Endpoints.Management.SearchAccessKeys);
            Assert.Equal("v1/mgmt/accesskey/create", Endpoints.Management.CreateAccessKey);
            Assert.Equal("v1/mgmt/accesskey/update", Endpoints.Management.UpdateAccessKey);
            Assert.Equal("v1/mgmt/accesskey/activate", Endpoints.Management.ActivateAccessKey);
            Assert.Equal("v1/mgmt/accesskey/deactivate", Endpoints.Management.DeactivateAccessKey);
            Assert.Equal("v1/mgmt/accesskey/delete", Endpoints.Management.DeleteAccessKey);
            Assert.Equal("v1/mgmt/audit/search", Endpoints.Management.SearchAudit);
            Assert.Equal("v1/mgmt/flow/list", Endpoints.Management.LoadAllFlows);
            Assert.Equal("v1/mgmt/flow/export", Endpoints.Management.ExportFlow);
            Assert.Equal("v1/mgmt/flow/import", Endpoints.Management.ImportFlow);
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
            Assert.Equal("v1/mgmt/theme/export", Endpoints.Management.ExportTheme);
            Assert.Equal("v1/mgmt/theme/import", Endpoints.Management.ImportTheme);
            Assert.Equal("v1/mgmt/user", Endpoints.Management.LoadUser);
            Assert.Equal("v1/mgmt/user/provider/token", Endpoints.Management.LoadUserToken);
            Assert.Equal("v1/mgmt/user/search", Endpoints.Management.SearchUsers);
            Assert.Equal("v1/mgmt/user/create", Endpoints.Management.CreateUser);
            Assert.Equal("v1/mgmt/user/create/batch", Endpoints.Management.BatchCreateUsers);
            Assert.Equal("v1/mgmt/user/update", Endpoints.Management.UpdateUser);
            Assert.Equal("v1/mgmt/user/update/status", Endpoints.Management.UpdateUserStatus);
            Assert.Equal("v1/mgmt/user/update/email", Endpoints.Management.UpdateUserEmail);
            Assert.Equal("v1/mgmt/user/update/loginid", Endpoints.Management.UpdateUserLoginId);
            Assert.Equal("v1/mgmt/user/update/phone", Endpoints.Management.UpdateUserPhone);
            Assert.Equal("v1/mgmt/user/update/name", Endpoints.Management.UpdateUserName);
            Assert.Equal("v1/mgmt/user/update/picture", Endpoints.Management.UpdateUserPicture);
            Assert.Equal("v1/mgmt/user/update/customAttribute", Endpoints.Management.UpdateUserCustomAttribute);
            Assert.Equal("v1/mgmt/user/update/tenant/add", Endpoints.Management.UpdateUserTenantsAdd);
            Assert.Equal("v1/mgmt/user/update/tenant/remove", Endpoints.Management.UpdateUserTenantsRemove);
            Assert.Equal("v1/mgmt/user/update/role/add", Endpoints.Management.UpdateUserRolesAdd);
            Assert.Equal("v1/mgmt/user/update/role/remove", Endpoints.Management.UpdateUserRolesRemove);
            Assert.Equal("v1/mgmt/user/password/set", Endpoints.Management.SetUserPassword);
            Assert.Equal("v1/mgmt/user/password/expire", Endpoints.Management.ExpireUserPassword);
            Assert.Equal("v1/mgmt/user/logout", Endpoints.Management.LogoutUser);
            Assert.Equal("v1/mgmt/user/signin/embeddedlink", Endpoints.Management.SigninUserEmbeddedLink);
            Assert.Equal("v1/mgmt/user/delete", Endpoints.Management.DeleteUser);
            Assert.Equal("v1/mgmt/tests/generate/otp", Endpoints.Management.GenerateTestUserOtp);
            Assert.Equal("v1/mgmt/tests/generate/magiclink", Endpoints.Management.GenerateTestUserMagicLink);
            Assert.Equal("v1/mgmt/tests/generate/enchantedlink", Endpoints.Management.GenerateTestUserEnchantedLink);
            Assert.Equal("v1/mgmt/user/test/delate/all", Endpoints.Management.DeleteTestUsers);
        }
    }
}
