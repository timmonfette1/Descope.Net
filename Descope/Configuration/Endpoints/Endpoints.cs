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
            internal static string LoadUser => Url(ManagementEndpoints.LoadUser);
            internal static string CreateTenant => Url(ManagementEndpoints.CreateTenant);
            internal static string UpdateTenant => Url(ManagementEndpoints.UpdateTenant);
        }

        #region Private Methods

        private static string Url(string route) => $"{VERSION}/{route}";

        #endregion Private Methods

        #region Management Endpoint Config

        private static class ManagementEndpoints
        {
            internal const string LoadUser = "mgmt/user";
            internal const string CreateTenant = "mgmt/tenant/create";
            internal const string UpdateTenant = "mgmt/tenant/update";
        }

        #endregion Management Endpoint Config
    }
}
