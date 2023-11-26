using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions
    {
        public static WireMockServer ConfigureDummy(this WireMockServer server)
        {
            server
                .ConfigureDummyGets()
                .ConfigureDummyPosts();

            return server;
        }

        public static WireMockServer ConfigureAccessKeys(this WireMockServer server)
        {
            server
                .GetAccessKey()
                .SearchAccessKeys()
                .CreateAccessKey()
                .UpdateAccessKey()
                .ActivateAccessKey()
                .DeactivateAccessKey()
                .DeleteAccessKey();

            return server;
        }

        public static WireMockServer ConfigureFlows(this WireMockServer server)
        {
            server
                .ListFlows()
                .ExportFlow()
                .ImportFlow();

            return server;
        }

        public static WireMockServer ConifgurePermissions(this WireMockServer server)
        {
            server
                .GetAllPermissions()
                .CreatePermissions()
                .UpdatePermissions()
                .DeletePermissions();

            return server;
        }

        public static WireMockServer ConifgureRoles(this WireMockServer server)
        {
            server
                .GetAllRoles()
                .CreateRoles()
                .UpdateRoles()
                .DeleteRoles();

            return server;
        }

        public static WireMockServer ConifgureTenants(this WireMockServer server)
        {
            server
                .GetAllTenants()
                .GetTenants()
                .SearchTenants()
                .CreateTenants()
                .UpdateTenants()
                .DeleteTenants();

            return server;
        }

        public static WireMockServer ConfigureThemes(this WireMockServer server)
        {
            server
                .ExportTheme()
                .ImportTheme();

            return server;
        }
    }
}
