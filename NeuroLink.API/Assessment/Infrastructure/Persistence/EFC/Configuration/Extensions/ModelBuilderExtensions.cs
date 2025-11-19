using Microsoft.EntityFrameworkCore;

namespace NeuroLink.API.Assessment.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyAssessmentConfiguration(this ModelBuilder builder)
    {
        // Aquí registras todas las configuraciones de este Bounded Context
        builder.ApplyConfiguration(new CognitiveAssessmentOrderConfiguration());
    }
}