using Microsoft.AspNetCore.Mvc;
using Token.HttpApi;
using Token.Management.Application.Contracts.AppServices.Users;
using Token.Management.Application.Contracts.Module.Users;
using ILogger = Serilog.ILogger;

namespace Token.ManagementApi.Host.Controllers;

/// <summary>
///     登录模块
/// </summary>
public class LoginController : BaseController
{
    private readonly IPrincipalAccessor _principalAccessor;
    private readonly ILogger _logger;
    private readonly IUserInfoService _userInfoService;

    /// <inheritdoc />
    public LoginController(
        IUserInfoService userInfoService,
        ILogger logger, IPrincipalAccessor principalAccessor)
    {
        _userInfoService = userInfoService;
        _logger = logger;
        _principalAccessor = principalAccessor;
    }

    /// <summary>
    ///     账号登录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Login(LoginInput input)
    {
        var userInfo = await _userInfoService.GetUserInfo(input);

        return new OkObjectResult(new { token=userInfo.Item2, userInfo=userInfo.Item1 });
    }

    /// <summary>
    /// 获取当前账户信息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<UserInfoDto> GetUserInfo()
    {
        var data = _principalAccessor.GetUserInfo<UserInfoDto>();

        return await Task.FromResult(data);
    }
}
