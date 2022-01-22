namespace PurchaseNexus.Server.StartupConfig;

public static class RegisterServicesConfig
{
    public static void AddCoreServices(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddScoped<IFoodInventoryService, FoodInventoryService>();
    }
}
