using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure.Logging
{
    public static class ConfigureLoggingExtension
    {

        public static IServiceCollection ConifigureLogging(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IFactory<>), typeof(Factory<>));
            services.AddFactory<IConsoleLoggingFactory, ConsoleLoggingFactory>();
            services.AddFactory<IFileLoggingFactory, FileLoggingFactory>();
            return services;
        }

        public static void AddFactory<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddTransient<TService, TImplementation>();
            services.AddSingleton<Func<TService>>(x => () => x.GetService<TService>());
        }
    }
}
