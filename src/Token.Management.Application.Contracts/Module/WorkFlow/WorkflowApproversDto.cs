using Token.Management.Domain.Shared;

namespace Token.Management.Application.Contracts.Module.WorkFlow;

public class WorkflowApproversDto
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

    public WorkflowInstanceDto? WorkflowInstance { get; set; }
}
