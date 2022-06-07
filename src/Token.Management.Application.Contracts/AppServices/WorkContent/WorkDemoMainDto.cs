using Token.Management.Domain.Shared;

namespace Token.Management.Application.Contracts.AppServices.WorkContent;

/// <summary>
/// WorkDemo
/// </summary>
public class WorkDemoMainDto
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 工作流Dmeo名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 工作流Demo备注
    /// </summary>
    public string? Remark { get; set; }

    /// <summary>
    /// 工作流Demo内容
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// 表单工作流状态
    /// </summary>
    public WorkFlowNodeStatusEnum WorkFlowNodeStatus { get; set; }

    /// <summary>
    /// 表单工作流状态
    /// </summary>
    public string WorkFlowNodeStatusName { get; set; }

    /// <summary>
    /// 项目开始时间
    /// </summary>
    public DateTime? StartTime { get; set; }

    /// <summary>
    /// 项目结束时间
    /// </summary>
    public DateTime? EndTime { get; set; }

    public bool IsDeleted { get; set; }
}
