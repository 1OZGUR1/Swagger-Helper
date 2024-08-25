namespace SwaggerHelperApp.VersioningTool.SwaggerServiceHelpers;

public static class SwaggerSecurityHelper
{
    /// <summary>
    /// En - This method is used to provide security support for Swagger documents in ASP.NET Core
    /// application. It is especially useful in projects that aim to protect your API using JWT (JSON
    /// Web Token) identity ranges. The function of the method is to select a security requirement
    /// (security requirement) for Swagger products and thus require users to authenticate with a valid
    /// "Bearer" token when using the API.
    /// ----------------------
    /// Tr - Bu yöntem, ASP.NET Core uygulamasında Swagger belgelerine güvenlik desteği sağlamak için
    /// kullanılır. Özellikle JWT (JSON Web Token) kimlik aralığı aralıklarını kullanarak API'nizi
    /// korumayı amaçlayan projelerde kullanışlıdır. Metodun işlevi, Swagger ürünlerine bir güvenlik
    /// gereksinimleri (güvenlik gereksinimi) seçme ve bu sayede kullanıcıların API'yi kullanırken
    /// geçerli bir "Bearer" token ile yetkilendirme yapmalarını gerektirmektir.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static IServiceCollection AddSwaggerSecuritySupportExtension(this IServiceCollection s)
    {
        return s.AddSwaggerGen(o =>
        {
            o.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }
}