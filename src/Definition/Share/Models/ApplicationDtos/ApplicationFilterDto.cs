using Definition.Entity.OpenId;
namespace Definition.Share.Models.ApplicationDtos;
/// <summary>
/// Application查询筛选
/// </summary>
/// <see cref="Definition.Entity.OpenId.Application"/>
public class ApplicationFilterDto : FilterBase
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
    
}
