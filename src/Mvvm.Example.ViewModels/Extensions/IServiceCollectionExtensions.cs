using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Mvvm.Example.Abstractions.ViewModels;
using Mvvm.Example.ViewModels.Abstractions;
using Mvvm.Example.ViewModels.Internals;

namespace Mvvm.Example.ViewModels.Extensions
{
    /// <summary>
    /// Static class that contains extension methods for <see cref="IServiceCollection" />.
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Registers all required components to enable ViewModel usage in the given <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services"> The <see cref="IServiceCollection" /> instance. </param>
        /// <returns> The same <see cref="IServiceCollection" /> instance with ViewModel-related services registered. </returns>
        public static IServiceCollection UseViewModel(this IServiceCollection services)
        {
            return services
                .AddSingleton<IViewModelLocator, ViewModelLocator>()
                .AddExternalServices()
                .AddSingletonServices()
                .AddViewModels();
        }

        private static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddSingletonServices(this IServiceCollection services)
        {
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IMessenger>(_ => WeakReferenceMessenger.Default);
            return services;
        }
    }
}
