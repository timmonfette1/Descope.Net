using Descope.Models;

namespace Descope.Test.Models.Internal
{
    public class DescopeInternalModelTests
    {
        [Fact]
        public void ShouldCreateIdModel()
        {
            var model = new DescopeIdModel
            {
                Id = "TEST"
            };

            Assert.NotNull(model);
            Assert.Equal("TEST", model.Id);
        }

        [Fact]
        public void ShouldCreateNameModel()
        {
            var model = new DescopeNameModel
            {
                Name = "Testing",
            };

            Assert.NotNull(model);
            Assert.Equal("Testing", model.Name);
        }
    }
}
