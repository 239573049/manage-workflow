using Management.Application.Services.Management;
using Microsoft.AspNetCore.Mvc;
using Token.HttpApi;
using Token.Management.Application.Contracts.Module.Management;

namespace Token.ManagementApi.Host.Controllers;

/// <summary>
/// 菜单模块
/// </summary>
public class MenuController : BaseController
{
    private readonly IRoleService _roleService;

    public MenuController(
        IRoleService roleService
    )
    {
        _roleService = roleService;
    }

    /// <summary>
    ///     获取当前用户菜单配置
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<MenuTreeDto>> GetUserMenuList()
    {
        return await _roleService.GetUserMenuList();
    }
}
