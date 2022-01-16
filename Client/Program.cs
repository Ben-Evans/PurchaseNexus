using PurchaseNexus.Client;
using PurchaseNexus.Client.Services;
using FluentValidation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using PurchaseNexus.Shared.Validators;
using PurchaseNexus.Client.StartupConfig;

try
{
    var builder = WebAssemblyHostBuilder.CreateDefault(args);

    builder.SetupLogging();

    Log.Information("Starting web client.");

    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    builder.Services.AddHttpClientInterceptor();

    builder.Services.AddScoped(sp =>
        new HttpClient
        {
            BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
        }.EnableIntercept(sp));

    builder.Services.AddSingleton<IJSInProcessRuntime>(services =>
        (IJSInProcessRuntime)services.GetRequiredService<IJSRuntime>());

    builder.Services.AddLoadingBar();

    builder.Services.AddValidatorsFromAssemblyContaining<TodoListValidator>();

    builder.Services.AddScoped<SessionStorageService>();

    builder.Services.Scan(scan => scan
        .FromAssemblyOf<IWeatherClient>()
        .AddClasses().AsImplementedInterfaces()
        .WithScopedLifetime());

    builder.UseLoadingBar();

    Log.Information("Running web client.");
    await builder.Build().RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Web client terminated unexpectedly.");
}
finally
{
    Log.CloseAndFlush();
}
