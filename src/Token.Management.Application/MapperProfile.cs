using AutoMapper;
using Token.Infrastructure.Extension;
using Token.Management.Application.Contracts.Module.Management;
using Token.Management.Application.Contracts.Module.Management.AccessFunction;
using Token.Management.Application.Contracts.Module.Users;
using Token.Management.Application.Contracts.Module.WorkFlow;
using Token.Management.Domain.Management;
using Token.Management.Domain.Management.AccessFunction;
using Token.Management.Domain.Shared;
using Token.Management.Domain.Users;
using Token.Management.Domain.WorkFlow;

namespace Token.Management.Application;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<UserInfo, UserInfoDto>()
            .ForMember(dest => dest.Role, l => l.MapFrom(a => a.UserRoleFunction.Select(a => a.Role)))
            .ForMember(dest => dest.SexName, l => l.MapFrom(a => a.Sex.GetEnumString()))
            .ForMember(dest => dest.Sex, l => l.MapFrom(a => (sbyte)a.Sex))
            .ForMember(dest => dest.StatueName, l => l.MapFrom(a => a.Status.GetEnumString()))
            .ForMember(dest => dest.Department, l => l.MapFrom(a => a.UserDepartmentFunction.Select(a => a.Department)));
        CreateMap<UserInfoDto, UserInfo>()
            .ForMember(dest=>dest.Sex,l=>l.MapFrom(a=>(SexEnum)a.Sex));
        CreateMap<MenuRoleFunctionDto, MenuRoleFunction>();
        CreateMap<MenuRoleFunction, MenuRoleFunctionDto>();
        CreateMap<UserDepartmentFunction, UserDepartmentFunctionDto>();
        CreateMap<UserDepartmentFunctionDto, UserDepartmentFunction>();
        CreateMap<UserRoleFunction, UserRoleFunctionDto>();
        CreateMap<UserRoleFunction, UserRoleFunctionDto>();
        CreateMap<Company, CompanyDto>();
        CreateMap<CompanyDto, Company>();
        CreateMap<Department, DepartmentDto>();
        CreateMap<DepartmentDto, Department>();
        CreateMap<Menu, MenuDto>();
        CreateMap<MenuDto, Menu>();
        CreateMap<Role, RoleDto>();
        CreateMap<RoleDto, Role>();

        #region 工作流
        CreateMap<WorkflowApprovalRoleDto, WorkflowApprovalRole>();
        CreateMap<WorkflowApprovalRole, WorkflowApprovalRoleDto>();
        CreateMap<WorkflowApprovers, WorkflowApproversDto>();
        CreateMap<WorkflowApproversDto, WorkflowApprovers>();
        CreateMap<WorkflowInstanceDto, WorkflowInstance>();
        CreateMap<WorkflowInstance, WorkflowInstanceDto>();
        CreateMap<WorkflowNodeInstance, WorkflowNodeInstanceDto>();
        CreateMap<WorkflowNodeInstanceDto, WorkflowNodeInstance>();
        CreateMap<WorkflowNodeTemplate, WorkflowNodeTemplateDto>();
        CreateMap<WorkflowNodeTemplateDto, WorkflowNodeTemplate>();
        CreateMap<WorkflowTemplate, WorkflowTemplateDto>();
        CreateMap<WorkflowTemplateDto, WorkflowTemplate>();
        #endregion
    }
}
