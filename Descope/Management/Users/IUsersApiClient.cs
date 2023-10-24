/* <copyright file="IUsersApiClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 19:26:51</date>
 */

using Descope.Models;

namespace Descope.Management.Users
{
    public interface IUsersApiClient
    {
        Task<IEnumerable<DescopeUser>> Get();
    }
}
