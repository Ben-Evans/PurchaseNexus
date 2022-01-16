using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Serilog.Core;
using Serilog.Debugging;
using Serilog.Events;

namespace PurchaseNexus.Client.StartupConfig;

/// <summary>
/// <para>Config for setting up <seealso href="https://github.com/serilog/serilog">Serilog</seealso> logging with Blazor WASM on the client side.</para>
/// <example>
///  Ex. #1 (Static Log)<br/>
///  using Serilog;<br/>
///  Log.Information("My message");<br/>
/// </example>
/// <br/>
/// <example>
///  Ex. #2 (Static Log w/ Context)<br/>
///  using Serilog;<br/>
///  private static readonly ILogger Logger = Log.ForContext≤T≥();<br/>
///  Logger.Information("My message");
/// </example>
/// </summary>
public static class ClientLoggingConfig
{
    /// <summary>
    /// <inheritdoc cref="LoggerConfiguration.CreateLogger"/>
    /// <para>
    /// Logs are being written to <seealso href="https://github.com/serilog/serilog-sinks-browserconsole">Serilog Browser Console</seealso> 
    /// and additonally sent to the server side using <seealso href="https://github.com/nblumhardt/serilog-sinks-browserhttp">Serilog Browser Http</seealso>.
    /// </para>
    /// </summary>
    public static void SetupLogging(this WebAssemblyHostBuilder builder)
    {
        // Writes any internal Serilog exceptions to the browser's console
        SelfLog.Enable(m => Console.Error.WriteLine(m));

        var levelSwitch = new LoggingLevelSwitch(LogEventLevel.Debug);

        // Enable Serilog for Blazor WASM to display logs in the browser's console & send to the server
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.ControlledBy(levelSwitch)
            .WriteTo.BrowserConsole()
            .WriteTo.BrowserHttp($"{builder.HostEnvironment.BaseAddress}ingest", controlLevelSwitch: levelSwitch)
            .CreateLogger();
    }
}
