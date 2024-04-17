using Definition.Entity;

namespace Definition.Share.Models.SystemUserDtos;
/// <summary>
/// 用户账户更新时请求结构
/// </summary>
/// <inheritdoc cref="SystemUser"/>
public class SystemUserUpdateDto
{
    [MaxLength(60)]
    public string? Password { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    /// <summary>
    /// 头像url
    /// </summary>
    [MaxLength(200)]
    public string? Avatar { get; set; }

}
