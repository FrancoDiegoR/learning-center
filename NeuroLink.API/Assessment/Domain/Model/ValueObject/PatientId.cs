namespace NeuroLink.API.Assessment.Domain.Model.ValueObject;

public record PatientId
{
    public long Value { get; }

    public PatientId(long value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("PatientId must be greater than zero");
        }
        Value = value;
    }
}