using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HRMPortal.Employee.Extentions
{
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter()
            : base(dateOnly =>
                    dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime))
        { }

		public sealed class JSONHelper : JsonConverter<DateOnly>
		{
			public override DateOnly Read(
			ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			{
				using (var jsonDoc = JsonDocument.ParseValue(ref reader))
				{
					//var x=DateOnly.FromDateTime(reader.GetDateTime());
					var x = jsonDoc.RootElement.GetRawText();
					return new DateOnly();
				}
			}
			public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
			{
				var isoDate = value.ToString("O");
				writer.WriteStringValue(isoDate);
			}
		}
	}
}
