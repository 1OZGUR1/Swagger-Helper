namespace SwaggerHelperApp.VersioningTool.GlobalOperations;

public static class SwaggerServiceExtensions
{
    public static IServiceCollection AddMyAwesomeSwaggerSupport(
        this IServiceCollection s, SwaggerDocumentBasic doc, ApiDefaultOpt o,
        EndpointTypeHelper? filterType = null)
    {
        s.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
                options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
            });

        s.AddEndpointsApiExplorer();
        s.AddSwaggerGen(options =>
        {
            options.CustomSchemaIds(type => type.ToString().Replace('+', '.'));
            options.MapType<DateOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date"
            });
            options.MapType<TimeOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "time",
                Example = OpenApiAnyFactory.CreateFromJson(DateTime.Now.ToString("HH:mm:ss"))
            });

            if (filterType != null)
                options.OperationFilter<SwaggerOperationFilter>(filterType);
        });


        s.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        s.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(doc.Version, new OpenApiInfo
            {
                Title = doc.Title,
                Version = doc.Version,
                Description = doc.Description,
                Contact = !string.IsNullOrEmpty(doc.ContactName)
                    ? new OpenApiContact
                    {
                        Name = doc.ContactName,
                        Email = doc.ContactEmail
                    }
                    : null,
                License = !string.IsNullOrEmpty(doc.LicenseName)
                    ? new OpenApiLicense
                    {
                        Name = doc.LicenseName,
                        Url = new Uri(doc.LicenseUrl)
                    }
                    : null,
                TermsOfService = !string.IsNullOrEmpty(doc.TermsOfServiceUrl) ? new Uri(doc.TermsOfServiceUrl) : null
            });
        });

        s.ApiSetDefaultOption(o);

        return s;
    }
}