using Definition.Entity;

namespace Definition.Share.Models.SystemUserDtos;
/// <summary>
/// 用户账户查询筛选
/// </summary>
/// <inheritdoc cref="SystemUser"/>
public class SystemUserFilterDto : FilterBase
{
    /// <summary>
    /// 用户名
    /// </summary>
    [MaxLength(40)]
    public string? UserName { get; set; }
    /// <summary>
    /// 邮箱
    /// </summary>
    [MaxLength(100)]
    public string? Email { get; set; }
    public bool? EmailConfirmed { get; set; }
    public string? PhoneNumber { get; set; }
    public bool? PhoneNumberConfirmed { get; set; }

}
