using Token.Management.Application.Contracts.Module;
using Token.Management.Application.Contracts.Module.Management;
using Token.Management.Application.Contracts.Module.Users;
using Token.Management.Domain.Management;
using Token.Management.Domain.Management.AccessFunction;

namespace Management.Application.Services.Management;

public interface IRoleService
{
    /// <summary>
    ///     获取当前用户菜单列表
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<List<MenuTreeDto>> GetUserMenuList();

    /// <summary>
    ///     递归菜单树形结构
    /// </summary>
    /// <param name="roles"></param>
    /// <param name="menuIds"></param>
    /// <param name="parentId"></param>
    /// <returns></returns>
    Task<List<MenuTreeDto>> RecursionUserMenu(List<Menu> roles, List<Guid> menuIds, Guid parentId);

    /// <summary>
    ///     获取角色分页数据
    /// </summary>
    /// <param name="name"></param>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <param name="pageNo"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    Task<List<RoleDto>> GetRoleMenuList(string? name);

    /// <summary>
    ///     创建角色
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    Task<RoleDto> CreateRole(RoleDto role);

    /// <summary>
    ///     编辑角色
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    Task<RoleDto> UpdateRole(RoleDto role);

    /// <summary>
    ///     删除角色
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteRole(Guid id);

    /// <summary>
    ///     通过角色id获取当前角色下归属用户
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<(List<UserInfoDto>, int)> GetRoleUserInfo(Guid id,PageInput input);

    /// <summary>
    ///     编辑角色序号
    /// </summary>
    /// <param name="roles"></param>
    /// <returns></returns>
    Task<bool> UpdateRoleIndex(List<RoleDto> roles);

    /// <summary>
    /// 获取不存在当前角色的用户
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<(List<UserInfoDto>, int)> GetRoleUserInfoNotExit(Guid id,PageInput input);

    /// <summary>
    ///     添加|删除 用户至角色
    /// </summary>
    /// <param name="userIds"></param>
    /// <param name="roleId"></param>
    /// <param name="isAdd"></param>
    /// <returns></returns>
    Task CreateRoleUser(List<Guid> userIds, Guid roleId, bool isAdd = true);

    /// <summary>
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns>树形结构|选中的id</returns>
    Task<(List<MenuTreeDto>, List<Guid>)> GetMenuTreeAll(Guid roleId);

    /// <summary>
    ///     递归子集树形
    /// </summary>
    /// <param name="menus">所有数据</param>
    /// <param name="parentId">上级id</param>
    /// <param name="isParentChecked">上级是否选中</param>
    /// <returns></returns>
    Task<List<MenuTreeDto>> RecursiveTreeStructure(List<Menu> menus, Guid parentId, bool isParentChecked = false);

    /// <summary>
    ///     添加角色菜单权限配置
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="roleId"></param>
    /// <returns></returns>
    Task<bool> CreateRoleMenu(List<Guid> ids, Guid roleId);

    /// <summary>
    /// 获取集合角色下所有用户
    /// </summary>
    /// <param name="roleIds"></param>
    /// <returns></returns>
    Task<List<UserRoleFunction>> GetRoleUserAllAsync(List<Guid> roleIds);

    /// <summary>
    /// 获取用户角色权限
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<List<Guid>> GetUserInfoRoleIds(Guid userId);
}
