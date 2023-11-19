using Descope.Configuration;
using Descope.HttpClient;
using Descope.Management;
using Descope.Management.AccessKeys;
using Descope.Management.Permissions;
using Descope.Management.Roles;
using Descope.Management.Tenants;
using Microsoft.Extensions.DependencyInjection;

namespace Descope.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDescope(this IServiceCollection services, string projectId, string managementKey)
        {
            services
                .AddSingleton<IDescopeConfiguration, DescopeConfiguration>(x => new DescopeConfiguration(projectId, managementKey))
                .AddSingleton<IDescopeAuthHttpClient, DescopeAuthHttpClient>()
                .AddSingleton<IDescopeManagementHttpClient, DescopeManagementHttpClient>()
                .AddTransient<IAccessKeysApiClient, AccessKeysApiClient>()
                .AddTransient<IPermissionsApiClient, PermissionsApiClient>()
                .AddTransient<IRolesApiClient, RolesApiClient>()
                .AddTransient<ITenantsApiClient, TenantsApiClient>()
                .AddTransient<IManagementApiClient, ManagementApiClient>();

            services.AddTransient<IDescopeApiClient, DescopeApiClient>();

            return services;
        }
    }
}
