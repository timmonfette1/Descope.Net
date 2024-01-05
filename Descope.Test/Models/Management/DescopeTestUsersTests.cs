using Descope.Models;

namespace Descope.Test.Models.Management
{
    public class DescopeTestUsersTests
    {
        [Fact]
        public void ShouldCreateObject_Otp()
        {
            var otp = new DescopeTestUserOtp
            {
                LoginId = "LID",
                Code = "123456789"
            };

            Assert.NotNull(otp);
            Assert.Equal("LID", otp.LoginId);
            Assert.Equal("123456789", otp.Code);
        }

        [Fact]
        public void ShouldCreateObject_MagicLink()
        {
            var mLink = new DescopeTestUserMagicLink
            {
                LoginId = "LID",
                Link = "link",
            };

            Assert.NotNull(mLink);
            Assert.Equal("LID", mLink.LoginId);
            Assert.Equal("link", mLink.Link);
        }

        [Fact]
        public void ShouldCreateObject_EnchantedLink()
        {
            var eLink = new DescopeTestUserEnchantedLink
            {
                LoginId = "LID",
                Link = "link",
                PendingRef = "pending"
            };

            Assert.NotNull(eLink);
            Assert.Equal("LID", eLink.LoginId);
            Assert.Equal("link", eLink.Link);
            Assert.Equal("pending", eLink.PendingRef);
        }
    }
}
