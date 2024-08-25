namespace SwaggerHelperApp.VersioningTool.SwaggerServiceHelpers;

public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
{
    private readonly string _serializationFormat;

    public TimeOnlyJsonConverter() : this(null)
    {
    }

    public TimeOnlyJsonConverter(string? serializationFormat)
    {
        _serializationFormat = serializationFormat ?? "HH:mm:ss";
    }

    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var timeString = reader.GetString();
        if (TimeOnly.TryParseExact(timeString, _serializationFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out var time)) return time;

        throw new JsonException($"Unable to convert \"{timeString}\" to {nameof(TimeOnly)}.");
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_serializationFormat, CultureInfo.InvariantCulture));
    }
}