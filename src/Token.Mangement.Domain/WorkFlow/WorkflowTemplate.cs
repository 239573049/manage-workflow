using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Token.Management.Domain.WorkFlow;

/// <summary>
///     流程模板
/// </summary>
public class WorkflowTemplate : Entity<Guid>, ISoftDelete, IHasCreationTime
{
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


    public bool IsDeleted { get; set; }

    public DateTime CreationTime { get; }

    public List<WorkflowInstance> WorkflowInstance { get; set; } = new();

    public List<WorkflowNodeTemplate> WorkflowNodeTemplate { get; set; } = new();
}
