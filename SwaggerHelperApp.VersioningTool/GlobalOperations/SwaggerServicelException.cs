namespace SwaggerHelperApp.VersioningTool.GlobalOperations;

public static class SwaggerServicelException
{
    public static IServiceCollection AddGlobalExceptionExtension(this IServiceCollection s)
    {
        s.AddExceptionHandler<GlobalExceptionHandler>();
        s.AddProblemDetails();
        return s;
    }
}