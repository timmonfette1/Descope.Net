using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Descope.Test
{
    public static class ServerExtensions_Users
    {
        private static readonly string[] _loginIds = ["LID"];
        private static readonly string[] _externalIds = ["EID"];
        private static readonly string[] _ssoAppIds = ["App1", "App2"];
        private static readonly string[] _roleNames = ["Role1"];
        private static readonly string[] _tenantRoleNames = ["TRName"];
        private static readonly object[] _userTenants =
        [
            new
            {
                TenantId = "TID",
                TenantName = "Testing",
                RoleNames = _tenantRoleNames
            }
        ];

        private static readonly object _userObjectMock = new
        {
            LoginIds = _loginIds,
            UserId = "UID",
            Name = "Test User",
            GivenName = "Test",
            MiddleName = "Mid",
            FamilyName = "User",
            Email = "testuser@test.com",
            Phone = "+1-555-555-5555",
            VerifiedEmail = true,
            VerifiedPhone = false,
            RoleNames = _roleNames,
            UserTenants = _userTenants,
            Status = "active",
            ExternalIds = _externalIds,
            Picture = "pic",
            Test = false,
            CustomAttributes = new
            {
                Inner = "Inner"
            },
            CreatedTime = 12345,
            TOTP = false,
            SAML = true,
            OAuth = new
            {
                Auth = "Auth"
            },
            Webauthn = false,
            Password = true,
            SsoAppIds = _ssoAppIds
        };

        public static WireMockServer GetUser(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/user")
                        .WithParam("userId", true, "UID")
                        .UsingGet()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            User = _userObjectMock
                        })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/user")
                        .WithParam("loginId", true, "LID")
                        .UsingGet()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            User = _userObjectMock
                        })
                );

            return server;
        }
    }
}
