namespace Definition.Entity.OpenId;
/// <summary>
/// 服务器权限
/// </summary>
public class ServerPermission : IEntityBase
{
    /// <summary>
    /// 授权类型
    /// </summary>
    public GrantType GrantTypes { get; set; } =
        GrantType.AuthorizationCode |
        GrantType.ClientCredentials |
        GrantType.DeviceCode |
        GrantType.Implicit |
        GrantType.Password |
        GrantType.RefreshToken;

    /// <summary>
    /// 终结点
    /// </summary>
    public Endpoint Endpoints { get; set; } =
        Endpoint.Authorization |
        Endpoint.Introspection |
        Endpoint.Device |
        Endpoint.Logout |
        Endpoint.Revocation |
        Endpoint.Token;

    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }
}
