# Swagger-Helper
 This plugin provides automatic and a wide range of documentation, filter and global exception support for your rapid API development. It is modular

Dökümantasyon .Net 5 İçin Yazılmış Olup Kütüphane .Net 8 Desteklidir
 
V.1.00 bug içermekte olup stabil versiyon V.1.1

### 1. **BaseException Sınıfı**

- **BaseException**: Tüm özel hataları (custom exceptions) türetebileceğiniz bir temel sınıf. `HttpStatusCode` özelliği ile HTTP durum kodunu belirleyebilir, mesajla birlikte hata fırlatabilirsiniz.

### 2. **GlobalExceptionHandler Sınıfı**

- Bu sınıf, özel olarak fırlatılan `BaseException` sınıfını ele alarak HTTP durumu ve hata mesajını ayarlıyor. Diğer tüm hatalar için genel bir hata mesajı veriyor. Ayrıca, bir hata meydana geldiğinde loglamayı da gerçekleştiriyor.

### 3. **Swagger Middleware ve Service Extensions**

- **SwaggerMiddlewareExtensions**: Swagger desteğini ekleyen bir uzantı metodu içerir. `isExceptionHelper` bayrağı ile hata işleme orta katmanı (middleware) ekleyip eklememeyi seçebilirsiniz.
- **SwaggerServiceExtensions**: Swagger ve diğer çeşitli seçeneklerle API sürümlemeyi yapılandırır.
- **SwaggerServicelException**: Uygulamaya global hata işleme ve problem detayları desteği ekleyen bir uzantı metodudur.

### 4. **ApiDefaultOpt Sınıfı ve Builder Deseni**

- **ApiDefaultOpt**: Swagger ve API belgelerini yapılandırmak için bir sınıf. İçerisinde bir Builder deseni ile çeşitli ayarları belirleyebilirsiniz.

### 5. **SwaggerDocumentBasic Sınıfı ve Builder Deseni**

- **SwaggerDocumentBasic**: Swagger doküman bilgilerini (sürüm, başlık, açıklama, lisans vb.) tanımlayan bir sınıf. Bu sınıfta da Builder deseni kullanılmış.

### 6. **DateOnlyJsonConverter**

- **DateOnlyJsonConverter**: `DateOnly` türü için bir JSON dönüştürücüdür. Bu, tarih formatlarını belirli bir şekilde serileştirmek ve ayrıştırmak için kullanılır.

### 7. **EndpointTypeHelper Enum**

- **EndpointTypeHelper**: API işlemleri (GET, POST, PUT, DELETE, Query, Command) için enum değerleri tanımlar.

### 8. **Swagger Operation ve Security Helper Sınıfları**

- **SwaggerOperationFilter**: API işlemlerini belirli türlere göre filtrelemek için kullanılan bir sınıftır.
- **SwaggerJwtSecurityHelper**: JWT tabanlı kimlik doğrulama desteğini Swagger'a ekler.

### Kullanım Durumları ve Esneklik:

Bu kod, büyük ve esnek bir API uygulaması için tasarlanmış. Swagger entegrasyonu, hata yönetimi, JSON serileştirme ve API sürümleme gibi çeşitli önemli yapı taşlarını içeriyor. API'yi daha kullanışlı hale getirmek ve farklı ihtiyaçlara göre yapılandırmak için genişletilebilir ve uyarlanabilir bir altyapı sağlıyor.

-------------------------------------------------------------------------

### 1. Swagger Entegrasyonu

Swagger, API'nizin dökümantasyonunu otomatik olarak oluşturmanızı sağlar. Sağladığınız kodda Swagger desteğini eklemek ve yapılandırmak için aşağıdaki adımları izleyin:

#### a) `Startup.cs` veya `Program.cs` Dosyasında Swagger Desteğini Ekleyin

```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Swagger hizmetlerini ekleyin
        var swaggerDoc = new SwaggerDocumentBasic.Builder()
            .SetVersion("v1")
            .SetTitle("My Awesome API")
            .SetDescription("API Documentation")
            .SetContactName("John Doe")
            .SetContactEmail("johndoe@example.com")
            .Build();

        var apiDefaultOpt = new ApiDefaultOpt.Builder()
            .AddAnnatationSupport(true)
            .AddXmlDocSupport(true)
            .AddSwaggerJwtSecuritySupport(true)
            .Build();

        services.AddMyAwesomeSwaggerSupport(swaggerDoc, apiDefaultOpt);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Swagger Middleware'ini ekleyin
        app.UseMyAwesomeSwaggerSupport(apiDefaultOpt, isExceptionHelper: true);

        // Diğer middleware'ler
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

```

#### b) API Dökümantasyonunun Görselleştirilmesi

Yukarıdaki yapılandırma ile, API'nizi çalıştırdıktan sonra Swagger dökümantasyonunu görmek için tarayıcınızda `https://localhost:{PORT}/swagger/index.html` adresine gidin.

### 2. Global Exception Handler Entegrasyonu

Global Exception Handler, uygulamanızdaki tüm hataları yakalayıp özelleştirilmiş bir yanıt döndürebileceğiniz bir yapı sağlar.

#### a) `Startup.cs` veya `Program.cs` Dosyasında Global Exception Handler'ı Ekleyin

```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Global Exception Handler'ı ekleyin
        services.AddGlobalExceptionExtension();

        // Diğer servisler
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Exception Handler Middleware'i ekleyin
        app.UseExceptionHandler();

        // Diğer middleware'ler
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

```

### 3. Swagger ve Exception Handler'ın Birlikte Kullanımı

Yukarıdaki adımlarla, Swagger ve Global Exception Handler'ı projenize entegre ettiniz. Bu yapılar, API'nizdeki hataları daha iyi yönetmenizi ve API'nizi daha iyi dökümante etmenizi sağlar.

### 4. Ekstra Güvenlik Desteği (JWT)

Eğer JWT güvenliği kullanıyorsanız, Swagger üzerinde JWT desteğini ekleyerek kullanıcıların `Authorization` başlığında bir `Bearer` token sağlamasını gerektirebilirsiniz. Bunun için `SwaggerJwtSecurityHelper` sınıfındaki `AddSwaggerJwtSecuritySupportExtension` metodunu kullanarak güvenlik desteğini ekleyebilirsiniz.

### 5. Örnek Kullanım

```csharp
var swaggerDoc = new SwaggerDocumentBasic.Builder()
    .SetVersion("v1")
    .SetTitle("My Awesome API")
    .SetDescription("API Documentation")
    .SetContactName("John Doe")
    .SetContactEmail("johndoe@example.com")
    .Build();

var apiDefaultOpt = new ApiDefaultOpt.Builder()
    .AddAnnatationSupport(true)
    .AddXmlDocSupport(true)
    .AddSwaggerJwtSecuritySupport(true)
    .Build();

services.AddMyAwesomeSwaggerSupport(swaggerDoc, apiDefaultOpt);
services.AddGlobalExceptionExtension();

app.UseMyAwesomeSwaggerSupport(apiDefaultOpt, isExceptionHelper: true);

```

---

## `SwaggerOperationFilter` Kullanımı

### 1. `SwaggerOperationFilter` Nedir?

`SwaggerOperationFilter`, Swagger belgelerinde API endpoint'lerinin açıklamalarını ve etiketlerini dinamik olarak özelleştirmeyi sağlayan bir özelliktir. Bu filtre, Swagger UI'da görünecek açıklama metinlerini ve meta verileri belirlemek için kullanılır.

### 2. `SwaggerOperationFilter` Yapısı

`SwaggerOperationFilter`, Swagger belgelerindeki operasyonların açıklamalarını değiştirmek veya eklemek için kullanılan bir `IOperationFilter` implementasyonudur.

#### a) **Filtre Yapısı**

Öncelikle, `SwaggerOperationFilter` sınıfını oluşturmanız gerekecek. Bu sınıf, Swagger belgelerine operasyon açıklamaları ekler veya mevcut açıklamaları değiştirir.

##### `SwaggerOperationFilter` Sınıfı:

```csharp
public class SwaggerOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Örnek: Operasyonun açıklamasını dinamik olarak ayarlayın
        if (operation.Description == null)
        {
            operation.Description = "Bu endpoint ile ilgili açıklama eklenmemiş.";
        }
        
        // Örnek: Operasyonun etiketlerini ekleyin veya değiştirin
        if (operation.Tags == null || !operation.Tags.Any())
        {
            operation.Tags = new List<OpenApiTag>
            {
                new OpenApiTag { Name = "Default Tag" }
            };
        }
    }
}

```

Bu filtre, her Swagger operasyonu için açıklamaları ve etiketleri dinamik olarak belirler.

#### b) **Filtreyi Eklemek**

`SwaggerOperationFilter` sınıfını Swagger yapılandırmanıza eklemek için `Startup.cs` veya ilgili yapılandırma dosyasında gerekli ayarları yapmalısınız.

##### `Startup.cs` Dosyasında Filtreyi Eklemek:

```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

            // SwaggerOperationFilter'ı ekleyin
            c.OperationFilter<SwaggerOperationFilter>();
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
        }

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

```

### 3. Dökümantasyon ve Kullanım Örnekleri

#### a) **Dinamik Açıklama Ekleme**

`SwaggerOperationFilter`, API endpoint'lerinin açıklamalarını dinamik olarak eklemek veya değiştirmek için kullanılabilir. Örneğin, operasyonun açıklaması eksikse, varsayılan bir açıklama ekleyebilirsiniz.

#### b) **Dinamik Etiket Ekleme**

Bu filtre ayrıca operasyonlara etiketler eklemeye veya mevcut etiketleri değiştirmeye olanak sağlar. Etiketler, Swagger UI'daki endpoint'lerin düzenli bir şekilde gruplanmasını sağlar.

#### c) **Gelişmiş Özelleştirme**

`SwaggerOperationFilter` kullanarak, Swagger belgelerinizi daha anlamlı ve kullanıcı dostu hale getirebilirsiniz. Özelleştirilmiş açıklamalar, etiketler veya meta veriler ekleyerek API'nizin belgelenmesini iyileştirebilirsiniz.

### 4. Dikkat Edilmesi Gerekenler

- **Performans:** Filtrenin performansa etkisini göz önünde bulundurarak, işlemleri optimize edin.
- **Açıklama Tutarlılığı:** Dinamik açıklamalar eklerken, açıklama metinlerinin API'nin gerçek işleviyle tutarlı olduğundan emin olun.

----------------------------------------------------------------------
## `EndpointTypeHelper` Kullanımı

### 1. `EndpointTypeHelper` Nedir?

`EndpointTypeHelper`, API endpoint'lerinin türlerini belirlemek ve bu türlerle ilgili işlemleri yönetmek için kullanılan bir yardımcı sınıftır. Bu sınıf, endpoint türlerini dinamik olarak belirlemeye ve endpoint yapılandırmalarını kolaylaştırmaya yardımcı olur.

### 2. `EndpointTypeHelper` Yapısı

`EndpointTypeHelper`, genellikle endpoint'lerin türleriyle ilgili çeşitli işlemleri gerçekleştirmek için kullanılan statik yöntemler içerir. Bu yöntemler, endpoint'lerin dinamik olarak yönetilmesini sağlar.

#### a) **Yardımcı Sınıfın Yapısı**


```csharp
public static class EndpointTypeHelper
{
    /// <summary>
    /// Verilen endpoint türü için uygun açıklamayı döndürür.
    /// </summary>
    /// <param name="endpointType">Endpoint türü.</param>
    /// <returns>Açıklama metni.</returns>
    public static string GetDescriptionForEndpointType(Type endpointType)
    {
        // Endpoint türüne bağlı olarak açıklamayı döndürür
        if (endpointType == typeof(SomeSpecificEndpoint))
        {
            return "Bu endpoint belirli bir işlevi yerine getirir.";
        }

        return "Bu endpoint için açıklama mevcut değil.";
    }

    /// <summary>
    /// Endpoint türü için uygun etiketleri döndürür.
    /// </summary>
    /// <param name="endpointType">Endpoint türü.</param>
    /// <returns>Etiket listesi.</returns>
    public static List<string> GetTagsForEndpointType(Type endpointType)
    {
        // Endpoint türüne bağlı olarak etiketleri döndürür
        var tags = new List<string>();

        if (endpointType == typeof(SomeSpecificEndpoint))
        {
            tags.Add("Özel Etiket");
        }
        else
        {
            tags.Add("Genel Etiket");
        }

        return tags;
    }
}

```
Bu sınıf, `GetDescriptionForEndpointType` ve `GetTagsForEndpointType` gibi metodlar içerir. Bu metodlar, belirli bir endpoint türü için açıklama metinleri ve etiketler sağlar.

### 3. Dökümantasyon ve Kullanım Örnekleri

#### a) **Endpoint Açıklamasını Alma**

`EndpointTypeHelper` sınıfını kullanarak, belirli bir endpoint türü için açıklama metnini dinamik olarak alabilirsiniz.

##### Kullanım Örneği:

```csharp
var endpointType = typeof(SomeSpecificEndpoint);
var description = EndpointTypeHelper.GetDescriptionForEndpointType(endpointType);
Console.WriteLine(description);
```

#### b) **Endpoint Etiketlerini Alma**

Endpoint'ler için etiketleri dinamik olarak almak amacıyla `EndpointTypeHelper` sınıfını kullanabilirsiniz. Bu etiketler, Swagger UI'da endpoint'lerin gruplanmasını sağlar.

##### Kullanım Örneği:

```csharp
var endpointType = typeof(SomeSpecificEndpoint);
var tags = EndpointTypeHelper.GetTagsForEndpointType(endpointType);
Console.WriteLine(string.Join(", ", tags));
```

### 4. Dikkat Edilmesi Gerekenler

- **Performans:** Endpoint türleri ve açıklamaları üzerinde işlemler yaparken performansı göz önünde bulundurun. Özellikle büyük projelerde, metodların verimli çalışmasını sağlamak önemlidir.
- **Açıklama ve Etiket Tutarlılığı:** Endpoint açıklamaları ve etiketler, API'nin gerçek işleviyle tutarlı olmalıdır. Bu, API belgelerinin doğru ve kullanıcı dostu olmasını sağlar.
