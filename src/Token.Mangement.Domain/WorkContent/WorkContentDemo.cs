using Token.Management.Domain.Base;
using Token.Management.Domain.Users;

namespace Token.Management.Domain.WorkContent;

/// <summary>
/// 子任务
/// </summary>
public class WorkContentDemo : WorkFlowStatus
{
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

    public virtual UserInfo Principal { get; set; }

    public virtual WorkDemoMain WorkDemoMain { get; set; }
}
