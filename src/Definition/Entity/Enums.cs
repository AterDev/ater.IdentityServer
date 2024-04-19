namespace Definition.Entity;
/// <summary>
/// 授权类型
/// </summary>
public enum GrantTypes
{
    AuthorizationCode,
    ClientCredentials,
    DeviceCode,
    Implicit,
    Password,
    RefreshToken,
}

/// <summary>
/// 知情同意
/// </summary>
public enum ConsentType
{
    /// <summary>
    /// 明确同意
    /// </summary>
    Explicit,
    /// <summary>
    /// Systematic
    /// </summary>
    Systematic,
    /// <summary>
    /// 隐式
    /// </summary>
    Implicit,

}

public enum ClientType
{
    /// <summary>
    /// Confidential
    /// </summary>
    Confidential,

    /// <summary>
    /// Public
    /// </summary>
    Public
}

public enum Status
{
    Inactive,
    Redeemed,
    Rejected,
    Revoked,
    Valid
}

public enum SubjectType
{
    Pairwise,
    Public
}

public enum ResponseType
{
    FormPost,
    Fragment,
    Query
}

public enum ResponseMode
{
    FormPost,
    Fragment,
    Query
}

public enum ApplicationType
{
    Web,
    App,
    Desktop,
    Browser
}
public enum AuthorizationType
{
    AdHoc,
    Permanent
}

public enum TokenType
{
    Bearer
}