using Descope.Configuration;
using Descope.DependencyInjection;
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

namespace Descope.Test.DependencyInjection
{
    public class ServiceCollectionExtensionsTests
    {
        [Fact]
        public void ShouldGetInjectedServices()
        {
            var services = new ServiceCollection();
            services.AddDescope("myProjectId", "myManagementKey");
            var serviceProvider = services.BuildServiceProvider();

            var config = Record.Exception(serviceProvider.GetRequiredService<IDescopeConfiguration>);
            Assert.Null(config);

            var authClient = Record.Exception(serviceProvider.GetRequiredService<IDescopeAuthHttpClient>);
            Assert.Null(authClient);

            var mgmtClient = Record.Exception(serviceProvider.GetRequiredService<IDescopeManagementHttpClient>);
            Assert.Null(mgmtClient);

            var accessKey = Record.Exception(serviceProvider.GetRequiredService<IAccessKeysApiClient>);
            Assert.Null(accessKey);

            var audit = Record.Exception(serviceProvider.GetRequiredService<IAuditApiClient>);
            Assert.Null(audit);

            var flow = Record.Exception(serviceProvider.GetRequiredService<IFlowsApiClient>);
            Assert.Null(flow);

            var role = Record.Exception(serviceProvider.GetRequiredService<IRolesApiClient>);
            Assert.Null(role);

            var permission = Record.Exception(serviceProvider.GetRequiredService<IPermissionsApiClient>);
            Assert.Null(permission);

            var tenant = Record.Exception(serviceProvider.GetRequiredService<ITenantsApiClient>);
            Assert.Null(tenant);

            var theme = Record.Exception(serviceProvider.GetRequiredService<IThemesApiClient>);
            Assert.Null(theme);

            var user = Record.Exception(serviceProvider.GetRequiredService<IUsersApiClient>);
            Assert.Null(user);

            var mgmt = Record.Exception(serviceProvider.GetRequiredService<IManagementApiClient>);
            Assert.Null(mgmt);

            var api = Record.Exception(serviceProvider.GetRequiredService<IDescopeApiClient>);
            Assert.Null(api);
        }
    }
}
