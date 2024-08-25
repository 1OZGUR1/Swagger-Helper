namespace SwaggerHelperApp.VersioningTool.GlobalOperations;

public static class SwaggerMiddlewareExtensions
{
   
    public static WebApplication UseMyAwesomeSwaggerSupport(this WebApplication app, ApiDefaultOpt opt,
        bool isExceptionHelper = false)
    {
        if (isExceptionHelper == true) app.UseExceptionHandler();


        if (!app.Environment.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                options.DocumentTitle = "API Documentation";
            });

            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });

            // your code here
        }

        return app;
    }
}