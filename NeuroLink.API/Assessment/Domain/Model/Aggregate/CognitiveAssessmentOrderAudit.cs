using System.ComponentModel.DataAnnotations.Schema;

namespace NeuroLink.API.Assessment.Domain.Model.Aggregate;

public partial class CognitiveAssessmentOrder
{
    [Column("created_at")] public DateTime CreatedAt { get; set; }
    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }
}