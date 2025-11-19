namespace NeuroLink.API.Assessment.Interfaces.REST.Resources;

public record CognitiveAssessmentOrderResource(
    string Id,
    long PatientId,
    int SessionCount,
    string AssessmentStatus,
    DateTime RequestedAt,
    CognitiveCriteriaResource CognitiveCriteria
);