/* <copyright file="IDescopeApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 19:21:58</date>
 */

using Descope.Management;

namespace Descope
{
    public interface IDescopeApiClient
    {
        IManagementApiClient Management { get; }
    }
}
