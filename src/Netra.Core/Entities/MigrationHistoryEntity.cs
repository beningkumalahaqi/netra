using Netra.Core.Enums;

namespace Netra.Core.Entities;

public class MigrationHistoryEntity : Entity<Guid>
{
    public Guid ProjectId { get; set; }
    public string Version { get; set; } = string.Empty;
    public string Status { get; set; } = MigrationStatus.Pending.ToString();
    public DateTime? AppliedAt { get; set; }

    public ProjectEntity? Project { get; set; }

    public MigrationHistoryEntity() : base(Guid.NewGuid()) { }
}
