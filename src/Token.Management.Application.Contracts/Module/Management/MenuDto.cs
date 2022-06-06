namespace Token.Management.Application.Contracts.Module.Management;

public class MenuDto
{
    public Guid Id { get; set; }

    /// <summary>
    ///     标题
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    ///     名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     图标
    /// </summary>
    public string? Icon { get; set; }

    /// <summary>
    ///     路由
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    ///     父级id
    /// </summary>
    public Guid? ParentId { get; set; }
}
