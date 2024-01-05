using Descope.Models;

namespace Descope.Test.Models.Management
{
    public class DescopeLoginOptionsTests
    {
        [Fact]
        public void ShouldCreateObject()
        {
            var loginOptions = new DescopeLoginOptions
            {
                Stepup = false,
                CustomClaims = new
                {
                    Inner = "Inner"
                },
                Mfa = true,
                SsoAppId = "SSO"
            };

            var customClaimsInner = loginOptions.CustomClaims.GetType().GetProperty("Inner")?.GetValue(loginOptions.CustomClaims, null)?.ToString();

            Assert.NotNull(loginOptions);
            Assert.False(loginOptions.Stepup);
            Assert.Equal("Inner", customClaimsInner);
            Assert.True(loginOptions.Mfa);
            Assert.Equal("SSO", loginOptions.SsoAppId);
        }
    }
}
