using WireMock.Matchers;
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
        private static readonly string[] _scopes = ["Scope1"];
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

        private static readonly object[] _usersObjectMock = [_userObjectMock];

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

        public static WireMockServer GetProviderToken(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/user/provider/token")
                        .WithParam("loginId", true, "LID")
                        .WithParam("provider", true, "Google")
                        .UsingGet()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Provider = "Google",
                            ProviderUserId = "PUID",
                            AccessToken = "token",
                            Expiration = 99999,
                            Scopes = _scopes
                        })
                );

            return server;
        }

        public static WireMockServer SearchUser(this WireMockServer server)
        {

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/user/search")
                        .UsingPost()
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new
                        {
                            Users = _usersObjectMock
                        })
                );

            return server;
        }

        public static WireMockServer UpdateUserStatus(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/user/update/status")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            LoginId = "LID",
                            Status = "active"
                        }, true))
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

        public static WireMockServer UpdateUserEmail(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/user/update/email")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            LoginId = "LID",
                            Email = "testuser@test.com",
                            Verified = true
                        }, true))
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

        public static WireMockServer UpdateUserLoginId(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/user/update/loginid")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            LoginId = "OLID",
                            NewLoginId = "LID",
                        }, true))
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

        public static WireMockServer UpdateUserPhone(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/user/update/phone")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            LoginId = "LID",
                            Phone = "+1-555-555-5555",
                            Verified = false
                        }, true))
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

        public static WireMockServer UpdateUserName(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/user/update/name")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            LoginId = "LID",
                            GivenName = "Test",
                            MiddleName = "Mid",
                            FamilyName = "User",
                            DisplayName = "Test User"
                        }, true))
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

        public static WireMockServer UpdateUserCustomAttribute(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/user/update/customAttribute")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            LoginId = "LID",
                            AttributeKey = "Inner",
                            AttributeValue = "Inner"
                        }, true))
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

        public static WireMockServer UpdateUserPicture(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/user/update/picture")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            LoginId = "LID",
                            Picture = "picture",
                        }, true))
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

        public static WireMockServer SetUserPassword(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/user/password/set")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            LoginId = "LID",
                            Password = "secret-password"
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new { })
                );

            return server;
        }

        public static WireMockServer ExpireUserPassword(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/user/password/expire")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            LoginId = "LID",
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new { })
                );

            return server;
        }

        public static WireMockServer LogoutUser(this WireMockServer server)
        {
            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/user/logout")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            UserId = "UID"
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new { })
                );

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/user/logout")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            LoginId = "LID"
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new { })
                );

            return server;
        }

        public static WireMockServer DeleteUser(this WireMockServer server)
        {

            server
                .Given(
                    Request
                        .Create()
                        .WithPath("/v1/mgmt/user/delete")
                        .UsingPost()
                        .WithBody(new JsonMatcher(new
                        {
                            LoginId = "LID"
                        }, true))
                )
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new { })
                );

            return server;
        }
    }
}
