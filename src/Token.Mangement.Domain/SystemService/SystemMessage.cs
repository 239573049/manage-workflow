using Token.Management.Domain.Shared;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Token.Management.Domain.SystemService;

/// <summary>
///     系统信息
/// </summary>
public class SystemMessage:AggregateRoot<Guid>,IHasCreationTime
{
    /// <summary>
    ///     标题
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    ///     信息
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    ///     是否查看
    /// </summary>
    public bool IsCheck { get; set; } = false;

    /// <summary>
    ///     信息表示
    /// </summary>
    public WorkFlowFormCodeEnum WorkFormCode { get; set; }

    /// <summary>
    ///     绑定表单id
    /// </summary>
    public Guid? WorkFormId { get; set; }

    public DateTime CreationTime { get; }
}
