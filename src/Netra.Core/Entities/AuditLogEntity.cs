namespace Netra.Core.Entities;

public class AuditLogEntity : Entity<Guid>
{
    public Guid? ProjectId { get; set; }
    public Guid? ActorId { get; set; }
    public string Action { get; set; } = string.Empty;
    public string MetadataJson { get; set; } = "{}";

    public ProjectEntity? Project { get; set; }

    public AuditLogEntity() : base(Guid.NewGuid()) { }
}
