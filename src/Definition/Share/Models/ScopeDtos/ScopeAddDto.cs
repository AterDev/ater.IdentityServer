using Definition.Entity.OpenId;
namespace Definition.Share.Models.ScopeDtos;
/// <summary>
/// Scope添加时请求结构
/// </summary>
/// <see cref="Definition.Entity.OpenId.Scope"/>
public class ScopeAddDto
{
    [MaxLength(500)]
    public string? Description { get; set; }
    [MaxLength(100)]
    public string? DisplayName { get; set; }
    [MaxLength(100)]
    public string? Name { get; set; }
    public ICollection<AdditionProperty> Properties { get; set; } = [];
    
}
