namespace PurchaseNexus.Server;

public class Program
{
    public static void Main(string[] args)
    {
        ServerLogConfig.SetupInitialLogging();

        try
        {
            Log.Information("Starting web host.");
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly.");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .SetupFullLogging()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
