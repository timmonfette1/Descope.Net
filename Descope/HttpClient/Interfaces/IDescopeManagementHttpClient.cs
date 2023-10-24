/* <copyright file="IDescopeManagementHttpClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 19:57:41</date>
 */

using RestSharp;

namespace Descope.HttpClient
{
    internal interface IDescopeManagementHttpClient
    {
        RestClient Client { get; }
    }
}
