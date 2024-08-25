namespace SwaggerHelperApp.VersioningTool.SwaggerServiceHelpers;

public static class XmlDocSupportHelper
{

    /// <summary>
    /// En - This Extension Method is Add Xml Documantation
    /// For Endpoint and Controllers
    /// -------------
    /// Tr - Bu ekstenşin metod endpoind ve controller'lar
    /// üzerindeki yorum dökümantasyon desteği sağlar
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static IServiceCollection AddXmlDocSupportExtension(this IServiceCollection s)
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        return s.AddSwaggerGen(x =>
        {
            // Swagger XML yorum desteği
            x.IncludeXmlComments(xmlPath);
        });
    }
}