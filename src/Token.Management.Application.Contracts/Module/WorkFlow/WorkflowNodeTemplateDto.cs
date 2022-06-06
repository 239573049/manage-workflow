namespace Token.Management.Application.Contracts.Module.WorkFlow;

public class WorkflowNodeTemplateDto
{
    public Guid Id { get; set; }

    /// <summary>
    ///     关联流程模板
    /// </summary>
    public Guid WorkflowTemplateId { get; set; }

    /// <summary>
    ///     节点审批顺序
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    ///     上一节点
    /// </summary>
    public Guid? PrevNodeId { get; set; }

    /// <summary>
    ///     下一节点
    /// </summary>
    public Guid? NextNodeId { get; set; }

    /// <summary>
    ///     描述
    /// </summary>
    public string? Remark { get; set; }

    public WorkflowTemplateDto? WorkflowTemplate { get; set; }

    /// <summary>
    ///     当前模板需要审批的角色
    /// </summary>
    public List<WorkflowApprovalRoleDto> WorkflowApprovalRole { get; set; } = new();
}
