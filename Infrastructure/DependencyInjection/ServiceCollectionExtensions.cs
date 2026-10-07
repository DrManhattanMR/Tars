using Tars.Interfaces;
using Tars.Infrastructure.Middlewares;
using Tars.Services;

namespace Tars.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Registrar Servicios de Aplicación / Negocio
        services.AddScoped<ISystemHealthService, SystemHealthService>();
        
        // Manejo de errores global
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        
        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Registrar DbContext, Repositorios y Servicios Externos
        // services.AddDbContext<ApplicationDbContext>(options => ...);
        // services.AddScoped<ITicketRepository, TicketRepository>();
        
        return services;
    }
}