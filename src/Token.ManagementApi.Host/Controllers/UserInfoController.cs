using Microsoft.AspNetCore.Mvc;
using Token.HttpApi;
using Token.Infrastructure;
using Token.Management.Application.Contracts.AppServices.Users;
using Token.Management.Application.Contracts.Module;
using Token.Management.Application.Contracts.Module.Users;
using Token.ManagementApi.Host.Module;

namespace Token.ManagementApi.Host.Controllers;

/// <summary>
/// 用户模块
/// </summary>
public class UserInfoController : BaseController
{
    private readonly IUserInfoService _userInfoService;

    /// <inheritdoc />
    public UserInfoController(
        IUserInfoService userInfoService
    )
    {
        _userInfoService = userInfoService;
    }

    /// <summary>
    /// 获取用户账号分页
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagingModelView<List<UserInfoDto>>> GetUserInfoPaging([FromQuery]UserInfoPagingInput input)
    {
        var data = await _userInfoService.GetUserInfoPaging(input);
        return new PagingModelView<List<UserInfoDto>>(SerialNumberHelper.GetList(data.Item1,input.PageNo,input.PageSize),
            data.Item2);
    }

    /// <summary>
    ///     编辑用户
    /// </summary>
    /// <param name="userInfo"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<UserInfoDto> UpdateUserInfo(UserInfoDto userInfo)
    {
        return await _userInfoService.UpdateUserInfo(userInfo);
    }

    /// <summary>
    ///     删除用户
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task DeleteUserInfo(Guid userId)
    {
        await _userInfoService.DeleteUserInfoAsync(userId);
    }

    /// <summary>
    ///     添加账号
    /// </summary>
    /// <param name="userInfo"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<UserInfoDto> CreateUserInfo(UserInfoDto userInfo)
    {
        return await _userInfoService.CreateUserInfo(userInfo);
    }
}
