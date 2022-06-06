using Token.Management.Domain.Base;

namespace Token.Management.Application.Contracts.Module.WorkFlow;

public class WorkflowTemplateDto : SerialNumberEntity
{
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

    public List<WorkflowInstanceDto> WorkflowInstance { get; set; } = new();
    public List<WorkflowNodeTemplateDto> WorkflowNodeTemplate { get; set; } = new();
}
