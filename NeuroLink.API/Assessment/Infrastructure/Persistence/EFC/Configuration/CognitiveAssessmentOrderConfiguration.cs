using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeuroLink.API.Assessment.Domain.Model.Aggregate;

namespace NeuroLink.API.Assessment.Infrastructure.Persistence.EFC.Configuration;

public class CognitiveAssessmentOrderConfiguration : IEntityTypeConfiguration<CognitiveAssessmentOrder>
{
    public void Configure(EntityTypeBuilder<CognitiveAssessmentOrder> builder)
    {
        builder.ToTable("cognitive_assessment_orders");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .HasConversion(
                id => id.Value, 
                value => new Domain.Model.ValueObject.CognitiveAssessmentOrderId(value) 
            )
            .HasColumnName("id")
            .IsRequired();

        builder.Property(t => t.PatientId)
            .HasConversion(v => v.Value, v => new Domain.Model.ValueObject.PatientId(v))
            .HasColumnName("patient_id")
            .IsRequired();

        // --- AQUÍ ESTÁ EL CAMBIO ---
        builder.OwnsOne(t => t.CognitiveCriteria, criteria =>
        {
            // SOLUCIÓN: Le decimos a EF que este objeto usa la misma llave "Id" que el dueño
            criteria.WithOwner().HasForeignKey("Id"); 

            criteria.Property(c => c.AttentionThreshold).HasColumnName("attention_threshold").IsRequired();
            criteria.Property(c => c.MemoryThreshold).HasColumnName("memory_threshold").IsRequired();
            criteria.Property(c => c.ProcessingSpeedThreshold).HasColumnName("processing_speed_threshold").IsRequired();
        });
        // ---------------------------

        builder.Property(t => t.SessionCount).HasColumnName("session_count").IsRequired();
        builder.Property(t => t.RequestedAt).HasColumnName("requested_at").IsRequired();
        builder.Property(t => t.AssessmentStatus).HasColumnName("assessment_status").HasConversion<string>().IsRequired();

        builder.Property(t => t.CreatedAt).HasColumnName("created_at");
        builder.Property(t => t.UpdatedAt).HasColumnName("updated_at");
    }
}