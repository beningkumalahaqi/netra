using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netra.Core.Entities;

namespace Netra.Infrastructure.Persistence.Configurations;

public class RouteConfiguration : IEntityTypeConfiguration<RouteEntity>
{
    public void Configure(EntityTypeBuilder<RouteEntity> builder)
    {
        builder.ToTable("routes");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedNever();
        builder.Property(r => r.Path).IsRequired().HasMaxLength(200);
        builder.Property(r => r.Method).IsRequired().HasMaxLength(10);
        builder.Property(r => r.Version).IsRequired();
        builder.Property(r => r.ConfigurationJson).IsRequired().HasColumnType("jsonb");
        builder.Property(r => r.IsActive).IsRequired();

        builder.HasOne(r => r.Project)
            .WithMany(p => p.Routes)
            .HasForeignKey(r => r.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(r => new { r.ProjectId, r.Path, r.Version }).IsUnique();
    }
}
