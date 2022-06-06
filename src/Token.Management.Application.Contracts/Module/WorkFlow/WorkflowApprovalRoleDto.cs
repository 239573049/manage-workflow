using Token.Management.Application.Contracts.Module.Management;

namespace Token.Management.Application.Contracts.Module.WorkFlow;

public class WorkflowApprovalRoleDto
{
    /// <summary>
    ///     关联流程节点
    /// </summary>
    public Guid WorkflowNodeTemplateId { get; set; }

    /// <summary>
    ///     关联角色
    /// </summary>
    public Guid RoleId { get; set; }

    public RoleDto? Role { get; set; }
    public WorkflowNodeTemplateDto? WorkflowNodeTemplate { get; set; }
}
