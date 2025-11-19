namespace NeuroLink.API.Assessment.Interfaces.REST.Resources;

public record CreateCognitiveAssessmentOrderResource(
    long PatientId,
    int SessionCount,
    DateTime RequestedAt,
    CognitiveCriteriaResource CognitiveCriteria
);