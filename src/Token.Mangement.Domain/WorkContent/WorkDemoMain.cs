using Token.Management.Domain.Base;

namespace Token.Management.Domain.WorkContent;

/// <summary>
/// 工作流Demo
/// </summary>
public class WorkDemoMain : WorkFlowStatue
{
    public string? Name { get; set; }
    public string? Remark { get; set; }
    public string? Content { get; set; }
    public int Count { get; set; }
}
