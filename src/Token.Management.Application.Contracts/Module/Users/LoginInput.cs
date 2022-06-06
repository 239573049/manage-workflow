namespace Token.Management.Application.Contracts.Module.Users;

/// <summary>
/// 登录模型
/// </summary>
public class LoginInput
{
    /// <summary>
    ///     账号
    /// </summary>
    public string? AccountNumber { get; set; }

    /// <summary>
    ///     密码
    /// </summary>
    public string? Password { get; set; }
}
