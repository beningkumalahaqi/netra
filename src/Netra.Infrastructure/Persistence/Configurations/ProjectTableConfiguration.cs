using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netra.Core.Entities;

namespace Netra.Infrastructure.Persistence.Configurations;

public class ProjectTableConfiguration : IEntityTypeConfiguration<ProjectTableEntity>
{
    public void Configure(EntityTypeBuilder<ProjectTableEntity> builder)
    {
        builder.ToTable("project_tables");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedNever();
        builder.Property(t => t.TableName).IsRequired().HasMaxLength(100);

        builder.HasOne(t => t.Schema)
            .WithMany(s => s.Tables)
            .HasForeignKey(t => t.SchemaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
