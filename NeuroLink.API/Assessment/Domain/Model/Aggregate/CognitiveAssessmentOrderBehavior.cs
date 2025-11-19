using NeuroLink.API.Assessment.Domain.Model.ValueObject;

namespace NeuroLink.API.Assessment.Domain.Model.Aggregate;

public partial class CognitiveAssessmentOrder
{
    public EAssessmentStatus AssessmentStatus { get; protected set; }

    /// <summary>
    /// Valida si la cantidad de sesiones es válida (Mayor a cero)
    /// </summary>
    private bool IsValidSessionCount(int count)
    {
        return count > 0;
    }

    /// <summary>
    /// Valida que la fecha solicitada no sea futura
    /// </summary>
    private bool IsValidRequestedDate(DateTime date)
    {
        return date <= DateTime.UtcNow;
    }

    // Ejemplo de método de negocio (como tu SendToEdit)
    public void Complete()
    {
        AssessmentStatus = EAssessmentStatus.Finalized;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Cancel()
    {
        AssessmentStatus = EAssessmentStatus.Cancelled;
        UpdatedAt = DateTime.UtcNow;
    }
}