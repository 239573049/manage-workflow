using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Token.Management.Domain.WorkFlow;

/// <summary>
///     流程节点
/// </summary>
public class WorkflowNodeTemplate : Entity<Guid>, ISoftDelete, IHasCreationTime
{
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

    public virtual WorkflowTemplate? WorkflowTemplate { get; set; }

    /// <summary>
    /// 当前模板需要审批的角色
    /// </summary>
    public virtual List<WorkflowApprovalRole> WorkflowApprovalRole { get; set; } = new();

    public bool IsDeleted { get; set; }

    public DateTime CreationTime { get; }
}
