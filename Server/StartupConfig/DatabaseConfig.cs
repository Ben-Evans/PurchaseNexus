namespace PurchaseNexus.Server.StartupConfig;

/// <summary>
/// Package Manager Console
/// Add-Migration Migration_Name -Project DataAccess
/// Get-Migration
/// Remove-Migration
/// Reset All Migrations - Delete Migrations folder and drop DB
/// 
/// Update-Database
/// </summary>
public static class DatabaseConfig
{
    public static void AddDatabaseContext(this IServiceCollection services, IConfiguration config)
    {
        string connectionString = config.GetConnectionString("DefaultConnection");

        services.AddSqlServer<ApplicationDbContext>(connectionString);

        services.AddDatabaseDeveloperPageExceptionFilter();
    }
}
