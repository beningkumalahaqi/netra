namespace Netra.Core.Entities;

public class ProjectEntity : Entity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending";
    public string? DbConnectionString { get; set; }

    public ICollection<ApiKeyEntity> ApiKeys { get; set; } = new List<ApiKeyEntity>();
    public ICollection<RouteEntity> Routes { get; set; } = new List<RouteEntity>();
    public ICollection<MigrationHistoryEntity> MigrationHistories { get; set; } = new List<MigrationHistoryEntity>();
    public ICollection<AuditLogEntity> AuditLogs { get; set; } = new List<AuditLogEntity>();

    public ProjectEntity() : base(Guid.NewGuid()) { }

    public ProjectEntity(string name)
        : base(Guid.NewGuid())
    {
        Name = name;
        Status = "Pending";
    }
}
