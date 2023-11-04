/* <copyright file="Endpoints" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 20:45:50</date>
 */

namespace Descope.Configuration
{
    internal static class Endpoints
    {
        private const string VERSION = "v1";

        internal static class Management
        {
            internal static string LoadAllPermissions => Url(ManagementEndpoints.LoadAllPermissions);
            internal static string CreatePermission => Url(ManagementEndpoints.CreatePermission);
            internal static string UpdatePermission => Url(ManagementEndpoints.UpdatePermission);
            internal static string DeletePermission => Url(ManagementEndpoints.DeletePermission);
            internal static string LoadAllTenants => Url(ManagementEndpoints.LoadAllTenants);
            internal static string LoadTenant => Url(ManagementEndpoints.LoadTenant);
            internal static string SearchTenants => Url(ManagementEndpoints.SearchTenants);
            internal static string CreateTenant => Url(ManagementEndpoints.CreateTenant);
            internal static string UpdateTenant => Url(ManagementEndpoints.UpdateTenant);
            internal static string DeleteTenant => Url(ManagementEndpoints.DeleteTenant);
            internal static string LoadUser => Url(ManagementEndpoints.LoadUser);
        }

        #region Private Methods

        private static string Url(string route) => $"{VERSION}/{route}";

        #endregion Private Methods

        #region Management Endpoint Config

        private static class ManagementEndpoints
        {
            internal const string LoadAllPermissions = "mgmt/permission/all";
            internal const string CreatePermission = "mgmt/permission/create";
            internal const string UpdatePermission = "mgmt/permission/update";
            internal const string DeletePermission = "mgmt/permission/delete";
            internal const string LoadTenant = "mgmt/tenant";
            internal const string LoadAllTenants = "mgmt/tenant/all";
            internal const string SearchTenants = "mgmt/tenant/search";
            internal const string CreateTenant = "mgmt/tenant/create";
            internal const string UpdateTenant = "mgmt/tenant/update";
            internal const string DeleteTenant = "mgmt/tenant/delete";
            internal const string LoadUser = "mgmt/user";
        }

        #endregion Management Endpoint Config
    }
}
