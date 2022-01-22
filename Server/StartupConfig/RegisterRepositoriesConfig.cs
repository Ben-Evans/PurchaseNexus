namespace PurchaseNexus.Server.StartupConfig;

public static class RegisterRepositoriesConfig
{
    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddScoped<IFoodInventoryRepository, FoodInventoryRepository>();
    }
}
