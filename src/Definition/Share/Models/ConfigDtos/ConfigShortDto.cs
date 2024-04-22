namespace Definition.Share.Models.ConfigDtos;
/// <summary>
/// 配置概要
/// </summary>
/// <see cref="Definition.Entity.OpenId.Config"/>
public class ConfigShortDto
{
    [MaxLength(100)]
    public string Group { get; set; } = Constants.Config.DefaultGroup;
    [MaxLength(100)]
    public string Key { get; set; } = default!;
    public string Value { get; set; } = default!;
    public ConfigValueType ValueType { get; set; } = ConfigValueType.String;

}
