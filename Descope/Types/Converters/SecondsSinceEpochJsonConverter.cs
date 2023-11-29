using System.Text.Json;
using System.Text.Json.Serialization;

namespace Descope.Types.Converters
{
    internal class SecondsSinceEpochJsonConverter : JsonConverter<SecondsSinceEpoch>
    {
        public override SecondsSinceEpoch Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TryGetInt64(out long secondsSinceEpoch))
            {
                return secondsSinceEpoch;
            }
            else
            {
                throw new JsonException("Unable to convert value to SecondsSinceEpoch.");
            }
        }

        public override void Write(Utf8JsonWriter writer, SecondsSinceEpoch value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }
    }
}
