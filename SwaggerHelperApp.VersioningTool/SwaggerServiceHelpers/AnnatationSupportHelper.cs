namespace SwaggerHelperApp.VersioningTool.SwaggerServiceHelpers;

public static class AnnatationSupportHelper
{

    /// <summary>
    /// En - This method is used to opt in to Swagger documentation annotation
    /// support in your ASP.NET Core application. Adding Swagger annotations
    /// allows developers to make the API more understandable and documented.
    /// ------------------
    /// Tr - Bu yöntem, ASP.NET Core uygulamanızda Swagger belgelerine
    /// açıklama desteği (annotation support) seçmek için kullanılır.
    /// Swagger açıklamalarının eklenmesi, geliştiricilere API'yi daha
    /// anlaşılır ve belgelenmiş hale getirme imkanı sağlar.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static IServiceCollection AddAnnatationDocSupportExtension(this IServiceCollection s)
    {
        return s.AddSwaggerGen(x => { x.EnableAnnotations(); });
    }
}