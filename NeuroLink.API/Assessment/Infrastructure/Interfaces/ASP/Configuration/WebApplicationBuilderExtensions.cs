using NeuroLink.API.Assessment.Application.Internal.CommandServices;
using NeuroLink.API.Assessment.Domain.Repositories;
using NeuroLink.API.Assessment.Infrastructure.Persistence.EFC.Repositories;

namespace NeuroLink.API.Assessment.Infrastructure.Interfaces.ASP.Configuration;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddAssessmentInfrastructure(this WebApplicationBuilder builder)
    {
        // Aquí solo registramos los repositorios de este contexto.
        // El DbContext usualmente se registra en el Program.cs principal o en el Shared.
        builder.Services.AddScoped<ICognitiveAssessmentOrderRepository, CognitiveAssessmentOrderRepository>();

        builder.Services.AddScoped<ICognitiveAssessmentOrderCommandService, CognitiveAssessmentOrderCommandService>();
        
        return builder;
    }
}