using System.ComponentModel;

namespace Token.Management.Domain.Shared;

/// <summary>
///     用户状态
/// </summary>
public enum StatusEnum
{
    /// <summary>
    ///     启用
    /// </summary>
    [Description("启用")] Enable,

    /// <summary>
    ///     禁用
    /// </summary>
    [Description("禁用")] Forbidden
}
