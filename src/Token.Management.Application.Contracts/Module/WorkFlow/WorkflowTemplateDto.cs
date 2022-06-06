using Token.Management.Domain.Base;

namespace Token.Management.Application.Contracts.Module.WorkFlow;

/// <summary>
/// 模板Dto
/// </summary>
public class WorkflowTemplateDto : SerialNumberEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     流程名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     流程编码
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    ///     描述
    /// </summary>
    public string? Remark { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<WorkflowInstanceDto> WorkflowInstance { get; set; } = new();

    /// <summary>
    /// 节点模板
    /// </summary>
    public List<WorkflowNodeTemplateDto> WorkflowNodeTemplate { get; set; } = new();
}
