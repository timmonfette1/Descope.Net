using System.Text.Json;
using Descope.Types.Converters;

namespace Descope.Configuration
{
    internal static class HttpConfigurations
    {
        internal static readonly JsonSerializerOptions JsonSerializerOptions = new()
        {
            IncludeFields = true,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters =
            {
                new SecondsSinceEpochJsonConverter(),
                new MillisecondsSinceEpochConverter()
            }
        };
    }
}
