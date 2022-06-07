using Microsoft.EntityFrameworkCore;
using Token.Infrastructure.Extension;
using Token.Management.Domain.Management;
using Token.Management.Domain.Management.AccessFunction;
using Token.Management.Domain.SystemService;
using Token.Management.Domain.Users;
using Token.Management.Domain.WorkContent;
using Token.Management.Domain.WorkFlow;
using Volo.Abp.Data;

namespace Token.Management.EntityFrameworkCore.EntityFrameworkCore;

public static class EntityFrameworkCoreConfig
{
    public static ModelBuilder Config(this ModelBuilder builder)
    {
        var des = new DESHelper();
        builder.Entity<ExtraPropertyDictionary>().HasKey(x=>x.Count);

        builder.Entity<UserInfo>(x =>
        {
            x.ToTable("token_user_info");
            x.HasIndex(x => x.Id);
            x.HasKey(x => x.Id);

            x.Property(x => x.Name).HasComment("用户昵称");
            x.Property(x => x.Password).HasComment("密码");
            x.Property(x => x.Sex).HasComment("性别");
            x.Property(x => x.Status).HasComment("状态");
            x.Property(x => x.EMail).HasComment("邮箱");
            x.Property(x => x.HeadPortraits).HasComment("头像");

            x.Property(x => x.Password)
                .HasConversion(x => des.DESEncrypt(x),x => des.DESDecrypt(x));
        });

        builder.Entity<Role>(x =>
        {
            x.ToTable("token_role");
            x.HasIndex(x => x.Id);
            x.HasKey(x => x.Id);

            x.Property(x => x.Name).HasComment("角色名称");
            x.Property(x => x.Code).HasComment("角色编号");
            x.Property(x => x.Remark).HasComment("备注");
            x.Property(x => x.ParentId).HasComment("父节点");
            x.Property(x => x.Index).HasComment("序号");

        });

        builder.Entity<UserRoleFunction>(x =>
        {
            x.ToTable("token_user_role_function");
            x.HasIndex(x => x.Id);
            x.HasKey(x => x.Id);

        });

        builder.Entity<UserDepartmentFunction>(x =>
        {
            x.ToTable("token_user_department_function");
            x.HasIndex(x => x.Id);
            x.HasKey(x => x.Id);
        });

        builder.Entity<WorkflowInstance>(x =>
        {
            x.ToTable("token_workflow_instance");
            x.HasIndex(x => x.Id);
            x.HasKey(x => x.Id);

            x.Property(x => x.Code).HasComment("工作流实例code");
            x.Property(x => x.Remark).HasComment("工作流实例备注");
        });

        builder.Entity<WorkflowTemplate>(x =>
        {
            x.ToTable("token_workflow_template");
            x.HasIndex(x => x.Id);
            x.HasKey(x => x.Id);

            x.Property(x => x.Code).HasComment("工作流模板编号");
            x.Property(x => x.Remark).HasComment("工作流模板备注");
            x.Property(x => x.Name).HasComment("工作流模板名称");
        });

        builder.Entity<WorkflowNodeTemplate>(x =>
        {
            x.ToTable("token_workflow_node_template");
            x.HasIndex(x => x.Id);
            x.HasKey(x => x.Id);

        });

        builder.Entity<WorkflowNodeInstance>(x =>
        {
            x.ToTable("token_workflowNode_instance");
            x.HasIndex(x => x.Id);
            x.HasKey(x => x.Id);

        });

        builder.Entity<WorkflowApprovers>(x =>
        {
            x.ToTable("token_workflow_approvers");
            x.HasIndex(x => x.Id);
            x.HasKey(x => x.Id);

        });

        builder.Entity<WorkflowApprovalRole>(x =>
        {
            x.ToTable("token_workflow_approval_role");
            x.HasIndex(x => x.Id);
            x.HasKey(x => x.Id);
        });

        builder.Entity<WorkDemoMain>(x =>
        {
            x.ToTable("token_work_demo_main");
            x.HasIndex(x => x.Id);
            x.HasKey(x => x.Id);
        });

        builder.Entity<SystemMessage>(x =>
        {
            x.ToTable("token_system_message");
            x.HasIndex(x => x.Id);
            x.HasKey(x => x.Id);
        });

        builder.Entity<Department>(x =>
        {
            x.ToTable("token_department");
            x.HasIndex(x => x.Id);
            x.HasKey(x => x.Id);

        });

        builder.Entity<Menu>(x =>
        {
            x.ToTable("token_menu");
            x.HasIndex(x => x.Id);
            x.HasKey(x => x.Id);

        });

        builder.Entity<MenuRoleFunction>(x =>
        {
            x.ToTable("token_menu_role_function");
            x.HasIndex(x => x.Id);
            x.HasKey(x => x.Id);

        });

        builder.Entity<Company>(x =>
        {
            x.ToTable("token_company");
            x.HasIndex(x => x.Id);
            x.HasKey(x => x.Id);
        });

        return builder;
    }
}
