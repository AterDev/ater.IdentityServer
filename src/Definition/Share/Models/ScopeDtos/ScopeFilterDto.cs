using Definition.Entity.OpenId;
namespace Definition.Share.Models.ScopeDtos;
/// <summary>
/// Scope查询筛选
/// </summary>
/// <see cref="Definition.Entity.OpenId.Scope"/>
public class ScopeFilterDto : FilterBase
{
    [MaxLength(500)]
    public string? Description { get; set; }
    [MaxLength(100)]
    public string? DisplayName { get; set; }
    [MaxLength(100)]
    public string? Name { get; set; }
    
}
