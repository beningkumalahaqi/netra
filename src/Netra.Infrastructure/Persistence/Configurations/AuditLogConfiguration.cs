using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netra.Core.Entities;

namespace Netra.Infrastructure.Persistence.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLogEntity>
{
    public void Configure(EntityTypeBuilder<AuditLogEntity> builder)
    {
        builder.ToTable("audit_logs");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedNever();
        builder.Property(a => a.Action).IsRequired().HasMaxLength(200);
        builder.Property(a => a.MetadataJson).HasColumnType("jsonb");
        builder.Property(a => a.CreatedAt).IsRequired();

        builder.HasOne(a => a.Project)
            .WithMany(p => p.AuditLogs)
            .HasForeignKey(a => a.ProjectId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(a => a.ProjectId);
        builder.HasIndex(a => a.CreatedAt);
    }
}
