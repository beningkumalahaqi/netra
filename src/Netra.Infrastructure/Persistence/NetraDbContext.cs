using Microsoft.EntityFrameworkCore;
using Netra.Core.Entities;
using Netra.Infrastructure.Persistence.Configurations;

namespace Netra.Infrastructure.Persistence;

public class NetraDbContext : DbContext
{
    public DbSet<ProjectEntity> Projects => Set<ProjectEntity>();
    public DbSet<ApiKeyEntity> ApiKeys => Set<ApiKeyEntity>();
    public DbSet<RouteEntity> Routes => Set<RouteEntity>();
    public DbSet<MigrationHistoryEntity> MigrationHistories => Set<MigrationHistoryEntity>();
    public DbSet<AuditLogEntity> AuditLogs => Set<AuditLogEntity>();
    public DbSet<ProjectSchemaEntity> ProjectSchemas => Set<ProjectSchemaEntity>();
    public DbSet<ProjectTableEntity> ProjectTables => Set<ProjectTableEntity>();
    public DbSet<ProjectColumnEntity> ProjectColumns => Set<ProjectColumnEntity>();

    public NetraDbContext(DbContextOptions<NetraDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new ApiKeyConfiguration());
        modelBuilder.ApplyConfiguration(new RouteConfiguration());
        modelBuilder.ApplyConfiguration(new MigrationHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new AuditLogConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectSchemaConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectTableConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectColumnConfiguration());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        foreach (var entry in ChangeTracker.Entries<Entity<Guid>>())
        {
            if (entry.State == EntityState.Modified)
                entry.Entity.UpdatedAt = DateTime.UtcNow;
        }

        return await base.SaveChangesAsync(ct);
    }
}
