using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using PurchaseNexus.Server.StartupConfig;

namespace PurchaseNexus.Server;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        Log.Information("Starting host service configuration.");

        services.AddDatabaseContext(Configuration);

        IMvcBuilder mvcBuilder = services.AddApiControllers();
        
        mvcBuilder.AddValidators();
        
        mvcBuilder.AddJsonOptions(config =>
            config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        services.AddRazorPages();

        services.AddOpenApiDoc();

        Log.Information("Completed host service configuration.");
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        Log.Information("Starting host configuration.");

        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.SetupClientLoggingReceiver();
        app.SetupRequestLogging();

        app.SetupSwaggerUi();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
            endpoints.MapFallbackToFile("index.html");
        });

        Log.Information("Completed host configuration.");
    }
}
