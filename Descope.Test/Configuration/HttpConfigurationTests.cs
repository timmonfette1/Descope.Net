using System.Text.Json;
using Descope.Configuration;
using Descope.Types.Converters;

namespace Descope.Test.Configuration
{
    public class HttpConfigurationTests
    {
        [Fact]
        public void ShouldHaveJsonSerializerOptions()
        {
            var options = HttpConfigurations.JsonSerializerOptions;

            Assert.NotNull(options);
            Assert.True(options.IncludeFields);
            Assert.True(options.PropertyNameCaseInsensitive);
            Assert.Equal(JsonNamingPolicy.CamelCase, options.PropertyNamingPolicy);
            Assert.Equal(2, options.Converters.Count);
            Assert.IsType<SecondsSinceEpochJsonConverter>(options.Converters[0]);
            Assert.IsType<MillisecondsSinceEpochConverter>(options.Converters[1]);
        }
    }
}
