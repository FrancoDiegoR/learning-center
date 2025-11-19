using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using NeuroLink.API.Assessment.Application.Internal.CommandServices;
using NeuroLink.API.Assessment.Interfaces.REST.Resources;
using NeuroLink.API.Assessment.Interfaces.REST.Transform;

namespace NeuroLink.API.Assessment.Interfaces.REST;

[ApiController]
[Route("api/v1/cognitive-assessments")] 
[Produces(MediaTypeNames.Application.Json)]
public class CognitiveAssessmentOrdersController(
    ICognitiveAssessmentOrderCommandService commandService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(201)] 
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> CreateCognitiveAssessmentOrder(
        [FromBody] CreateCognitiveAssessmentOrderResource resource)
    {
        // 1. Validar el modelo
        if (!ModelState.IsValid) return BadRequest(ModelState);

        // 2. Transformar Resource (JSON) -> Command (Dominio)
        var command = CreateCognitiveAssessmentOrderCommandFromResourceAssembler
            .ToCommandFromResource(resource);

        // 3. Ejecutar la lógica de negocio (Application Service)
        var cognitiveAssessmentOrder = await commandService.Handle(command);

        // 4. Transformar Entidad -> Resource (Respuesta JSON)
        var responseResource = CognitiveAssessmentOrderResourceFromEntityAssembler
            .ToResourceFromEntity(cognitiveAssessmentOrder);

        // 5. Retornar 201 Created con el recurso creado en el cuerpo
        return CreatedAtAction(
            nameof(CreateCognitiveAssessmentOrder), 
            new { id = responseResource.Id }, 
            responseResource);
    }
}