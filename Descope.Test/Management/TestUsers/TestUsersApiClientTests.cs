namespace Descope.Test.Management.TestUsers
{
    [Collection("ClientServer")]
    public class TestUsersApiClientTests(TestUsersApiClientFixture fixture) : IClassFixture<TestUsersApiClientFixture>
    {
        private readonly TestUsersApiClientFixture _fixture = fixture;

        [Fact]
        public async Task ShouldGenerateOtp()
        {
            var otp = await _fixture.TestUsersApiClient.GenerateOtp("LID", "email", null);

            Assert.NotNull(otp);
            Assert.Equal("LID", otp.LoginId);
            Assert.Equal("123456789", otp.Code);
        }

        [Fact]
        public async Task ShouldGenerateMagicLink()
        {
            var mLink = await _fixture.TestUsersApiClient.GenerateMagicLink("LID", "email", "redirect", null);

            Assert.NotNull(mLink);
            Assert.Equal("LID", mLink.LoginId);
            Assert.Equal("link", mLink.Link);
        }

        [Fact]
        public async Task ShouldGenerateEnchantedLink()
        {
            var eLink = await _fixture.TestUsersApiClient.GenerateEnchantedLink("LID", "redirect", null);

            Assert.NotNull(eLink);
            Assert.Equal("LID", eLink.LoginId);
            Assert.Equal("link", eLink.Link);
            Assert.Equal("pending", eLink.PendingRef);
        }

        [Fact]
        public async Task ShouldDeleteAll()
        {
            var delete = await Record.ExceptionAsync(_fixture.TestUsersApiClient.DeleteAll);

            Assert.Null(delete);
        }
    }
}
