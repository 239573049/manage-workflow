using Token.Management.Domain.Shared;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Token.Management.Domain.Base;

/// <summary>
///
/// </summary>
public class WorkFlowStatus : Entity<Guid>, ISoftDelete
{
    /// <summary>
    ///     表单工作流状态
    /// </summary>
    public WorkFlowNodeStatusEnum WorkFlowNodeStatus { get; set; }

    /// <summary>
    /// 实例id
    /// </summary>
    public Guid? WorkflowInstanceId { get; set; }

    /// <summary>
    ///     提交时间
    /// </summary>
    public DateTime? SubmitTime { get; set; }

    public bool IsDeleted { get; set; }
}
