/* <copyright file="ServiceCollectionExtensionsTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/26/2023 21:40:09</date>
 */

using Descope.Configuration;
using Descope.DependencyInjection;
using Descope.HttpClient;
using Descope.Management;
using Descope.Management.Tenants;
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

            var user = Record.Exception(serviceProvider.GetRequiredService<IUsersApiClient>);
            Assert.Null(user);

            var tenant = Record.Exception(serviceProvider.GetRequiredService<ITenantsApiClient>);
            Assert.Null(tenant);

            var mgmt = Record.Exception(serviceProvider.GetRequiredService<IManagementApiClient>);
            Assert.Null(mgmt);

            var api = Record.Exception(serviceProvider.GetRequiredService<IDescopeApiClient>);
            Assert.Null(api);
        }
    }
}
