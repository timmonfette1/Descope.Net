/* <copyright file="ServiceCollectionExtensions" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/23/2023 19:18:28</date>
 */

using Descope.Configuration;
using Descope.HttpClient;
using Descope.Management;
using Microsoft.Extensions.DependencyInjection;

namespace Descope.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDescope(this IServiceCollection services, string projectId, string managementKey)
        {
            // Internals
            services
                .AddSingleton<IDescopeConfiguration, DescopeConfiguration>(x => new DescopeConfiguration(projectId, managementKey))
                .AddSingleton<IDescopeAuthHttpClient, DescopeAuthHttpClient>()
                .AddSingleton<IDescopeManagementHttpClient, DescopeManagementHttpClient>()
                .AddSingleton<IManagementApiClient, ManagementApiClient>();

            // Publics
            services.AddSingleton<IDescopeApiClient, DescopeApiClient>();

            return services;
        }
    }
}
