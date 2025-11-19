namespace NeuroLink.API.Assessment.Interfaces.REST.Resources;

public record CognitiveCriteriaResource(
    double AttentionThreshold, 
    double MemoryThreshold, 
    double ProcessingSpeedThreshold
);