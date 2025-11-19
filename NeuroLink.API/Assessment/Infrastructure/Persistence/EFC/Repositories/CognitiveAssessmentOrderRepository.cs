using Microsoft.EntityFrameworkCore;
using NeuroLink.API.Assessment.Domain.Model.Aggregate;
using NeuroLink.API.Assessment.Domain.Model.ValueObject;
using NeuroLink.API.Assessment.Domain.Repositories;
using NeuroLink.API.Shared.Infrastructure.Persistence.EFC.Configuration; 

namespace NeuroLink.API.Assessment.Infrastructure.Persistence.EFC.Repositories;

public class CognitiveAssessmentOrderRepository(AppDbContext context) : ICognitiveAssessmentOrderRepository
{
    public async Task AddAsync(CognitiveAssessmentOrder order)
    {
        await context.Set<CognitiveAssessmentOrder>().AddAsync(order);
        // Usualmente SaveChanges se llama aquí, o en una UnitOfWork superior. 
        // Para el examen, llamar SaveChangesAsync aquí asegura que se guarde.
        await context.SaveChangesAsync();
    }

    public async Task<CognitiveAssessmentOrder?> FindByIdAsync(CognitiveAssessmentOrderId id)
    {
        return await context.Set<CognitiveAssessmentOrder>()
            .FirstOrDefaultAsync(o => o.Id == id);
    }
}