namespace Token.Management.Application.Contracts.Module;

/// <summary>
/// 分页模型
/// </summary>
public class PageInput
{
    /// <summary>
    /// 当前页
    /// </summary>
    public int PageNo { get; set; }

    /// <summary>
    /// 当前页最大数
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// 关键字
    /// </summary>
    public string? Keyword { get; set; }

    public int SkipCount
    {
        get
        {
            return PageSize * (PageNo - 1);
        }
    }

    public int MaxResultCount
    {
        get
        {
            return PageSize;
        }
    }
}
