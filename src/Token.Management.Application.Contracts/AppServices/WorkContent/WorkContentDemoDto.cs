using Token.Management.Application.Contracts.Module.Users;
using Token.Management.Domain.Shared;

namespace Token.Management.Application.Contracts.AppServices.WorkContent;

/// <summary>
/// WorkContent
/// </summary>
public class WorkContentDemoDto
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 表单工作流状态
    /// </summary>
    public WorkFlowNodeStatusEnum WorkFlowNodeStatus { get; set; }

    /// <summary>
    /// 表单工作流状态
    /// </summary>
    public string WorkFlowNodeStatusName { get; set; }

    /// <summary>
    /// 实例id
    /// </summary>
    public Guid? WorkflowInstanceId { get; set; }

    /// <summary>
    ///     提交时间
    /// </summary>
    public DateTime? SubmitTime { get; set; }

    /// <summary>
    /// 子项目名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 子项目内容
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// 项目负责人
    /// </summary>
    public Guid PrincipalId { get; set; }

    public Guid WorkDemoMainId { get; set; }

    public virtual UserInfoDto Principal { get; set; }

    public virtual WorkDemoMainDto WorkDemoMain { get; set; }
}
