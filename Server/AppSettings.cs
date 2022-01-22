namespace PurchaseNexus.Server;

public interface IAppSettings
{
}

/* TODO: Might want to do something like this on Statup?
 * public static void AddAppSettings(this WebApplicationBuilder builder)
 * {
 *     builder.Configuration.AddJsonFile("appsettings.json");
 *     builder.Services.AddScoped<IAppSettings, AppSettings>();
 * }
 */
public class AppSettings : IAppSettings
{
    private readonly IConfiguration _config;

    public AppSettings(IConfiguration config)
    {
        _config = config;
    }

    public string ConnectionString => _config["ConnectionStrings:DefaultConnection"];
}
