using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netra.Core.Entities;

namespace Netra.Infrastructure.Persistence.Configurations;

public class ProjectSchemaConfiguration : IEntityTypeConfiguration<ProjectSchemaEntity>
{
    public void Configure(EntityTypeBuilder<ProjectSchemaEntity> builder)
    {
        builder.ToTable("project_schemas");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedNever();
        builder.Property(s => s.Version).IsRequired();
    }
}
