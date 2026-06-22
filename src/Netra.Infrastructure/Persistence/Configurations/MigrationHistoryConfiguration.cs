using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netra.Core.Entities;

namespace Netra.Infrastructure.Persistence.Configurations;

public class MigrationHistoryConfiguration : IEntityTypeConfiguration<MigrationHistoryEntity>
{
    public void Configure(EntityTypeBuilder<MigrationHistoryEntity> builder)
    {
        builder.ToTable("migration_history");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedNever();
        builder.Property(m => m.Version).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Status).IsRequired().HasMaxLength(50);

        builder.HasOne(m => m.Project)
            .WithMany(p => p.MigrationHistories)
            .HasForeignKey(m => m.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
