using Token.Management.Domain.Shared;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Token.Management.Domain.WorkFlow;

/// <summary>
///
/// </summary>
public class WorkflowApprovers : AggregateRoot<Guid>, ISoftDelete,IHasCreationTime
{
    /// <summary>
    ///     当前接单操作人
    /// </summary>
    public Guid UserInfoId { get; set; }

    public string? UserName { get; set; }

    /// <summary>
    ///     关联工作流
    /// </summary>
    public Guid WorkflowInstanceId { get; set; }

    /// <summary>
    ///     操作
    /// </summary>
    public WorkFlowFormCodeEnum WorkFlowFormCode { get; set; }

    public WorkflowInstance? WorkflowInstance { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreationTime { get; }
}
