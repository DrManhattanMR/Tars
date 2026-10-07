using Scalar.AspNetCore;
using Tars.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// 1. Controladores
builder.Services.AddControllers();

// 2. Inyección de Módulos / Servicios
builder.Services.AddApplicationServices();

// 3. Documentación OpenAPI
builder.Services.AddOpenApi();

// 4. CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Interceptor de errores
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Arquetipo Web API");
        options.WithTheme(ScalarTheme.Moon);
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();