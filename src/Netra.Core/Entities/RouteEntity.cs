namespace Netra.Core.Entities;

public class RouteEntity : Entity<Guid>
{
    public Guid ProjectId { get; set; }
    public string Path { get; set; } = string.Empty;
    public string Method { get; set; } = "GET";
    public int Version { get; set; } = 1;
    public string ConfigurationJson { get; set; } = "{}";
    public bool IsActive { get; set; } = true;

    public ProjectEntity? Project { get; set; }

    public RouteEntity() : base(Guid.NewGuid()) { }
}
