namespace Netra.Core.Entities;

public class ProjectTableEntity : Entity<Guid>
{
    public Guid SchemaId { get; set; }
    public string TableName { get; set; } = string.Empty;

    public ProjectSchemaEntity? Schema { get; set; }
    public ICollection<ProjectColumnEntity> Columns { get; set; } = new List<ProjectColumnEntity>();

    public ProjectTableEntity() : base(Guid.NewGuid()) { }
}
