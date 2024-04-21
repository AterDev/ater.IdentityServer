using Definition.Entity.OpenId;
namespace Definition.Share.Models.ConfigDtos;
/// <summary>
/// 配置添加时请求结构
/// </summary>
/// <see cref="Definition.Entity.OpenId.Config"/>
public class ConfigAddDto
{
    [MaxLength(100)]
    public string Group { get; set; } = Constants.Config.DefaultGroup;
    [MaxLength(100)]
    public required string Key { get; set; } = null!;
    public required string Value { get; set; } = default!;
    public ConfigValueType ValueType { get; set; } = ConfigValueType.String;
    
}
