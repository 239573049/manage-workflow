using System.ComponentModel;

namespace Token.Management.Domain.Shared;

public enum SexEnum
{
    /// <summary>
    ///     未知
    /// </summary>
    [Description("未知")] None = 0,

    /// <summary>
    ///     男性
    /// </summary>
    [Description("男性")] Male,

    /// <summary>
    ///     女性
    /// </summary>
    [Description("女性")] Female
}
