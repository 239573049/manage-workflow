using Token.Management.Application.Contracts.Module;
using Token.Management.Application.Contracts.Module.Management;
using Token.Management.Application.Contracts.Module.Users;

namespace Token.Management.Application.Contracts.AppServices.Users;

/// <summary>
/// 用户接口
/// </summary>
public interface IUserInfoService
{
    /// <summary>
    ///     通过账号密码获取账号信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<(UserInfoDto, string)> GetUserInfo(LoginInput input);

    /// <summary>
    /// 用户分页数据
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<Tuple<List<UserInfoDto>, int>> GetUserInfoPaging(UserInfoPagingInput input);

    /// <summary>
    ///     获取账号下所有部门
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<List<DepartmentDto>> GetUserInfoDepartmentList(Guid userId);

    /// <summary>
    ///     编辑用户信息
    /// </summary>
    /// <param name="userInfo"></param>
    /// <returns></returns>
    Task<UserInfoDto> UpdateUserInfo(UserInfoDto userInfo);

    /// <summary>
    ///     删除用户
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task DeleteUserInfoAsync(Guid userId);

    /// <summary>
    ///     创建账号
    /// </summary>
    /// <param name="userInfo"></param>
    /// <returns></returns>
    Task<UserInfoDto> CreateUserInfo(UserInfoDto userInfo);
}
