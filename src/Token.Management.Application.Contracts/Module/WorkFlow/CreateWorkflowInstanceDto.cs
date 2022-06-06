using Token.Management.Domain.Shared;

namespace Token.Management.Application.Contracts.Module.WorkFlow;

public class CreateWorkflowInstanceDto
{
    /// <summary>
    ///     归属流程模板
    /// </summary>
    public string? WorkflowTemplateCode { get; set; }

    /// <summary>
    ///     描述
    /// </summary>
    public string? Remark { get; set; }

    /// <summary>
    ///     流程实例名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     关联表单
    /// </summary>
    public Guid WorkFormId { get; set; }

    /// <summary>
    ///     表单标识
    /// </summary>
    public WorkFlowFormCodeEnum WorkFlowFormCode { get; set; }
}
