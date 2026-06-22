using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netra.Core.Entities;

namespace Netra.Infrastructure.Persistence.Configurations;

public class ApiKeyConfiguration : IEntityTypeConfiguration<ApiKeyEntity>
{
    public void Configure(EntityTypeBuilder<ApiKeyEntity> builder)
    {
        builder.ToTable("api_keys");
        builder.HasKey(k => k.Id);
        builder.Property(k => k.Id).ValueGeneratedNever();
        builder.Property(k => k.KeyHash).IsRequired().HasMaxLength(256);
        builder.Property(k => k.Prefix).IsRequired().HasMaxLength(20);
        builder.Property(k => k.IsActive).IsRequired();

        builder.HasOne(k => k.Project)
            .WithMany(p => p.ApiKeys)
            .HasForeignKey(k => k.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(k => k.Prefix);
    }
}
