using Fiap_Hackaton.Health_Med.Domain.ErrorNotificator;
using Fiap_Hackaton.Health_Med.Domain.Interfaces.Services;

namespace Fiap_Hackaton.Health_Med.API.Configuration;

    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddRepositoryDependency();
            services.AddServiceDependency();
            return services;
        }

        public static IServiceCollection AddRepositoryDependency(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<INotificator, Notificator>();
            return services;
        }
    }