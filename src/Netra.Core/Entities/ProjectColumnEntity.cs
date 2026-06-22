namespace Netra.Core.Entities;

public class ProjectColumnEntity : Entity<Guid>
{
    public Guid TableId { get; set; }
    public string ColumnName { get; set; } = string.Empty;
    public string DataType { get; set; } = "text";
    public bool Nullable { get; set; } = true;

    public ProjectTableEntity? Table { get; set; }

    public ProjectColumnEntity() : base(Guid.NewGuid()) { }
}
