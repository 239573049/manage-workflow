using Microsoft.EntityFrameworkCore;
using Token.Management.Domain.Management;
using Token.Management.Domain.Management.AccessFunction;
using Token.Management.Domain.SystemService;
using Token.Management.Domain.Users;
using Token.Management.Domain.WorkContent;
using Token.Management.Domain.WorkFlow;
using Volo.Abp.EntityFrameworkCore;

namespace Token.Management.EntityFrameworkCore.EntityFrameworkCore;

/// <summary>
/// dbContext
/// </summary>
public class TokenDbContext : AbpDbContext<TokenDbContext>
{
    public DbSet<Role> Role { get; set; }

    public DbSet<Menu> Menu { get; set; }

    public DbSet<Department> Department { get; set; }

    public DbSet<Company> Company { get; set; }

    public DbSet<UserRoleFunction> UserRoleFunction { get; set; }

    public DbSet<UserDepartmentFunction> UserDepartmentFunction { get; set; }

    public DbSet<MenuRoleFunction> MenuRoleFunction { get; set; }

    public DbSet<UserInfo> UserInfo { get; set; }

    public DbSet<WorkflowApprovers> WorkflowApprovers { get; set; }

    public DbSet<WorkflowApprovalRole> WorkflowApprovalRole { get; set; }

    public DbSet<WorkflowInstance> WorkflowInstance { get; set; }

    public DbSet<WorkflowTemplate> WorkflowTemplate { get; set; }

    public DbSet<WorkflowNodeInstance> WorkflowNodeInstance { get; set; }

    public DbSet<WorkflowNodeTemplate> WorkflowNodeTemplate { get; set; }

    public DbSet<WorkDemoMain> WorkDemoMain { get; set; }

    public DbSet<SystemMessage> SystemMessage { get; set; }

    /// <inheritdoc />
    public TokenDbContext(DbContextOptions<TokenDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // 禁用查询跟踪
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);

#if DEBUG
        // 显示更详细的异常日志
        optionsBuilder.EnableDetailedErrors();
#endif
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Initia();
        
        builder.Config();


    }
}
