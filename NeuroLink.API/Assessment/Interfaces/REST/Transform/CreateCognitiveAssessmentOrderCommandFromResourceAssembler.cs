using NeuroLink.API.Assessment.Domain.Model.Commands;
using NeuroLink.API.Assessment.Domain.Model.ValueObject;
using NeuroLink.API.Assessment.Interfaces.REST.Resources;

namespace NeuroLink.API.Assessment.Interfaces.REST.Transform;

public static class CreateCognitiveAssessmentOrderCommandFromResourceAssembler
{
    public static CreateCognitiveAssessmentOrderCommand ToCommandFromResource(CreateCognitiveAssessmentOrderResource resource)
    {
        return new CreateCognitiveAssessmentOrderCommand(
            resource.PatientId,
            resource.SessionCount,
            resource.RequestedAt,
            new CognitiveCriteria(
                resource.CognitiveCriteria.AttentionThreshold,
                resource.CognitiveCriteria.MemoryThreshold,
                resource.CognitiveCriteria.ProcessingSpeedThreshold
            )
        );
    }
}