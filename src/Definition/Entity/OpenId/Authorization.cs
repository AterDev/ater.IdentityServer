using System.Security.Claims;

namespace Definition.Entity.OpenId;

/// <summary>
/// Authorizatio
/// </summary>
[Index(nameof(Status))]
public class Authorization : IEntityBase
{
    public Guid ApplicationId { get; set; } = default!;
    [ForeignKey(nameof(ApplicationId))]
    public Application Application { get; set; } = null!;

    [NotMapped]
    public ClaimsPrincipal? Principal { get; set; }

    /// <summary>
    /// Gets the additional properties associated with the authorization.
    /// </summary>
    public ICollection<AdditionProperty> Properties { get; set; } = [];

    /// <summary>
    /// Gets the scopes associated with the authorization.
    /// </summary>
    public ICollection<string> Scopes { get; } = [];

    public Status? Status { get; set; }

    public SubjectType? Subject { get; set; }

    public AuthorizationType? Type { get; set; }

    public ICollection<Token> Tokens { get; set; } = [];

    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }
}
