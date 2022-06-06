namespace Token.Management.Domain.Shared;

/// <summary>
///     工作流状态
/// </summary>
public enum WorkFlowStatusEnum
{
    /// <summary>
    ///     完成【审核通过】
    /// </summary>
    SuccessFinished = 0,

    /// <summary>
    ///     完成【审核不通过】
    /// </summary>
    FailFinished,

    /// <summary>
    ///     审批中
    /// </summary>
    Approving,

    /// <summary>
    ///     删除
    /// </summary>
    Deleted,

    /// <summary>
    ///     驳回
    /// </summary>
    Rejected,

    /// <summary>
    ///     待审批
    /// </summary>
    ApprovePending,

    /// <summary>
    ///     终止
    /// </summary>
    Terminate
}
