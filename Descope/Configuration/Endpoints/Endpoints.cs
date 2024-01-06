namespace Descope.Configuration
{
    internal static class Endpoints
    {
        private const string VERSION = "v1";

        internal static class Auth
        {
            internal static string ExchangeAccessKey => Url(AuthEndpoints.ExchangeAccessKey);
        }

        internal static class Management
        {
            internal static string LoadAccessKey => Url(ManagementEndpoints.LoadAccessKey);
            internal static string SearchAccessKeys => Url(ManagementEndpoints.SearchAccessKeys);
            internal static string CreateAccessKey => Url(ManagementEndpoints.CreateAccessKey);
            internal static string UpdateAccessKey => Url(ManagementEndpoints.UpdateAccessKey);
            internal static string ActivateAccessKey => Url(ManagementEndpoints.ActivateAccessKey);
            internal static string DeactivateAccessKey => Url(ManagementEndpoints.DeactivateAccessKey);
            internal static string DeleteAccessKey => Url(ManagementEndpoints.DeleteAccessKey);
            internal static string SearchAudit => Url(ManagementEndpoints.SearchAudit);
            internal static string LoadAllFlows => Url(ManagementEndpoints.LoadAllFlows);
            internal static string ExportFlow => Url(ManagementEndpoints.ExportFlow);
            internal static string ImportFlow => Url(ManagementEndpoints.ImportFlow);
            internal static string LoadAllPermissions => Url(ManagementEndpoints.LoadAllPermissions);
            internal static string CreatePermission => Url(ManagementEndpoints.CreatePermission);
            internal static string UpdatePermission => Url(ManagementEndpoints.UpdatePermission);
            internal static string DeletePermission => Url(ManagementEndpoints.DeletePermission);
            internal static string LoadAllRoles => Url(ManagementEndpoints.LoadAllRoles);
            internal static string CreateRole => Url(ManagementEndpoints.CreateRole);
            internal static string UpdateRole => Url(ManagementEndpoints.UpdateRole);
            internal static string DeleteRole => Url(ManagementEndpoints.DeleteRole);
            internal static string LoadAllTenants => Url(ManagementEndpoints.LoadAllTenants);
            internal static string LoadTenant => Url(ManagementEndpoints.LoadTenant);
            internal static string SearchTenants => Url(ManagementEndpoints.SearchTenants);
            internal static string CreateTenant => Url(ManagementEndpoints.CreateTenant);
            internal static string UpdateTenant => Url(ManagementEndpoints.UpdateTenant);
            internal static string DeleteTenant => Url(ManagementEndpoints.DeleteTenant);
            internal static string ExportTheme => Url(ManagementEndpoints.ExportTheme);
            internal static string ImportTheme => Url(ManagementEndpoints.ImportTheme);
            internal static string LoadUser => Url(ManagementEndpoints.LoadUser);
            internal static string LoadUserToken => Url(ManagementEndpoints.LoadUserToken);
            internal static string SearchUsers => Url(ManagementEndpoints.SearchUsers);
            internal static string CreateUser => Url(ManagementEndpoints.CreateUser);
            internal static string BatchCreateUsers => Url(ManagementEndpoints.BatchCreateUsers);
            internal static string UpdateUser => Url(ManagementEndpoints.UpdateUser);
            internal static string UpdateUserStatus => Url(ManagementEndpoints.UpdateUserStatus);
            internal static string UpdateUserEmail => Url(ManagementEndpoints.UpdateUserEmail);
            internal static string UpdateUserLoginId => Url(ManagementEndpoints.UpdateUserLoginId);
            internal static string UpdateUserPhone => Url(ManagementEndpoints.UpdateUserPhone);
            internal static string UpdateUserName => Url(ManagementEndpoints.UpdateUserName);
            internal static string UpdateUserPicture => Url(ManagementEndpoints.UpdateUserPicture);
            internal static string UpdateUserCustomAttribute => Url(ManagementEndpoints.UpdateUserCustomAttribute);
            internal static string UpdateUserTenantsAdd => Url(ManagementEndpoints.UpdateUserTenantsAdd);
            internal static string UpdateUserTenantsRemove => Url(ManagementEndpoints.UpdateUserTenantsRemove);
            internal static string UpdateUserRolesAdd => Url(ManagementEndpoints.UpdateUserRolesAdd);
            internal static string UpdateUserRolesRemove => Url(ManagementEndpoints.UpdateUserRolesRemove);
            internal static string SetUserPassword => Url(ManagementEndpoints.SetUserPassword);
            internal static string ExpireUserPassword => Url(ManagementEndpoints.ExpireUserPassword);
            internal static string LogoutUser => Url(ManagementEndpoints.LogoutUser);
            internal static string SigninUserEmbeddedLink => Url(ManagementEndpoints.SigninUserEmbeddedLink);
            internal static string DeleteUser => Url(ManagementEndpoints.DeleteUser);
            internal static string GenerateTestUserOtp => Url(ManagementEndpoints.GenerateTestUserOtp);
            internal static string GenerateTestUserMagicLink => Url(ManagementEndpoints.GenerateTestUserMagicLink);
            internal static string GenerateTestUserEnchantedLink => Url(ManagementEndpoints.GenerateTestUserEnchantedLink);
            internal static string DeleteTestUsers => Url(ManagementEndpoints.DeleteTestUsers);
        }

        #region Private Methods

        private static string Url(string route) => $"{VERSION}/{route}";

        #endregion Private Methods

        #region Auth Endpoint Config

        private static class AuthEndpoints
        {
            internal const string ExchangeAccessKey = "auth/accesskey/exchange";
        }

        #endregion Auth Endpoint Config

        #region Management Endpoint Config

        private static class ManagementEndpoints
        {
            internal const string LoadAccessKey = "mgmt/accesskey";
            internal const string SearchAccessKeys = "mgmt/accesskey/search";
            internal const string CreateAccessKey = "mgmt/accesskey/create";
            internal const string UpdateAccessKey = "mgmt/accesskey/update";
            internal const string ActivateAccessKey = "mgmt/accesskey/activate";
            internal const string DeactivateAccessKey = "mgmt/accesskey/deactivate";
            internal const string DeleteAccessKey = "mgmt/accesskey/delete";
            internal const string SearchAudit = "mgmt/audit/search";
            internal const string LoadAllFlows = "mgmt/flow/list";
            internal const string ExportFlow = "mgmt/flow/export";
            internal const string ImportFlow = "mgmt/flow/import";
            internal const string LoadAllPermissions = "mgmt/permission/all";
            internal const string CreatePermission = "mgmt/permission/create";
            internal const string UpdatePermission = "mgmt/permission/update";
            internal const string DeletePermission = "mgmt/permission/delete";
            internal const string LoadAllRoles = "mgmt/role/all";
            internal const string CreateRole = "mgmt/role/create";
            internal const string UpdateRole = "mgmt/role/update";
            internal const string DeleteRole = "mgmt/role/delete";
            internal const string LoadTenant = "mgmt/tenant";
            internal const string LoadAllTenants = "mgmt/tenant/all";
            internal const string SearchTenants = "mgmt/tenant/search";
            internal const string CreateTenant = "mgmt/tenant/create";
            internal const string UpdateTenant = "mgmt/tenant/update";
            internal const string DeleteTenant = "mgmt/tenant/delete";
            internal const string ExportTheme = "mgmt/theme/export";
            internal const string ImportTheme = "mgmt/theme/import";
            internal const string LoadUser = "mgmt/user";
            internal const string LoadUserToken = "mgmt/user/provider/token";
            internal const string SearchUsers = "mgmt/user/search";
            internal const string CreateUser = "mgmt/user/create";
            internal const string BatchCreateUsers = "mgmt/user/create/batch";
            internal const string UpdateUser = "mgmt/user/update";
            internal const string UpdateUserStatus = "mgmt/user/update/status";
            internal const string UpdateUserEmail = "mgmt/user/update/email";
            internal const string UpdateUserLoginId = "mgmt/user/update/loginid";
            internal const string UpdateUserPhone = "mgmt/user/update/phone";
            internal const string UpdateUserName = "mgmt/user/update/name";
            internal const string UpdateUserPicture = "mgmt/user/update/picture";
            internal const string UpdateUserCustomAttribute = "mgmt/user/update/customAttribute";
            internal const string UpdateUserTenantsAdd = "mgmt/user/update/tenant/add";
            internal const string UpdateUserTenantsRemove = "mgmt/user/update/tenant/remove";
            internal const string UpdateUserRolesAdd = "mgmt/user/update/role/add";
            internal const string UpdateUserRolesRemove = "mgmt/user/update/role/remove";
            internal const string SetUserPassword = "mgmt/user/password/set";
            internal const string ExpireUserPassword = "mgmt/user/password/expire";
            internal const string LogoutUser = "mgmt/user/logout";
            internal const string SigninUserEmbeddedLink = "mgmt/user/signin/embeddedlink";
            internal const string DeleteUser = "mgmt/user/delete";
            internal const string GenerateTestUserOtp = "mgmt/tests/generate/otp";
            internal const string GenerateTestUserMagicLink = "mgmt/tests/generate/magiclink";
            internal const string GenerateTestUserEnchantedLink = "mgmt/tests/generate/enchantedlink";
            internal const string DeleteTestUsers = "mgmt/user/test/delate/all";
        }

        #endregion Management Endpoint Config
    }
}
