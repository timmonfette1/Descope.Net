using System.Text.Json;
using Descope.Models;

namespace Descope.Test.Management.Users
{
    [Collection("ClientServer")]
    public class UsersApiClientTests(UsersApiClientFixture fixture) : IClassFixture<UsersApiClientFixture>
    {
        private readonly UsersApiClientFixture _fixture = fixture;

        [Fact]
        public async Task ShouldGetByUserId()
        {
            var user = await _fixture.UsersApiClient.GetByUserId("UID");

            Assert.NotNull(user);
            UserAssertations(user);
        }

        [Fact]
        public async Task ShouldGetByLoginId()
        {
            var user = await _fixture.UsersApiClient.GetByLoginId("LID");

            Assert.NotNull(user);
            UserAssertations(user);
        }

        #region Private Methods

        private static void UserAssertations(DescopeUser user)
        {
            var customAttributesInner = ((JsonElement)user.CustomAttributes).GetProperty("Inner").GetString();
            var oauth = ((JsonElement)user.OAuth).GetProperty("Auth").GetString();

            Assert.Single(user.LoginIds);
            Assert.Equal("LID", user.LoginIds.ElementAt(0));
            Assert.Equal("UID", user.UserId);
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

            Assert.Single(user.UserTenants);
            var tenant = user.UserTenants.ElementAt(0);
            Assert.Equal("TID", tenant.TenantId);
            Assert.Equal("Testing", tenant.TenantName);
            Assert.Single(tenant.RoleNames);
            Assert.Equal("TRName", tenant.RoleNames.ElementAt(0));

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

        #endregion Private Methods
    }
}
