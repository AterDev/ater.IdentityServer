namespace Definition.Entity.OpenId;

/// <summary>
/// Application
/// </summary>
[Index(nameof(ClientId))]
[Index(nameof(ApplicationType))]
[Index(nameof(DisplayName))]
public class Application : IEntityBase
{
    /// <summary>
    /// Web/App/Client
    /// </summary>
    public ApplicationType ApplicationType { get; set; } = ApplicationType.Web;

    /// <summary>
    /// ClientId
    /// </summary>
    [MaxLength(100)]
    public required string ClientId { get; set; }

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
    public required string DisplayName { get; set; }

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

    public ICollection<Authorization> Authorizations { get; set; } = [];

    public ICollection<Token> Tokens { get; set; } = [];

    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }
}

