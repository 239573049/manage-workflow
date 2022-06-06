using Microsoft.EntityFrameworkCore;
using Token.Infrastructure.Extension;
using Token.Management.Domain.Management;
using Token.Management.Domain.Management.AccessFunction;
using Token.Management.Domain.Shared;
using Token.Management.Domain.Users;

namespace Token.Management.EntityFrameworkCore.EntityFrameworkCore;

public static class EntityFrameworkCoreInitialData
{

    /// <summary>
    /// 初始化系统数据
    /// </summary>
    /// <param name="model"></param>
    public static void Initia(this ModelBuilder model)
    {
        var des = new DESHelper();
        var now = DateTime.Now;
        var userInfoData = new List<UserInfo>()
        {
            new(Guid.NewGuid())
            {
                AccountNumber="admin",
                EMail="239573049@qq.com",
                Sex=SexEnum.Male,
                HeadPortraits="https://upfile2.asqql.com/upfile/hdimg/wmtp/wmtp/2018-07/08/18_7_8_16_10_08yoqapqci.jpg",
                MobileNumber=13049809673,
                Name="管理员",
                Password=des.DESEncrypt("Aa010426"),
                CreationTime=now,
                Statue =StatueEnum.Enable
            },
        };

        model.Entity<UserInfo>().HasData(userInfoData);

        var roleData = new Role(Guid.NewGuid())
        {
            Name = "管理员",
            Code = "admin",
            Index = 0,
            Remark = "系统管理员",
            CreationTime = now,
        };
        model.Entity<Role>().HasData(roleData);

        var userRole = new List<UserRoleFunction>();
        var company = new Company(Guid.NewGuid())
        {
            Name = "Microsoft",
            Code = "wr",
            CreationTime = now,
            Describe = "微软（Microsoft）是一家 美国 跨国科技企业，由 比尔·盖茨 和 保罗·艾伦 于1975年4月4日创立。 公司总部设立在 华盛顿州 雷德蒙德 （Redmond，邻近 西雅图 ），以 研发 、 制造 、 授权 和提供广泛的 电脑软件 服务业务为主 。",
        };
        model.Entity<Company>().HasData(company);

        var departmentData = new Department(Guid.NewGuid())
        {
            Name = "测试部门",
            Code = "cs",
            CreationTime = now,
            Index = 0,
            CompanyId = company.Id
        };
        model.Entity<Department>().HasData(departmentData);
        var userDepartmentFunction = new List<UserDepartmentFunction>();
        foreach (var u in userInfoData)
        {
            userDepartmentFunction.Add(new UserDepartmentFunction(Guid.NewGuid())
            {
                UserInfoId = u.Id,
                DepartmentId = departmentData.Id,
                CreationTime = now,
            });
            userRole.Add(new UserRoleFunction(Guid.NewGuid())
            {
                UserInfoId = u.Id,
                RoleId = roleData.Id,
                CreationTime = now,
            });
        }
        model.Entity<UserDepartmentFunction>().HasData(userDepartmentFunction);
        model.Entity<UserRoleFunction>().HasData(userRole);

        var menu = new List<Menu>();
        var menuHome = new Menu(Guid.NewGuid())
        {
            Component = "Home",
            CreationTime = now,
            Index = 0,
            Name = "首页",
            Path = "/home/index",
            Title = "首页"
        };
        var menuUser = new Menu(Guid.NewGuid())
        {
            Component = "User",
            CreationTime = now,
            Index = 1,
            Name = "用户管理",
            Path = "/user/index",
            Title = "用户管理"
        };
        var menuSystem = new Menu(Guid.NewGuid())
        {
            CreationTime = now,
            Component = "System",
            Index = 2,
            Name = "系统配置",
            Path = "/system/index",
            Title = "系统配置"
        };
        var systemWorkConfig = new Menu(Guid.NewGuid())
        {
            CreationTime = now,
            Component = "WorkConfig",
            Index = 2,
            Name = "工作流配置",
            ParentId = menuSystem.Id,
            Path = "/system/workConfig/index",
            Title = "工作流配置"
        };
        var systemUserConfig = new Menu(Guid.NewGuid())
        {
            CreationTime = now,
            Component = "UserConfig",
            Index = 1,
            Name = "用户权限配置",
            ParentId = menuSystem.Id,
            Path = "/system/userConfig/index",
            Title = "用户权限配置"
        };
        var systemRoleConfig = new Menu(Guid.NewGuid())
        {
            CreationTime = now,
            Component = "RoleConfig",
            Index = 0,
            Name = "角色配置",
            ParentId = menuSystem.Id,
            Path = "/system/roleConfig/index",
            Title = "角色配置"
        };
        var menuWork = new Menu(Guid.NewGuid())
        {
            CreationTime = now,
            Component = "Work",
            Index = 3,
            Name = "工作",
            Path = "/Work/index",
            Title = "工作"
        };

        menu.Add(menuHome);
        menu.Add(menuUser);
        menu.Add(menuSystem);
        menu.Add(menuWork);
        menu.Add(systemUserConfig);
        menu.Add(systemRoleConfig);
        menu.Add(systemWorkConfig);
        model.Entity<Menu>().HasData(menu);

        var menuRoleFunction = new List<MenuRoleFunction>();

        foreach (var d in menu)
        {
            menuRoleFunction.Add(new MenuRoleFunction(Guid.NewGuid())
            {
                MenuId = d.Id,
                RoleId = roleData.Id,
            });
        }
        model.Entity<MenuRoleFunction>().HasData(menuRoleFunction);

    }
}
