namespace Netra.Core.Entities;

public class ApiKeyEntity : Entity<Guid>
{
    public Guid ProjectId { get; set; }
    public string KeyHash { get; set; } = string.Empty;
    public string Prefix { get; set; } = string.Empty;
    public DateTime? LastUsedAt { get; set; }
    public bool IsActive { get; set; } = true;

    public ProjectEntity? Project { get; set; }

    public ApiKeyEntity() : base(Guid.NewGuid()) { }
}
