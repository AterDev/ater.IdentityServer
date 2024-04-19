namespace Definition.Entity.OpenId;

/// <summary>
/// Token
/// </summary>
[Index(nameof(Status))]
[Index(nameof(CreatedTime))]
[Index(nameof(ExpirationDate))]
public class Token : IEntityBase
{

    public Guid ApplicationId { get; set; } = default!;
    public Application Application { get; set; } = null!;

    public Guid AuthorizationId { get; set; }
    public Authorization Authorization { get; set; } = null!;

    /// <summary>
    /// 过期日期
    /// </summary>
    public DateTimeOffset? ExpirationDate { get; set; }

    /// <summary>
    /// payload
    /// </summary>
    [MaxLength(1000)]
    public string? Payload { get; set; }

    public ICollection<AdditionProperty> Properties { get; set; } = [];

    /// <summary>
    /// 赎回 
    /// </summary>
    public DateTimeOffset? RedemptionDate { get; set; }

    /// <summary>
    /// Gets or sets the reference identifier associated with the token.
    /// Note: depending on the application manager used when creating it,
    /// this property may be hashed or encrypted for security reasons.
    /// </summary>
    [MaxLength(1000)]
    public string? ReferenceId { get; set; }

    public Status? Status { get; set; }

    public SubjectType? Subject { get; set; }

    public TokenType Type { get; set; } = TokenType.Bearer;
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }
}
