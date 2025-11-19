using NeuroLink.API.Assessment.Domain.Model.ValueObject; // O ValueObjects, revisa tu namespace

namespace NeuroLink.API.Assessment.Domain.Model.Commands;

public record CreateCognitiveAssessmentOrderCommand(
    long PatientId, 
    int SessionCount, 
    DateTime RequestedAt, 
    CognitiveCriteria CognitiveCriteria
);