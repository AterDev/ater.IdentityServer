using Definition.Entity.OpenId;
namespace Definition.Share.Models.ApplicationDtos;
/// <summary>
/// Application更新时请求结构
/// </summary>
/// <see cref="Definition.Entity.OpenId.Application"/>
public class ApplicationUpdateDto
{
    /// <summary>
    /// Web/App/Client
    /// </summary>
    public ApplicationType? ApplicationType { get; set; }
    /// <summary>
    /// ClientId
    /// </summary>
    [MaxLength(100)]
    public string? ClientId { get; set; }
    /// <summary>
    /// Secret
    /// </summary>
    [MaxLength(120)]
    public string? ClientSecret { get; set; }
    /// <summary>
    /// Confidential as default
    /// </summary>
    public ClientType? ClientType { get; set; }
    /// <summary>
    /// 同意书类型
    /// </summary>
    public ConsentType? ConsentType { get; set; }
    /// <summary>
    /// 名称
    /// </summary>
    [MaxLength(100)]
    public string? DisplayName { get; set; }
    /// <summary>
    /// The permissions of application.
    /// </summary>
    public ICollection<string>? Permissions { get; set; }
    /// <summary>
    /// The post-logout redirect URIs of  application.
    /// </summary>
    public ICollection<string>? PostLogoutRedirectUris { get; set; }

    /// <summary>
    /// Gets the redirect URIs associated with the application.
    /// </summary>
    public ICollection<string>? RedirectUris { get; set; }
}
