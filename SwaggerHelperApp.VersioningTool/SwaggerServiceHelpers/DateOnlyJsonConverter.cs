namespace SwaggerHelperApp.VersioningTool.SwaggerServiceHelpers;

public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    private readonly string _serializationFormat;

    public DateOnlyJsonConverter() : this(null)
    {
    }

    public DateOnlyJsonConverter(string? serializationFormat)
    {
        _serializationFormat = serializationFormat ?? "yyyy-MM-dd";
    }

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateString = reader.GetString();
        if (DateOnly.TryParseExact(dateString, _serializationFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out var date)) return date;

        throw new JsonException($"Unable to convert \"{dateString}\" to {nameof(DateOnly)}.");
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_serializationFormat, CultureInfo.InvariantCulture));
    }
}