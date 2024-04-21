using Definition.Entity.OpenId;
namespace Definition.Share.Models.ConfigDtos;
/// <summary>
/// 配置更新时请求结构
/// </summary>
/// <see cref="Definition.Entity.OpenId.Config"/>
public class ConfigUpdateDto
{
    [MaxLength(100)]
    public string? Group { get; set; }
    [MaxLength(100)]
    public string? Key { get; set; }
    public string? Value { get; set; }
    public ConfigValueType? ValueType { get; set; }
    
}
