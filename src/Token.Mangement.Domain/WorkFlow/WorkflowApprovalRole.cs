using Token.Management.Domain.Management;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Token.Management.Domain.WorkFlow;

public class WorkflowApprovalRole : AggregateRoot<Guid>, ISoftDelete,IHasCreationTime
{
    /// <summarAggregateRoot
    /// <Guid>
    ///     ,ISoftDeletey>
    ///     关联流程节点
    ///     </summary>
    public Guid WorkflowNodeTemplateId { get; set; }

    /// <summary>
    ///     关联角色
    /// </summary>
    public Guid RoleId { get; set; }

    public Role? Role { get; set; }

    public WorkflowNodeTemplate? WorkflowNodeTemplate { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreationTime { get; }
}
