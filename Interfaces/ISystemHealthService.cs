using Tars.DTOs;

namespace Tars.Interfaces;

public interface ISystemHealthService
{
    SystemHealthDto GetHealthStatus();
}