using NeuroLink.API.Assessment.Domain.Model.ValueObject;

namespace NeuroLink.API.Assessment.Domain.Model.Aggregate;

    public partial class CognitiveAssessmentOrder
    {
        public CognitiveAssessmentOrder()
        {
            // Constructor vacío requerido por EF Core y para inicializar defaults
            AssessmentStatus = EAssessmentStatus.Pending;
        }

        /// <summary>
        ///     Constructor principal con reglas de negocio
        /// </summary>
        public CognitiveAssessmentOrder(PatientId patientId, int sessionCount, DateTime requestedAt, CognitiveCriteria criteria) : this()
        {
            // Validaciones usando los métodos del archivo de Behavior
            if (!IsValidSessionCount(sessionCount))
                throw new ArgumentException("Session count must be greater than zero");

            if (!IsValidRequestedDate(requestedAt))
                throw new ArgumentException("Requested date cannot be in the future");

            // Asignación de propiedades
            Id = new CognitiveAssessmentOrderId(); // Se autogenera el GUID
            PatientId = patientId;
            SessionCount = sessionCount;
            RequestedAt = requestedAt;
            CognitiveCriteria = criteria;
        
            // Auditoría inicial
            CreatedAt = DateTime.UtcNow;
        }

        // Propiedades Públicas (Getters)
        public CognitiveAssessmentOrderId Id { get; }
        public PatientId PatientId { get; private set; }
        public int SessionCount { get; private set; }
        public DateTime RequestedAt { get; private set; }
    
        // OwnsOne maneja esto, pero aquí exponemos el objeto
        public CognitiveCriteria CognitiveCriteria { get; private set; }
    }
