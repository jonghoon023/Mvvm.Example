using Microsoft.Extensions.DependencyInjection;
using Mvvm.Example.Abstractions.Views;
using Mvvm.Example.Wpf.Services;
using System.Runtime.InteropServices;

namespace Mvvm.Example.Wpf.Extensions;

/// <summary>
/// Static class that contains extension methods for <see cref="IServiceCollection" />.
/// </summary>
internal static class IServiceCollectionExtensions
{
    /// <summary>
    /// Registers services with <see cref="ServiceLifetime.Singleton" /> lifetime.
    /// </summary>
    /// <param name="services"> An implementation of <see cref="IServiceCollection" />. </param>
    /// <returns> The <see cref="IServiceCollection" /> instance after registering singleton services. </returns>
    public static IServiceCollection AddSingletonServices(this IServiceCollection services)
    {
        services.AddSingleton<IMainThread, MainThread>();
        return services;
    }

    /// <summary>
    /// Registers services required for each operating system.
    /// </summary>
    /// <param name="services"> An implementation of <see cref="IServiceCollection" />. </param>
    /// <returns> The <see cref="IServiceCollection" /> instance after registering OS-specific services. </returns>
    public static IServiceCollection AddOperatingSystemServices(this IServiceCollection services)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            services.AddSingleton<IAppInfo, WindowsAppInfo>();
        }

        return services;
    }
}
