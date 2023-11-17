using Descope.Models;

namespace Descope.Test.Models
{
    public class DescopeExceptionTests
    {
        private const string MESSAGE = "My Message";
        private const string ERROR_CODE = "My Error Code";
        private const string ERROR_DESCRIPTION = "My Error Description";
        private const string ERROR_MESSAGE = "My Error Message";

        [Fact]
        public void ShouldCreateWithEmptyConstructor()
        {
            var dex = new DescopeException()
            {
                ErrorCode = ERROR_CODE,
                ErrorDescription = ERROR_DESCRIPTION,
                ErrorMessage = ERROR_MESSAGE
            };

            Assert.Equal("Exception of type 'Descope.Models.DescopeException' was thrown.", dex.Message);
            Assert.Equal(ERROR_CODE, dex.ErrorCode);
            Assert.Equal(ERROR_DESCRIPTION, dex.ErrorDescription);
            Assert.Equal(ERROR_MESSAGE, dex.ErrorMessage);
        }

        [Fact]
        public void ShouldCreateWithMessageConstructor()
        {
            var dex = new DescopeException(MESSAGE)
            {
                ErrorCode = ERROR_CODE,
                ErrorDescription = ERROR_DESCRIPTION,
                ErrorMessage = ERROR_MESSAGE
            };

            Assert.Equal(MESSAGE, dex.Message);
            Assert.Equal(ERROR_CODE, dex.ErrorCode);
            Assert.Equal(ERROR_DESCRIPTION, dex.ErrorDescription);
            Assert.Equal(ERROR_MESSAGE, dex.ErrorMessage);
        }

        [Fact]
        public void ShouldCreateWithInnerExceptionConstructor()
        {
            var otherEx = new Exception("Inner Exception");

            var dex = new DescopeException(MESSAGE, otherEx)
            {
                ErrorCode = ERROR_CODE,
                ErrorDescription = ERROR_DESCRIPTION,
                ErrorMessage = ERROR_MESSAGE
            };

            Assert.Equal(MESSAGE, dex.Message);
            Assert.Equal(ERROR_CODE, dex.ErrorCode);
            Assert.Equal(ERROR_DESCRIPTION, dex.ErrorDescription);
            Assert.Equal(ERROR_MESSAGE, dex.ErrorMessage);
            Assert.IsType<Exception>(dex.InnerException);
            Assert.Equal("Inner Exception", dex.InnerException.Message);
        }
    }
}
