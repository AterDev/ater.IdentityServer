namespace Definition.Entity.OpenId;

/// <summary>
/// Scope
/// </summary>
[Index(nameof(Name))]
public class Scope : IEntityBase
{
    [MaxLength(500)]
    public string? Description { get; set; }

    [MaxLength(100)]
    public string? DisplayName { get; set; }

    [MaxLength(100)]
    public string? Name { get; set; }

    public ICollection<AdditionProperty> Properties { get; set; } = [];

    public ICollection<string> Resources { get; } = [];

    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }
}
