namespace Netra.Core.Entities;

public class ProjectSchemaEntity : Entity<Guid>
{
    public Guid ProjectId { get; set; }
    public int Version { get; set; } = 1;

    public ICollection<ProjectTableEntity> Tables { get; set; } = new List<ProjectTableEntity>();

    public ProjectSchemaEntity() : base(Guid.NewGuid()) { }
}
