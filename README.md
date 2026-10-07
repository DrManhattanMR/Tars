# 🚀 Backend Web API Archetype (.NET 9 / .NET 10)

Un arquetipo/plantilla base para el desarrollo de Web APIs robustas y escalables en C#. Diseñado bajo principios de **Clean Architecture**, enrutamiento por **Controllers**, serialización estandarizada y documentación moderna interactiva.

---

## 🛠️ Tecnologías y Características

* **Framework:** .NET 10 (C#)
* **Arquitectura:** Clean Architecture / Layered Architecture
* **Endpoints:** ASP.NET Core Web API Controllers (`[ApiController]`)
* **Documentación:** OpenAPI + **Scalar** (Sustituto moderno de Swagger UI)
* **Respuesta Estandarizada:** Wrapper genérico `ApiResponse<T>` para tipado estricto
* **Manejo de Errores:** Middleware Global de Excepciones con `IExceptionHandler`
* **Logging:** Inyección nativa de `ILogger<T>` con soporte para trazado y `LogDebug`
* **CORS:** Política abierta preconfigurada para consumo desde clientes Web/Mobile

---

## 📂 Estructura del Proyecto

```text
TuProyecto.Api/
│
├── Controllers/
│   └── HealthController.cs          # Endpoint base de verificación de infraestructura
│── DTOs/
│   ├── ApiResponse.cs        # Wrapper genérico para respuestas de la API
│   ── SystemHealthDto.cs   # DTO para status e infraestructura
│   │
│── Interfaces/
│   │└── ISystemHealthService.cs   # Contrato de servicios de aplicación
│   │
│└──Services/
│      └── SystemHealthService.cs   # Lógica de negocio y recolección de métricas
│
├── Infrastructure/
│   └── Middlewares/
│       └── GlobalExceptionHandler.cs # Interceptor global de excepciones no controladas
│   └── DependencyInjection/
│       └── ServiceCollectionExtensions.cs # Registros modularizados de IoC / Inyección
│
├── appsettings.json                 # Configuración del entorno
├── appsettings.Development.json     # Niveles de logging (Debug)
└── Program.cs                       # Pipeline de la aplicación
```
## 📊 Arquitectura de Respuestas HTTP
Todas las peticiones a la API responden con una estructura JSON uniforme mediante la clase ApiResponse<T>:
```text
1. Respuesta Exitosa (200 OK)

{
  "success": true,
  "message": "Sistema operando normalmente",
  "data": {
    "status": "Healthy",
    "appName": "TuProyecto.Api",
    "environment": "Development",
    "serverTimeUtc": "2026-10-06T22:30:00.000Z",
    "version": "1.0.0.0"
  },
  "errors": null
}

2. Respuesta con Error (400 Bad Request / 500 Server Error)

{
  "success": false,
  "message": "Ocurrió un error inesperado en el servidor",
  "data": null,
  "errors": [
    "Descripción detallada de la excepción o fallo de validación"
  ]
}
```

Explorar la documentación (Scalar UI):
Abre tu navegador e ingresa a:
http://localhost:5246/scalar/v1#description/introduction