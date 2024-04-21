using Definition.Entity.OpenId;
namespace Definition.Share.Models.ConfigDtos;
/// <summary>
/// 配置查询筛选
/// </summary>
/// <see cref="Definition.Entity.OpenId.Config"/>
public class ConfigFilterDto : FilterBase
{
    [MaxLength(100)]
    public string? Group { get; set; }
    [MaxLength(100)]
    public string? Key { get; set; }
    
}
