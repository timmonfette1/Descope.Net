/* <copyright file="IDescopeAuthHttpClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 20:14:07</date>
 */

using RestSharp;

namespace Descope.HttpClient
{
    internal interface IDescopeAuthHttpClient
    {
        RestClient Client { get; }

    }
}
