using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netra.Core.Entities;

namespace Netra.Infrastructure.Persistence.Configurations;

public class ProjectColumnConfiguration : IEntityTypeConfiguration<ProjectColumnEntity>
{
    public void Configure(EntityTypeBuilder<ProjectColumnEntity> builder)
    {
        builder.ToTable("project_columns");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();
        builder.Property(c => c.ColumnName).IsRequired().HasMaxLength(100);
        builder.Property(c => c.DataType).IsRequired().HasMaxLength(50);

        builder.HasOne(c => c.Table)
            .WithMany(t => t.Columns)
            .HasForeignKey(c => c.TableId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
