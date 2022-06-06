using System.ComponentModel;

namespace Token.Management.Domain.Shared;

/// <summary>
///     工作流程节点状态
/// </summary>
public enum WorkFlowNodeStatusEnum
{
    /// <summary>
    ///     驳回
    /// </summary>
    [Description("驳回")] Rejected = 0,

    /// <summary>
    ///     通过
    /// </summary>
    [Description("通过")] Pass,

    /// <summary>
    ///     未处理
    /// </summary>
    [Description("未处理")] UnDeal,

    /// <summary>
    ///     终止【用作当前整个流程终止】
    /// </summary>
    [Description("终止")] Terminate,

    /// <summary>
    ///     撤回
    /// </summary>
    [Description("未处理")] Withdraw = 5
}
