using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RoutePlan.API.CustomFormat
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));

            if (reader.GetString() == null)
                return new DateTime();

            return DateTime.Parse(reader.GetString()).ToLocalTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToLocalTime().ToString("yyyy-MM-dd HH:mm"));
        }
    }
}