using NeuroLink.API.Assessment.Domain.Model.Aggregate;
using NeuroLink.API.Assessment.Interfaces.REST.Resources;

namespace NeuroLink.API.Assessment.Interfaces.REST.Transform;

public static class CognitiveAssessmentOrderResourceFromEntityAssembler
{
    public static CognitiveAssessmentOrderResource ToResourceFromEntity(CognitiveAssessmentOrder entity)
    {
        return new CognitiveAssessmentOrderResource(
            entity.Id.Value.ToString(),
            entity.PatientId.Value,
            entity.SessionCount,
            entity.AssessmentStatus.ToString(),
            entity.RequestedAt,
            new CognitiveCriteriaResource(
                entity.CognitiveCriteria.AttentionThreshold,
                entity.CognitiveCriteria.MemoryThreshold,
                entity.CognitiveCriteria.ProcessingSpeedThreshold
            )
        );
    }
}