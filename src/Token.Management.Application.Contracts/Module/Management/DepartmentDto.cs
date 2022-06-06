namespace Token.Management.Application.Contracts.Module.Management;

/// <summary>
///     部门
/// </summary>
public class DepartmentDto
{
    public Guid Id { get; set; }

    /// <summary>
    ///     部门名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     部门编号
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    ///     父级id
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    ///     序号
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    ///     公司id
    /// </summary>
    public Guid CompanyId { get; set; }

    public CompanyDto? Company { get; set; }
}
