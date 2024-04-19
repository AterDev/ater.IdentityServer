using Definition.Entity.OpenId;
namespace Definition.Share.Models.ApplicationDtos;
/// <summary>
/// Application概要
/// </summary>
/// <see cref="Definition.Entity.OpenId.Application"/>
public class ApplicationShortDto
{
    /// <summary>
    /// Web/App/Client
    /// </summary>
    public ApplicationType ApplicationType { get; set; } = ApplicationType.Web;
    /// <summary>
    /// Secret
    /// </summary>
    [MaxLength(120)]
    public string? ClientSecret { get; set; }
    /// <summary>
    /// Confidential as default
    /// </summary>
    public ClientType ClientType { get; set; } = ClientType.Confidential;
    /// <summary>
    /// 同意书类型
    /// </summary>
    public ConsentType? ConsentType { get; set; }
    /// <summary>
    /// 名称
    /// </summary>
    [MaxLength(100)]
    public string DisplayName { get; set; } = default!;
    /// <summary>
    /// The permissions of application.
    /// </summary>
    public ICollection<string> Permissions { get; set; } = [];
    /// <summary>
    /// The post-logout redirect URIs of  application.
    /// </summary>
    public ICollection<string> PostLogoutRedirectUris { get; set; } = [];
    /// <summary>
    /// The properties of application.
    /// </summary>
    public ICollection<AdditionProperty> Properties { get; set; } = [];
    /// <summary>
    /// Gets the redirect URIs associated with the application.
    /// </summary>
    public ICollection<string> RedirectUris { get; set; } = [];
    /// <summary>
    /// The requirements of application.
    /// </summary>
    public ICollection<string> Requirements { get; set; } = [];
    /// <summary>
    /// The settings of  application.
    /// </summary>
    public Dictionary<string, string>? Settings { get; set; }
    
}
