﻿/* <copyright file="Endpoints" company="Solidus">
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
            internal static string LoadAccessKey => ManagementEndpoints.LoadAccessKey;
            internal static string SearchAccessKeys => ManagementEndpoints.SearchAccessKeys;
            internal static string CreateAccessKey => ManagementEndpoints.CreateAccessKey;
            internal static string UpdateAccessKey => ManagementEndpoints.UpdateAccessKey;
            internal static string ActivateAccessKey => ManagementEndpoints.ActivateAccessKey;
            internal static string DeactivateAccessKey => ManagementEndpoints.DeactivateAccessKey;
            internal static string DeleteAccessKey => ManagementEndpoints.DeleteAccessKey;
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
        }

        #region Private Methods

        private static string Url(string route) => $"{VERSION}/{route}";

        #endregion Private Methods

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
        }

        #endregion Management Endpoint Config
    }
}
