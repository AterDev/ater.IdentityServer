namespace Definition.Share.Models.ApplicationDtos;
/// <summary>
/// 应用添加模型
/// </summary>
public class ApplicationAddDto
{
    /// <summary>
    /// 应用类型
    /// </summary>
    public string? ApplicationType { get; set; }
    public required string ClientId { get; set; }
    public string? ClientSecret { get; set; }

    /// <summary>
    /// 是否机密
    /// </summary>
    public bool IsConfidential { get; set; }

    /// <summary>
    /// 知情同意类型
    /// </summary>
    public ConsentType ConsentType { get; set; }
    public required string DisplayName { get; set; }

    /// <summary>
    /// 权限
    /// </summary>
    public List<string> Permissions { get; set; } = [];

    /// <summary>
    /// 退出后的重定向地址
    /// </summary>
    public List<string> PostLogoutRedirectUris { get; set; } = [];

    /// <summary>
    /// 重定向地址
    /// </summary>
    public List<string> RedirectUris { get; set; } = [];
    public List<string> Roles { get; set; } = [];
    public List<string> Scopes { get; set; } = [];
    public bool AllowIntrospectionEndpoint { get; set; }
    public bool AllowRevocationEndpoint { get; set; }
    public bool RequireProofKeyForCodeExchange { get; set; }
    public bool AllowHybridFlow { get; set; }
    public bool AllowLogoutEndpoint { get; set; }
    public bool AllowAuthorizationCodeFlow { get; set; }
    public bool AllowClientCredentialsFlow { get; set; }
    public bool AllowImplicitFlow { get; set; }
    public bool AllowPasswordFlow { get; set; }
    public bool AllowRefreshTokenFlow { get; set; }
}

/// <summary>
/// 同意方式
/// </summary>
public enum ConsentType
{
    /// <summary>
    /// 自动
    /// </summary>
    Systematic,
    /// <summary>
    /// 明确的
    /// </summary>
    Explicit,
    /// <summary>
    /// 隐式的
    /// </summary>
    Implicit
}
