using NeuroLink.API.Assessment.Domain.Model.Aggregate;
using NeuroLink.API.Assessment.Domain.Model.ValueObject;

namespace NeuroLink.API.Assessment.Domain.Repositories
{
    public interface ICognitiveAssessmentOrderRepository
    {
        // Método para guardar la orden (Necesario para el POST que pide el examen)
        Task AddAsync(CognitiveAssessmentOrder order);

        // Método para buscar por ID (Útil para validaciones o consultas futuras)
        Task<CognitiveAssessmentOrder?> FindByIdAsync(CognitiveAssessmentOrderId id);
        
        // Opcional: Método para buscar por PatientId si fuera necesario
        // Task<IEnumerable<CognitiveAssessmentOrder>> FindByPatientIdAsync(PatientId patientId);
    }
}