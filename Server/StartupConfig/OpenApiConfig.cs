namespace PurchaseNexus.Server.StartupConfig;

public static class OpenApiConfig
{
    public static void AddOpenApiDoc(this IServiceCollection services)
    {
        services.AddOpenApiDocument(configure =>
        {
            configure.Title = "PurchaseNexus API";
        });
    }

    public static void SetupSwaggerUi(this IApplicationBuilder app)
    {
        app.UseSwaggerUi3(configure =>
            configure.DocumentPath = "/api/v1/specification.json");
    }
}
