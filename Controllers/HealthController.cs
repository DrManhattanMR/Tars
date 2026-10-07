using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tars.DTOs;
using Tars.Interfaces;

namespace Tars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly ISystemHealthService _healthService;
        private readonly ILogger<HealthController> _logger;

        public HealthController(
            ISystemHealthService healthService,
            ILogger<HealthController> logger)
        {
            _healthService = healthService;
            _logger = logger;
        }

        /// <summary>
        /// Verifica la salud del sistema y la conectividad base
        /// </summary>
        [HttpGet]
        public ActionResult<ApiResponse<SystemHealthDto>> Check()
        {
            _logger.LogInformation("Petición recibida en GET /api/health");
        
            var healthData = _healthService.GetHealthStatus();
        
            return Ok(ApiResponse<SystemHealthDto>.Ok(healthData, "Sistema operando normalmente"));
        }
    }
}
