using Descope.Models;

namespace Descope.Test.Models.Management
{
    public class DescopeUserTests
    {
        [Fact]
        public void ShouldCreateObject_LoginIdRequest()
        {
            var loginIdRequest = new DescopeUserLoginIdRequest
            {
                LoginId = "email"
            };

            Assert.Equal("email", loginIdRequest.LoginId);
        }

        [Fact]
        public void ShouldCreateObject_PasswordRequest()
        {
            var passwordRequest = new DescopeUserPasswordRequest
            {
                LoginId = "email",
                Password = "secret"
            };

            Assert.Equal("email", passwordRequest.LoginId);
            Assert.Equal("secret", passwordRequest.Password);
        }

        [Fact]
        public void ShouldCreateObject_UpdateRequest()
        {
            var update = new DescopeUserUpdateRequest
            {
                LoginId = "email",
                DisplayName = "Test User",
                GivenName = "Test",
                MiddleName = "Mid",
                FamilyName = "User",
                Email = "testuser@test.com",
                Phone = "+1-555-555-5555",
                VerifiedEmail = true,
                VerifiedPhone = false,
                RoleNames = ["Role1"],
                UserTenants =
                [
                    new DescopeUserTenant
                    {
                        TenantId = "TID",
                        TenantName = "Testing",
                        RoleNames = ["TRName"]
                    }
                ],
                Picture = "pic",
                CustomAttributes = new
                {
                    Inner = "Inner"
                },
                SsoAppIds = ["App1", "App2"]
            };

            var customAttributesInner = update.CustomAttributes.GetType().GetProperty("Inner")?.GetValue(update.CustomAttributes, null)?.ToString();

            Assert.Equal("email", update.LoginId);
            Assert.Equal("Test User", update.DisplayName);
            Assert.Equal("Test", update.GivenName);
            Assert.Equal("Mid", update.MiddleName);
            Assert.Equal("User", update.FamilyName);
            Assert.Equal("testuser@test.com", update.Email);
            Assert.Equal("+1-555-555-5555", update.Phone);
            Assert.True(update.VerifiedEmail);
            Assert.False(update.VerifiedPhone);
            Assert.Single(update.RoleNames);
            Assert.Equal("Role1", update.RoleNames.ElementAt(0));

            Assert.Single(update.UserTenants);
            var tenant = update.UserTenants.ElementAt(0);
            Assert.Equal("TID", tenant.TenantId);
            Assert.Equal("Testing", tenant.TenantName);
            Assert.Single(tenant.RoleNames);
            Assert.Equal("TRName", tenant.RoleNames.ElementAt(0));

            Assert.Equal("pic", update.Picture);
            Assert.Equal("Inner", customAttributesInner);
            Assert.Equal(2, update.SsoAppIds.Count());
            Assert.Equal("App1", update.SsoAppIds.ElementAt(0));
            Assert.Equal("App2", update.SsoAppIds.ElementAt(1));
        }

        [Fact]
        public void ShouldCreateObject_Response()
        {
            var response = new DescopeUserResponse
            {
                User = new DescopeUser
                {
                    LoginIds = ["email"],
                    UserId = "IUser",
                    Name = "Test User",
                    GivenName = "Test",
                    MiddleName = "Mid",
                    FamilyName = "User",
                    Email = "testuser@test.com",
                    Phone = "+1-555-555-5555",
                    VerifiedEmail = true,
                    VerifiedPhone = false,
                    RoleNames = ["Role1"],
                    UserTenants = [],
                    Status = "active",
                    ExternalIds = ["EID"],
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
                    SsoAppIds = ["App1", "App2"]
                }
            };

            var customAttributesInner = response.User.CustomAttributes.GetType().GetProperty("Inner")?.GetValue(response.User.CustomAttributes, null)?.ToString();
            var oauth = response.User.OAuth.GetType().GetProperty("Auth")?.GetValue(response.User.OAuth, null)?.ToString();

            Assert.Single(response.User.LoginIds);
            Assert.Equal("email", response.User.LoginIds.ElementAt(0));
            Assert.Equal("IUser", response.User.UserId);
            Assert.Equal("Test User", response.User.Name);
            Assert.Equal("Test", response.User.GivenName);
            Assert.Equal("Mid", response.User.MiddleName);
            Assert.Equal("User", response.User.FamilyName);
            Assert.Equal("testuser@test.com", response.User.Email);
            Assert.Equal("+1-555-555-5555", response.User.Phone);
            Assert.True(response.User.VerifiedEmail);
            Assert.False(response.User.VerifiedPhone);
            Assert.Single(response.User.RoleNames);
            Assert.Equal("Role1", response.User.RoleNames.ElementAt(0));
            Assert.Empty(response.User.UserTenants);
            Assert.Equal("active", response.User.Status);
            Assert.Single(response.User.ExternalIds);
            Assert.Equal("EID", response.User.ExternalIds.ElementAt(0));
            Assert.Equal("pic", response.User.Picture);
            Assert.False(response.User.Test);
            Assert.Equal("Inner", customAttributesInner);
            Assert.Equal(12345, response.User.CreatedTime);
            Assert.False(response.User.TOTP);
            Assert.True(response.User.SAML);
            Assert.Equal("Auth", oauth);
            Assert.False(response.User.Webauthn);
            Assert.True(response.User.Password);
            Assert.Equal(2, response.User.SsoAppIds.Count());
            Assert.Equal("App1", response.User.SsoAppIds.ElementAt(0));
            Assert.Equal("App2", response.User.SsoAppIds.ElementAt(1));
        }

        [Fact]
        public void ShouldCreateObject_ListResponse()
        {
            var response = new DescopeUserListResponse
            {
                Users =
                [
                    new DescopeUser
                    {
                        LoginIds = ["email"],
                        UserId = "IUser",
                        Name = "Test User",
                        GivenName = "Test",
                        MiddleName = "Mid",
                        FamilyName = "User",
                        Email = "testuser@test.com",
                        Phone = "+1-555-555-5555",
                        VerifiedEmail = true,
                        VerifiedPhone = false,
                        RoleNames = ["Role1"],
                        UserTenants = [],
                        Status = "active",
                        ExternalIds = ["EID"],
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
                        SsoAppIds = ["App1", "App2"]
                    }
                ]
            };

            Assert.Single(response.Users);
            var user = response.Users.ElementAt(0);

            var customAttributesInner = user.CustomAttributes.GetType().GetProperty("Inner")?.GetValue(user.CustomAttributes, null)?.ToString();
            var oauth = user.OAuth.GetType().GetProperty("Auth")?.GetValue(user.OAuth, null)?.ToString();

            Assert.Single(user.LoginIds);
            Assert.Equal("email", user.LoginIds.ElementAt(0));
            Assert.Equal("IUser", user.UserId);
            Assert.Equal("Test User", user.Name);
            Assert.Equal("Test", user.GivenName);
            Assert.Equal("Mid", user.MiddleName);
            Assert.Equal("User", user.FamilyName);
            Assert.Equal("testuser@test.com", user.Email);
            Assert.Equal("+1-555-555-5555", user.Phone);
            Assert.True(user.VerifiedEmail);
            Assert.False(user.VerifiedPhone);
            Assert.Single(user.RoleNames);
            Assert.Equal("Role1", user.RoleNames.ElementAt(0));
            Assert.Empty(user.UserTenants);
            Assert.Equal("active", user.Status);
            Assert.Single(user.ExternalIds);
            Assert.Equal("EID", user.ExternalIds.ElementAt(0));
            Assert.Equal("pic", user.Picture);
            Assert.False(user.Test);
            Assert.Equal("Inner", customAttributesInner);
            Assert.Equal(12345, user.CreatedTime);
            Assert.False(user.TOTP);
            Assert.True(user.SAML);
            Assert.Equal("Auth", oauth);
            Assert.False(user.Webauthn);
            Assert.True(user.Password);
            Assert.Equal(2, user.SsoAppIds.Count());
            Assert.Equal("App1", user.SsoAppIds.ElementAt(0));
            Assert.Equal("App2", user.SsoAppIds.ElementAt(1));
        }

        [Fact]
        public void ShouldCreateObject_Create()
        {
            var create = new DescopeUserCreateRequest
            {
                LoginId = "email",
                Name = "Test User",
                GivenName = "Test",
                MiddleName = "Mid",
                FamilyName = "User",
                Email = "testuser@test.com",
                Phone = "+1-555-555-5555",
                VerifiedEmail = true,
                VerifiedPhone = false,
                RoleNames = ["Role1"],
                UserTenants = [],
                Picture = "pic",
                Test = false,
                CustomAttributes = new
                {
                    Inner = "Inner"
                },
                Password = true,
                HashedPassword = new DescopeHashedPassword
                {
                    Algorithm = "SHA-256",
                    Hash = [],
                    Salt = [],
                    Iterations = 15
                },
                SsoAppIds = ["App1", "App2"],
                Invite = true,
                InviteUrl = "url",
                SendMail = true,
                SendSms = true
            };

            var customAttributesInner = create.CustomAttributes.GetType().GetProperty("Inner")?.GetValue(create.CustomAttributes, null)?.ToString();

            Assert.Equal("email", create.LoginId);
            Assert.Equal("Test User", create.Name);
            Assert.Equal("Test", create.GivenName);
            Assert.Equal("Mid", create.MiddleName);
            Assert.Equal("User", create.FamilyName);
            Assert.Equal("testuser@test.com", create.Email);
            Assert.Equal("+1-555-555-5555", create.Phone);
            Assert.True(create.VerifiedEmail);
            Assert.False(create.VerifiedPhone);
            Assert.Single(create.RoleNames);
            Assert.Equal("Role1", create.RoleNames.ElementAt(0));
            Assert.Empty(create.UserTenants);
            Assert.Equal("pic", create.Picture);
            Assert.False(create.Test);
            Assert.Equal("Inner", customAttributesInner);
            Assert.True(create.Password);
            Assert.Equal("SHA-256", create.HashedPassword.Algorithm);
            Assert.Empty(create.HashedPassword.Hash);
            Assert.Empty(create.HashedPassword.Salt);
            Assert.Equal(15, create.HashedPassword.Iterations);
            Assert.Equal(2, create.SsoAppIds.Count());
            Assert.Equal("App1", create.SsoAppIds.ElementAt(0));
            Assert.Equal("App2", create.SsoAppIds.ElementAt(1));
            Assert.True(create.Invite);
            Assert.Equal("url", create.InviteUrl);
            Assert.True(create.SendMail);
            Assert.True(create.SendSms);
        }

        [Fact]
        public void ShouldCreateObject_BatchCreateRequest()
        {
            var batch = new DescopeUserBatchCreateRequest
            {
                Users = [],
                Invite = true,
                InviteUrl = "url",
                SendMail = true,
                SendSms = true
            };

            Assert.Empty(batch.Users);
            Assert.True(batch.Invite);
            Assert.Equal("url", batch.InviteUrl);
            Assert.True(batch.SendMail);
            Assert.True(batch.SendSms);
        }

        [Fact]
        public void ShouldCreateObject_BatchCreateResponse()
        {
            var batchResponse = new DescopeUserBatchCreateResponse
            {
                CreatedUsers = [new DescopeUser { }],
                FailedUsers =
                [
                    new DescopeFailedUser
                    {
                        Failure = "failed",
                        User = null
                    }
                ]
            };

            Assert.Single(batchResponse.CreatedUsers);
            Assert.Single(batchResponse.FailedUsers);
            Assert.Equal("failed", batchResponse.FailedUsers.ElementAt(0).Failure);
            Assert.Null(batchResponse.FailedUsers.ElementAt(0).User);
        }

        [Fact]
        public void ShouldCreateObject_OAuthToken()
        {
            var token = new DescopeUserOAuthToken
            {
                Provider = "Google",
                ProviderUserId = "PID",
                AccessToken = "a-token",
                Expiration = 9999,
                Scopes = ["Scope1"]
            };

            Assert.Equal("Google", token.Provider);
            Assert.Equal("PID", token.ProviderUserId);
            Assert.Equal("a-token", token.AccessToken);
            Assert.Equal(9999, token.Expiration);
            Assert.Single(token.Scopes);
            Assert.Equal("Scope1", token.Scopes.ElementAt(0));
        }

        [Fact]
        public void ShouldCreateObject_SearchRequest()
        {
            var search = new DescopeUserSearchRequest
            {
                LoginId = "login",
                TenantIds = [],
                RoleNames = [],
                Text = "",
                SsoOnly = false,
                WithTestUser = false,
                TestUsersOnly = false,
                CustomAttributes = null,
                Statuses = [],
                Emails = [],
                Phones = [],
                SsoAppIds = [],
                Limit = 1,
                Page = 1,
            };

            Assert.Equal("login", search.LoginId);
            Assert.Empty(search.TenantIds);
            Assert.Empty(search.RoleNames);
            Assert.Equal(string.Empty, search.Text);
            Assert.False(search.SsoOnly);
            Assert.False(search.WithTestUser);
            Assert.False(search.TestUsersOnly);
            Assert.Null(search.CustomAttributes);
            Assert.Empty(search.Statuses);
            Assert.Empty(search.Emails);
            Assert.Empty(search.Phones);
            Assert.Empty(search.SsoAppIds);
            Assert.Equal(1, search.Limit);
            Assert.Equal(1, search.Page);
        }
    }
}
