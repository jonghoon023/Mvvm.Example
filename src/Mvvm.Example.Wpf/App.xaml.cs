using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mvvm.Example.ViewModels.Extensions;
using Mvvm.Example.Wpf.Extensions;
using System.Windows;

namespace Mvvm.Example.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private const string ApplicationNameSectionName = "Application:Name";
    private readonly IHost _host;

    /// <summary>
    /// Initializes a new instance of the <see cref="App" /> class.
    /// </summary>
    public App()
    {
        IHostBuilder hostBuilder = Host.CreateDefaultBuilder()
        .ConfigureAppConfiguration(builder =>
        {
            builder.SetBasePath(AppContext.BaseDirectory);
            builder.AddEnvironmentVariables();
            builder.AddAppSettings();
        })
        .ConfigureServices((context, services) =>
        {
            context.HostingEnvironment.ApplicationName = GetApplicationName(context.Configuration, context.HostingEnvironment);

            services.UseViewModel();
            services.AddSingletonServices();
            services.AddOperatingSystemServices();

            services.AddSingleton<MainWindow>();
        })
        .ConfigureLogging(builder => builder.ClearProviders())
        .UseSerilogWithFile();

        _host = hostBuilder.Build();
        MainWindow = _host.Services.GetRequiredService<MainWindow>();
    }

    /// <inheritdoc cref="Application.OnStartup(StartupEventArgs)" />
    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();
        MainWindow.Show();

        base.OnStartup(e);
    }

    /// <inheritdoc cref="Application.OnExit(ExitEventArgs)" />
    protected override void OnExit(ExitEventArgs e)
    {
        using (_host)
        {
            _host.StopAsync();
        }

        base.OnExit(e);
    }

    private static string GetApplicationName(IConfiguration configuration, IHostEnvironment environment)
    {
        return configuration.GetValue<string>(ApplicationNameSectionName) ?? environment.ApplicationName;
    }
}
