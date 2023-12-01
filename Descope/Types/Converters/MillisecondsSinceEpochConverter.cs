using System.Text.Json;
using System.Text.Json.Serialization;

namespace Descope.Types.Converters
{
    internal class MillisecondsSinceEpochConverter : JsonConverter<MillisecondsSinceEpoch>
    {
        public override MillisecondsSinceEpoch Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TryGetInt64(out long millisecondsSinceEpoch))
            {
                return millisecondsSinceEpoch;
            }
            else
            {
                throw new JsonException("Unable to convert value to MillisecondsSinceEpoch.");
            }
        }

        public override void Write(Utf8JsonWriter writer, MillisecondsSinceEpoch value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }
    }
}
