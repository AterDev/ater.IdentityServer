using Definition.Entity;

namespace Definition.Share.Models.SystemUserDtos;
/// <summary>
/// 用户账户添加时请求结构
/// </summary>
/// <inheritdoc cref="SystemUser"/>
public class SystemUserAddDto
{
    /// <summary>
    /// 用户名
    /// </summary>
    [MaxLength(40)]
    public required string UserName { get; set; }
    public required string Password { get; set; }
    /// <summary>
    /// 邮箱
    /// </summary>
    [MaxLength(100)]
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    /// <summary>
    /// 头像url
    /// </summary>
    [MaxLength(200)]
    public string? Avatar { get; set; }

}
