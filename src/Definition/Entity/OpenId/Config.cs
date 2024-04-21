using System.Text.Json;

namespace Definition.Entity.OpenId;
/// <summary>
/// 配置
/// </summary>
public class Config : IEntityBase
{
    [MaxLength(100)]
    public string Group { get; set; } = Constants.Config.DefaultGroup;

    [MaxLength(100)]
    public string Key { get; set; } = null!;

    public JsonDocument Value { get; set; } = default!;

    public ConfigValueType ValueType { get; set; } = ConfigValueType.String;

    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }

    public Config() { }

    public Config(string key, string jsonStr)
    {
        Key = key;
        Value = JsonDocument.Parse(jsonStr);
    }

    public Config(string group, string key, string jsonStr)
    {
        Group = group;
        Key = key;
        Value = JsonDocument.Parse(jsonStr);
    }


    public static List<Config> DefaultPermissionConfigs()
    {
        var configs = new List<Config>();
        var grantType = JsonSerializer.Serialize(GrantType.AuthorizationCode |
            GrantType.ClientCredentials |
            GrantType.DeviceCode |
            GrantType.Implicit |
            GrantType.Password |
            GrantType.RefreshToken);
        configs.Add(new Config(Constants.Config.GrantType, grantType));
        var endpoint = JsonSerializer.Serialize(Endpoint.Authorization |
            Endpoint.Introspection |
            Endpoint.Device |
            Endpoint.Logout |
            Endpoint.Revocation |
            Endpoint.Token);
        configs.Add(new Config(Constants.Config.Endpoint, endpoint));
        return configs;
    }
}

