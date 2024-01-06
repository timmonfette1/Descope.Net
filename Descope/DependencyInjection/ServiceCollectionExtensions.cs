using Descope.Auth;
using Descope.Auth.AccessKey;
using Descope.Configuration;
using Descope.HttpClient;
using Descope.Management;
using Descope.Management.AccessKeys;
using Descope.Management.Audit;
using Descope.Management.Flows;
using Descope.Management.Permissions;
using Descope.Management.Roles;
using Descope.Management.Tenants;
using Descope.Management.Themes;
using Descope.Management.Users;
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
                .AddTransient<IAccessKeyApiClient, AccessKeyApiClient>()
                .AddTransient<IAccessKeysApiClient, AccessKeysApiClient>()
                .AddTransient<IAuditApiClient, AuditApiClient>()
                .AddTransient<IFlowsApiClient, FlowsApiClient>()
                .AddTransient<IPermissionsApiClient, PermissionsApiClient>()
                .AddTransient<IRolesApiClient, RolesApiClient>()
                .AddTransient<ITenantsApiClient, TenantsApiClient>()
                .AddTransient<IThemesApiClient, ThemesApiClient>()
                .AddTransient<ITestUsersApiClient, TestUsersApiClient>()
                .AddTransient<IUsersApiClient, UsersApiClient>()
                .AddTransient<IAuthApiClient, AuthApiClient>()
                .AddTransient<IManagementApiClient, ManagementApiClient>();

            services.AddTransient<IDescopeApiClient, DescopeApiClient>();

            return services;
        }
    }
}
