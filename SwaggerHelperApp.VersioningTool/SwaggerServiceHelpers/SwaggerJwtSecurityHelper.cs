namespace SwaggerHelperApp.VersioningTool.SwaggerServiceHelpers;

public static class SwaggerJwtSecurityHelper
{
    /// <summary>
    /// En - This method is used to select support for configuring identity
    /// with JWT (JSON Web Token) in your ASP.NET Core application according to
    /// Swagger documentation. The purpose of the method is to enable
    /// JWT based authorization for API execution via Swagger UI.
    /// It requires users to provide a "Bearer" token in the
    /// "Authorization" header when using the API.
    /// ---------------
    /// Tr - Bu yöntem, ASP.NET Core uygulamanızda Swagger belgelerine
    /// JWT (JSON Web Token) ile kimlik yapılandırma desteğini seçmek için kullanılır.
    /// Metodun amacı, Swagger UI üzerinden API gerçekleştirilmesini
    /// JWT tabanlı yetkilendirmeyi sağlayabilmektir. Kullanıcıların API'yi kullanırken
    /// "Yetkilendirme" başlığında bir "Hamiline" jeton sağlamasını gerektirir.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static IServiceCollection AddSwaggerJwtSecuritySupportExtension(this IServiceCollection s)
    {
        return s.AddSwaggerGen(o =>
        {
            // Swagger güvenlik desteği
            o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
            });
        });
    }
}