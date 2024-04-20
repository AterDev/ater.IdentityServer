using System.ComponentModel;

namespace Definition.Entity;
/// <summary>
/// 授权类型
/// </summary>
public enum GrantTypes
{
    /// <summary>
    /// 授权码
    /// </summary>
    [Description("授权码")]
    AuthorizationCode,
    /// <summary>
    /// 客户端凭证
    /// </summary>
    [Description("客户端凭证")]
    ClientCredentials,
    /// <summary>
    /// 设备码
    /// </summary>
    [Description("设备码")]
    DeviceCode,
    /// <summary>
    /// 隐式
    /// </summary>
    [Description("隐式")]
    Implicit,
    /// <summary>
    /// 密码
    /// </summary>
    [Description("密码")]
    Password,
    /// <summary>
    /// 刷新令牌
    /// </summary>
    [Description("刷新令牌")]
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
    [Description("明确同意")]
    Explicit,
    /// <summary>
    /// Systematic
    /// </summary>
    [Description("系统默认")]
    Systematic,
    /// <summary>
    /// 隐式
    /// </summary>
    [Description("隐式同意")]
    Implicit,
}

public enum ClientType
{
    /// <summary>
    /// Confidential
    /// </summary>
    [Description("机密")]
    Confidential,

    /// <summary>
    /// Public
    /// </summary>
    [Description("公开")]
    Public
}

public enum Status
{
    /// <summary>
    /// 未激活
    /// </summary>
    [Description("未激活")]
    Inactive,
    /// <summary>
    /// 已兑换
    /// </summary>
    [Description("已兑换")]
    Redeemed,
    /// <summary>
    /// 已拒绝
    /// </summary>
    [Description("已拒绝")]
    Rejected,
    /// <summary>
    /// 已撤销
    /// </summary>
    [Description("已撤销")]
    Revoked,
    /// <summary>
    /// 有效
    /// </summary>
    [Description("有效")]
    Valid
}

public enum SubjectType
{
    /// <summary>
    /// 一对一
    /// </summary>
    [Description("一对一")]
    Pairwise,
    /// <summary>
    /// 公开
    /// </summary>
    [Description("公开")]
    Public
}

public enum ResponseType
{
    /// <summary>
    /// 表单提交
    /// </summary>
    [Description("表单提交")]
    FormPost,
    /// <summary>
    /// 片段
    /// </summary>
    [Description("片段")]
    Fragment,
    /// <summary>
    /// 查询
    /// </summary>
    [Description("查询")]
    Query
}

public enum ResponseMode
{
    /// <summary>
    /// 表单提交
    /// </summary>
    [Description("表单提交")]
    FormPost,
    /// <summary>
    /// 片段
    /// </summary>
    [Description("片段")]
    Fragment,
    /// <summary>
    /// 查询
    /// </summary>
    [Description("查询")]
    Query
}

public enum ApplicationType
{
    /// <summary>
    /// Web
    /// </summary>
    [Description("Web")]
    Web,
    /// <summary>
    /// App
    /// </summary>
    [Description("App")]
    App,
    /// <summary>
    /// 桌面
    /// </summary>
    [Description("桌面")]
    Desktop,
    /// <summary>
    /// 浏览器
    /// </summary>
    [Description("浏览器")]
    Browser
}
public enum AuthorizationType
{
    /// <summary>
    /// 临时
    /// </summary>
    [Description("临时")]
    AdHoc,
    /// <summary>
    /// 永久
    /// </summary>
    [Description("永久")]
    Permanent
}

public enum TokenType
{
    /// <summary>
    /// Bearer
    /// </summary>
    [Description("Bearer")]
    Bearer
}
