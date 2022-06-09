using Token.Management.Application.Contracts.Module;

namespace Token.Management.Application.Contracts.AppServices.Users;

/// <summary>
/// 获取用户列表input
/// </summary>
public class UserInfoPagingInput:PageInput
{
    /// <summary>
    /// 状态
    /// </summary>
    public sbyte? Status { get; set; }
}
