/* <copyright file="DescopeApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 19:51:15</date>
 */

using Descope.Management;

namespace Descope
{
    internal class DescopeApiClient : IDescopeApiClient
    {
        private readonly IManagementApiClient _managementApiClient;

        internal DescopeApiClient(IManagementApiClient managementApiClient)
        {
            _managementApiClient = managementApiClient;
        }

        public IManagementApiClient Management => _managementApiClient;
    }
}
