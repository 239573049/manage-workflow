using AutoMapper;
using Management.Application.Services.Management;
using Token.HttpApi;
using Token.Infrastructure.Extension;
using Token.Management.Application.Contracts.Module;
using Token.Management.Application.Contracts.Module.Management;
using Token.Management.Application.Contracts.Module.Users;
using Token.Management.Domain;
using Token.Management.Domain.Management;
using Token.Management.Domain.Management.AccessFunction;
using Token.Management.Domain.Users;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Token.Management.Application.Services.Management;

public class RoleService : ApplicationService, IRoleService
{
    private readonly IPrincipalAccessor _principalAccessor;
    private readonly IRepository<Role> _roleRepository;
    private readonly IRepository<Menu> _menuRepository;
    private readonly IUserInfoRepository _userInfoRepository;
    private readonly IUserRoleFunctionRepository _userRoleFunctionRepository;
    private readonly IRepository<MenuRoleFunction> _menuRoleFunctionRepository;
    public RoleService(
        IPrincipalAccessor principalAccessor,
        IUserInfoRepository userInfoRepository,
        IRepository<Menu> menuRepository,
        IUserRoleFunctionRepository userRoleFunctionRepository,
        IRepository<MenuRoleFunction> menuRoleFunctionRepository,
        IRepository<Role> roleRepository)
    {
        _menuRepository = menuRepository;
        _principalAccessor = principalAccessor;
        _userInfoRepository = userInfoRepository;
        _userRoleFunctionRepository = userRoleFunctionRepository;
        _menuRoleFunctionRepository = menuRoleFunctionRepository;
        _roleRepository = roleRepository;
    }
    public async Task<RoleDto> CreateRole(RoleDto role)
    {
        var data = ObjectMapper.Map<RoleDto,Role>(role);
        if (data.Code.IsNull() || data.Name.IsNull()) throw new BusinessException("角色编号或名称不能为空");
        if (await _roleRepository.AnyAsync(a => a.Code == data.Code || a.Name == data.Name))
            throw new BusinessException("已经存在相同编号或名称的角色");

        data.Index =(await _roleRepository.GetQueryableAsync()).Max(a => a.Index) + 1;
        data = await _roleRepository.InsertAsync(data);

        await CurrentUnitOfWork.SaveChangesAsync();

        return ObjectMapper.Map<Role,RoleDto>(data);

    }

    public async Task CreateRoleUser(List<Guid> userIds, Guid roleId, bool isAdd = true)
    {
        userIds=userIds.Where(a=>a.Equals(_principalAccessor.UserId())).ToList();
        if (isAdd)
        {
            var data =(await _userRoleFunctionRepository.GetQueryableAsync())
                .Where(a => roleId==a.RoleId&& userIds.Contains(a.UserInfoId)).Select(a=>a.UserInfoId).ToList();

            userIds = userIds.Where(a => !data.Contains(a)).ToList();
            var list = userIds.Select(a => new UserRoleFunction { RoleId = roleId, UserInfoId = a }).ToList();
            await _userRoleFunctionRepository.InsertManyAsync(list);
        }
        else
        {
            var data = (await _userRoleFunctionRepository
                    .GetQueryableAsync()).Where(a => roleId == a.RoleId && userIds.Contains(a.UserInfoId))
                .Select(a => a.Id).ToList();
            await _userRoleFunctionRepository.DeleteManyAsync(data);
        }

    }

    public async Task<bool> DeleteRole(Guid id)
    {
        var isExist = await _roleRepository.FirstOrDefaultAsync(a => a.Id == id);
        if (isExist!=null)
        {
            if (isExist.Code == "admin") throw new BusinessException("无法删除内置角色");
            await _roleRepository.DeleteAsync(x=>x.Id==id);

            return true;
        }
        throw new BusinessException("角色已经被删除");
    }

    public async Task<(List<MenuTreeDto>,List<Guid>)> GetMenuTreeAll(Guid roleId)
    {
        var tree =await _menuRepository.ToListAsync();
        var roleMenu =await _menuRoleFunctionRepository.GetListAsync(x=>roleId==x.RoleId);//当前角色存在的菜单权限
        var treeData = await RecursiveTreeStructure(tree, Guid.Empty);
        return (treeData, roleMenu.Select(a=>a.MenuId).ToList());
    }

    public async Task<List<MenuTreeDto>> RecursiveTreeStructure(List<Menu> menus,Guid parentId,bool isParentChecked=false)
    {
        var trees =new List<MenuTreeDto>();
        var data = menus.Where(a => parentId == Guid.Empty ? a.ParentId == null : a.ParentId == parentId);
        menus = menus.Where(a => !data.Select(a => a.Id).Contains(a.Id)).ToList();
        foreach (var d in data)
        {
            var tree = new MenuTreeDto()
            {
                Key = d.Id,
                Index = d.Index,
                Icon = d.Icon,
                Name = d.Name,
                Path = d.Path,
                Title = d.Title,
                ParentId = parentId,
                Component=d.Component,
            };
            tree.Children.AddRange(await RecursiveTreeStructure(menus,d.Id,tree.Selectable));
            trees.Add(tree);
        }
        return trees;
    }
    public async Task<List<RoleDto>> GetRoleMenuList(string? name)
    {
        var data = (await _roleRepository
                .GetListAsync(a => (string.IsNullOrEmpty(name) || a.Name!.ToLower().Contains(name.ToLower()))))
                .OrderBy(x=>x.Index);

        return ObjectMapper.Map<IOrderedEnumerable<Role>,List<RoleDto>>(data);
    }

    public async Task<(List<UserInfoDto>, int)> GetRoleUserInfo(Guid id, PageInput input)
    {
        var data=await  _userRoleFunctionRepository
            .GetPageUserListAsync(x => id==x.RoleId,a => a.CreationTime,
                input.SkipCount,input.MaxResultCount);

        return (ObjectMapper.Map<List<UserInfo>,List<UserInfoDto>>(data.Item1),data.Item2);
    }

    public async Task<(List<UserInfoDto>, int)> GetRoleUserInfoNotExit(Guid id,PageInput input)
    {
        var data =await _userInfoRepository
            .GetListAsync(a => (string.IsNullOrEmpty(input.Keyword) ||
                                a.Name.ToLower().Contains(input.Keyword.ToLower())||
                                a.AccountNumber.ToLower().Contains(input.Keyword.ToLower()))
                               &&!a.UserRoleFunction.Any(a => a.RoleId == id),
                x=>x.CreationTime,input.SkipCount,input.MaxResultCount);

        return (ObjectMapper.Map<List<UserInfo>,List<UserInfoDto>>(data.Item1),data.Item2);
    }

    public async Task<List<MenuTreeDto>> GetUserMenuList()
    {
        var roleIds = _principalAccessor.GetRoleIds();

        var menuRole =(await _menuRoleFunctionRepository.GetListAsync(a => roleIds.Contains(a.RoleId)))
            .Select(x=>x.MenuId)
            .Distinct().ToList();

        var menu = (await _menuRepository.GetListAsync()).OrderBy(a => a.Index).ToList();

        return await RecursionUserMenu(menu, menuRole, Guid.Empty);
    }
    public async Task<List<MenuTreeDto>> RecursionUserMenu(List<Menu> roles, List<Guid> menuIds, Guid parentId)
    {
        var menuList = new List<MenuTreeDto>();
        var role = roles.Where(a =>(parentId == Guid.Empty ? a.ParentId == null : a.ParentId == parentId)).OrderBy(a => a.Index).ToList();
        roles = roles.Where(a => !role.Select(a => a.Id).Contains(a.Id)).ToList();
        foreach (var r in role)
        {
            var result = await RecursionUserMenu(roles, menuIds, r.Id);
            bool isAdd = result.Count > 0 || menuIds.Contains(r.Id);
            if (!isAdd) continue;
            menuList.Add(new MenuTreeDto
            {
                Component = r.Component,
                Icon = r.Icon,
                Key = r.Id,
                Index = r.Index,
                ParentId = parentId,
                Name = r.Name,
                Path = r.Path,
                Title = r.Title,
                Children = result
            });
        }
        return menuList;
    }

    public async Task<RoleDto> UpdateRole(RoleDto role)
    {
        if (await _roleRepository.AnyAsync(a => a.Id != role.Id && (a.Name == role.Name || a.Code == role.Code)))
            throw new BusinessException("已经存在相同编号或名称的角色");

        var data = await _roleRepository.FirstOrDefaultAsync(a => a.Id == role.Id);
        if (data == null) throw new BusinessException("数据不存在或者已经被删除");
        ObjectMapper.Map(role, data);
        await _roleRepository.UpdateAsync(data);

        return role;
    }

    public async Task<bool> UpdateRoleIndex(List<RoleDto> roles)
    {
        var data = ObjectMapper.Map<List<RoleDto>,List<Role>>(roles);
        for (int i = 0; i < data.Count; i++)
        {
            data[i].Index = i;
        }
        await _roleRepository.UpdateManyAsync(data);

        return true;
    }

    public async Task<bool> CreateRoleMenu(List<Guid> ids, Guid roleId)
    {
        var data=await _menuRoleFunctionRepository.GetListAsync(a=>a.RoleId == roleId);
        var deleteIds = data.Where(a => !ids.Contains(a.MenuId)).ToList();

        ids = ids.Where(a => !data.Select(a=>a.MenuId).Contains(a)).ToList();

        await _menuRoleFunctionRepository.DeleteManyAsync(deleteIds);
        await _menuRoleFunctionRepository.InsertManyAsync(ids.Distinct().Select(a => new MenuRoleFunction { RoleId = roleId, MenuId = a }).ToList());

        return true;
    }

    public async Task<List<UserRoleFunction>> GetRoleUserAllAsync(List<Guid> roleIds)
    {
        return (await _userRoleFunctionRepository
                .GetListAsync(a => roleIds.Contains(a.Id),
                    a=>a,
                    a => a.UserInfo));
    }

    public async Task<List<Guid>> GetUserInfoRoleIds(Guid userId)
    {
        var data=await _userRoleFunctionRepository
            .GetListAsync<Guid,Guid>(a=>a.UserInfoId==userId,a=>a.RoleId,null);

        return data;
    }
}
