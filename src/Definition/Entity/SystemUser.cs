﻿using System.Text.Json.Serialization;

namespace Definition.Entity;
/// <summary>
/// SystemUser
/// </summary>
[Index(nameof(UserName), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
[Index(nameof(PhoneNumber), IsUnique = true)]
[Index(nameof(CreatedTime))]
[Index(nameof(IsDeleted))]
public class SystemUser : IEntityBase
{
    /// <summary>
    /// 用户名
    /// </summary>
    [Length(2, 40)]
    public required string UserName { get; set; }
    /// <summary>
    /// 邮箱
    /// </summary>
    [Length(5, 100)]
    [EmailAddress]
    public string? Email { get; set; } = null!;
    public bool EmailConfirmed { get; set; }
    [JsonIgnore]
    [MaxLength(100)]
    public string PasswordHash { get; set; } = default!;
    [JsonIgnore]
    [MaxLength(60)]
    public string PasswordSalt { get; set; } = default!;
    [Phone]
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
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }

    #region 用户关联内容

    #endregion
}
