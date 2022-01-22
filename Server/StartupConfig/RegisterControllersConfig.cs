namespace PurchaseNexus.Server.StartupConfig;

public static class RegisterControllersConfig
{
    public static IMvcBuilder AddApiControllers(this IServiceCollection services)
    {
        return services.AddControllersWithViews();
    }

    public static void AddMinApiControllers(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("/", () => "Hello World");
        routeBuilder.MapGet("/weather", () => new { Weather = "Rainy" });
    }
}
