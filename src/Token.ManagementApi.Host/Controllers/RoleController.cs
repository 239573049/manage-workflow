using Management.Application.Services.Management;
using Microsoft.AspNetCore.Mvc;
using Token.HttpApi;
using Token.Infrastructure;
using Token.Management.Application.Contracts.Module;
using Token.Management.Application.Contracts.Module.Management;
using Token.Management.Application.Contracts.Module.Users;
using Token.ManagementApi.Host.Module;

namespace Token.ManagementApi.Host.Controllers;

/// <summary>
///     角色模块
/// </summary>
public class RoleController : BaseController
{
    private readonly IRoleService _roleService;

    /// <inheritdoc/>
    public RoleController(
        IRoleService roleService
    )
    {
        _roleService = roleService;
    }

    /// <summary>
    /// 获取角色列表
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<RoleDto>> GetRoleMenuList(string? name)
    {
        List<RoleDto> data = await _roleService.GetRoleMenuList(name);
        return SerialNumberHelper.GetList(data, 1, data.Count());
    }

    /// <summary>
    ///     创建角色
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<RoleDto> CreateRole(RoleDto role)
    {
        return await _roleService.CreateRole(role);
    }

    /// <summary>
    ///     编辑角色
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<RoleDto> UpdateRole(RoleDto role)
    {
        return await _roleService.UpdateRole(role);
    }

    /// <summary>
    ///     删除角色
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<bool> DeleteRole(Guid id)
    {
        return await _roleService.DeleteRole(id);
    }

    /// <summary>
    ///     通过角色id获取当前角色下归属用户
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pageNo"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagingModelView<List<UserInfoDto>>> GetRoleUserInfo(Guid id, int pageNo = 1, int pageSize = 20)
    {
        (List<UserInfoDto>, int) data = await _roleService.GetRoleUserInfo(id, new PageInput()
        {
            PageNo = pageNo,
            PageSize = pageSize
        });
        return new PagingModelView<List<UserInfoDto>>(SerialNumberHelper.GetList(data.Item1, pageNo, pageSize),
            data.Item2);
    }

    /// <summary>
    ///     编辑角色序号
    /// </summary>
    /// <param name="roles"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<bool> UpdateRoleIndex(List<RoleDto> roles)
    {
        return await _roleService.UpdateRoleIndex(roles);
    }

    /// <summary>
    ///     获取角色不存在的用户
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="pageNo"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagingModelView<List<UserInfoDto>>> GetRoleUserInfoNotExit(Guid id, string? name, int pageNo = 1,
        int pageSize = 20)
    {
        (List<UserInfoDto>, int) data = await _roleService.GetRoleUserInfoNotExit(id, new PageInput()
        {
            Keyword = name,
            PageNo = pageNo,
            PageSize = pageSize
        });

        return new PagingModelView<List<UserInfoDto>>(SerialNumberHelper.GetList(data.Item1, pageNo, pageSize),
            data.Item2);
    }

    /// <summary>
    ///     添加|删除 用户至角色
    /// </summary>
    /// <param name="userIds"></param>
    /// <param name="roleId"></param>
    /// <param name="isAdd"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task CreateRoleUser(List<Guid> userIds, Guid roleId, bool isAdd = true)
    {
        await _roleService.CreateRoleUser(userIds, roleId, isAdd);
    }

    /// <summary>
    ///     获取菜单树形，角色权限已配置的为选中
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<Tuple<List<MenuTreeDto>, List<Guid>>> GetMenuTreeAll(Guid roleId)
    {
        (List<MenuTreeDto>, List<Guid>) data = await _roleService.GetMenuTreeAll(roleId);
        return new Tuple<List<MenuTreeDto>, List<Guid>>(data.Item1, data.Item2);
    }

    /// <summary>
    ///     创建角色菜单配置
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="roleId"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> CreateRoleMenu(List<Guid> ids, Guid roleId)
    {
        return await _roleService.CreateRoleMenu(ids, roleId);
    }
}
