/* <copyright file="IDescopeManagementHttpClient" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 19:57:41</date>
 */

namespace Descope.HttpClient
{
    internal interface IDescopeManagementHttpClient : IDisposable
    {
        Task<TResponse> GetAsync<TResponse>(string resource, object parameters = null) where TResponse : class, new();
        Task PostAsync<TBody>(string resource, TBody body) where TBody : class, new();
        Task<TResponse> PostAsync<TBody, TResponse>(string resource, TBody body) where TBody : class, new() where TResponse : class, new();
    }
}
