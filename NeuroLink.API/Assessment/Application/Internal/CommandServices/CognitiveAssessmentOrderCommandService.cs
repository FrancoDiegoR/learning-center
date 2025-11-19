using NeuroLink.API.Assessment.Domain.Model.Aggregate;
using NeuroLink.API.Assessment.Domain.Model.Commands;
using NeuroLink.API.Assessment.Domain.Model.ValueObject;
using NeuroLink.API.Assessment.Domain.Repositories;
using NeuroLink.API.Assessment.Application.Internal.CommandServices; // Namespace propio

namespace NeuroLink.API.Assessment.Application.Internal.CommandServices;

// Interfaz del servicio (puedes ponerla en un archivo aparte o aquí mismo por brevedad)
public interface ICognitiveAssessmentOrderCommandService
{
    Task<CognitiveAssessmentOrder> Handle(CreateCognitiveAssessmentOrderCommand command);
}

public class CognitiveAssessmentOrderCommandService(ICognitiveAssessmentOrderRepository repository) 
    : ICognitiveAssessmentOrderCommandService
{
    public async Task<CognitiveAssessmentOrder> Handle(CreateCognitiveAssessmentOrderCommand command)
    {
        // 1. Convertir el Command a Value Objects (si es necesario)
        var patientId = new PatientId(command.PatientId);
        
        // 2. Crear la Entidad
        var order = new CognitiveAssessmentOrder(
            patientId,
            command.SessionCount,
            command.RequestedAt,
            command.CognitiveCriteria // Ya viene como ValueObject desde el Assembler
        );

        // 3. Guardar en Base de Datos
        await repository.AddAsync(order);
        
        // 4. Retornar la entidad creada (con su ID autogenerado)
        return order;
    }
}