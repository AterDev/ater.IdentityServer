using Definition.Entity.OpenId;
namespace Definition.Share.Models.ConfigDtos;
/// <summary>
/// 配置列表元素
/// </summary>
/// <see cref="Definition.Entity.OpenId.Config"/>
public class ConfigItemDto
{
    [MaxLength(100)]
    public string Group { get; set; } = Constants.Config.DefaultGroup;
    [MaxLength(100)]
    public string Key { get; set; } = default!;
    public string Value { get; set; } = default!;
    public ConfigValueType ValueType { get; set; } = ConfigValueType.String;
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    
}
