using Definition.Entity.OpenId;
namespace Definition.Share.Models.ApplicationDtos;
/// <summary>
/// Application列表元素
/// </summary>
/// <see cref="Definition.Entity.OpenId.Application"/>
public class ApplicationItemDto
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
    /// The settings of  application.
    /// </summary>
    public Dictionary<string, string>? Settings { get; set; }
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    
}
