namespace NeuroLink.API.Assessment.Domain.Model.ValueObject;

public record CognitiveCriteria
{
    // 1. Agrega 'private set' o 'init' para que EF Core pueda escribir el dato al leer de la BD
    public double AttentionThreshold { get; private set; }
    public double MemoryThreshold { get; private set; }
    public double ProcessingSpeedThreshold { get; private set; }

    // 2. Constructor VACÍO Protegido (La solución al error)
    // EF Core usará este constructor cuando lea de la base de datos, ignorando tu lógica de validación
    protected CognitiveCriteria() 
    { 
    }

    // Tu constructor público con validaciones (se usa cuando TÚ creas el objeto en el código)
    public CognitiveCriteria(double attention, double memory, double speed)
    {
        if (attention <= 0 || memory <= 0 || speed <= 0)
        {
            throw new ArgumentException("All cognitive criteria thresholds must be greater than zero");
        }

        AttentionThreshold = attention;
        MemoryThreshold = memory;
        ProcessingSpeedThreshold = speed;
    }
}