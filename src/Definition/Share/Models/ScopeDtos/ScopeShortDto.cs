using Definition.Entity.OpenId;
namespace Definition.Share.Models.ScopeDtos;
/// <summary>
/// Scope概要
/// </summary>
/// <see cref="Definition.Entity.OpenId.Scope"/>
public class ScopeShortDto
{
    [MaxLength(500)]
    public string? Description { get; set; }
    [MaxLength(100)]
    public string? DisplayName { get; set; }
    [MaxLength(100)]
    public string? Name { get; set; }
    public ICollection<AdditionProperty> Properties { get; set; } = [];
    public ICollection<string> Resources { get; set; } = [];
    
}
