using Fiap_Hackaton.Health_Med.Data.Contexto;
using Fiap_Hackaton.Health_Med.Data.Repository;
using Fiap_Hackaton.Health_Med.Domain.ErrorNotificator;
using Fiap_Hackaton.Health_Med.Domain.Interfaces.Repository;
using Fiap_Hackaton.Health_Med.Domain.Interfaces.Services;
using Fiap_Hackaton.Health_Med.Services;
using Microsoft.EntityFrameworkCore;

namespace Fiap_Hackaton.Health_Med.API.Configuration;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContexto>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
    sql => sql.MigrationsAssembly("Fiap_Hackaton.Health_Med.Data")));

        services.AddRepositoryDependency();
        services.AddServiceDependency();
        return services;
    }

    public static IServiceCollection AddRepositoryDependency(this IServiceCollection services)
    {
        services.AddScoped<IDisponibilidadeRepository, DisponibilidadeRepository>();
        services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
        return services;
    }

    public static IServiceCollection AddServiceDependency(this IServiceCollection services)
    {
        services.AddHttpClient<AuthService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<INotificator, Notificator>();
        services.AddHttpContextAccessor(); 
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IConfiguracaoService, ConfiguracaoService>();
        services.AddScoped<IAgendaService, AgendaService>();
        return services;
    }
}