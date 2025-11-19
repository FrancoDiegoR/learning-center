using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NeuroLink.API.Assessment.Infrastructure.Interfaces.ASP.Configuration;
using NeuroLink.API.Shared.Infrastructure.Persistence.EFC.Configuration; 

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar Rutas en minúsculas (Requisito del PDF)
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// 2. Configuración de Controladores
builder.Services.AddControllers();

// 3. Configuración de Swagger (Swashbuckle) para ver la UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "NeuroLink API",
        Version = "v1",
        Description = "API para NeuroLink Health Tech - PC2"
    });
});

// 4. CONEXIÓN A BASE DE DATOS (MySQL)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString != null)
    {
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
               .LogTo(Console.WriteLine, LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors();
    }
});

// 5. INYECTAR TU BOUNDED CONTEXT (Assessment)
// Esto registra tus Repositorios y Servicios que creamos en WebApplicationBuilderExtensions
builder.AddAssessmentInfrastructure(); 

var app = builder.Build();

// 6. Configurar el Pipeline HTTP
// Validar que cree la base de datos automáticamente al iniciar (opcional pero útil)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated(); // Esto crea la tabla si no existe
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();