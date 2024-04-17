using Definition.Entity;

namespace Definition.Share.Models.SystemUserDtos;
/// <summary>
/// 用户账户列表元素
/// </summary>
/// <inheritdoc cref="SystemUser"/>
public class SystemUserItemDto
{
    /// <summary>
    /// 用户名
    /// </summary>
    [MaxLength(40)]
    public string UserName { get; set; } = default!;
    /// <summary>
    /// 邮箱
    /// </summary>
    [MaxLength(100)]
    public string? Email { get; set; }
    public bool EmailConfirmed { get; set; }
    // [MaxLength(100)]
    // public string PasswordHash { get; set; } = default!;
    // [MaxLength(60)]
    // public string PasswordSalt { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public DateTimeOffset? LockoutEnd { get; set; }
    public bool LockoutEnabled { get; set; }
    public int AccessFailedCount { get; set; }
    /// <summary>
    /// 最后登录时间
    /// </summary>
    public DateTimeOffset? LastLoginTime { get; set; }
    /// <summary>
    /// 密码重试次数
    /// </summary>
    public int RetryCount { get; set; }
    /// <summary>
    /// 头像url
    /// </summary>
    [MaxLength(200)]
    public string? Avatar { get; set; }

}
