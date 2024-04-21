using System.ComponentModel;

namespace Definition.Entity;
/// <summary>
/// 授权类型
/// </summary>
[Flags]
public enum GrantType
{
    /// <summary>
    /// 授权码
    /// </summary>
    [Description("授权码")]
    AuthorizationCode = 1,
    /// <summary>
    /// 客户端凭证
    /// </summary>
    [Description("客户端凭证")]
    ClientCredentials = 1 << 1,
    /// <summary>
    /// 设备码
    /// </summary>
    [Description("设备码")]
    DeviceCode = 1 << 2,
    /// <summary>
    /// 隐式
    /// </summary>
    [Description("隐式")]
    Implicit = 1 << 3,
    /// <summary>
    /// 密码
    /// </summary>
    [Description("密码")]
    Password = 1 << 4,
    /// <summary>
    /// 刷新令牌
    /// </summary>
    [Description("刷新令牌")]
    RefreshToken = 1 << 5,
}
/// <summary>
/// 终结点
/// </summary>
[Flags]
public enum Endpoint
{
    /// <summary>
    /// 授权
    /// </summary>
    [Description("授权")]
    Authorization = 1,
    /// <summary>
    /// 设备
    /// </summary>
    [Description("设备")]
    Device = 1 << 1,
    /// <summary>
    /// 检查
    /// </summary>
    [Description("检查")]
    Introspection = 1 << 2,
    /// <summary>
    /// 注销
    /// </summary>
    [Description("注销")]
    Logout = 1 << 3,
    /// <summary>
    /// 撤销
    /// </summary>
    [Description("撤销")]
    Revocation = 1 << 4,
    /// <summary>
    /// 令牌
    /// </summary>
    [Description("令牌")]
    Token = 1 << 5
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
    /// 系统默认
    /// </summary>
    [Description("系统默认")]
    Systematic,
    /// <summary>
    /// 隐式同意
    /// </summary>
    [Description("隐式同意")]
    Implicit,
}

public enum ClientType
{
    /// <summary>
    /// 机密
    /// </summary>
    [Description("机密")]
    Confidential,

    /// <summary>
    /// 公开
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
    /// 成对
    /// </summary>
    [Description("成对")]
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
    /// 授权码
    /// </summary>
    [Description("授权码")]
    Code,

    /// <summary>
    /// 授权码和身份令牌
    /// </summary>
    [Description("授权码和身份令牌")]
    CodeIdToken,

    /// <summary>
    /// 授权码、身份令牌和访问令牌
    /// </summary>
    [Description("授权码、身份令牌和访问令牌")]
    CodeIdTokenToken,

    /// <summary>
    /// 授权码和访问令牌
    /// </summary>
    [Description("授权码和访问令牌")]
    CodeToken,

    /// <summary>
    /// 身份令牌
    /// </summary>
    [Description("身份令牌")]
    IdToken,

    /// <summary>
    /// 身份令牌和访问令牌
    /// </summary>
    [Description("身份令牌和访问令牌")]
    IdTokenToken,

    /// <summary>
    /// 无
    /// </summary>
    [Description("无")]
    None,

    /// <summary>
    /// 访问令牌
    /// </summary>
    [Description("访问令牌")]
    Token,
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

public enum ConfigValueType
{
    /// <summary>
    /// 数字
    /// </summary>
    [Description("数字")]
    Number,
    /// <summary>
    /// 字符串
    /// </summary>
    [Description("字符串")]
    String,
    /// <summary>
    /// 布尔值
    /// </summary>
    [Description("布尔值")]
    Boolean,
    /// <summary>
    /// 对象
    /// </summary>
    [Description("对象")]
    Object,
    /// <summary>
    /// 数组
    /// </summary>
    [Description("数组")]
    Array
}
