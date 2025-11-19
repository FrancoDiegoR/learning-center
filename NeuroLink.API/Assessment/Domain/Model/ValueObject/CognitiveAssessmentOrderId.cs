namespace NeuroLink.API.Assessment.Domain.Model.ValueObject;

public record CognitiveAssessmentOrderId(Guid Value)
{ 
    public CognitiveAssessmentOrderId() : this(Guid.NewGuid()) { }
}
