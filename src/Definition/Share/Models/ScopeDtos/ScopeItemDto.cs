using Definition.Entity.OpenId;
namespace Definition.Share.Models.ScopeDtos;
/// <summary>
/// Scope列表元素
/// </summary>
/// <see cref="Definition.Entity.OpenId.Scope"/>
public class ScopeItemDto
{
    [MaxLength(500)]
    public string? Description { get; set; }
    [MaxLength(100)]
    public string? DisplayName { get; set; }
    [MaxLength(100)]
    public string? Name { get; set; }
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    
}
