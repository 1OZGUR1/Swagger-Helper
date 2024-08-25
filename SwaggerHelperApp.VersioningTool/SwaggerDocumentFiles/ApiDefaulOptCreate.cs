namespace SwaggerHelperApp.VersioningTool.SwaggerDocumentFiles;

public static class ApiDefaulOptCreate
{
    public static IServiceCollection ApiSetDefaultOption(this IServiceCollection s, ApiDefaultOpt o)
    {
        if (o.IsAddAnnatationSupport) s.AddAnnatationDocSupportExtension();

        if (o.IsAddXmlDocSupport) s.AddXmlDocSupportExtension();

        if (o.IsAddSwaggerJwtSecuritySupport) s.AddSwaggerJwtSecuritySupportExtension();

        if (o.IsAddSwaggerSecuritySupport) s.AddSwaggerSecuritySupportExtension();

        return s;
    }
}