using System.Reflection;
using Tars.DTOs;
using Tars.Interfaces;

namespace Tars.Services;

public class SystemHealthService : ISystemHealthService
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<SystemHealthService> _logger;

    public SystemHealthService(IWebHostEnvironment environment,ILogger<SystemHealthService> logger)
    {
        _environment = environment;
        _logger = logger;
    }

    public SystemHealthDto GetHealthStatus()
    {
        _logger.LogInformation("Ejecutando verificación de estado de salud del sistema.");
        var assemblyName = Assembly.GetExecutingAssembly().GetName();

        var healthStatus = new SystemHealthDto(
            Status: "Healthy",
            AppName: assemblyName.Name ?? "Web API",
            Environment: _environment.EnvironmentName,
            ServerTimeUtc: DateTime.UtcNow,
            Version: assemblyName.Version?.ToString() ?? "1.0.0"
        );
        _logger.LogInformation("Estado del sistema generado correctamente: {@HealthStatus}", healthStatus);
        return healthStatus;
    }
}