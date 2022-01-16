using Serilog.Core;
using Serilog.Events;

namespace PurchaseNexus.Server;

/// <summary>
/// <para>Config for setting up <seealso href="https://github.com/serilog/serilog">Serilog</seealso> logging with .Net Core Web Server.</para>
/// <example>
///  Ex. (using Dependency Injection)
///  using Serilog;<br/>
///  ctor(ILogger≤T≥ logger)<br/>
///  logger.Information("My message");
/// </example>
/// </summary>
public static class ServerLogConfig
{
    /// <summary>
    /// <inheritdoc cref="LoggerConfigurationExtensions.CreateBootstrapLogger"/>
    /// </summary>
    public static void SetupInitialLogging()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateBootstrapLogger();
    }

    /// <summary>
    /// <inheritdoc cref="SerilogHostBuilderExtensions.UseSerilog"/>
    /// </summary>
    public static IHostBuilder SetupFullLogging(this IHostBuilder hostBuilder)
    {
        return hostBuilder.UseSerilog((context, services, configuration) =>
            configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .WriteTo.Console());
    }

    /// <summary>
    /// <inheritdoc cref="ApplicationBuilderSerilogClientExtensions.UseSerilogIngestion"/>
    /// <para>
    /// Client side logs are received here using <seealso href="https://github.com/nblumhardt/serilog-sinks-browserhttp">Serilog Ingestion</seealso>.
    /// These logs are sent to the server using <seealso href="https://github.com/nblumhardt/serilog-sinks-browserhttp">Serilog Browser Http</seealso>.
    /// </para>
    /// </summary>
    public static void SetupClientLoggingReceiver(this IApplicationBuilder app)
    {
        app.UseSerilogIngestion(opts =>
        {
            opts.EndpointPath = "/ingest";
            opts.ClientLevelSwitch = new LoggingLevelSwitch(LogEventLevel.Debug);
        });
    }

    /// <summary>
    /// <inheritdoc cref="SerilogApplicationBuilderExtensions.UseSerilogRequestLogging"/>
    /// </summary>
    public static void SetupRequestLogging(this IApplicationBuilder app)
    {
        app.UseSerilogRequestLogging();
    }
}
