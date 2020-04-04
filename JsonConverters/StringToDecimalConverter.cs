using System;
using System.Buffers.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace splitourbill_backend.JsonConverters
{
    public class StringToDecimalConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var isConverted = Utf8Parser.TryParse(reader.ValueSpan, out decimal result, out int bytesConsumed);

            if (!isConverted)
                return 0;
            return result;
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}