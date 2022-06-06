namespace Token.Management.Application.Contracts.Module.Management;

public class CompanyDto
{
    public Guid Id { get; set; }

    /// <summary>
    ///     公司名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     公司编号
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    ///     公司Logo
    /// </summary>
    public string? Logo { get; set; }

    /// <summary>
    ///     描述
    /// </summary>
    public string? Describe { get; set; }

    public List<DepartmentDto> Department { get; set; } = new();
}
